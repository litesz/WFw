using System;
using System.Threading.Tasks;
using WFw.Core.Identity.Entities;
using WFw.Data;
using WFw.DbContext;
using WFw.Exceptions;
using WFw.Extensions;
using WFw.Identity.Dtos;
using WFw.Identity.Entities;
using WFw.Utils.Security;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace WFw.Identity
{

    public class IdentityService : IIdentityService
    {
        private readonly IServiceProvider _serviceProvider;
        private IRepository<User, int> UserRepository => _serviceProvider.GetService<IRepository<User, int>>();
        private IRepository<UserOrganization, int> CompanyRepository => _serviceProvider.GetService<IRepository<UserOrganization, int>>();
        private IRepository<UserRole, int> UserRoleRepository => _serviceProvider.GetService<IRepository<UserRole, int>>();
        private IRepository<Role, int> RoleRepository => _serviceProvider.GetService<IRepository<Role, int>>();
        private SqlSugarDbContext DbContext => _serviceProvider.GetService<SqlSugarDbContext>();

        public IdentityService(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<LoginResultDto> Login(LoginDto dto)
        {
            CheckParam.NotNull(dto, nameof(LoginDto));

            var user = await UserRepository.GetFirstAsync(u => u.Phone == dto.Username);
            if (user == null)
            {
                return new LoginResultDto { ErrCode = -1 };
            }
            if (user.IsLock)
            {
                return new LoginResultDto { ErrCode = 1 };
            }

            if (user.AuditState != UserAuditType.Success)
            {
                return new LoginResultDto { ErrCode = (int)user.AuditState };
            }

            if (EncryptProvider.GetMd5Password(dto.Password, user.PasswordSalt).Equals(user.Password))
            {
                var roleIds = UserRoleRepository.Query.Where(u => u.UserId == user.Id).Select(u => u.RoleId).ToList();
                var roles = RoleRepository.Query.Where(u => roleIds.Contains(u.Id)).Select(u => u.Name).ToArray();

                user.RefreshToken = new Random().NextLetterAndNumberString(32);
                user.LastLoginTime = DateTime.Now;
                await UserRepository.UpdateAsync(user);
                return new LoginResultDto
                {
                    Id = user.Id,
                    RefreshToken = user.RefreshToken,
                    Avatar = user.HeadImg,
                    Name = user.NickName,
                    Roles = roles,
                    OrganizationId = user.OrganizationId,
                    Phone = user.Phone
                };
            }
            return new LoginResultDto { ErrCode = -2 };
        }

        public async Task Logout()
        {

        }


        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="dto">注册信息</param>
        /// <returns>业务操作结果</returns>
        public async Task RegisterWithOrganization(RegisterWithOrganizationDto dto, bool isLock)
        {
            CheckParam.NotNull(dto, nameof(RegisterWithOrganizationDto));

            if (await UserRepository.CheckExistsAsync(u => u.Phone == dto.Phone))
            {
                throw new BadRequestException(OperationResultType.IsExist, "电话号码");
            }

            if (await CompanyRepository.CheckExistsAsync(u => u.Name == dto.OrganizationName))
            {
                throw new BadRequestException(OperationResultType.IsExist, "公司名称");
            }

            UserOrganization company = new UserOrganization
            {
                Name = dto.OrganizationName,
                Address = dto.Address,
                District = dto.District,
                IsLock = isLock
            };

            await CompanyRepository.InsertAsync(company);

            User user = new User
            {
                Phone = dto.Phone,
                NickName = dto.NickName,
                UserName = dto.Phone,
                OrganizationId = company.Id,
                IsLock = isLock,
                AuditState = dto.AuditType
            };

            user.Password = EncryptProvider.GetMd5Password(dto.Password, user.PasswordSalt);

            var count = await UserRepository.InsertAsync(user);
        }


        public async Task<PagedUserQueryOutputDto> GetPagedUser(PagedUserQueryInputDto inputDto)
        {
            RefAsync<int> total = new RefAsync<int>();
            var result = await UserRepository.Query
                .WhereIF(inputDto.OrganizationId.HasValue, u => u.OrganizationId == inputDto.OrganizationId.Value)
                .OrderBy(u => u.CreatedTime, OrderByType.Desc)
                .Select(u => new UserQueryOutputDto
                {
                    Id = u.Id,
                    AuditState = u.AuditState,
                    HeadImg = u.HeadImg,
                    IsLock = u.IsLock,
                    NickName = u.NickName,
                    PaymentType = u.PaymentType,
                    Phone = u.Phone,
                    Remark = u.Remark
                })
                .ToPageListAsync(inputDto.PageIndex, inputDto.PageSize, total);
            return new PagedUserQueryOutputDto(result, total.Value);
        }

        public async Task<PagedUserWithOrganizationQueryOutputDto> GetPagedUserWithOrganization(PagedUserWithOrganizationQueryInputDto inputDto)
        {

            RefAsync<int> total = new RefAsync<int>();

            var result = await DbContext.Db
                .Queryable<User, UserOrganization>((u, o) => new object[] { JoinType.Left, u.OrganizationId == o.Id })
                .Where((u, o) => u.IsDeleted == false && o.IsDeleted == false && u.IsSystem == false)
                .OrderBy((u, o) => u.CreatedTime, OrderByType.Desc)
                .Select((u, o) => new UserWithOrganizationQueryOutputDto
                {
                    Id = u.Id,
                    Address = o.Address,
                    NickName = u.NickName,
                    OrganizationId = o.Id,
                    OrganizationName = o.Name,
                    Phone = u.Phone,
                    Remark = u.Remark,
                    DistrictId = o.District,
                    UserAuditState = u.AuditState
                })
                .ToPageListAsync(inputDto.PageIndex, inputDto.PageSize, total);

            return new PagedUserWithOrganizationQueryOutputDto(result, total.Value);
        }


        public async Task RefuseUserAduit(int id)
        {
            var user = await UserRepository.GetFirstAsync(u => u.Id == id);
            if (user == null)
            {
                throw new BadRequestException(OperationResultType.NotExist, $"用户:{id}");
            }

            user.AuditState = UserAuditType.Failure;
            await UserRepository.UpdateAsync(user);
        }

        public async Task AgreeUserAduit(int id)
        {
            var user = await UserRepository.GetFirstAsync(u => u.Id == id);
            if (user == null)
            {
                throw new BadRequestException(OperationResultType.NotExist, $"用户:{id}");
            }

            user.AuditState = UserAuditType.Success;
            user.IsLock = false;
            await UserRepository.UpdateAsync(user);
        }


        public async Task LockOrganization(int id)
        {
            var o = await CompanyRepository.GetFirstAsync(u => u.Id == id);
            if (o == null)
            {
                throw new BadRequestException(OperationResultType.NotExist, $"组织:{id}");
            }
            o.IsLock = true;
            await CompanyRepository.UpdateAsync(o);
        }

        public async Task UnLockOrganization(int id)
        {
            var o = await CompanyRepository.GetFirstAsync(u => u.Id == id);
            if (o == null)
            {
                throw new BadRequestException(OperationResultType.NotExist, $"组织:{id}");
            }
            o.IsLock = false;
            await CompanyRepository.UpdateAsync(o);
        }


        public async Task BindRole(int userId, int roleId)
        {
            var role = RoleRepository.GetFirstAsync(u => u.Id == roleId);
            if (role == null)
            {
                throw new BadRequestException(OperationResultType.NotExist, $"角色:{roleId}");
            }

            await UserRoleRepository.InsertAsync(new UserRole { RoleId = roleId, UserId = userId });
        }

        public async Task<bool> ValidPassword(int id, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var entity = await UserRepository.GetFirstAsync(u => u.Id == id);
            if (entity == null)
            {
                return false;
            }
            return EncryptProvider.GetMd5Password(password, entity.PasswordSalt).Equals(entity.Password);
        }

        public async Task UpdatePassword(string phone, string newPassword)
        {

            var entity = await UserRepository.GetFirstAsync(u => u.Phone == phone && u.AuditState == UserAuditType.Success);
            if (entity == null)
            {
                throw new BadRequestException(OperationResultType.NotExist, $"用户:{phone}");
            }

            entity.Password = EncryptProvider.GetMd5Password(newPassword, entity.PasswordSalt);
            await UserRepository.UpdateAsync(entity);
        }
    }
}
