using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SIGMA_8_2
{
    class Storage
    {
        public List<Product> products { get; set; }
        public Storage(int size)
        {
            products = new List<Product>();
        }

        public Storage() { products = new List<Product>(); }

        public Product this[int index]
        {
            get { return products[index]; }
            set { products.Add(value); }
        }

        public void ChangePriceForAll(double percent)
        {
            double percentage = percent / 100;

            for (int i = 0; i < products.Count; i++)
            {
                products[i].Price = products[i].Price + (products[i].Price * percentage);
            }
        }

        public void PrintInfo()
        {
            try
            {
                if (products == null)
                {
                    throw new Exception("There is no products");
                }

                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} No products", e);
            }

        }

        public void FindAllMeat()
        {
            List<Product> meatProducts;
            int i = 0;
            foreach (Product product in products)
            {
                if (product.GetType() == typeof(Meat))
                {
                    i++;
                }
            }

            meatProducts = new List<Product>(i);

            foreach (Product product in products)
            {
                for (int j = 0; j < i;)
                {
                    if (product.GetType() == typeof(Meat))
                    {
                        meatProducts[j++] = product;
                    }
                }
            }
        }


        public void EnterInfo()
        {
            try
            {
                Console.Write("How many products do you want to add?: ");
                int size = Int32.Parse(Console.ReadLine());

                products = new List<Product>(size);

                for (int j = 0; j < products.Count; j++)
                {
                    Console.Write("Enter the type of product <1> - meat; <2> - dairy: ");
                    int result = Int32.Parse(Console.ReadLine());
                    if (result == 1)
                    {
                        try
                        {
                            Console.Write("The category <1> - HighGrade; <2> - FirstGrade; <3> - SecondGrade: ");
                            int categoryResult = Int32.Parse(Console.ReadLine());
                            CategoryOfMeat COM = CategoryOfMeat.HighGrade;
                            SortOfMeat SOM = SortOfMeat.chicken;

                            switch (categoryResult)
                            {
                                case 1:
                                    COM = CategoryOfMeat.HighGrade;
                                    break;
                                case 2:
                                    COM = CategoryOfMeat.FirstGrade;
                                    break;
                                case 3:
                                    COM = CategoryOfMeat.SecondGrade;
                                    break;
                                default:
                                    break;
                            }

                            Console.Write("The sort of meat <1> - mutton; <2> - veal; <3> - pork; <4> - chicken: ");
                            int sortResult = Int32.Parse(Console.ReadLine());


                            switch (sortResult)
                            {

                                case 1:
                                    SOM = SortOfMeat.mutton;
                                    break;
                                case 2:
                                    SOM = SortOfMeat.veal;
                                    break;
                                case 3:
                                    SOM = SortOfMeat.pork;
                                    break;
                                case 4:
                                    SOM = SortOfMeat.chicken;
                                    break;
                                default:
                                    break;
                            }

                            Console.Write("Enter the name of product: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter the price of product: ");
                            double price = Double.Parse(Console.ReadLine());

                            Console.Write("Enter the weight of product: ");
                            double weight = Double.Parse(Console.ReadLine());

                            Console.Write("Enter the expiration date of product: ");
                            int expDate = Int32.Parse(Console.ReadLine());

                            Console.Write("Enter the date of product in format [dd.mm.yyyy]: ");
                            string date = Console.ReadLine();

                            products[j] = new Meat(COM, SOM, name, price, weight, expDate, date);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    if (result == 2)
                    {
                        try
                        {
                            Console.Write("Enter the name of product: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter the price of product: ");
                            double price = Double.Parse(Console.ReadLine());

                            Console.Write("Enter the weight of product: ");
                            double weight = Double.Parse(Console.ReadLine());

                            Console.Write("Enter the expiration date of product: ");
                            int expDate = Int32.Parse(Console.ReadLine());

                            Console.Write("Enter the date of product in format [dd.mm.yyyy]: ");
                            string date = Console.ReadLine();

                            products[j] = new Dairy(name, price, weight, expDate, date);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e + "Bad Input");
            }

        }


        public void RemoveExpired()
        {
            try
            {
                int size = 0;
                if (products == null)
                {
                    throw new Exception("There is no products");
                }
                for (int i = 0; i < products.Count; i++)
                {
                    try
                    {

                        if (products[i].GetType() == typeof(Dairy))
                        {
                            var arr = products[i].Date.Split('.');
                            int days = Int32.Parse(arr[0]);
                            int months = Int32.Parse(arr[1]);
                            int years = Int32.Parse(arr[2]);
                            DateTime dateNow = new DateTime(years, months, days);

                            if (dateNow.AddDays(products[i].ExpirationDate) > dateNow)
                            {
                                size++;
                            }
                        }
                        else
                        {
                            throw new Exception("There is no dairy products");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                List<Product> expiredProducts = new List<Product>(size);

                for (int i = 0; i < products.Count; i++)
                {

                    if (products[i].GetType() == typeof(Dairy))
                    {
                        var arr = products[i].Date.Split('.');
                        int days = Int32.Parse(arr[0]);
                        int months = Int32.Parse(arr[1]);
                        int years = Int32.Parse(arr[2]);
                        DateTime dateNow = new DateTime(years, months, days);

                        if (dateNow.AddDays(products[i].ExpirationDate) > dateNow)
                        {
                            for (int j = 0; j < expiredProducts.Count; j++)
                            {
                                expiredProducts[j] = products[i];
                            }
                        }
                    }
                }

                Console.WriteLine("Please, enter the name of file: ");
                string path = Console.ReadLine();

                StreamWriter sw = new StreamWriter(path);

                for (int i = 0; i < size; i++)
                {
                    sw.WriteLine(expiredProducts[i]);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public void ReadFromFile()
        {

            try
            {
                Console.WriteLine("Please, enter the name of file: ");
                string path = Console.ReadLine();
                StreamReader sr = new StreamReader(path);

                String filecontent;
                filecontent = sr.ReadToEnd();
                sr.Close();

                string[] allFile = File.ReadAllLines(path);

                if (allFile.Length == 0)
                {
                    throw new Exception("Empty file");
                }

                string name;
                double price;
                double weight;
                string date;
                int expDate;


                var items = filecontent.Replace("\r\n\r\n", " ").Replace("\r\n", " ").Split(' ');

                int size = Int32.Parse(items[0]);

                products = new List<Product>(size);

                for (int i = 1, k = 0; i < 5 * products.Count; i += 5, k++)
                {
                    name = items[i];
                    Double.TryParse(items[i + 1], out price);
                    Double.TryParse(items[i + 2], out weight);
                    date = items[i + 3];
                    Int32.TryParse(items[i + 4], out expDate);

                    Product product = new Product(name, price, weight, expDate, date);
                    products[k] = product;
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }




        }



    }
}

