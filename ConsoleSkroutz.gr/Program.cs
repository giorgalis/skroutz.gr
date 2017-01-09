using skroutz.gr;
using skroutz.gr.Model.SKUs;
using System;
using System.Text;
using static skroutz.gr.Constants;
using skroutz.gr.Model.Categories;

namespace ConsoleSkroutz.gr
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            //Authentication auth = new Authentication(new Authentication.AppCredentials { client_id = "ImSv9s5ycQlvJcU5JhckJA==", client_secret = "mi1etJfdWw2TR5-Erm1KhE31AnxOfx7ZXTlyOul-zvijWQNusGIwROVUfFuNXJI9GCNf9Fz_MK8agdir0bh2Fg==" });

            string token = "";

           
            Product pro = new Product(token, sb);
            User use = new User(token, sb);

            SKU sku = new SKU(token, sb);
            sku.ListSKUsOfSpecificCategory(1, OrderBy.popularity,  OrderDir.asc, null, new int[] { 1, 2, 3 });

            try
            {
                skroutz.gr.Category cat = new skroutz.gr.Category(token, sb);
                Categories result1 = cat.ListAllCategories().Result;
                CategoryRoot result2 = cat.RetrieveSingleCategory(1442).Result;
                CategoryRoot result3 = cat.RetrieveTheParentOfCategory(1442).Result;
                CategoryRoot result4 = cat.RetrieveTheRootCategory().Result;
                Categories result5 = cat.ListChildrenCategoriesOfCategory(252).Result;
                Specifications result6 = cat.ListCategorysSpecifications(40).Result;
                Groups result7 = cat.ListCategorysSpecificationsGroup(40).Result;
                skroutz.gr.Model.Manufacturers.Manufacturers result8 = cat.ListCategorysManufactures(25, skroutz.gr.Model.Manufacturers.OrderBy.popularity, OrderDir.asc).Result;
                
                //User token is required
                skroutz.gr.Model.User.Favorites result9 = cat.ListCategorysFavorites(40).Result;


            }
            catch (Exception se)
            {

            }
        }
    }
}
