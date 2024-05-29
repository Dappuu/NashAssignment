import useSWR from 'swr';
import apiClient from './apiClient'
import { categoryDto, createCategoryRequest } from './models/ModelCategory';
import { toast } from 'react-toastify';



const fetcher = (url: string) => apiClient.get(url).then(res => res.data);

export const getAllCategories = () => {
    const { data, error } = useSWR<categoryDto[]>('api/category', fetcher);
    return {
        data,
        error,
    };
}

export const createCategory = async (categoryData: createCategoryRequest) => {
    try {
        const response = await apiClient.post('api/category', categoryData);
        toast.success("Successfully created category!", {
            position: toast.POSITION.TOP_RIGHT,
          });
        return response.data; 
    } catch (error) {
        toast.error("Failed to create category", {
            position: toast.POSITION.TOP_RIGHT,
          });
        throw new Error('Failed to create category in api'); 
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