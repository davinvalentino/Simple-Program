using Project_AMDP3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_AMDP3.Repository;

namespace Project_AMDP3
{
    class Program
    {
        private ProductRepository productRepository;

        public Program()
        {
            productRepository = new ProductRepository();
            int menu = 0;
            int menu1 = 0;
            int menu2 = 0;
            do
            {
                Console.WriteLine("Supermarket System");
                Console.WriteLine("==================");
                Console.WriteLine("1. Login as User");
                Console.WriteLine("2. Login as Admin");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");
                menu = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                switch (menu)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("1. View Product");
                            Console.WriteLine("2. Buy Product");
                            Console.WriteLine("3. Exit");
                            Console.Write("Choice: ");
                            menu1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("");

                            switch (menu1)
                            {
                                case 1:
                                    View();
                                    break;
                                case 2:
                                    Console.WriteLine("Sorry! Under development :(");
                                    Console.WriteLine("");
                                    break;
                            }

                        } while (menu1 != 3);
                        break;

                    case 2:
                        do
                        {
                            Console.WriteLine("1. Insert Product");
                            Console.WriteLine("2. Update Product");
                            Console.WriteLine("3. Delete Product");
                            Console.WriteLine("4. View Product");
                            Console.WriteLine("5. View Transaction");
                            Console.WriteLine("6. Exit");
                            Console.Write("Choice: ");
                            menu2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("");

                            switch (menu2)
                            {
                                case 1:
                                    Insert();
                                    break;
                                case 2:
                                    Update();
                                    break;
                                case 3:
                                    Delete();
                                    break;
                                case 4:
                                    View();
                                    break;
                                case 5:
                                    Console.WriteLine("Sorry! Under development :(");
                                    Console.WriteLine("");
                                    break;
                            }

                        } while (menu2 != 6);
                        break;

                    case 3:
                        Console.WriteLine("Thank You For Using This Application.");
                        break;
                }

            } while (menu != 3);
            Console.Read();
        }

        private void View()
        {
            List<Product> productList = productRepository.GetAll();

            Console.WriteLine("View Product");
            Console.WriteLine("============");

            if (productList.Count == 0)
            {
                Console.WriteLine("No product available!");
                Console.WriteLine("");
            }
            else
            {
                int i = 1;
                foreach(Product product in productList)
                {
                    Console.WriteLine("Product ID         : {0}", i++);
                    Console.WriteLine("Product Name       : " + product.name);
                    Console.WriteLine("Product Quantity   : " + product.quantity);
                    Console.WriteLine("Product Price      : " + product.price);
                    Console.WriteLine("");
                }
            }
        }

        private void Insert()
        {
            string name = "";
            int quantity = 0;
            int price = 0;


            Console.WriteLine("Insert Product");
            Console.WriteLine("============");

            do
            {
                Console.Write("Input Product Name [Length between 5-20]: ");
                name = Console.ReadLine();
            } while (name.Length < 5 || name.Length > 20);

            do
            {
                Console.Write("Input Product Price [1000-1000000]: ");
                price = int.Parse(Console.ReadLine());
            } while (price < 1000 || price > 1000000);

            do
            {
                Console.Write("Input Product Quantity [1-1000]: ");
                quantity = int.Parse(Console.ReadLine());
            } while (quantity < 1 || quantity > 1000);

            Product product = new Product();
            product.name = name;
            product.price = price;
            product.quantity = quantity;

            productRepository.Insert(product);

            Console.WriteLine("The product has been successfully inserted!");
            Console.Write("Press enter to continue...");
            Console.ReadLine();
            Console.WriteLine("");
        }


        private void Delete()
        {
            List<Product> productList = productRepository.GetAll();

            int ID = 0;

            Console.WriteLine("Delete Product");
            Console.WriteLine("============");
            do
            {
                Console.Write("Input Product ID [1-10]: ");
                ID = int.Parse(Console.ReadLine());
            } while (ID < 1 || ID > 10);

            Product product = new Product();
            product.ID = ID;




            Console.Write("Are you sure you want to delete this product? [Yes | No]: ");
            string choice = "";
            do
            {
                choice = Console.ReadLine();
            } while (choice != "Yes" && choice != "No");

            if (choice.Equals("Yes"))
            {
                productRepository.Delete(product);
                Console.WriteLine("The product has been successfully deleted!");
            }else if (choice.Equals("No"))
            {
                Console.WriteLine("Deletion has been canceled.");
            }
            Console.Write("Press enter to continue...");
            Console.ReadLine();
            Console.WriteLine("");
        }

        private void Update()
        {
            string name = "";
            int quantity = 0;
            int price = 0;
            int ID = 0;

            Console.WriteLine("Update Product");
            Console.WriteLine("============");

            do
            {
                Console.Write("Input Product ID [1-10]: ");
                ID = int.Parse(Console.ReadLine());
            } while (ID < 1 || ID > 10);

            do
            {
                Console.Write("Input Product Name [Length between 5-20]: ");
                name = Console.ReadLine();
            } while (name.Length < 5 || name.Length > 20);

            do
            {
                Console.Write("Input Product Price [1000-1000000]: ");
                price = int.Parse(Console.ReadLine());
            } while (price < 1000 || ID > 1000000);

            do
            {
                Console.Write("Input Product Quantity [1-1000]: ");
                quantity = int.Parse(Console.ReadLine());
            } while (quantity < 1 || quantity > 1000);

            Product product = new Product();
            product.ID = ID;
            product.name = name;
            product.price = price;
            product.quantity = quantity;

            productRepository.Update(product);
            Console.WriteLine("The product has been successfully updated!");
            Console.Write("Press enter to continue...");
            Console.ReadLine();
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}
