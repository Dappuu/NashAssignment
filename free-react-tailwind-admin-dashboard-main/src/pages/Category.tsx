import Breadcrumb from '../components/Breadcrumbs/Breadcrumb'
import DefaultLayout from '../layout/DefaultLayout'
import TableCategory from '../components/Tables/TableCategory'
import { getAllCategories } from '../api'

interface Props {}

const Category = (props: Props) => {
    const {data, error} = getAllCategories();
    
    if (error) return <div>Failed to load categories</div>;
    if (!data) return <div>Loading...</div>;

    return (
        <DefaultLayout>
            <Breadcrumb pageName="Category" />
            <div className="flex flex-col gap-10">
                <TableCategory categoriesDto={data} />
            </div>
        </DefaultLayout>
  )
}

export default Category