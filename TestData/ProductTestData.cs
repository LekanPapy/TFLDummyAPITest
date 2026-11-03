using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.TestData
{
    public class ProductTestData
    {
        public const int ExpectedFifteenthProductId = 15;

        public const int ExpectedUpdatedProductId = 121;

        public const decimal ExpectedFifteenthProductPrice = 799.99m;

        public const string ExpectedFifteenthProductTitle = "Wooden Bathroom Sink With Mirror";

        public const decimal ExpectedIphone13ProPrice = 1099.99m;

        public static UpdateProductRequest GetUpdatedProduct()
        {
            return new UpdateProductRequest
            {
                Title = "Updated Product Title"
            };
        }
    }
}