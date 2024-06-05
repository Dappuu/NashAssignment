import DefaultLayout from '../../layout/DefaultLayout';
import { getAllSizes, getAllUsers } from '../../api';
import { Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
import TableUser from '../../components/Tables/TableUser';
import { UserDto } from '../../models/ModelUser';


const Product = () => {
  const [users, setUsers] = useState<UserDto[]>([]);
  const fetchUsers = async () => {
    try {
      const data = await getAllUsers();
      setUsers(data);
    } catch (error) {
      console.error('Error fetching size:', error);
    }
    // console.log(users);
  };
  useEffect(() => {
    if (users.length === 0) {
      fetchUsers();
    }
  }, [users]);
  const onClickDelete = () => fetchUsers();


  return (
    <DefaultLayout>
      <div className="flex flex-col bg-white px-4 rounded-xl pb-6">
        <div className="flex justify-between pt-6 px-4 md:px-6 xl:px-7.5 items-center">
          <h2 className="text-title-md2 font-semibold text-black dark:text-white">
            User
          </h2>
          {/* <Link to={'form'}>
            <button className="bg-black text-white py-2 px-4 rounded hover:opacity-75">
              Create New Size    
            </button>
          </Link> */}
        </div>
        <TableUser usersDto={users} onclickDelete={onClickDelete} />
      </div>
    </DefaultLayout>
  );
};

export default Product;
