using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                UserId = userModel.UserId,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Age = userModel.Age,
                // RelationshipMembers = userModel.RelationshipMembers.Select(c=>c.ToRelationshipMemberDto()).ToList(),
                // Posts = userModel.Posts.Select(c=>c.ToPostDto()).ToList()
            };
        }
        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age,
                // RelationshipMembers = userDto.RelationshipMembers.Select(c=>c.ToRelationshipMemberFromCreateDTO()).ToList(),
                // Posts = userDto.Posts.Select(c=>c.ToPostFromCreateDTO()).ToList()
            };
        }
        public static User ToUserFromUpdateDTO(this UpdateUserRequestDto userUpdateDto)
        {
            return new User
            {
                FirstName = userUpdateDto.FirstName,
                LastName = userUpdateDto.LastName,
                Age = userUpdateDto.Age,
                // RelationshipMembers = userUpdateDto.RelationshipMembers.Select(c=>c.ToRelationshipMemberFromUpdateDTO()).ToList(),
                // Posts = userUpdateDto.Posts.Select(c=>c.ToPostFromUpdateDTO()).ToList()
            };
        }
    }
}