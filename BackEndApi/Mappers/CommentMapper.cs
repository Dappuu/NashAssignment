using BackEndApi.Models;
using ViewModels.Comment;

namespace BackEndApi.Mappers
{
	public static class CommentMapper
	{
		public static CommentDto ToCommentDto(this Comment commentModel)
		{
            string? userName = null;
			if (commentModel.User is not null)
			{
				if (commentModel.User.UserName is not null) 
					userName = commentModel.User.UserName;
            }
            return new CommentDto
            {
				Id = commentModel.Id,
				Content = commentModel.Content,
				Rating = commentModel.Rating,
				CreatedDate = commentModel.CreatedDate,
				ProductId = commentModel.ProductId,
				UserName = userName,
			};
		}
		public static Comment ToCommentFromCreateDto(this CreateRequestCommentDto commentDto)
		{
			return new Comment
			{
				Content = commentDto.Content,
				ProductId = commentDto.ProductId,
				Rating = commentDto.Rating,
            };
		}

    }
}
