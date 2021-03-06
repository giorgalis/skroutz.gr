﻿using skroutz.gr.Authorization;
using skroutz.gr.Exceptions;
using skroutz.gr.ServiceBroker;
using skroutz.gr.Shared;
using System;
using System.Text;

namespace ConsoleSkroutz.gr
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Unicode;

            try
            {
                SkroutzRequest skroutzRequest = new SkroutzRequest(new Credentials { ClientId = "", ClientSecret = "" });

                dynamic result = null;
                
                #region CATEGORY

                Category category = new Category(skroutzRequest);

                //List All Categories.
                result = category.ListAllCategories().Result.categories.printReflected();

                //Retrieve only fields Id and Code, of Category with Id: 1442. 
                result = category.RetrieveSingleCategory(1442, x => x.Code, x => x.Id).Result.Category.printReflected();

                //Retrieve the Parent Category, of Category with Id: 1442. 
                result = category.RetrieveTheParentOfCategory(1442).Result.Category.printReflected();

                //Retrieve the Root Category.
                result = category.RetrieveTheRootCategory().Result.Category.printReflected();

                //List children Categories, of Category with Id: 252. 
                result = category.ListChildrenCategoriesOfCategory(252).Result.categories.printReflected();

                //List Category specifications, of Category with Id: 40. 
                result = category.ListCategorysSpecifications(40).Result.specifications.printReflected();

                //List Category specifications, of Category with Id: 40 and include Group information.
                result = category.ListCategorysSpecificationsGroup(40).Result.groups.printReflected();

                //List Category's Manufacturers, of Category with Id: 25.
                result = category.ListCategorysManufactures(25).Result.manufacturers.printReflected();

                //List Category's Manufacturers, of Category with Id: 25 and order results by Name.
                result = category.ListCategorysManufactures(25, OrderByNamePop.name).Result.manufacturers.printReflected();

                //List Category's Manufacturers, of Category with Id: 25 and order results by Popularity Asceding.
                result = category.ListCategorysManufactures(25, OrderByNamePop.popularity, OrderDir.asc).Result.manufacturers.printReflected();

                //List Category's Favorites, of Category with Id: 40. 
                //[Important] User token is required or else exception is thrown.
                //result = category.ListCategorysFavorites(40).Result;

                #endregion

                #region SKU

                Sku sku = new Sku(skroutzRequest);

                //List SKU's, of Category with Id: 40.
                result = sku.ListSKUsOfSpecificCategory(40).Result.skus.printReflected();

                //List SKU's, of Category with Id: 40 and order results by Popularity.
                result = sku.ListSKUsOfSpecificCategory(40, OrderByPrcPopRating.popularity).Result.skus.printReflected();

                //List SKU's, of Category with Id: 40 and order results by Rating Descending.
                result = sku.ListSKUsOfSpecificCategory(40, OrderByPrcPopRating.rating, OrderDir.desc).Result.skus.printReflected();

                //List SKU's, of Category with Id: 40 and keyword equal to iphone.
                result = sku.ListSKUsOfSpecificCategory(40, searchKeyword: "iphone").Result.skus.printReflected();

                //List SKU's, of Category with Id: 40 and manufacturerIds 28, 2.
                result = sku.ListSKUsOfSpecificCategory(40, manufacturerIds: new int[] { 28, 2 }).Result.skus.printReflected();

                //List SKU's, of Category with Id: 40 and filter Ids 355559, 6282.
                result = sku.ListSKUsOfSpecificCategory(40, filterIds: new int[] { 355559, 6282 }).Result.skus.printReflected();

                //Retrieve SKU with SKUid: 3690169.
                result = sku.RetrieveSingleSKU(3690169).Result.sku.printReflected();

                //Retrieve similar SKU's of SKUid: 3034682.
                result = sku.RetrieveSimilarSKUs(3034682).Result.skus.printReflected();

                //Retrieve SKU's products of SKUid: 3783654.
                result = sku.RetrieveSKUsProducts(3783654).Result.products.printReflected();

                //Retrieve SKU's Reviews of SKUid: 3690169.
                result = sku.RetrieveSKUsReviews(3690169).Result.reviews.printReflected();

                #endregion

                #region PRODUCT

                Product product = new Product(skroutzRequest);

                //Retrieve Product with ProductId: 12176638.
                result = product.RetrieveSingleProduct(12176638).Result.Product.printReflected();

                //Search for Products with ShopId: 670 and ShopUniqueId : 220004386.
                result = product.SearchForProducts(670, "220004386").Result.products.printReflected();

                #endregion

                #region SHOP

                Shop shop = new Shop(skroutzRequest);

                //Retrieve Shop with ShopId: 452.
                var singleShop = shop.RetrieveSingleShop(452).Result.shop;

                //Print additional info.
                singleShop.printReflected();
                singleShop.PaymentMethods.printReflected();
                singleShop.Shipping.printReflected();
                singleShop.ExtraInfo.printReflected();

                //Retrieve Shop Reviews of ShopId: 452.
                result = shop.RetrieveShopReview(452).Result.Reviews.printReflected();

                //List Shop Locations of ShopId: 452.
                result = shop.ListShopLocations(452).Result.Locations.printReflected();

                //Retrieve Shop Location of ShopId: 452 and LocationId: 2500.
                result = shop.RetrieveSingleShopLocation(452, 2500).Result.Locations.printReflected();

                #endregion

                #region MANUFACTURER

                Manufacturer manufacturer = new Manufacturer(skroutzRequest);

                //List Manufacturers 
                result = manufacturer.ListManufacturers().Result.manufacturers.printReflected();

                //Retrieve Manufacturer with ManufacturerId: 12907.
                result = manufacturer.RetrieveSingleManufacturer(12907).Result.Manufacturer.printReflected();

                //Retrieve Manufacturer Categories with ManufacturerId: 356. Retrieve the first 10 results.
                result = manufacturer.RetrieveManufacturerCategories(356, page: 1, per: 10).Result.categories.printReflected();

                //Retrieve Manufacturer Categories with ManufacturerId: 356 and order results by Manufacturer name.
                result = manufacturer.RetrieveManufacturerCategories(356, OrderByNamePop.name).Result.categories.printReflected();

                //Retrieve Manufacturer Categories with ManufacturerId: 356 and order results by Popularity Asceding.
                result = manufacturer.RetrieveManufacturerCategories(356, OrderByNamePop.popularity, OrderDir.asc).Result.categories.printReflected();

                //Retrieve Manufacturer SKU's with ManufacturerId: 356.
                result = manufacturer.RetrieveManufacturerSKUs(356).Result.skus.printReflected();

                //Retrieve Manufacturer SKU's with ManufacturerId: 356 and order results by Price.
                result = manufacturer.RetrieveManufacturerSKUs(356, OrderByPrcPop.price).Result.skus.printReflected();

                //Retrieve Manufacturer SKU's with ManufacturerId: 356 and order results by Popularity Asceding.
                result = manufacturer.RetrieveManufacturerSKUs(356, OrderByPrcPop.popularity, OrderDir.asc).Result.skus.printReflected();

                #endregion

                #region SEARCH

                Search search = new Search(skroutzRequest);

                //Query with less than 2 characters
                //[Important] Exception is thrown if query is less than 2 characters.
                result = search.SearchQuery("a").Result;

                //Query that doesn't match anything
                result = search.SearchQuery("asdf").Result.Categories;
           
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

                #endregion

                #region FLAG

                Flag flag = new Flag(skroutzRequest);

                //Retrieve All Flags.
                result = flag.RetrieveAllFlags().Result.flags.printReflected();

                #endregion

                #region FILTER GROUP

                FilterGroup filterGroup = new FilterGroup(skroutzRequest);

                //List Filter Groups of Category with CategoryId: 40.
                result = filterGroup.ListFilterGroups(40).Result.filter_groups.printReflected();

                #endregion
            }
            catch (AggregateException aggregateException)
            {
                aggregateException.Handle(ex =>
                {
                    SkroutzException skroutzException = ex.InnerException as SkroutzException;
                    if (skroutzException != null)
                    {
                        Console.WriteLine($"Status code: {skroutzException.StatusCode}");

                        foreach (Error error in skroutzException.SkroutzError.Errors)
                        {
                            Console.WriteLine($"Error code: {error.Code}");

                            foreach (string errorMessage in error.Messages)
                                Console.WriteLine($"Error message: {errorMessage}");

                        }
                        return true;

                    }
                    return false;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
