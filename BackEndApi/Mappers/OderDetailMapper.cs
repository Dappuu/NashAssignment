using BackEndApi.Models;
using ViewModels.OrderDetail;
using ViewModels.Size;

namespace BackEndApi.Mappers
{
	public static class OderDetailMapper
	{
		public static OrderDetailDto ToOrderDetailDto(this OrderDetail orderDetailModel)
		{
			return new OrderDetailDto
			{
				Id = orderDetailModel.Id,
				Discount = orderDetailModel.Discount,
				Price = orderDetailModel.Price,
				Quantity = orderDetailModel.Quantity
			};
		}
	}
}
