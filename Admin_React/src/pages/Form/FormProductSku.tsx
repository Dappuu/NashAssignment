import { useEffect, useState } from 'react';
import DefaultLayout from '../../layout/DefaultLayout';
import { createProductSku, getAllSizes, updateProductSku} from '../../api';
import { Link, useLocation, useNavigate} from 'react-router-dom';
import { SubmitHandler, useForm } from 'react-hook-form';
import { CreateProductSkuRequest, ProductSkuDto, UpdateProductSkuRequest } from '../../models/ModelProductSku';
import { SizeDto } from '../../models/ModelSize';

interface IFormInput {
  unitsInStock: number;
  sizeId: number | null;
}

const FormElements = () => {
  const navigate = useNavigate();
  const location = useLocation(); // Location
  const queryParams = new URLSearchParams(location.search); // Query String
  const productId = parseInt(queryParams.get('productId')!);

  const [isOptionSelected, setIsOptionSelected] = useState<boolean>(false); // Check selected
  const changeTextColor = () => {
    setIsOptionSelected(true);
  };

  const [sizes, setSizes] = useState<SizeDto[]>([]);
  const fetchSizes = async () => {
    try {
      const data = await getAllSizes();
      setSizes(data);
    } catch (error) {
      console.error('Error fetching sizes:', error);
    }
  };

  const productSkuFromState: ProductSkuDto | null = location.state || null; // To update the form

  useEffect(() => {
    if (productSkuFromState !== null) {
      reset({
        sizeId: productSkuFromState.sizeId,
        unitsInStock: productSkuFromState.unitsInStock,
      });
    }
    
    if (sizes.length === 0) {
      fetchSizes();
    } else {
      setValue('sizeId', sizes[0].id);
    }
  }, [sizes]);
  
  const { register, handleSubmit, reset, setValue, formState: { errors } } = useForm<IFormInput>({
    mode: 'onSubmit',
  });
  const onSubmit: SubmitHandler<IFormInput> = async (data) => {
    if (productSkuFromState === null) {
      const productSkuData: CreateProductSkuRequest = {
        productId: productId,
        sizeId: data.sizeId!,
        unitsInStock: data.unitsInStock,
      };
      try {
        await createProductSku(productSkuData);
        navigate(`/product/${productId}`);

      } catch (error) {
        console.error(error);
      }
    } else {
      const productSkuData: UpdateProductSkuRequest = {
        sizeId: data.sizeId!,
        unitsInStock: data.unitsInStock,
      };
      try {
        await updateProductSku(productSkuFromState.id, productSkuData);
        navigate(`/product/${productId}`);
      } catch (error) {
        console.error(error);
      }
    }
  };

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
              Size Form
            </h2>
          </div>
          <div className="flex flex-col gap-5.5 p-6.5">
            <div>
              <label className="mb-3 block text-black dark:text-white">
                Units In Stock
              </label>
              <input
                type="number"
                placeholder="Type your Units In Stock..."
                className="w-full rounded-lg border-[1.5px] border-stroke bg-transparent py-3 px-5 text-primary dark:text-white outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                {...register('unitsInStock', { required: 'Units In Stock is required.' })}
              />
              {errors.unitsInStock && <span className='text-red-500 p-3'>{errors.unitsInStock.message}</span>}
            </div>

            <div className="mb-4.5">
              <label className="mb-2.5 block text-black dark:text-white">
                {' '}
                Size{' '}
              </label>

              <div
                className={'relative z-20 bg-transparent dark:bg-form-input'}
              >
                <select
                  {...register('sizeId', {
                    onChange: () => {
                      changeTextColor();
                    },
                  })}
                  className={`relative z-20 w-full appearance-none rounded border border-stroke bg-transparent py-3 px-5 outline-none transition focus:border-primary active:border-primary dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary ${isOptionSelected ? 'text-primary dark:text-white' : ''
                    }`}
                >
                  {sizes.map((size) => (
                    <option
                      key={size.id}
                      value={size.id}
                      className="text-body dark:text-bodydark"
                    >
                      {size.name}
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
              Submit
            </button>
            <Link to={`/product/${productId}`}>
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
