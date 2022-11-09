using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            // context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string usersJsonAsString = File.ReadAllText("../../../Datasets/users.json");
            // string productsJsonAsString = File.ReadAllText("../../../Datasets/products.json");
            // string categoriesJsonAsString = File.ReadAllText("../../../Datasets/categories.json");
            // string categoryProductsJsonAsString = File.ReadAllText("../../../Datasets/categories-products.json");
            // Console.WriteLine(ImportCategoryProducts(context, categoryProductsJsonAsString));

            Console.WriteLine(GetProductsInRange(context));


        }
        //1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IEnumerable<UserInputDto> users = JsonConvert.DeserializeObject<IEnumerable<UserInputDto>>(inputJson);
            InizializeMapper();

            var mapperdUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mapperdUsers);
            context.SaveChanges();

            return $"Successfully imported {mapperdUsers.Count()}";
        }

        private static void InizializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        //2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<ProductInputDto> products = JsonConvert.DeserializeObject<IEnumerable<ProductInputDto>>(inputJson);
            InizializeMapper();

            var mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        //3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoriesInputDto> categories = JsonConvert.DeserializeObject<IEnumerable<CategoriesInputDto>>(inputJson)
                .Where(x => !string.IsNullOrEmpty(x.Name));
            InizializeMapper();

            var mappedCategories = mapper.Map<IEnumerable<Category>>(categories);


            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        //4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IEnumerable<CategoryProductsInputDto> categoryProduct = JsonConvert.DeserializeObject<IEnumerable<CategoryProductsInputDto>>(inputJson);
            InizializeMapper();

            var mappedCategoryProduct = mapper.Map<IEnumerable<CategoryProduct>>(categoryProduct);


            context.CategoryProducts.AddRange(mappedCategoryProduct);
            context.SaveChanges();

            return $"Successfully imported {mappedCategoryProduct.Count()}";
        }

        //5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var result = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    Name = x.Name,
                    Price = x.Price,
                    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };

            string productAsJson = JsonConvert.SerializeObject(result, jsonSettings);

            return productAsJson;
        }

       
    }
}