import { Link } from 'react-router-dom';
interface BreadcrumbProps {
  pageName: string;
  parentId: number | undefined;
  parentName: string | undefined;
}
const Breadcrumb = ({ pageName, parentId, parentName }: BreadcrumbProps) => {
  return (
    <div className="mb-6 flex flex-col gap-3 sm:flex-row sm:items-center sm:justify-between">
      {/* <h2 className="text-title-md2 font-semibold text-black dark:text-white">
        {pageName}
      </h2> */}

      <nav>
        <ol className="flex items-center gap-2">
          <li>
            <Link className="font-medium" to={`/${pageName.toLowerCase()}`}>
              {pageName}
            </Link>
          </li>
          {
            parentId ?
            <li className="font-medium text-primary">
              <Link className="font-medium" to={`/${pageName.toLowerCase()}/${parentId}`}>
                / {parentName}
              </Link>
            </li> : <></>
          }
        </ol>
      </nav>
    </div>
  );
};

export default Breadcrumb;
