using skroutz.gr;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSkroutz.gr
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Authentication auth = new Authentication(new Authentication.AppCredentials { client_id = "client_id", client_secret = "client_secret" });
                       
            Category cat = new Category(auth.ApplicationToken, sb);
            Product pro = new Product(auth.ApplicationToken, sb);
            User use = new User(auth.UserToken, sb);

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
