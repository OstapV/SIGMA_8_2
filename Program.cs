using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGMA_8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWorker file1 = new FileWorker("C:\\Users\\lenovo\\source\\repos\\SIGMA_8_2\\SIGMA_8_2\\Storage1.txt");
            FileWorker file2 = new FileWorker("C:\\Users\\lenovo\\source\\repos\\SIGMA_8_2\\SIGMA_8_2\\Storage2.txt");

            Storage storage1 = file1.GetProducts();
            Storage storage2 = file2.GetProducts();


            var arr1 = FindProduct.Intersection(storage1.products, storage2.products);
            Console.WriteLine("П:\n");
            for (int i = 0; i < arr1.Count; i++)
            {
                Console.WriteLine(arr1[i]);
            }


            Console.WriteLine("FIRST/SECOND\n");
            var arr2 = FindProduct.DifferenceFirstStorage(storage1.products, storage2.products);
            for (int i = 0; i < arr2.Count; i++)
            {
                Console.WriteLine(arr2[i]);
            }


            Console.WriteLine("Symmetric difference:\n");
            var arr3 = FindProduct.Difference(storage1.products, storage2.products);
            for (int i = 0; i < arr3.Count; i++)
            {
                Console.WriteLine(arr3[i]);
            }

            Console.ReadLine();
        }
    }
}
