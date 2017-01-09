using skroutz.gr;
using System;
using System.Text;
using static skroutz.gr.Constants;
using skroutz.gr.Models;

namespace ConsoleSkroutz.gr
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            
            string token = "";

            try
            {
                Category cat = new Category(token, sb);

                dynamic result = cat.ListAllCategories().Result;

                result = cat.RetrieveSingleCategory(1442).Result;

                result = cat.RetrieveTheParentOfCategory(1442).Result;

                result = cat.RetrieveTheRootCategory().Result;

                result = cat.ListChildrenCategoriesOfCategory(252).Result;

                result = cat.ListCategorysSpecifications(40).Result;

                result = cat.ListCategorysSpecificationsGroup(40).Result;

                result = cat.ListCategorysManufactures(25).Result;
                result = cat.ListCategorysManufactures(25, Manufacturers.OrderBy.name).Result;
                result = cat.ListCategorysManufactures(25, Manufacturers.OrderBy.popularity, OrderDir.asc).Result;
                
                //User token is required
                result = cat.ListCategorysFavorites(40).Result;
            }
            catch (Exception se)
            {

            }
        }
    }
}
