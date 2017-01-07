using skroutz.gr;
using System.Text;

namespace ConsoleSkroutz.gr
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Authentication auth = new Authentication(new Authentication.AppCredentials { client_id = "1", client_secret = "2" });

            //Categories
            Category cat = new Category(auth.ApplicationToken, sb);
            dynamic result = cat.ListAllCategories();
            result = cat.RetrieveSingleCategory(1).Result;

            //Products
            Product pro = new Product(auth.ApplicationToken, sb);
            result = pro.RetrieveSingleProduct(1);

        }
    }
}
