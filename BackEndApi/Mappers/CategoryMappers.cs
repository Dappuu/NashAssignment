using BackEndApi.Models;
using ViewModels.Category;

namespace BackEndApi.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description,
                ParentId = categoryModel.ParentId,
                SubCategoriesDto = categoryModel.SubCategories is null ? null : categoryModel.SubCategories.Select(c => c.ToCategoryDto()).ToList(),
                Products = categoryModel.Products is null ? null : categoryModel.Products.Select(p => p.ToProductDto()).ToList(),

                
            };
        }
        public static Category ToCategoryFromCreateDto(this CreateRequestCategoryDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
                ParentId = categoryDto.ParentId is null ? null : categoryDto.ParentId,
                Description = categoryDto.Description,
            };
        }
    }
}
