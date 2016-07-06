using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Tests
{
    [TestClass()]
    public class HomeWorkSampleTests
    {
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id=1, Cost=1,Revenue=11,SellPrice=21},
                new Product { Id=2, Cost=2,Revenue=12,SellPrice=22},
                new Product { Id=3, Cost=3,Revenue=13,SellPrice=23},
                new Product { Id=4, Cost=4,Revenue=14,SellPrice=24},
                new Product { Id=5, Cost=5,Revenue=15,SellPrice=25},
                new Product { Id=6, Cost=6,Revenue=16,SellPrice=26},
                new Product { Id=7, Cost=7,Revenue=17,SellPrice=27},
                new Product { Id=8, Cost=8,Revenue=18,SellPrice=28},
                new Product { Id=9, Cost=9,Revenue=19,SellPrice=29},
                new Product { Id=10, Cost=10,Revenue=20,SellPrice=30},
                new Product { Id=11, Cost=11,Revenue=21,SellPrice=31}
            };
        }

        [TestMethod]
        public void Product_Cost_Sum_Group_By_3_Record_Test()
        {
            List<Product> products = GetProducts();
            var target = new HomeWorkSample(products);
            
            var expected = new List<int> { 6, 15, 24, 21 };
            var actual = target.GetProductGroup(3,"Cost");

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void Product_Revenue_Sum_Group_By_4_Record_Test()
        {
            List<Product> products = GetProducts();
            var target = new HomeWorkSample(products);

            var expected = new List<int> { 50,66,60 };
            var actual = target.GetProductGroup(4, "Revenue");

            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}