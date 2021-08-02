using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Example.Core.Account.Entities;
using WFw.Exceptions;
using WFw.Utils;
using Example.Core.Account.Dtos;
using WFw.Results;
using WFw.IDbContext;
using WFw.DbContext;

namespace Example.Core.Account
{
    public interface IAccountService
    {
        public void InitTable();
        Task<SignInOutputDto> SignInAsync(SignInInputDto inputDto);
    }

    public class AccountService : IAccountService
    {
        private readonly IServiceProvider _serviceProvider;

        private IRepository<User, int> UserRepository => _serviceProvider.GetService<IRepository<User, int>>();
        private IRepository<UserAddress, int> UserAddressRepository => _serviceProvider.GetService<IRepository<UserAddress, int>>();

        private ISqlSugarDbContext DbContext => _serviceProvider.GetService<ISqlSugarDbContext>();

        public AccountService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void InitTable()
        {
            //UserRepository.Init();
            //UserAddressRepository.Init();
            //UserRepository.Insert(new User("admin", "nick", "123123"));
            //UserAddressRepository.Insert(new UserAddress { Address = "address1", UserId = 1 });
            //UserAddressRepository.Insert(new UserAddress { Address = "address2", UserId = 1 });
            UserRepository.Init(new User
            {
                NickName = "admin",
                UserName = "admin",
                Pwd = "123",
                Role = "a",


            });
            UserAddressRepository.Init(new UserAddress { Address = "aaa", UserId = 2 });
            // var list = DbContext.Db.Queryable<User>().Mapper(it => it.Address, it => it.Id, it => it.Address.First().UserId).ToList();

        }

        public async Task<SignInOutputDto> SignInAsync(SignInInputDto inputDto)
        {
            var entity = await UserRepository.GetFirstAsync(u => u.UserName == inputDto.UserName);
            if (entity == null)
            {
                throw new WFw.WFwException(OperationResultType.IsErr, "用户名或密码");
            }

            if (!entity.Pwd.Equals(EncryptProvider.GetMd5($"{ inputDto.Password}{entity.PwdSalt}")))
            {
                throw new WFw.WFwException(OperationResultType.IsErr, "用户名或密码");
            }
            entity.Remark = "a";
            await UserRepository.UpdateAsync(entity);
            return new SignInOutputDto
            {
                Id = entity.Id,
                NickName = entity.NickName,
                Role = entity.Role
            };
        }
    }
}
