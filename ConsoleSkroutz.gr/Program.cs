using skroutz.gr;
using System;
using System.Collections.Generic;
using System.Text;
using static skroutz.gr.Constants;

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

            SKU sku = new SKU(auth.ApplicationToken, sb);
            sku.ListSKUsOfSpecificCategory(1, skroutz.gr.Entities.SKUs.OrderBy.popularity,  OrderDir.asc, null, new int[] { 1, 2, 3 });

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
