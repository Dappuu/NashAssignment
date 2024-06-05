import { useEffect, useState } from 'react';
import DefaultLayout from '../../layout/DefaultLayout';
import {
  CategoryDto,
  CreateCategoryRequest,
  UpdateCategoryRequest,
} from '../../models/ModelCategory';
import { createCategory, getAllCategories, updateCategory } from '../../api';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { SubmitHandler, useForm } from 'react-hook-form';

interface IFormInput {
  name: string;
  parentId: string;
  description: string;
}

const FormElements = () => {
  const [isOptionSelected, setIsOptionSelected] = useState<boolean>(false); // Check selected

  const navigate = useNavigate();
  const location = useLocation(); // Location
  const queryParams = new URLSearchParams(location.search); // Query String
  const parentId = queryParams.get('parentId');

  const [parentCategory, setParentCategory] = useState<CategoryDto>(); // Show Parent Category for specific child category
  const [categories, setCategories] = useState<CategoryDto[]>([]); // Show all categories in options
  const categoryFromState: CategoryDto | null = location.state || null; // To update the form

  const changeTextColor = () => {
    setIsOptionSelected(true);
  };

  const { register, handleSubmit, reset, setValue, formState: {errors} } = useForm<IFormInput>({
    mode: 'onSubmit',
  });
  const fetchCategories = async () => {
    try {
      const data = await getAllCategories();
      setCategories(data);
    } catch (error) {
      console.error('Error fetching categories:', error);
    }
  };

  useEffect(() => {
    if (categoryFromState !== null) {
      reset({
        name: categoryFromState.name,
        description: categoryFromState.description,
      });
    }

    if (categories.length === 0) {
      fetchCategories();
    }
    if (parentId && categories.length > 0) {
      const result = categories.find((c) => c.id === parseInt(parentId));
      setParentCategory(result);
      setValue('parentId', parentId);
    }
  }, [categories]);

  const onSubmit: SubmitHandler<IFormInput> = async (data) => {
    if (categoryFromState === null) {
      const categoryData: CreateCategoryRequest = {
        name: data.name,
        parentId: data.parentId === 'None' ? null : parseInt(data.parentId),
        description: data.description,
      };
      try {
        await createCategory(categoryData);
        if (parentId === null) {
          navigate('/category');
        }
        else {
          navigate(`/category/${parentId}`);
        }
      } catch (error) {
        console.error(error);
      }
    } else {
      const categoryData: UpdateCategoryRequest = {
        name: data.name,
        description: data.description,
      };
      try {
        await updateCategory(categoryFromState.id, categoryData);
        if (parentId === null) {
          navigate('/category');
        }
        else {
          navigate(`/category/${parentId}`);
        }
      } catch (error) {
        console.error(error);
      }
    }
  };
  if (!categories) return <div>Loading...</div>;

  return (
    <DefaultLayout>
      {/* <Breadcrumb pageName="Form Elements" /> */}
      <form
        className="flex justify-center items-center"
        onSubmit={handleSubmit(onSubmit)}
      >
        <div className="w-full max-w-3xl p-6 bg-white dark:bg-boxdark rounded-lg shadow-default border border-stroke dark:border-strokedark">
          <div className="py-2 px-5.5 border-b border-stroke dark:border-strokedark">
            <h2 className="text-title-md2 font-semibold text-black dark:text-white">
              Category Form
            </h2>
          </div>
          <div className="flex flex-col gap-5.5 p-6.5">
            <div>
              <label className="mb-3 block text-black dark:text-white">
                Category Name
              </label>
              <input
                type="text"
                placeholder="Type your category name..."
                className="w-full rounded-lg border-[1.5px] border-stroke bg-transparent py-3 px-5 text-primary dark:text-white outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                {...register('name', { required: "Name is required." })}
                />
                {errors.name && <span className='text-red-500 p-3'>{ errors.name.message}</span>}
            </div>
            <div>
              <label className="mb-3 block text-black dark:text-white">
                Description
              </label>
              <input
                type="text"
                placeholder="Type your category name..."
                className="w-full rounded-lg border-[1.5px] border-stroke bg-transparent py-3 px-5 text-primary dark:text-white outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                {...register('description', { })}
              />
              {errors.description && <span className='text-red-500 p-3'>{ errors.description.message}</span>}
            </div>
            {/* Select options */}
            {categoryFromState === null && (
              <div className="mb-4.5">
                <label className="mb-2.5 block text-black dark:text-white">
                  {' '}
                  Parent Category{' '}
                </label>

                <div
                  className={'relative z-20 bg-transparent dark:bg-form-input'}
                >
                  <select
                    {...register('parentId', {
                      onChange: () => {
                        changeTextColor();
                      },
                    })}
                    className={`relative z-20 w-full appearance-none rounded border border-stroke bg-transparent py-3 px-5 outline-none transition focus:border-primary active:border-primary dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary ${isOptionSelected ? 'text-primary dark:text-white' : ''
                      }`}
                  >
                    {parentCategory ? (
                      <option
                        value={parentCategory.id}
                        className="text-body dark:text-bodydark"
                      >
                        {parentCategory.name}
                      </option>
                    ) : (
                      <>
                        <option
                          value="None"
                          className="text-body dark:text-bodydark"
                        >
                          None
                        </option>
                        {categories.map((category) => (
                          <option
                            key={category.id}
                            value={category.id}
                            className="text-body dark:text-bodydark"
                          >
                            {category.name}
                          </option>
                        ))}
                      </>
                    )}
                  </select>

                  <span className="absolute top-1/2 right-4 z-30 -translate-y-1/2">
                    <svg
                      className="fill-current"
                      width="24"
                      height="24"
                      viewBox="0 0 24 24"
                      fill="none"
                      xmlns="http://www.w3.org/2000/svg"
                    >
                      <g opacity="0.8">
                        <path
                          fillRule="evenodd"
                          clipRule="evenodd"
                          d="M5.29289 8.29289C5.68342 7.90237 6.31658 7.90237 6.70711 8.29289L12 13.5858L17.2929 8.29289C17.6834 7.90237 18.3166 7.90237 18.7071 8.29289C19.0976 8.68342 19.0976 9.31658 18.7071 9.70711L12.7071 15.7071C12.3166 16.0976 11.6834 16.0976 11.2929 15.7071L5.29289 9.70711C4.90237 9.31658 4.90237 8.68342 5.29289 8.29289Z"
                          fill=""
                        ></path>
                      </g>
                    </svg>
                  </span>
                </div>
              </div>
            )}
          </div>
          <div className="flex justify-end mt-4 space-x-4">
            <button
              className="bg-black text-white py-2 px-4 rounded hover:opacity-75"
              type="submit"
            >
              Submit
            </button>
            <Link to={parentId ? `/category/${parentId}` : '/category'}>
              <button className="bg-black text-white py-2 px-4 rounded hover:opacity-75">
                Back
              </button>
            </Link>
          </div>
        </div>
      </form>
    </DefaultLayout>
  );
};

export default FormElements;
