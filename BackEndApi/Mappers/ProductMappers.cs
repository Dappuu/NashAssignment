using BackEndApi.Models;
using System.ComponentModel.DataAnnotations;
using ViewModels.Comment;
using ViewModels.Image;
using ViewModels.Product;
using ViewModels.ProductSku;

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
                productSkusDto = productModel.productSkus is null ? null : productModel.productSkus.Select(p => p.ToProductSkuDto()).ToList(),
                Comments = productModel.Comments is null ? null : productModel.Comments.Select(c => c.ToCommentDto()).ToList(),
				Images = productModel.Images is null ? null : productModel.Images.Select(i => i.ToImageDto()).ToList(),
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
