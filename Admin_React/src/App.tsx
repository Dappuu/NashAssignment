import { useEffect, useState } from 'react';
import { Route, Routes, useLocation } from 'react-router-dom';
import Loader from './common/Loader';
import PageTitle from './components/PageTitle';
import Category from './pages/Category/Category';
import FormCategory from './pages/Form/FormCategory';
import 'react-toastify/dist/ReactToastify.css';
import CategoryDetail from './pages/Category/CategoryDetail';
import Product from './pages/Product/Product';
import ProductDetail from './pages/Product/ProductDetail';
import Size from './pages/Size/Size';
import FormSize from './pages/Form/FormSize';
import FormProductSku from './pages/Form/FormProductSku';
import FormProduct from './pages/Form/FormProduct';
import User from './pages/User/User';

function App() {
  const [loading, setLoading] = useState<boolean>(true);
  const { pathname } = useLocation();

  useEffect(() => {
    window.scrollTo(0, 0);
  }, [pathname]);

  useEffect(() => {
    setTimeout(() => setLoading(false), 1000);
  }, []);

  return loading ? (
    <Loader />
  ) : (
    <>
      <Routes>
        <Route
          path="/"
          element={
            <>
              <PageTitle title="Category" />
              <Category />
            </>
          }
        />
        <Route
          path="/category"
          element={
            <>
              <PageTitle title="Category" />
              <Category />
            </>
          }
        />
        <Route
          path="/category/:id"
          element={
            <>
              <PageTitle title="Category Detail" />
              <CategoryDetail />
            </>
          }
        />
        <Route
          path="/category/form"
          element={
            <>
              <PageTitle title="Form Category" />
              <FormCategory />
            </>
          }
        />
        <Route
          path="/product"
          element={
            <>
              <PageTitle title="Product" />
              <Product />
            </>
          }
        />
        <Route
          path="/product/:id"
          element={
            <>
              <PageTitle title="Product Detail" />
              <ProductDetail />
            </>
          }
        />
        <Route
          path="/product/form"
          element={
            <>
              <PageTitle title="Form Product" />
              <FormProduct />
            </>
          }
        />
        <Route
          path="/productSku/form"
          element={
            <>
              <PageTitle title="Form Product Sku" />
              <FormProductSku />
            </>
          }
        />
        <Route
          path="/size"
          element={
            <>
              <PageTitle title="Size" />
              <Size />
            </>
          }
        />
        <Route
          path="/size/form"
          element={
            <>
              <PageTitle title="Form Size" />
              <FormSize />
            </>
          }
        />
        <Route
          path="/user"
          element={
            <>
              <PageTitle title="User" />
              <User />
            </>
          }
        />
      </Routes>
    </>
  );
}

export default App;