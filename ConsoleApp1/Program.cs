using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }


        static async Task RunAsync()
        {
            // Update port # in the following line.
            //client.BaseAddress = new Uri("http://fiddler2.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                string res = await client.GetStringAsync("http://fiddler2.com/content/GetArticles?clientId=608AB7854A43E6C1F5A3D823D62583B1613C21816488439366F09C8568CAD07A");
                //res.EnsureSuccessStatusCode();
                //string str = await res.Content.ReadAsStringAsync();
                Console.Write(res);
                // Create a new product
                //Product product = new Product
                //{
                //    Name = "Gizmo",
                //    Price = 100,
                //    Category = "Widgets"
                //};

                //var url = await CreateProductAsync(product);
                //Console.WriteLine($"Created at {url}");

                //// Get the product
                //product = await GetProductAsync(url.PathAndQuery);
                //ShowProduct(product);

                //// Update the product
                //Console.WriteLine("Updating price...");
                //product.Price = 80;
                //await UpdateProductAsync(product);

                //// Get the updated product
                //product = await GetProductAsync(url.PathAndQuery);
                //ShowProduct(product);

                //// Delete the product
                //var statusCode = await DeleteProductAsync(product.Id);
                //Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Console.ReadLine();
        }


    }
}
