using Newtonsoft.Json;
using skroutz.gr.Authorization;
using skroutz.gr.ServiceBroker;
using skroutz.gr.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleSkroutz.gr
{
    public class Token
    {

        public string access_token { get; set; }

  
        public string token_type { get; set; }

   
        public int expires_in { get; set; }

        public string refresh_token { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Authorization auth = new Authorization(new AppCredentials {  ClientId = "",  ClientSecret = "" });
            Authorization auth = new Authorization(new AppCredentials { ClientId = "",  ClientSecret = "" });
            StringBuilder sb = new StringBuilder();

            Console.OutputEncoding = Encoding.Unicode;

            string baseAddress = "http://dotnet.media/";

            // Start OWIN host     
            //using (Microsoft.Owin.Hosting.WebApp.Start<WebApp.Startup>(url: baseAddress))
            //{
                var client = new HttpClient() { BaseAddress = new Uri( baseAddress) };
                var response = client.GetAsync(baseAddress + "test").Result;
                Console.WriteLine(response);

                Console.WriteLine();

                var authorizationHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes("xyz:secretKey"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeader);

                var form = new Dictionary<string, string>
               {
                   {"grant_type", "password"},
                   {"username", "xyz"},
                   {"password", "xyz@123"},
               };

                var tokenResponse = client.PostAsync(baseAddress + "accesstoken", new FormUrlEncodedContent(form)).Result;
                //var token = JsonConvert.DeserializeObject<Token>(tokenResponse.Content.ToString());
                var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;

            auth.skroutzRequest.AccessToken = token.access_token;

                Console.WriteLine("Token issued is: {0}", token.access_token);

                Console.WriteLine();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
                var authorizedResponse = client.GetAsync(baseAddress + "test").Result;
                Console.WriteLine(authorizedResponse);
                Console.WriteLine(authorizedResponse.Content.ReadAsStringAsync().Result);
            //}

            //Console.ReadLine();
            try
            {
                dynamic result = null;

                //ApplyTitle("User");
                User user = new User(auth.skroutzRequest, sb);
                result = user.ListFavorites().Result;

                ApplyTitle("Category");
                Category category = new Category(auth.skroutzRequest, sb);

                result = category.ListAllCategories().Result.categories.printReflected();

                result = category.RetrieveSingleCategory(1442, x=> x.Code, x => x.Id).Result.Category.printReflected();
                result = category.RetrieveTheParentOfCategory(1442).Result.Category.printReflected();
                result = category.RetrieveTheRootCategory().Result.Category.printReflected();
                result = category.ListChildrenCategoriesOfCategory(252).Result.categories.printReflected();
                result = category.ListCategorysSpecifications(40).Result.specifications.printReflected();
                result = category.ListCategorysSpecificationsGroup(40).Result.groups.printReflected();

                result = category.ListCategorysManufactures(25).Result.manufacturers.printReflected();
                result = category.ListCategorysManufactures(25, OrderByNamePop.name).Result.manufacturers.printReflected();
                result = category.ListCategorysManufactures(25, OrderByNamePop.popularity, OrderDir.asc).Result.manufacturers.printReflected();

                //User token is required or else exception is thrown
                result = category.ListCategorysFavorites(40).Result;

                ApplyTitle("SKU");
                Sku sku = new Sku(auth.skroutzRequest, sb);

                result = sku.ListSKUsOfSpecificCategory(40).Result.skus.printReflected();
                result = sku.ListSKUsOfSpecificCategory(40, OrderByPrcPopRating.popularity).Result.skus.printReflected();
                result = sku.ListSKUsOfSpecificCategory(40, OrderByPrcPopRating.rating, OrderDir.desc).Result.skus.printReflected();
                result = sku.ListSKUsOfSpecificCategory(40, searchKeyword: "iphone").Result.skus.printReflected();
                result = sku.ListSKUsOfSpecificCategory(40, manufacturerIds: new int[] { 28, 2 }).Result.skus.printReflected();
                result = sku.ListSKUsOfSpecificCategory(40, filterIds: new int[] { 355559, 6282 }).Result.skus.printReflected();

                result = sku.RetrieveSingleSKU(3690169).Result.printReflected();
                result = sku.RetrieveSimilarSKUs(3034682).Result.printReflected();
                result = sku.RetrieveSKUsProducts(3783654).Result.printReflected();
                result = sku.RetrieveSKUsReviews(3690169).Result.printReflected();

                ApplyTitle("Product");
                Product product = new Product(auth.skroutzRequest, sb);

                result = product.RetrieveSingleProduct(12176638, x=> x.Name, x => x.Price).Result.Product;
                result = product.SearchForProducts(670, "220004386").Result.products.printReflected();

                ApplyTitle("Shop");
                Shop shop = new Shop(auth.skroutzRequest, sb);

                result = shop.RetrieveSingleShop(452).Result;
                result = shop.RetrieveShopReview(452).Result.Reviews.printReflected();
                result = shop.ListShopLocations(452).Result.Locations.printReflected();
                result = shop.RetrieveSingleShopLocation(452, 2500).Result;

                ApplyTitle("Manufacturer");
                Manufacturer manufacturer = new Manufacturer(auth.skroutzRequest, sb);

                result = manufacturer.ListManufacturers().Result.manufacturers.printReflected();
                result = manufacturer.RetrieveSingleManufacturer(12907).Result.manufacturer.printReflected();

                result = manufacturer.RetrieveManufacturerCategories(356, page: 1, per: 10).Result.categories;
                result = manufacturer.RetrieveManufacturerCategories(356, OrderByNamePop.name).Result.categories.printReflected();
                result = manufacturer.RetrieveManufacturerCategories(356, OrderByNamePop.popularity, OrderDir.asc).Result.categories.printReflected();

                result = manufacturer.RetrieveManufacturerSKUs(356).Result.skus.printReflected();
                result = manufacturer.RetrieveManufacturerSKUs(356, OrderByPrcPop.price).Result.skus.printReflected();
                result = manufacturer.RetrieveManufacturerSKUs(356, OrderByPrcPop.popularity, OrderDir.asc).Result.skus.printReflected();

                ApplyTitle("Search");
                Search search = new Search(auth.skroutzRequest, sb);

                //Query with less than 2 characters
                result = search.SearchQuery("a").Result;

                //Query that doesn't match anything
                result = search.SearchQuery("asdf").Result.Categories.printReflected();

                //Query with more results when written in another language
                result = search.SearchQuery("%CE%B9%CF%80%CE%B7%CE%BF%CE%BD%CE%B5").Result.Categories.printReflected();

                //Probably misspelled query
                result = search.SearchQuery("ipone").Result.Categories.printReflected();

                //Query matching many categories
                result = search.SearchQuery("iphone").Result.Categories.printReflected();

                //Query with strong hints for a specific category match
                result = search.SearchQuery("Tablets").Result.Categories.printReflected();

                //Query with strong hints for a specific manufacturer match
                result = search.SearchQuery("apple").Result.Categories.printReflected();

                //Query with strong hints for a specific SKU match
                result = search.SearchQuery("nikon+1+j2").Result.Categories.printReflected();

                //Query that matches SKUS from a single category
                result = search.SearchQuery("samsung+galaxy+s5+16GB").Result.Categories.printReflected();

                //Query with results when parts of the query are omitted
                result = search.SearchQuery("wrong+iphone").Result.Categories.printReflected();

                ApplyTitle("Flag");
                Flag flag = new Flag(auth.skroutzRequest, sb);

                result = flag.RetrieveAllFlags().Result.flags.printReflected();

                ApplyTitle("Filter Groups");
                FilterGroup filterGroup = new FilterGroup(auth.skroutzRequest, sb);

                result = filterGroup.ListFilterGroups(40).Result.filter_groups.printReflected();

              

                Console.ReadLine();

            }
            catch (skroutz.gr.Exceptions.SkroutzException se)
            {

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
