using BackEndApi.Models;
using ViewModels.Product;

namespace BackEndApi.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto (this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Color = productModel.Color,
                ImageUrl = productModel.ImageUrl,
                Price = productModel.Price,
                CreatedDate = productModel.CreatedDate,
                Discontinued = productModel.Discontinued,
                UnitsInStock = productModel.UnitsInStock,
                UnitsSold = productModel.UnitsSold,
                UpdatedDate = productModel.UpdatedDate,
                CategoryId = productModel.CategoryId,
            };
        }
        public static Product ToProductFromCreateDto(this CreateRequestProductDto ProductDto)
        {
            return new Product
            {
                Name = ProductDto.Name,
                Description = ProductDto.Description,
                Price = ProductDto.Price,
                Color = ProductDto.Color,
                ImageUrl = ProductDto.ImageUrl,
                UnitsInStock = ProductDto.UnitsInStock,
                UnitsSold = ProductDto.UnitsSold,
                Discontinued = false,
                CategoryId = ProductDto.CategoryId
            };
        }
    }
}
