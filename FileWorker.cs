using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SIGMA_8_2
{
    class FileWorker
    {
        public string Text { get; set; }

        public FileWorker(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            
            Text = reader.ReadToEnd();
        }
        public Storage GetProducts()
        {
            string[] products = Text.Replace("\r\n", "\n").Split('\n');

            Storage storage = new Storage();

            for (int i = 0; i < products.Length; i++)
            {
                Product product = new Product();

                product.Parse(products[i]);
                
                storage[i] = product;
            }

            return storage;
        }
        }
}
