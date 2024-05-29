import React from 'react';
import { categoryDto } from '../../models/ModelCategory';

interface SubCategoryProps {
  subCategory: categoryDto;
}

const SubCategory: React.FC<SubCategoryProps> = ({ subCategory }) => (
  <div className="flex justify-between pr-2">
    
    <div>
      <p className="text-black dark:text-white">
        {subCategory.name}
      </p>
    </div>
    <div className='space-x-3.5'>
      {/* Add the icons here */}
      <button className="hover:text-primary">
        <svg className="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="18" height="18" fill="none" viewBox="0 0 24 24"><path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="1" d="m14.304 4.844 2.852 2.852M7 7H4a1 1 0 0 0-1 1v10a1 1 0 0 0 1 1h11a1 1 0 0 0 1-1v-4.5m2.409-9.91a2.017 2.017 0 0 1 0 2.853l-6.844 6.844L8 14l.713-3.565 6.844-6.844a2.015 2.015 0 0 1 2.852 0Z"/></svg>
      </button>
      <button className="hover:text-primary">
        <svg className="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="18" height="18" fill="none" viewBox="0 0 24 24"><path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="1" d="M5 7h14m-9 3v8m4-8v8M10 3h4a1 1 0 0 1 1 1v3H9V4a1 1 0 0 1 1-1ZM6 7h12v13a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1V7Z"/></svg>
      </button>
    </div>
  </div>
);

interface SubCategoryTableProps {
  subCategories: categoryDto[];
}

const SubCategoryTable: React.FC<SubCategoryTableProps> = ({ subCategories }) => (
  <>
    {subCategories.map((subCategory) => (
      <div key={subCategory.id} className="py-5 dark:border-strokedark">
        <SubCategory subCategory={subCategory} />
      </div>
    ))}
  </>
);

export default SubCategoryTable;
