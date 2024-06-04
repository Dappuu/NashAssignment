import DefaultLayout from '../../layout/DefaultLayout';
import { getAllProducts} from '../../api';
import { Link} from 'react-router-dom';
import { useEffect, useState } from 'react';
import { ProductDto } from '../../models/ModelProduct';
import TableProduct from '../../components/Tables/TableProduct';


const Product = () => {
  const [products, setProducts] = useState<ProductDto[]>([]);
  const fetchProducts = async () => {
    try {
      const data = await getAllProducts();
      setProducts(data);
    } catch (error) {
      console.error('Error fetching products:', error);
    }
  };
  useEffect(() => {
    fetchProducts();
  }, [products]);

  if (!products) return <div>Loading...</div>;
  const onClickDelete = () => fetchProducts();
  return (
    <DefaultLayout>
      <div className="flex flex-col bg-white px-4 rounded-xl pb-6">
        <div className="flex justify-between pt-6 px-4 md:px-6 xl:px-7.5 items-center">
          <h2 className="text-title-md2 font-semibold text-black dark:text-white">
            Product
          </h2>

          <Link to={'form'}>
            <button className="bg-black text-white py-2 px-4 rounded hover:opacity-75">
              Create New Product    
            </button>
          </Link>
        </div>
        <TableProduct productsDto={products} onClickDelete={onClickDelete} />
      </div>
    </DefaultLayout>
  );
};

export default Product;
