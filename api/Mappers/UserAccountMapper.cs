using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.UserAccount;
using api.Models;

namespace api.Mappers
{
    public static class UserAccountMapper
    {
        public static UserAccountDto ToUserAccountDto(this UserAccount userAccountModel)
        {
            return new UserAccountDto
            {
                ID = userAccountModel.ID,
                UserID = userAccountModel.UserID,
                UserName = userAccountModel.UserName,
            };
        }
        public static UserAccount ToUserAccountFromCreateDTO(this CreateUserAccountRequestDto userAccountDto)
        {
            return new UserAccount
            {
                UserID = userAccountDto.UserID,
                UserName = userAccountDto.UserName,
            };
        }
    }
}