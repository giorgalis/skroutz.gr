# Portable Class Library for accessing the skroutz.gr API

            SkroutzRequest skroutzRequest = new SkroutzRequest(new Credentials { ClientId = "", ClientSecret = "" });
            
            ApplyTitle("Category");
            Category category = new Category(skroutzRequest);

            dynamic result = null;
            result = category.ListAllCategories().Result.categories.printReflected();

            result = category.RetrieveSingleCategory(1442, x => x.Code, x => x.Id).Result.Category.printReflected();
            result = category.RetrieveTheParentOfCategory(1442).Result.Category.printReflected();
            result = category.RetrieveTheRootCategory().Result.Category.printReflected();
            result = category.ListChildrenCategoriesOfCategory(252).Result.categories.printReflected();
            result = category.ListCategorysSpecifications(40).Result.specifications.printReflected();
            result = category.ListCategorysSpecificationsGroup(40).Result.groups.printReflected();

            result = category.ListCategorysManufactures(25).Result.manufacturers.printReflected();
            result = category.ListCategorysManufactures(25, OrderByNamePop.name).Result.manufacturers.printReflected();
            result = category.ListCategorysManufactures(25, OrderByNamePop.popularity, OrderDir.asc).Result.manufacturers.printReflected();

            //User token is required or else exception is thrown
            //result = category.ListCategorysFavorites(40).Result;

            ApplyTitle("SKU");
            Sku sku = new Sku(skroutzRequest);

            result = sku.ListSKUsOfSpecificCategory(40).Result.skus.printReflected();
            result = sku.ListSKUsOfSpecificCategory(40, OrderByPrcPopRating.popularity).Result.skus.printReflected();
            result = sku.ListSKUsOfSpecificCategory(40, OrderByPrcPopRating.rating, OrderDir.desc).Result.skus.printReflected();
            result = sku.ListSKUsOfSpecificCategory(40, searchKeyword: "iphone").Result.skus.printReflected();
            result = sku.ListSKUsOfSpecificCategory(40, manufacturerIds: new int[] { 28, 2 }).Result.skus.printReflected();
            result = sku.ListSKUsOfSpecificCategory(40, filterIds: new int[] { 355559, 6282 }).Result.skus.printReflected();

            result = sku.RetrieveSingleSKU(3690169).Result.sku.printReflected();
            result = sku.RetrieveSimilarSKUs(3034682).Result.skus.printReflected();
            result = sku.RetrieveSKUsProducts(3783654).Result.products.printReflected();
            result = sku.RetrieveSKUsReviews(3690169).Result.reviews.printReflected();

            ApplyTitle("Product");
            Product product = new Product(skroutzRequest);

            result = product.RetrieveSingleProduct(12176638, x => x.Name, x => x.Price).Result.Product;
            result = product.SearchForProducts(670, "220004386").Result.products.printReflected();

            ApplyTitle("Shop");
            Shop shop = new Shop(skroutzRequest);

            result = shop.RetrieveSingleShop(452).Result;
            result = shop.RetrieveShopReview(452).Result.Reviews.printReflected();
            result = shop.ListShopLocations(452).Result.Locations.printReflected();
            result = shop.RetrieveSingleShopLocation(452, 2500).Result;

            ApplyTitle("Manufacturer");
            Manufacturer manufacturer = new Manufacturer(skroutzRequest);

            //List Manufacturers 
            result = manufacturer.ListManufacturers().Result.manufacturers.printReflected();

            //Retrieve Manufacturer with Manufacturerid: 12907.
            result = manufacturer.RetrieveSingleManufacturer(12907).Result.manufacturer.printReflected();

            //Retrieve Manufacturer Categories with Manufacturerid: 356. Retrieve the first 10 results.
            result = manufacturer.RetrieveManufacturerCategories(356, page: 1, per: 10).Result.categories;

            //Retrieve Manufacturer Categories with Manufacturerid: 356. Order by Manufacturer name.
            result = manufacturer.RetrieveManufacturerCategories(356, OrderByNamePop.name).Result.categories.printReflected();

            //Retrieve Manufacturer Categories with Manufacturerid: 356. Order by Popularity Asceding.
            result = manufacturer.RetrieveManufacturerCategories(356, OrderByNamePop.popularity, OrderDir.asc).Result.categories.printReflected();

            result = manufacturer.RetrieveManufacturerSKUs(356).Result.skus.printReflected();
            result = manufacturer.RetrieveManufacturerSKUs(356, OrderByPrcPop.price).Result.skus.printReflected();
            result = manufacturer.RetrieveManufacturerSKUs(356, OrderByPrcPop.popularity, OrderDir.asc).Result.skus.printReflected();

            ApplyTitle("Search");
            Search search = new Search(skroutzRequest);

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
            Flag flag = new Flag(skroutzRequest);

            result = flag.RetrieveAllFlags().Result.flags.printReflected();

            ApplyTitle("Filter Groups");
            FilterGroup filterGroup = new FilterGroup(skroutzRequest);

            result = filterGroup.ListFilterGroups(40).Result.filter_groups.printReflected();
