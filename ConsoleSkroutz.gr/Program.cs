using skroutz.gr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSkroutz.gr
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Authentication auth = new Authentication(new Authentication.AppCredentials { client_id = "1", client_secret = "2" });

            Category cat = new Category(auth.ApplicationToken, sb);
            Product pro = new Product(auth.ApplicationToken, sb);

            try
            {
                IEnumerable<skroutz.gr.Entities.Categories.Category> result = cat.ListAllCategories().Result;
            }
            catch (Exception se)
            {

            }
        }
    }
}
