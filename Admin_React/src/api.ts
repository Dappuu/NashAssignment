import apiClient from './apiClient'
import { CategoryDto, CreateCategoryRequest, UpdateCategoryRequest } from './models/ModelCategory';
import { toast } from 'react-toastify';
import { CreateProductRequest, ProductDto, UpdateProductRequest } from './models/ModelProduct';
import { SizeDto } from './models/ModelSize';
import { CreateProductSkuRequest, UpdateProductSkuRequest } from './models/ModelProductSku';
import { UserDto } from './models/ModelUser';

// Category
export const getAllCategories = async ():Promise<CategoryDto[]> => {
    try {
        const response = await apiClient.get('api/category');
        return response.data; 
    } catch (error) {
        throw new Error('Failed to get all categories in api'); 
    }
}

export const getCategoryById = async (id:number):Promise<CategoryDto> => {
    try {
        const response = await apiClient.get(`api/category/${id}`);
        return response.data; 
    } catch (error) {
        throw new Error('Failed to get category in api'); 
    }
}

export const createCategory = async (categoryData: CreateCategoryRequest) => {
    try {
        const response = await apiClient.post('api/category', categoryData);
        toast.success("Successfully created category!");
        return response.data; 
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to create category in api'); 
    }
}

export const updateCategory = async (id: number, categoryData: UpdateCategoryRequest) => {
    try {
        const response = await apiClient.put(`api/category/${id}`, categoryData);
        toast.success("Successfully updated category!");
        return response.data; 
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to update category in api'); 
    }
}

export const deleteCategory = async (id: number) => {
    try {
        const response = await apiClient.delete(`api/category/${id}`);
        toast.success("Successfully deleted category!");
        return response.data;
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to delete category in api');
    }
}

// Product
export const getAllProducts = async ():Promise<ProductDto[]> => {
    try {
        const response = await apiClient.get('api/product');
        return response.data; 
    } catch (error) {
        throw new Error('Failed to get all products in api'); 
    }
}

export const getProductById = async (id:number):Promise<ProductDto> => {
    try {
        const response = await apiClient.get(`api/product/${id}`);
        return response.data; 
    } catch (error) {
        throw new Error('Failed to get product in api'); 
    }
}
export const createProduct = async (productData: CreateProductRequest) => {
    try {
        const response = await apiClient.post('api/product', productData);
        toast.success("Successfully created product!");
        return response.data; 
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to create product in api'); 
    }
}

export const updateProduct = async (id: number, productData: UpdateProductRequest) => {
    try {
        const response = await apiClient.put(`api/product/${id}`, productData);
        toast.success("Successfully updated product!");
        return response.data; 
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to update product in api'); 
    }
}

export const deleteProduct = async (id: number) => {
    try {
        const response = await apiClient.delete(`api/product/${id}`);
        toast.success("Successfully deleted product!");
        return response.data;
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to delete product in api');
    }
}

// ProductSku
export const createProductSku = async (productSkuData: CreateProductSkuRequest) => {
    try {
        const response = await apiClient.post('api/productSku', productSkuData);
        toast.success("Successfully created productSku!");
        return response.data; 
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to create productSku in api'); 
    }
}

export const updateProductSku = async (id: number, productSkuData: UpdateProductSkuRequest) => {
    try {
        const response = await apiClient.put(`api/productSku/${id}`, productSkuData);
        toast.success("Successfully updated productSku!");
        return response.data; 
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to update productSku in api'); 
    }
}

export const deleteProductSku = async (id: number) => {
    try {
        const response = await apiClient.delete(`api/productSku/${id}`);
        toast.success("Successfully deleted productSku!");
        return response.data;
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to delete productSku in api');
    }
}

// Size
export const getAllSizes = async ():Promise<SizeDto[]> => {
    try {
        const response = await apiClient.get('api/size');
        return response.data; 
    } catch (error) {
        throw new Error('Failed to get all sizes in api'); 
    }
}
export const createSize = async (sizeData: {name: string}) => {
    try {
        const response = await apiClient.post('api/size', sizeData);
        toast.success("Successfully created size!");
        return response.data; 
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to create size in api'); 
    }
}

export const updateSize = async (id: number, sizeData: {name: string}) => {
    try {
        const response = await apiClient.put(`api/size/${id}`, sizeData);
        toast.success("Successfully updated size!");
        return response.data; 
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to update size in api'); 
    }
}

export const deleteSize = async (id: number) => {
    try {
        const response = await apiClient.delete(`api/size/${id}`);
        toast.success("Successfully deleted size!");
        return response.data;
    } catch (error: any) {
        toast.error(error.response.data);
        throw new Error('Failed to delete size in api');
    }
}
// User
export const getAllUsers = async ():Promise<UserDto[]> => {
    try {
        const response = await apiClient.get('api/account');
        return response.data; 
    } catch (error) {
        throw new Error('Failed to get all users in api'); 
    }
}