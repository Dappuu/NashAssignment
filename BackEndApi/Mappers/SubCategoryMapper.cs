using BackEndApi.Models;
using ViewModels.SubCatgegory;

namespace BackEndApi.Mappers
{
    public static class SubCategoryMapper
    {
        public static SubCategoryDto ToSubCategoryDto(this Category categoryModel)
        {
            return new SubCategoryDto
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                SubCategories = categoryModel.SubCategories.Select(c => c.ToSubCategoryDto()).ToList()
            };
        }
        public static Category ToSubCategoryFromCreateDto(this CreateRequestSubCategoryDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name,
                ParentId = categoryDto.ParentId
            };
        }
    }
}
