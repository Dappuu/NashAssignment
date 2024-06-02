using BackEndApi.Models;
using System.ComponentModel.DataAnnotations;
using ViewModels.Product;

namespace BackEndApi.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                ProductSkuName = productModel.ProductSkuName,
                Description = productModel.Description,
                Material = productModel.Material,
                Price = productModel.Price,
				Discount = productModel.Discount,
                UnitsInStock = productModel.UnitsInStock,
                UnitsSold = productModel.UnitsSold,
                CreatedDate = productModel.CreatedDate,
                CategoryId = productModel.CategoryId,
                Active = productModel.Active,
                Rating = productModel.Rating,
                productSkusDto = productModel.productSkus is null ? null : productModel.productSkus.Select(p => p.ToProductSkuDto()).ToList(),
                Comments = productModel.Comments is null ? null : productModel.Comments.Select(c => c.ToCommentDto()).ToList(),
				ImageUrl = productModel.ImageUrl,
			};
        }
		public static Product ToProductFromCreateDto(this CreateRequestProductDto ProductDto)
        {
            return new Product
            {
                Name = ProductDto.Name,
                ProductSkuName = ProductDto.ProductSkuName,
                Description = ProductDto.Description,
                Material = ProductDto.Material,
                Price = ProductDto.Price,
                Discount = ProductDto.Discount,
                Active = ProductDto.Active,
                UnitsInStock = ProductDto.UnitsInStock,
                CategoryId = ProductDto.CategoryId,
            };
        }
    }
}
