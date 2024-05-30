import Breadcrumb from '../../components/Breadcrumbs/Breadcrumb';
import DefaultLayout from '../../layout/DefaultLayout';
import TableCategory from '../../components/Tables/TableCategory';
import { getCategoryById } from '../../api';
import { Link, useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { categoryDto } from '../../models/ModelCategory';

interface Props {}

const Category = (props: Props) => {
    const [categoryInfo, setCategoryInfo] = useState<categoryDto>();
    const [categoryParent, setCategoryParent] = useState<categoryDto>();
  const { id } = useParams();
  useEffect(() => {
    const fetchCategoryInfo = async () => {
      try {
        const data = await getCategoryById(parseInt(id!));
        setCategoryInfo(data);
      } catch (error) {
        console.error('Error fetching categories:', error);
      }
      };
      console.log('categoryInfo: ', categoryInfo);
    fetchCategoryInfo();
  }, [id]);
  useEffect(() => {
    const fetchCategoryParentInfo = async () => {
        if (categoryInfo?.parentId){
            try {
            const data = await getCategoryById(categoryInfo.parentId);
            setCategoryParent(data);
            } catch (error) {
            console.error('Error fetching categories:', error);
        }
      }
      };
      console.log('categoryParent: ', categoryParent);
    fetchCategoryParentInfo();
  }, []);
  if (!categoryInfo) return <div>Loading...</div>;

  return (
    <DefaultLayout>
      <Breadcrumb pageName='category' parentId={categoryInfo.parentId} parentName={categoryParent?.name} />
      <div className="flex flex-col bg-white gap-2 px-6 rounded-xl pb-4">
        {categoryInfo && (
          <div className="mt-4">
            <h3 className="text-title-md font-medium text-black dark:text-white mb-2 ">
              Name: {categoryInfo.name}
            </h3>
            <div className="grid grid-cols-1 gap-4 ">
              <div className="flex items-center">
                <span className="text-gray-700 dark:text-gray-400 mr-2">
                  ID:
                </span>
                <span>{categoryInfo.id}</span>
              </div>
              {/* <div className="flex items-center">
                <span className="text-gray-700 dark:text-gray-400 mr-2">
                  Name:
                </span>
                <span>{categoryInfo.name}</span>
              </div> */}
              <div className="flex items-center">
                <span className="text-gray-700 dark:text-gray-400 mr-2">
                  Description:
                </span>
                <span>{categoryInfo.description}</span>
              </div>
              {/* Add more details based on your category model properties */}
            </div>
          </div>
        )}
        {(categoryInfo.subCategoriesDto?.length != 0 ||
          categoryInfo.parentId === null) && (
          <>
            <div className="flex justify-between items-center">
              <h3 className="text-title-md font-medium text-black dark:text-white mb-2 ">
                Sub-Category
              </h3>
              <Link to={`/category/form?parentId=${categoryInfo.id}`}>
                <button className="bg-black text-white py-2 px-4 rounded hover:opacity-75">
                  Create New Category
                </button>
              </Link>
            </div>
            {categoryInfo.subCategoriesDto && (
              <TableCategory categoriesDto={categoryInfo.subCategoriesDto} />
            )}
          </>
        )}
      </div>
    </DefaultLayout>
  );
};

export default Category;
