using skroutz.gr;
using System.Text;

namespace ConsoleSkroutz.gr
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Authentication auth = new Authentication(new Authentication.Credentials { client_id = "1", client_secret = "2" });

            //Categories
            Category cat = new Category(sb);
            dynamic result = cat.ListAllCategories();
            result = cat.RetrieveSingleCategory(1).Result;

            //Products
            Product pro = new Product(sb);
            result = pro.RetrieveSingleProduct(1);

        }
    }
}
