export interface ProductSkuDto{
    id: number;
    productId: number;
    unitsInStock: number;
    unitsSold: number;
    size: string | null;
    sizeId: number | null;
}
export interface CreateProductSkuRequest {
    productId: number;
    sizeId: number;
    unitsInStock: number;
}

export interface UpdateProductSkuRequest {
    sizeId: number;
    unitsInStock: number;
}