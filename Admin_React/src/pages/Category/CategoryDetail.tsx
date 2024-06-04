import DefaultLayout from '../../layout/DefaultLayout';
import TableCategory from '../../components/Tables/TableCategory';
import { getCategoryById } from '../../api';
import { Link, useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { CategoryDto } from '../../models/ModelCategory';


const CategoryDetail = () => {
  const [categoryInfo, setCategoryInfo] = useState<CategoryDto>();
  const { id } = useParams();
  const fetchCategoryInfo = async () => {
    try {
      const data = await getCategoryById(parseInt(id!));
      setCategoryInfo(data);
    } catch (error) {
      console.error('Error fetching categories:', error);
    }
  };
  useEffect(() => {
    fetchCategoryInfo();
  }, [id]);

  const onClickDelete = () => {
    fetchCategoryInfo();
  }

  return (
    <DefaultLayout>
      {!categoryInfo ? (
        <div>Loading...</div>
      ) : (
        <>
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
                    <div className='gap-2 flex'>
                      <Link to={`/category/form?parentId=${categoryInfo.id}`}
                        state={categoryInfo}>
                        <button className="bg-black text-white py-2 px-4 rounded hover:opacity-75">
                          Update Category
                        </button>
                      </Link>
                      <Link to={`/category/form?parentId=${categoryInfo.id}`}>
                        <button className="bg-black text-white py-2 px-4 rounded hover:opacity-75">
                          Add New SubCategory
                        </button>
                      </Link>
                    </div>
                  </div>
                  {categoryInfo.subCategoriesDto && (
                    <TableCategory
                      categoriesDto={categoryInfo.subCategoriesDto} onClickDelete={onClickDelete}
                    />
                  )}
                </>
              )}
          </div>
        </>
      )}
    </DefaultLayout>
  );
};

export default CategoryDetail;
