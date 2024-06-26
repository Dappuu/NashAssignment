﻿using BackEndApi.Models;
using Microsoft.Extensions.Logging.Abstractions;
using ViewModels.User;

namespace BackEndApi.Mappers
{
	public static class UserMapper
	{
		public static UserDto ToUserDto(this User userModel)
		{
			return new UserDto
			{
				UserId = userModel.Id,
				UserName = userModel.UserName is null ? string.Empty : userModel.UserName,
				FirstName = userModel.FirstName,
				LastName = userModel.LastName,
				City = userModel.City,
				StreetAddress = userModel.StreetAddress,
				DateOfBirth = userModel.DateOfBirth,
				Comments = userModel.Comments is null ? null : userModel.Comments.Select(c => c.ToCommentDto()).ToList(),
				Orders = userModel.Orders is null ? null : userModel.Orders.Select(c => c.ToOrderDto()).ToList(),
				AvatarUrl = userModel.AvatarUrl,
				Email = userModel.Email is not null ? userModel.Email : string.Empty,
			};
		}
	}
}
