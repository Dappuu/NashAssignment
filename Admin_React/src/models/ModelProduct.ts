import { CommentDto } from "./ModelComment";
import { ProductSkuDto } from "./ModelProductSku";

export interface ProductDto {
    id: number;
    name: string;
    productSkuName: string;
    description: string;
    material: string;
    rating: number | null;
    price: number;
    discount: number;
    unitsInStock: number;
    unitsSold: number;
    createdDate: Date;
    updatedDate: Date;
    active: boolean;
    categoryId: number;
    productSkusDto: ProductSkuDto[] | null;
    commentDto: CommentDto[] | null;
    imageUrl: string;
}
export interface CreateProductRequest{
    name: string;
    productSkuName: string;
    description: string;
    material: string;
    price: number;
    discount: number;
    active: boolean;
    imageUrl: string;
    categoryId: number;
}
export interface UpdateProductRequest {
    name: string;
    productSkuName: string;
    description: string;
    material: string;
    price: number;
    discount: number;
    imageUrl: string;
    active: boolean;
}