using BackEndApi.Models;
using ViewModels.Size;

namespace BackEndApi.Mappers
{
	public static class SizeMapper
	{
		public static SizeDto ToSizeDto(this Size sizeModel)
		{
			return new SizeDto
			{
				Id = sizeModel.Id,
				Name = sizeModel.Name,
			};
		}
	}
}
