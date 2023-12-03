using System;

namespace PaginationHelperExample
{
    public class PaginationHelper<T>
    {
        private T[] data;
        private int itemsPerPage;

        public PaginationHelper(T[] data, int itemsPerPage)
        {
            this.data = data;
            this.itemsPerPage = itemsPerPage;
        }

        public int ItemCount()
        {
            return data.Length;
        }

        public int PageCount()
        {
            return (int)Math.Ceiling((double)data.Length / itemsPerPage);
        }

        public int PageItemCount(int pageIndex)
        {
            if (pageIndex < 0 || pageIndex >= PageCount())
                return -1;

            if (pageIndex == PageCount() - 1)
                return data.Length % itemsPerPage;
            else
                return itemsPerPage;
        }

        public int PageIndex(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex >= data.Length)
                return -1;

            return itemIndex / itemsPerPage;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int itemsPerPage = 3;

            PaginationHelper<int> paginationHelper = new PaginationHelper<int>(data, itemsPerPage);

            Console.WriteLine("Item count: " + paginationHelper.ItemCount());
            Console.WriteLine("Page count: " + paginationHelper.PageCount());
            Console.WriteLine("Items per page (page 1): " + paginationHelper.PageItemCount(0));
            Console.WriteLine("Items per page (page 2): " + paginationHelper.PageItemCount(1));
            Console.WriteLine("Items per page (page 3): " + paginationHelper.PageItemCount(2));
            Console.WriteLine("Page index (item 4): " + paginationHelper.PageIndex(3));
            Console.WriteLine("Page index (item 7): " + paginationHelper.PageIndex(6));
            //В этом примере класс PaginationHelper инкапсулирует логику работы с пагинацией.
            //Методы ItemCount(), PageCount(), PageItemCount(int pageIndex) и PageIndex(int itemIndex) позволяют получить необходимую информацию о пагинации.
            //В основной программе, класс PaginationHelper используется для работы с массивом данных data и определения параметров пагинации.
        }
    }
}