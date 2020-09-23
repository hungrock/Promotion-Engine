using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngineLibrary;
using System.Collections.Generic;

namespace UnitTestPromotionEngine
{
  [TestClass]
  public class UnitTest1
  {
    static readonly IEnumerable<Item> PriceList =
      new List<Item> {
        new Item { SKU = new SKU { Id = 'A' }, Quantity = 1, Price = 50 },
        new Item { SKU = new SKU { Id = 'B' }, Quantity = 1, Price = 30 },
        new Item { SKU = new SKU { Id = 'C' }, Quantity = 1, Price = 20 },
        new Item { SKU = new SKU { Id = 'D' }, Quantity = 1, Price = 15 } };

    static readonly IEnumerable<Promotion> Promotions = 
      new List<Promotion> {
        new Promotion {
          Items = new List<Item> {
            new Item { SKU = new SKU { Id = 'A' }, Quantity = 3 }},
          TotalAmount = 130 }, // 3 of A for 130
        new Promotion {
          Items = new List<Item> {
            new Item { SKU = new SKU { Id = 'B' }, Quantity = 2 }},
          TotalAmount = 45 }, // 2 of B for 45
        new Promotion {
          Items = new List<Item> {
            new Item { SKU = new SKU { Id = 'C' }, Quantity = 1 },
            new Item { SKU = new SKU { Id = 'D' }, Quantity = 1 }},
          TotalAmount = 30 } }; // C + D for 30
    static readonly Engine actualEngine = new Engine(PriceList, Promotions);

    [TestMethod]
    public void TestSenarioA()
    {
      var order = 
        new Order
        {
          Items = new List<Item>
          {
            new Item { SKU = new SKU { Id = 'A' }, Quantity = 1 },
            new Item { SKU = new SKU { Id = 'B' }, Quantity = 1 },
            new Item { SKU = new SKU { Id = 'C' }, Quantity = 1 } }
        };

      actualEngine.CheckOut(order);
      Assert.IsTrue(order.TotalAmount == 100);
    }

    [TestMethod]
    public void TestSenarioB()
    {
      var order = 
        new Order
        {
          Items = new List<Item>
          {
            new Item { SKU = new SKU { Id = 'A' }, Quantity = 5 },
            new Item { SKU = new SKU { Id = 'B' }, Quantity = 5 },
            new Item { SKU = new SKU { Id = 'C' }, Quantity = 1 } }
        };

      actualEngine.CheckOut(order);
      Assert.IsTrue(order.TotalAmount == 370);
    }
  }
}
