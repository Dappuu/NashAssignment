import useSWR from 'swr';
import apiClient from './apiClient'
import { categoryDto, createCategoryRequest, updateCategoryRequest } from './models/ModelCategory';
import { toast } from 'react-toastify';


export const getAllCategories = async ():Promise<categoryDto[]> => {
    try {
        const response = await apiClient.get('api/category');
        return response.data; 
    } catch (error) {
        throw new Error('Failed to get all categories in api'); 
    }
}

export const getCategoryById = async (id:number):Promise<categoryDto> => {
    try {
        const response = await apiClient.get(`api/category/${id}`);
        return response.data; 
    } catch (error) {
        throw new Error('Failed to get category in api'); 
    }
}

export const createCategory = async (categoryData: createCategoryRequest) => {
    try {
        const response = await apiClient.post('api/category', categoryData);
        toast.success("Successfully created category!", {
            position: toast.POSITION.TOP_RIGHT,
            autoClose: 1500
          });
        return response.data; 
    } catch (error) {
        toast.error("Failed to create category", {
            position: toast.POSITION.TOP_RIGHT,
            autoClose: 1500
          });
        throw new Error('Failed to create category in api'); 
    }
}

export const updateCategory = async (id: number, categoryData: updateCategoryRequest) => {
    try {
        const response = await apiClient.put(`api/category/${id}`, categoryData);
        toast.success("Successfully updated category!", {
            position: toast.POSITION.TOP_RIGHT,
            autoClose: 1500
          });
        return response.data; 
    } catch (error) {
        toast.error("Failed to update category", {
            position: toast.POSITION.TOP_RIGHT,
            autoClose: 1500
          });
        throw new Error('Failed to update category in api'); 
    }
}

export const deleteCategory = async (id: number) => {
    try {
        const response = await apiClient.delete(`api/category/${id}`);
        toast.success("Successfully deleted category!", {
            position: toast.POSITION.TOP_RIGHT,
        });
        return response.data;
    } catch (error) {
        toast.error("Failed to delete category", {
            position: toast.POSITION.TOP_RIGHT,
          });
        throw new Error('Failed to delete category in api');
    }
}