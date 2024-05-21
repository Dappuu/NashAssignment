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
				UserId = commentModel.UserId,
			};
		}
	}
}
