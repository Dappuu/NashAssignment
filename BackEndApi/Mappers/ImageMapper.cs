using BackEndApi.Models;
using ViewModels.Image;

namespace BackEndApi.Mappers
{
	public static class ImageMapper
	{
		public static ImageDto ToImageDto (this Image imageModel)
		{
			return new ImageDto
			{
				Id = imageModel.Id,
				Url = imageModel.Url,
			};
		}
	}
}
