export interface categoryDto {
    id: number;
    name: string;
    parentId?: string;
    subCategoriesDto: categoryDto[] | [];
}
export interface createCategoryRequest {
    name: string;
    parentId: number | null;
}