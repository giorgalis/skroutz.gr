using skroutz.gr;
using skroutz.gr.Model.SKUs;
using System;
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
            sku.ListSKUsOfSpecificCategory(1, OrderBy.popularity,  OrderDir.asc, null, new int[] { 1, 2, 3 });

            try
            {
                skroutz.gr.Model.Categories.Categories result = cat.ListAllCategories().Result;
            }
            catch (Exception se)
            {

            }
        }
    }
}
