export interface categoryDto {
    id: number;
    name: string;
    description: string;
    parentId?: number;
    subCategoriesDto: categoryDto[] | null;
}
export interface createCategoryRequest {
    name: string;
    parentId: number | null;
    description: string;
}

export interface updateCategoryRequest {
    name: string;
    description: string;
}