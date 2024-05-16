using BackEndApi.Models;
using ViewModels.Category;

namespace BackEndApi.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto (this Category categoryModel)
        {
            return new CategoryDto
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                ParentId = categoryModel.ParentId,
                productsDto = categoryModel.Products.Select(p => p.ToProductDto()).ToList()
            };
        }
        public static Category ToCategoryFromCreateDto(this CreateRequestCategoryDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
            };
        }
    }
}
