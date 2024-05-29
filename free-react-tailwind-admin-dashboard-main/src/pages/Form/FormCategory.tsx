import { useState,} from 'react';
import Breadcrumb from '../../components/Breadcrumbs/Breadcrumb';
import DefaultLayout from '../../layout/DefaultLayout';
import { createCategoryRequest } from '../../models/ModelCategory';
import { createCategory, getAllCategories } from '../../api';
import { Link, useNavigate } from 'react-router-dom';
import { SubmitHandler, useForm } from 'react-hook-form';

interface IFormInput {
  name: string;
  parentId: string;
}

const FormElements = () => {
  const navigate = useNavigate();
  const [selectedOption, setSelectedOption] = useState<string>();
  const [isOptionSelected, setIsOptionSelected] = useState<boolean>(false);

  const changeTextColor = () => {
    setIsOptionSelected(true);
  };

  const { register, handleSubmit } = useForm<IFormInput>({ mode: 'onSubmit' });
  const onSubmit:SubmitHandler<IFormInput> = async (data) => {
    console.log(data);
    const { name, parentId } = data;
    const categoryData: createCategoryRequest = {
      name,
      parentId: parentId === 'None' ? null : parseInt(parentId)
    }

    try {
      await createCategory(categoryData);
      navigate('/')
    } catch (error) {
      console.error(error);
    }
  };
  const { data: categories, error } = getAllCategories();

  if (error) return <div>{error}</div>;
  if (!categories) return <div>Loading...</div>;

  return (
    <DefaultLayout>
      <Breadcrumb pageName="Form Elements" />
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
                {...register('name', {required:true})}
                
              />
            </div>
            {/* Select options */}
            <div className="mb-4.5">
              <label className="mb-2.5 block text-black dark:text-white">
                {' '}
                Parent Category{' '}
              </label>

              <div className="relative z-20 bg-transparent dark:bg-form-input">
                <select
                  value={selectedOption}
                  {...register('parentId', {
                    onChange: (e) => {
                      setSelectedOption(e.target.value);
                      changeTextColor();
                    }
                  })}
                  className={`relative z-20 w-full appearance-none rounded border border-stroke bg-transparent py-3 px-5 outline-none transition focus:border-primary active:border-primary dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary ${
                    isOptionSelected ? 'text-primary dark:text-white' : ''}`
                }
                >
                  <option value="None" className="text-body dark:text-bodydark">
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
          </div>
          <div className="flex justify-end mt-4 space-x-4">
            <button
              className="bg-black text-white py-2 px-4 rounded hover:opacity-75"
              type="submit"
            >
              Create
            </button>
            <Link to={'/'}>
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
