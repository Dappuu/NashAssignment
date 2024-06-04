import DefaultLayout from '../../layout/DefaultLayout';
import { getProductById } from '../../api';
import { Link, useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { ProductDto } from '../../models/ModelProduct';
import TableProductSku from '../../components/Tables/TableProductSku';


const ProductDetail = () => {
    const [product, setProduct] = useState<ProductDto>();
    const { id } = useParams();
    const fetchProduct = async () => {
        try {
            const data = await getProductById(parseInt(id!));
            setProduct(data);
        } catch (error) {
            console.error('Error fetching product by id:', error);
        }
    };
    useEffect(() => {
        if (!product) {
            fetchProduct();
        }
    }, [id, product]);

    return (
        <DefaultLayout>
            {!product ? (<div>Loading...</div>) : (
                <>
                    <div className="flex flex-col bg-white gap-2 px-6 rounded-xl pb-4">
                        {product && (
                            <div className="mt-4 flex">
                                {/* Image card */}
                                <div className="w-1/3 p-4 bg-gray-100 rounded-lg">
                                    <img src={product.imageUrl} alt={product.name} className="rounded-lg" />
                                </div>

                                {/* Product details */}
                                <div className="w-2/3 ml-6">
                                    <h3 className="text-title-md font-medium text-black dark:text-white mb-2">
                                        Name: {product.name}
                                    </h3>
                                    <div className="grid grid-cols-1 gap-4">
                                        <div className='flex justify-between'>
                                            <div className="flex items-center">
                                                <span className="text-gray-700 dark:text-gray-400 mr-2">ID:</span>
                                                <span>{product.id}</span>
                                            </div>
                                            <div className="flex items-center">
                                                <span className="text-gray-700 dark:text-gray-400 mr-2">SKU Name:</span>
                                                <span>{product.productSkuName}</span>
                                            </div>
                                            <div className="flex items-center">
                                                <span className="text-gray-700 dark:text-gray-400 mr-2">CategoryID:</span>
                                                <span>{product.categoryId}</span>
                                            </div>
                                            <div className="flex items-center">
                                                <span className="text-gray-700 dark:text-gray-400 mr-2">Status:</span>
                                                <span>
                                                    {product.active ? (
                                                        <button className="bg-green-500 text-white py-1 px-3 rounded">
                                                            Active
                                                        </button>
                                                    ) : (
                                                        <button className="bg-red-500 text-white py-1 px-3 rounded">
                                                            Inactive
                                                        </button>
                                                    )}
                                                </span>
                                            </div>
                                        </div>
                                        <div className="flex items-center">
                                            <span className="text-gray-700 dark:text-gray-400 mr-2">Material:</span>
                                            <span>{product.material}</span>
                                        </div>
                                        <div className="flex items-center">
                                            <span className="text-gray-700 dark:text-gray-400 mr-2">Rating:</span>
                                            <span>{product.rating} /5</span>
                                        </div>
                                        <div className="flex items-center">
                                            <span className="text-gray-700 dark:text-gray-400 mr-2">Price:</span>
                                            <span>{formatPrice(product.price)}</span>
                                        </div>
                                        <div className="flex items-center">
                                            <span className="text-gray-700 dark:text-gray-400 mr-2">Discount:</span>
                                            <span>{product.discount}%</span>
                                        </div>
                                        <div className="flex items-center">
                                            <span className="text-gray-700 dark:text-gray-400 mr-2">Units in Stock:</span>
                                            <span>{product.unitsInStock}</span>
                                        </div>
                                        <div className="flex items-center">
                                            <span className="text-gray-700 dark:text-gray-400 mr-2">Units Sold:</span>
                                            <span>{product.unitsSold}</span>
                                        </div>
                                        <div className="flex items-center">
                                            <span className="text-gray-700 dark:text-gray-400 mr-2">Created Date:</span>
                                            <span>{new Date(product.createdDate).toLocaleString()}</span>
                                        </div>
                                        <div className="flex items-center">
                                            <span className="text-gray-700 dark:text-gray-400 mr-2">Updated Date:</span>
                                            <span>{new Date(product.updatedDate).toLocaleString()}</span>
                                        </div>
                                        <div className="">
                                            <span className="text-gray-700 dark:text-gray-400 mr-2">Description:</span>
                                            <span>{product.description}</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        )}
                        <div className="flex justify-between items-center mt-4">
                            <h3 className="text-title-md font-medium text-black dark:text-white mb-2">
                                Product SKUs
                            </h3>
                            <div className='gap-2 flex'>
                                <Link to={`/product/form?productId=${product.id}`}
                                    state={product}>
                                    <button className="bg-black text-white py-2 px-4 rounded hover:opacity-75">
                                        Update Product
                                    </button>
                                </Link>
                                <Link to={`/productSku/form?productId=${product.id}`}>
                                    <button className="bg-black text-white py-2 px-4 rounded hover:opacity-75">
                                        Add New SKU
                                    </button>
                                </Link>
                            </div>
                        </div>
                        {product.productSkusDto && (
                            <TableProductSku productDto={product} fetchDelete={fetchProduct}  />
                        )}
                </div>
                </>
                )
            }
    </DefaultLayout >
  );
};

export default ProductDetail;

const formatPrice = (price: number) => {
    return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(price);
  };