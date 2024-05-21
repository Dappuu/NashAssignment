using BackEndApi.Models;
using ViewModels.Order;
using ViewModels.OrderDetail;

namespace BackEndApi.Mappers
{
	public static class OderMapper
	{
		public static OrderDto ToOrderDto(this Order orderModel)
		{
			return new OrderDto
			{
				Id = orderModel.Id,
				City = orderModel.City,
				StreetAddress = orderModel.StreetAddress,
				OrderDate = orderModel.OrderDate,
				PhoneNumber = orderModel.PhoneNumber,
				Quantity = orderModel.Quantity,
				Total = orderModel.Total,
				OrderDetails = orderModel.OrderDetails is null ? null : orderModel.OrderDetails.Select(o => o.ToOrderDetailDto()).ToList(),
			};
		}
	}
}
