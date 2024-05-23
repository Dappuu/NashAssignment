using BackEndApi.Models;
using ViewModels.Comment;
using ViewModels.Image;

namespace BackEndApi.Mappers
{
	public static class CommentMapper
	{
		public static CommentDto ToCommentDto(this Comment commentModel)
		{
			return new CommentDto
			{
				Id = commentModel.Id,
				Content = commentModel.Content,
				Rating = commentModel.Rating,
				CreatedDate = commentModel.CreatedDate,
				ProductId = commentModel.ProductId,
				UserName = commentModel.User is null ? null : commentModel.User.UserName
			};
		}
		public static Comment ToCommentFromCreateDto(this CreateRequestCommentDto commentDto)
		{
			return new Comment
			{
				Content = commentDto.Content,
				ProductId = commentDto.ProductId,
				Rating = commentDto.Rating
			};
		}

    }
}
