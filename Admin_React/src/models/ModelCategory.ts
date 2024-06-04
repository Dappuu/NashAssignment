export interface CategoryDto {
    id: number;
    name: string;
    description: string;
    parentId?: number;
    subCategoriesDto: CategoryDto[] | null;
}
export interface CreateCategoryRequest {
    name: string;
    parentId: number | null;
    description: string;
}

export interface UpdateCategoryRequest {
    name: string;
    description: string;
}