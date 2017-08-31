using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientForWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9000/");
            // Add an Accept header for JSON format.
            // 为JSON格式添加一个Accept报头
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List all products.
            // 列出所有产品
            HttpResponseMessage response = client.GetAsync("api/products").Result;  // Blocking call（阻塞调用）! 
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                // 解析响应体。阻塞！
                var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                foreach (var p in products)
                {
                    Console.WriteLine("{0}\t{1};\t{2}", p.Name, p.Price, p.Category);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Create a new product
            // 创建一个新产品
            var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
            Uri gizmoUri = null;

            response = client.PostAsJsonAsync("api/products", gizmo).Result;
            if (response.IsSuccessStatusCode)
            {
                gizmoUri = response.Headers.Location;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Update a product
            // 更新一个产品
            gizmo.Price = 99.9;
            response = client.PutAsJsonAsync(gizmoUri.PathAndQuery, gizmo).Result;
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            // Delete a product 
            // 删除一个产品
            response = client.DeleteAsync(gizmoUri).Result;
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}
