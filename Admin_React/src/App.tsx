import { useEffect, useState } from 'react';
import { Route, Routes, useLocation } from 'react-router-dom';
import Loader from './common/Loader';
import PageTitle from './components/PageTitle';
import SignIn from './pages/Authentication/SignIn';
import SignUp from './pages/Authentication/SignUp';
import Calendar from './pages/Calendar';
import Chart from './pages/Chart';
import FormElements from './pages/Form/FormElements';
import FormLayout from './pages/Form/FormLayout';
import Profile from './pages/Profile';
import Settings from './pages/Settings';
import Tables from './pages/Tables';
import Alerts from './pages/UiElements/Alerts';
import Buttons from './pages/UiElements/Buttons';
import Category from './pages/Category/Category';
import FormCategory from './pages/Form/FormCategory';
import 'react-toastify/dist/ReactToastify.css';
import ECommerce from './pages/Dashboard/ECommerce';
import CategoryDetail from './pages/Category/CategoryDetail';
import Product from './pages/Product/Product';
import ProductDetail from './pages/Product/ProductDetail';
import Size from './pages/Size/Size';
import FormSize from './pages/Form/FormSize';
import FormProductSku from './pages/Form/FormProductSku';
import FormProduct from './pages/Form/FormProduct';
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
          index
          element={
            <>
              <PageTitle title="eCommerce Dashboard | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <ECommerce />
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
          path="/calendar"
          element={
            <>
              <PageTitle title="Calendar | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <Calendar />
            </>
          }
        />
        <Route
          path="/profile"
          element={
            <>
              <PageTitle title="Profile | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <Profile />
            </>
          }
        />
        <Route
          path="/forms/form-elements"
          element={
            <>
              <PageTitle title="Form Elements | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <FormElements />
            </>
          }
        />
        <Route
          path="/forms/form-layout"
          element={
            <>
              <PageTitle title="Form Layout | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <FormLayout />
            </>
          }
        />
        <Route
          path="/tables"
          element={
            <>
              <PageTitle title="Tables | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <Tables />
            </>
          }
        />
        <Route
          path="/settings"
          element={
            <>
              <PageTitle title="Settings | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <Settings />
            </>
          }
        />
        <Route
          path="/chart"
          element={
            <>
              <PageTitle title="Basic Chart | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <Chart />
            </>
          }
        />
        <Route
          path="/ui/alerts"
          element={
            <>
              <PageTitle title="Alerts | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <Alerts />
            </>
          }
        />
        <Route
          path="/ui/buttons"
          element={
            <>
              <PageTitle title="Buttons | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <Buttons />
            </>
          }
        />
        <Route
          path="/auth/signin"
          element={
            <>
              <PageTitle title="Signin | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <SignIn />
            </>
          }
        />
        <Route
          path="/auth/signup"
          element={
            <>
              <PageTitle title="Signup | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <SignUp />
            </>
          }
        />
        </Routes>
    </>
  );
}

export default App;
