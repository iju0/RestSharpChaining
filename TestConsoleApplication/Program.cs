using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharpChaining;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiClient apiClient = new ApiClient("https://jsonplaceholder.typicode.com/posts");

            var posts = apiClient.Get<List<Posts>>();


            foreach(var post in posts)
            {
                Console.WriteLine(post.title);
            }

        }
    }

    class Posts
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

}
