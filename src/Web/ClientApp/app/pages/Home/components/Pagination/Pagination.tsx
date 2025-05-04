import style from './Pagination.module.css';

type PaginationProps = {
    pageNumber: number
    hasPreviousPage: boolean
    hasNextPage: boolean
    totalCount: number
    totalPages: number
    onChangePage: (page: number) => void
}

export const PaginationComponent: React.FC<PaginationProps> = ({
    pageNumber = 1,
    hasPreviousPage,
    hasNextPage,
    totalPages,
    onChangePage,
}) => {
    const getVisiblePages = () => {
        const maxVisiblePages = 3;
        const startPage = Math.max(1, pageNumber - Math.floor(maxVisiblePages / 2));
        const endPage = Math.min(totalPages, startPage + maxVisiblePages - 1);

        const adjustedStartPage = Math.max(1, endPage - maxVisiblePages + 1);
        return Array.from({ length: endPage - adjustedStartPage + 1 }, (_, index) => adjustedStartPage + index);
    };

    const visiblePages = getVisiblePages();

    const handlePageChange = (page: number) => {
        if (page !== pageNumber) {
            onChangePage(page);
            window.scrollTo({ top: 0, behavior: 'smooth' });
        }
    };

    return (
        <form className={style.pagination} onSubmit={(e) => e.preventDefault()}>
            {hasPreviousPage && (
                <button
                    className={`${style.pagination_button} ${style.pagination_button_large} ${style.pagination_button_previous}`}
                    onClick={() => handlePageChange(1)}
                >
                    First page
                </button>
            )}

            {visiblePages.map((page) => (
                <button
                    key={page}
                    className={`${style.pagination_button} ${page === pageNumber ? style.pagination_button_selected : ''
                        }`}
                    onClick={() => handlePageChange(page)}
                >
                    {page}
                </button>
            ))}

            {hasNextPage && (
                <button
                    className={`${style.pagination_button} ${style.pagination_button_large} ${style.pagination_button_next}`}
                    onClick={() => handlePageChange(totalPages)}
                >
                    Last page
                </button>
            )}
        </form>
    );
};

