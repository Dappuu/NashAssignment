using BackEndApi.Models;
using ViewModels.ProductSku;

namespace BackEndApi.Mappers
{
	public static class ProductSkuMapper
	{
		public static ProductSkuDto ToProductSkuDto (this ProductSku productSkuModel)
		{
			return new ProductSkuDto
			{
				Id = productSkuModel.Id,
				ProductId = productSkuModel.ProductId,
				UnitsInStock = productSkuModel.UnitsInStock,
				UnitsSold = productSkuModel.UnitsSold,
				Size =  productSkuModel.Size is null ? null : productSkuModel.Size.Name,
			};
		}
		public static ProductSku ToProductSkuFromCreateDto(this CreateRequestProductskuDto productSkuDto) 
		{
			return new ProductSku
			{
				ProductId = productSkuDto.ProductId,
				SizeId = productSkuDto.SizeId,
				UnitsInStock = productSkuDto.UnitsInStock,
			};
		}

    }
}
