import { useEffect, useState } from 'react';
import DefaultLayout from '../../layout/DefaultLayout';
import { createProduct, getAllCategories, updateProduct } from '../../api';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { SubmitHandler, useForm } from 'react-hook-form';
import { CategoryDto } from '../../models/ModelCategory';
import { CreateProductRequest, ProductDto, UpdateProductRequest } from '../../models/ModelProduct';
import { getDownloadURL, ref, uploadBytes } from 'firebase/storage';
import { storage } from '../../firebase';
import { v4 } from 'uuid';
import { toast } from 'react-toastify';

interface IFormInput {
  name: string;
  productSkuName: string;
  description: string;
  material: string;
  price: number;
  discount: number;
  active: boolean;
  imageUrl: string;
  parentCategoryId: number;
  categoryId: number;
}

const FormElements = () => {
  const navigate = useNavigate();
  const location = useLocation(); // Location
  const queryParams = new URLSearchParams(location.search); // Query String
  const productId = parseInt(queryParams.get('productId')!);

  const [isOptionSelected, setIsOptionSelected] = useState<boolean>(false); // Check selected
  const [parentCategoryId, setParentCategoryId] = useState<number>();

  const parentCategoryChangeHandler = (event: any) => {
    const selectedParentCategoryId = parseInt(event.target.value);
    setParentCategoryId(selectedParentCategoryId);
    setIsOptionSelected(true);
  };

  const [categories, setCategories] = useState<CategoryDto[]>([]); // Show all categories in options
  const fetchCategories = async () => {
    try {
      const data = await getAllCategories();
      setCategories(data);
    } catch (error) {
      console.error('Error fetching categories:', error);
    }
  };

  const productFromState: ProductDto | null = location.state || null; // To update the form

  useEffect(() => {
    if (productFromState !== null) {
      reset({
        name: productFromState.name,
        productSkuName: productFromState.productSkuName,
        description: productFromState.description,
        material: productFromState.material,
        price: productFromState.price,
        discount: productFromState.discount,
        active: productFromState.active,
        imageUrl: productFromState.imageUrl
      });
      setIsOptionSelected(true);
    }

    if (categories.length === 0) {
      fetchCategories();
    } else {
      setParentCategoryId(categories[0].id);
      setIsOptionSelected(true);
    }
  }, [categories]);

  const { register, handleSubmit, reset, formState: { errors } } = useForm<IFormInput>({
    mode: 'onSubmit',
  });
  const onSubmit: SubmitHandler<IFormInput> = async (data) => {
    const imgUrl = await uploadImage();
    if (!isOptionSelected){
      toast.error("Please choose category.");
      }
    if (productFromState === null) {
      if (!imgUrl) {
        toast.error("Please upload your image");
        return;
      }
      const productSkuData: CreateProductRequest = {
        name: data.name,
        productSkuName: data.productSkuName,
        description: data.description,
        material: data.material,
        price: data.price,
        discount: data.discount,
        active: data.active,
        categoryId: data.categoryId,
        imageUrl: imgUrl!,
      };
      try {
        await createProduct(productSkuData);
        navigate(`/product/`);

      } catch (error) {
        console.error(error);
      }
    } 
    else
    {
      const productSkuData: UpdateProductRequest = {
        name: data.name,
        productSkuName: data.productSkuName,
        description: data.description,
        material: data.material,
        price: data.price,
        discount: data.discount,
        active: data.active,
        imageUrl: imgUrl ? imgUrl : data.imageUrl,
      };
      try {
        await updateProduct(productFromState.id, productSkuData);
        navigate(`/product/${productId}`);
      } catch (error) {
        console.error(error);
      }
    }
  };
  const [imageUpload, setImageUpload] = useState<File | null>(null);
  const uploadImage = async () => {
    let imgUrl: string = '';
    if (imageUpload === null) return;
    const imageRef = ref(storage, `images/${imageUpload.name + v4()}`);
    await uploadBytes(imageRef, imageUpload).then(() => {
      toast.success("Image Uploaded");
    });
    await getDownloadURL(imageRef).then((downloadURL) => {
      imgUrl = downloadURL;
    });
    return imgUrl;
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
              Product Form
            </h2>
          </div>
          <div className="flex flex-col gap-5.5 p-6.5">
            <div className="flex gap-5.5">
              <div className="flex-1">
                <label className="mb-3 block text-black dark:text-white">Name</label>
                <input
                  type="text"
                  placeholder="Type your product name..."
                  className="w-full rounded-lg border-[1.5px] border-stroke bg-transparent py-3 px-5 text-primary dark:text-white outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                  {...register('name', { required: "Name is required." })}
                />
                {errors.name && <span className='text-red-500 p-3'>{errors.name.message}</span>}
              </div>

              <div className="flex-1">
                <label className="mb-3 block text-black dark:text-white">SKU Name</label>
                <input
                  type="text"
                  placeholder="Type your SKU name..."
                  className="w-full rounded-lg border-[1.5px] border-stroke bg-transparent py-3 px-5 text-primary dark:text-white outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                  {...register('productSkuName', { required: "SKU Name is required." })}
                />
                {errors.productSkuName && <span className='text-red-500 p-3'>{errors.productSkuName.message}</span>}
              </div>
            </div>

            <div className="flex gap-5.5">
              <div className="flex-2">
                <label className="mb-3 block text-black dark:text-white">Material</label>
                <input
                  type="text"
                  placeholder="Type your material..."
                  className="w-full rounded-lg border-[1.5px] border-stroke bg-transparent py-3 px-5 text-primary dark:text-white outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                  {...register('material', { required: "Material is required." })}
                />
                {errors.material && <span className='text-red-500 p-3'>{errors.material.message}</span>}
              </div>

              <div className="flex flex-col items-center space-y-3">
                <label htmlFor="active" className="text-black dark:text-white">
                  Active
                </label>
                <input
                  type="checkbox"
                  id="active"
                  className="w-6 h-6 text-primary border-2 border-gray-300 rounded focus:ring-primary focus:ring-2 focus:ring-offset-0 transition-colors duration-200 bg-transparent checked:bg-primary checked:border-transparent"
                  {...register('active')}
                />
                {errors.active && <span className='text-red-500 p-3'>{errors.active.message}</span>}
              </div>
            </div>


            <div className="flex gap-5.5">
              <div className="flex-1">
                <label className="mb-3 block text-black dark:text-white">Price</label>
                <input
                  type="number"
                  placeholder="Type your price..."
                  className="w-full rounded-lg border-[1.5px] border-stroke bg-transparent py-3 px-5 text-primary dark:text-white outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                  {...register('price', { required: "Price is required." })}
                />
                {errors.price && <span className='text-red-500 p-3'>{errors.price.message}</span>}
              </div>

              <div className="flex-1">
                <label className="mb-3 block text-black dark:text-white">Discount</label>
                <input
                  type="number"
                  placeholder="Type your discount..."
                  className="w-full rounded-lg border-[1.5px] border-stroke bg-transparent py-3 px-5 text-primary dark:text-white outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                  {...register('discount', { required: "Discount is required." })}
                />
                {errors.discount && <span className='text-red-500 p-3'>{errors.discount.message}</span>}
              </div>
            </div>

            <div>
              <label className="mb-3 block text-black dark:text-white">Description</label>
              <input
                type="text"
                placeholder="Type your description..."
                className="w-full rounded-lg border-[1.5px] border-stroke bg-transparent py-3 px-5 text-primary dark:text-white outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                {...register('description', { required: "Description is required." })}
              />
              {errors.description && <span className='text-red-500 p-3'>{errors.description.message}</span>}
            </div>

            <div className="flex gap-5.5">
              <div className='flex-1'>
                <label className="mb-3 block text-black dark:text-white">Image</label>
                <input
                  type="file"
                  placeholder="Type your image URL..."
                  className="w-full rounded-lg border-[1.5px] border-stroke bg-transparent py-3 px-3 text-primary dark:text-white outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                  onChange={(e: any) => {
                    setImageUpload(e.target.files[0]);
                  }}
                />
              </div>
              <div>
                {imageUpload && <img className='w-50 h-50 object-cover rounded-lg mt-3' src={URL.createObjectURL(imageUpload)} alt="Selected Image Preview" />}
              </div>
            </div>
            <div>
              {/* <button
                className="bg-black text-white py-2 px-4 mt-2 rounded hover:opacity-75"
                onClick={uploadImage}>
                Upload image
              </button> */}
            </div>

            {/* Select options */}
            {productFromState === null && (
              <div className="mb-4.5">
                <label className="mb-2.5 block text-black dark:text-white">
                  {' '}
                  Category{' '}
                </label>

                <div className={'relative z-20 bg-transparent dark:bg-form-input'}>
                  <select
                    {...register('parentCategoryId', {
                      required: "Parent Category is required.",
                      onChange: parentCategoryChangeHandler,
                    })}
                    className={`relative z-20 w-full appearance-none rounded border border-stroke bg-transparent py-3 px-5 outline-none transition focus:border-primary active:border-primary dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary ${isOptionSelected ? 'text-primary dark:text-white' : ''
                      }`}
                  >
                    {categories &&
                      categories.map((category) => (
                        <option value={category.id} key={category.id} className='text-body dark:text-bodydark'>
                          {category.name}
                        </option>
                      ))}
                  </select>
                  {errors.parentCategoryId && <span className='text-red-500 p-3'>{errors.parentCategoryId.message}</span>}
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
                {categories && parentCategoryId &&
                  (() => {
                    const category = categories.find((category) => category.id === parentCategoryId);
                    if (category && category.subCategoriesDto) {
                      return (
                        <div className='my-4.5'>
                          <label className="mb-2.5 block text-black dark:text-white">
                            {' '}
                            SubCategory{' '}
                          </label>
                          <div className={'relative z-20 bg-transparent dark:bg-form-input'}>
                            <select
                              className='relative z-20 w-full appearance-none rounded border border-stroke bg-transparent py-3 px-5 outline-none transition focus:border-primary active:border-primary dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary text-primary dark:text-white'
                              {...register('categoryId', {
                                required: "SubCategory is required.",
                              })}

                            >
                              {category.subCategoriesDto.map((subcategory: CategoryDto) => (
                                <option value={subcategory.id} key={subcategory.id} className='text-body dark:text-bodydark'>
                                  {subcategory.name}
                                </option>
                              ))}
                            </select>
                            {errors.categoryId && <span className='text-red-500 p-3'>{errors.categoryId.message}</span>}
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
                      )
                    }
                  })()
                }



              </div>
            )}
          </div>
          <div className="flex justify-end mt-4 space-x-4">
            <button
              className="bg-black text-white py-2 px-4 rounded hover:opacity-75"
              type='submit'
            >
              Submit
            </button>
            <Link to={productFromState ? `/product/${productId}` : '/product'}>
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
