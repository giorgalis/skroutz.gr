using ConsoleSkroutz.gr;
using skroutz.gr;
using skroutz.gr.Authorization;
using skroutz.gr.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSkroutz.gr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
          
            Authorization auth = new Authorization(new AppCredentials { client_id = "", client_secret = "" });
            StringBuilder sb = new StringBuilder();

            try
            {
                ApplyTitle("CATEGORIES");
                Category cat = new Category(auth.ApplicationToken, sb);

                dynamic result = cat.ListAllCategories().Result.categories.printReflected();
                result = cat.RetrieveSingleCategory(1442).Result.category.printReflected();
                result = cat.RetrieveTheParentOfCategory(1442).Result.category.printReflected();
                result = cat.RetrieveTheRootCategory().Result.category.printReflected();
                result = cat.ListChildrenCategoriesOfCategory(252).Result.categories.printReflected();
                result = cat.ListCategorysSpecifications(40).Result.specifications.printReflected();
                result = cat.ListCategorysSpecificationsGroup(40).Result.groups.printReflected();

                result = cat.ListCategorysManufactures(25).Result.manufacturers.printReflected();
                result = cat.ListCategorysManufactures(25, OrderByNamePop.name).Result.manufacturers.printReflected();
                result = cat.ListCategorysManufactures(25, OrderByNamePop.popularity, OrderDir.asc).Result.manufacturers.printReflected();

                //User token is required or else exception is thrown
                //result = cat.ListCategorysFavorites(40).Result;

                ApplyTitle("PRODUCTS");
                Product pro = new Product(auth.ApplicationToken, sb);

                result = pro.RetrieveSingleProduct(12176638).Result.product;
                result = pro.SearchForProducts(670, "220004386").Result.products.printReflected();

                ApplyTitle("MANUFACTURERS");
                Manufacturer man = new Manufacturer(auth.ApplicationToken, sb);

                result = man.ListManufacturers().Result.manufacturers.printReflected();
                result = man.RetrieveSingleManufacturer(12907).Result.manufacturer.printReflected();

                result = man.RetrieveManufacturerCategories(356).Result.categories;
                result = man.RetrieveManufacturerCategories(356, OrderByNamePop.name).Result.categories.printReflected();
                result = man.RetrieveManufacturerCategories(356, OrderByNamePop.popularity, OrderDir.asc).Result.categories.printReflected();

                result = man.RetrieveManufacturerSKUs(356).Result.skus.printReflected();
                result = man.RetrieveManufacturerSKUs(356, OrderByPrcPop.price).Result.skus.printReflected();
                result = man.RetrieveManufacturerSKUs(356, OrderByPrcPop.popularity, OrderDir.asc).Result.skus.printReflected();

                ApplyTitle("FLAG");
                Flag fl = new Flag(auth.ApplicationToken, sb);

                result = fl.RetrieveAllFlags().Result.flags.printReflected();

                ApplyTitle("FILTER GROUPS");
                FilterGroup filGroup = new FilterGroup(auth.ApplicationToken, sb);

                result = filGroup.ListFilterGroups(40).Result.filter_groups.printReflected();

                ApplyTitle("SKUs");
                Sku sku = new Sku(auth.ApplicationToken, sb);

                result = sku.ListSKUsOfSpecificCategory(40).Result.skus.printReflected();

                ApplyTitle("SKUs - Ordering");
                result = sku.ListSKUsOfSpecificCategory(40, OrderByPrcPopRating.popularity).Result.skus.printReflected();
                result = sku.ListSKUsOfSpecificCategory(40, OrderByPrcPopRating.rating, OrderDir.desc).Result.skus.printReflected();

                ApplyTitle("SKUs - Filtering by search keyword");
                result = sku.ListSKUsOfSpecificCategory(40, searchKeyword: "iphone").Result.skus.printReflected();

                ApplyTitle("SKUs - Filtering by manufacturers");
                result = sku.ListSKUsOfSpecificCategory(40, manufacturerIds: new int[] { 28, 2 }).Result.skus.printReflected();

                ApplyTitle("SKUs - Filtering by filters");
                result = sku.ListSKUsOfSpecificCategory(40, filterIds: new int[] { 355559, 6282 }).Result.skus.printReflected();

                result = sku.RetrieveSingleSKU(3690169).Result.printReflected();
                result = sku.RetrieveSimilarSKUs(3034682).Result.printReflected();
                result = sku.RetrieveSKUsProducts(3783654).Result.printReflected();
                result = sku.RetrieveSKUsReviews(3690169).Result.printReflected();

                Console.ReadLine();

            }
            catch (Exception se)
            {

            }
        }

        private static void ApplyTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"# # # {title} # # #");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
