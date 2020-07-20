using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFw.DbContext;
using Microsoft.Extensions.DependencyInjection;
using Example.Core.Account.Entities;
using WFw.Exceptions;
using WFw.Utils.Security;
using Example.Core.Account.Dtos;

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

        public AccountService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void InitTable()
        {
            UserRepository.Init();
        }

        public async Task<SignInOutputDto> SignInAsync(SignInInputDto inputDto)
        {
            var entity = await UserRepository.GetFirstAsync(u => u.UserName == inputDto.UserName);
            if (entity == null)
            {
                throw new BadRequestException(WFw.Data.OperationResultType.IsErr, "用户名或密码");
            }

            if (!entity.Pwd.Equals(EncryptProvider.GetMd5($"{ inputDto.Password}{entity.PwdSalt}")))
            {
                throw new BadRequestException(WFw.Data.OperationResultType.IsErr, "用户名或密码");
            }

            return new SignInOutputDto
            {
                Id = entity.Id,
                NickName = entity.NickName,
                Role = entity.Role
            };
        }
    }
}
