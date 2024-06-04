import DefaultLayout from '../../layout/DefaultLayout';
import { getAllSizes } from '../../api';
import { Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
import TableSize from '../../components/Tables/TableSize';
import { SizeDto } from '../../models/ModelSize';


const Product = () => {
  const [sizes, setSizes] = useState<SizeDto[]>([]);
  const fetchSizes = async () => {
    try {
      const data = await getAllSizes();
      setSizes(data);
    } catch (error) {
      console.error('Error fetching size:', error);
    }
  };
  useEffect(() => {
    if (sizes.length === 0) {
      fetchSizes();
    }
  }, [sizes]);
  const onClickDelete = () => fetchSizes();


  return (
    <DefaultLayout>
      <div className="flex flex-col bg-white px-4 rounded-xl pb-6">
        <div className="flex justify-between pt-6 px-4 md:px-6 xl:px-7.5 items-center">
          <h2 className="text-title-md2 font-semibold text-black dark:text-white">
            Size
          </h2>


          <Link to={'form'}>
            <button className="bg-black text-white py-2 px-4 rounded hover:opacity-75">
              Create New Size    
            </button>
          </Link>
        </div>
        <TableSize sizesDto={sizes} onclickDelete={onClickDelete} />
      </div>
    </DefaultLayout>
  );
};

export default Product;
