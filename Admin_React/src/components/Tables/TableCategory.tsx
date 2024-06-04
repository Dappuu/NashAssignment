import { Link } from 'react-router-dom';
import { CategoryDto } from '../../models/ModelCategory';
import { deleteCategory } from '../../api';
import Swal from 'sweetalert2';

interface Props {
  categoriesDto: CategoryDto[] | null;
  onClickDelete: () => void;
}

const TableCategory = ({ categoriesDto, onClickDelete }: Props) => {
  const handleClickDelete = async (id: number): Promise<void> => {
    Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!"
    }).then(async (result) => {
      if (result.isConfirmed) {
        await deleteCategory(id);
      }
      onClickDelete();
    });
  }

  return (
    <div className="rounded-sm px-5 py-5 pb-4 shadow-default dark:border-strokedark dark:bg-boxdark">
      <div className="max-w-full overflow-x-auto text-center">
        <table className="w-full table-auto">
          <thead>
            <tr className="bg-gray-2 dark:bg-meta-4 text-center">
              <th className="min-w-[80px] py-4 font-medium text-black dark:text-white xl:pl-11">
                Id
              </th>
              <th className="min-w-[150px] py-4 font-medium text-black dark:text-white">
                Name
              </th>
              <th className="min-w-[200px] py-4 font-medium text-black dark:text-white">
                Description
              </th>
              <th className="py-4 font-medium text-black dark:text-white">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
            {categoriesDto!.map((categoryDto, index) => (
              <tr key={index}>
                <td className="border-b border-[#eee] py-5 pl-9 dark:border-strokedark xl:pl-11">
                  <h5 className="font-medium text-black dark:text-white">
                    {categoryDto.id}
                  </h5>
                </td>
                <td className="border-b border-[#eee] py-5 dark:border-strokedark">
                  <p className="text-black dark:text-white">
                    {categoryDto.name}
                  </p>
                </td>
                <td className="border-b border-[#eee] py-5 dark:border-strokedark">
                  <p className="text-black dark:text-white">
                    {categoryDto.description}
                  </p>
                </td>
                <td className="border-b border-[#eee] py-5 dark:border-strokedark">
                  <div className="flex justify-center space-x-3.5">
                    <Link to={`/category/${categoryDto.id}`} className='block'>
                      <button className="hover:text-primary">
                        <svg
                          className="w-6 h-6 text-gray-800 dark:text-white"
                          aria-hidden="true"
                          xmlns="http://www.w3.org/2000/svg"
                          width="18"
                          height="18"
                          fill="none"
                          viewBox="0 -4 24 24"
                        >
                          <path
                            stroke="currentColor"
                            strokeWidth="1"
                            d="M21 12c0 1.2-4.03 6-9 6s-9-4.8-9-6c0-1.2 4.03-6 9-6s9 4.8 9 6Z"
                          />
                          <path
                            stroke="currentColor"
                            strokeWidth="1"
                            d="M15 12a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z"
                          />
                        </svg>
                      </button>
                    </Link>
                    <Link className='block'
                      to={categoryDto.parentId !== null ? `/category/form?parentId=${categoryDto.parentId}` : '/category/form'}
                      state={categoryDto}>
                      <button className="hover:text-primary">
                        <svg
                          className="w-6 h-6 text-gray-800 dark:text-white"
                          aria-hidden="true"
                          xmlns="http://www.w3.org/2000/svg"
                          width="18"
                          height="18"
                          fill="none"
                          viewBox="0 -3 24 24"
                        >
                          <path
                            stroke="currentColor"
                            strokeLinecap="round"
                            strokeLinejoin="round"
                            strokeWidth="1"
                            d="m14.304 4.844 2.852 2.852M7 7H4a1 1 0 0 0-1 1v10a1 1 0 0 0 1 1h11a1 1 0 0 0 1-1v-4.5m2.409-9.91a2.017 2.017 0 0 1 0 2.853l-6.844 6.844L8 14l.713-3.565 6.844-6.844a2.015 2.015 0 0 1 2.852 0Z"
                          />
                        </svg>
                      </button>
                    </Link>
                    <button onClick={() => handleClickDelete(categoryDto.id)} className="hover:text-primary">
                      <svg
                        className="w-6 h-6 text-gray-800 dark:text-white"
                        aria-hidden="true"
                        xmlns="http://www.w3.org/2000/svg"
                        width="18"
                        height="18"
                        fill="none"
                        viewBox="0 1 24 24"
                      >
                        <path
                          stroke="currentColor"
                          strokeLinecap="round"
                          strokeLinejoin="round"
                          strokeWidth="1"
                          d="M5 7h14m-9 3v8m4-8v8M10 3h4a1 1 0 0 1 1 1v3H9V4a1 1 0 0 1 1-1ZM6 7h12v13a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1V7Z"
                        />
                      </svg>
                    </button>
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default TableCategory;
