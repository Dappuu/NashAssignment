import { useEffect} from 'react';
import DefaultLayout from '../../layout/DefaultLayout';
import { createSize, updateSize } from '../../api';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { SubmitHandler, useForm } from 'react-hook-form';
import { SizeDto } from '../../models/ModelSize';

interface IFormInput {
  name: string;
}

const FormElements = () => {
  const navigate = useNavigate();
  const location = useLocation(); // Location
  

  const sizeFromState: SizeDto | null = location.state || null; // To update the form

  const { register, handleSubmit, reset, formState: {errors} } = useForm<IFormInput>({
    mode: 'onSubmit',
  });

  useEffect(() => {
    if (sizeFromState !== null) {
      reset({
        name: sizeFromState.name,
      });
    }
  }, []);

  const onSubmit: SubmitHandler<IFormInput> = async (data) => {
    if (sizeFromState === null) {
      const sizeData = {name: data.name};
      try {
        await createSize(sizeData);
        navigate('/size');
    
      } catch (error) {
        console.error(error);
      }
    } else {
      const sizeData = {name: data.name};
      try {
        await updateSize(sizeFromState.id, sizeData);
        navigate('/size');
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
                Size Name
              </label>
              <input
                type="text"
                placeholder="Type your category name..."
                className="w-full rounded-lg border-[1.5px] border-stroke bg-transparent py-3 px-5 text-primary dark:text-white outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:focus:border-primary"
                {...register('name', { required: 'Name is required.' })}
              />
              {errors.name && <span className='text-red-500 p-3'>{ errors.name.message}</span>}
            </div>
          </div>
          <div className="flex justify-end mt-4 space-x-4">
            <button
              className="bg-black text-white py-2 px-4 rounded hover:opacity-75"
              type="submit"
            >
              Submit
            </button>
            <Link to='/size'>
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
