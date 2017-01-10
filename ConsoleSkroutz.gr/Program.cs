using skroutz.gr;
using System;
using System.Text;

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
                //CATEGORIES ##############################################################################
                Category cat = new Category(token, sb);

                dynamic result = cat.ListAllCategories().Result;
                result = cat.RetrieveSingleCategory(1442).Result;
                result = cat.RetrieveTheParentOfCategory(1442).Result;
                result = cat.RetrieveTheRootCategory().Result;
                result = cat.ListChildrenCategoriesOfCategory(252).Result;
                result = cat.ListCategorysSpecifications(40).Result;
                result = cat.ListCategorysSpecificationsGroup(40).Result;

                result = cat.ListCategorysManufactures(25).Result;
                result = cat.ListCategorysManufactures(25, OrderByNamePop.name).Result;
                result = cat.ListCategorysManufactures(25, OrderByNamePop.popularity, OrderDir.asc).Result;

                //User token is required or else exception is thrown
                result = cat.ListCategorysFavorites(40).Result;

                //PRODUCTS ################################################################################
                Product pro = new Product(token, sb);
                result = pro.RetrieveSingleProduct(12176638).Result;
                result = pro.SearchForProducts(670, "220004386").Result;

                //MANUFACTURERS ###########################################################################
                Manufacturer man = new Manufacturer(token, sb);
                result = man.ListManufacturers().Result;
                result = man.RetrieveSingleManufacturer(12907).Result;

                result = man.RetrieveManufacturerCategories(356).Result;
                result = man.RetrieveManufacturerCategories(356, OrderByNamePop.name).Result;
                result = man.RetrieveManufacturerCategories(356, OrderByNamePop.popularity, OrderDir.asc).Result;

                result = man.RetrieveManufacturerSKUs(356).Result;
                result = man.RetrieveManufacturerSKUs(356, OrderByPrcPop.price).Result;
                result = man.RetrieveManufacturerSKUs(356, OrderByPrcPop.popularity, OrderDir.asc).Result;

                //FLAGS ###################################################################################
                Flag fl = new Flag(token, sb);
                result = fl.RetrieveAllFlags().Result;

                //FILTER GROUPS ###########################################################################
                FilterGroup filGroup = new FilterGroup(token, sb);
                result = filGroup.ListFilterGroups(40).Result;

            }
            catch (Exception se)
            {

            }
        }
    }
}
