import DefaultLayout from '../../layout/DefaultLayout';
import TableCategory from '../../components/Tables/TableCategory';
import { getAllCategories} from '../../api';
import { Link} from 'react-router-dom';
import { useEffect, useState } from 'react';
import { CategoryDto } from '../../models/ModelCategory';


const Category = () => {
  const [categories, setCategories] = useState<CategoryDto[]>([]);
  const fetchCategories = async () => {
    try {
      const data = await getAllCategories();
      setCategories(data);
    } catch (error) {
      console.error('Error fetching categories:', error);
    }
  };
  useEffect(() => {
    if (categories.length === 0)
    {
      fetchCategories();
      }
  }, [categories]);
  const onClickDelete = () => fetchCategories();

  return (
    <DefaultLayout>
      <div className="flex flex-col bg-white px-4 rounded-xl pb-6">
        <div className="flex justify-between pt-6 px-4 md:px-6 xl:px-7.5 items-center">
          <h2 className="text-title-md2 font-semibold text-black dark:text-white">
            Category
          </h2>

          <Link to={'form'}>
            <button className="bg-primary text-white py-2 px-4 rounded hover:opacity-75">
              Create New Category
            </button>
          </Link>
        </div>
        <TableCategory categoriesDto={categories} onClickDelete={onClickDelete} />
      </div>
    </DefaultLayout>
  );
};

export default Category;
