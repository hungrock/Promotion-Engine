﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngineLibrary
{
  public class Engine
  {
    IEnumerable<Item> PriceList { get; }
    IEnumerable<Promotion> Promotions { get; }
    public Engine(IEnumerable<Item> priceList, IEnumerable<Promotion> promotions)
    {
      PriceList = priceList;
      Promotions = promotions;
    }

    public void CheckOut(Order order)
    {
      var foundItems = new List<Item>();
      if (Promotions != null && Promotions.Count() > 0)
        foreach (var promotion in Promotions)
        {
          var validatedItems = promotion.Validate(order, foundItems);
          if (validatedItems != null && validatedItems.Count() > 0)
            foundItems.AddRange(validatedItems);
        }

      foreach (var item in order.Items)
      {
        var validateItem = foundItems.FirstOrDefault(x => x.SKU_Id == item.SKU_Id) ?? item; 
        var quantity = validateItem.Quantity;
        if (quantity > 0)
          order.TotalAmount += quantity * PriceList.First(x => x.SKU_Id == item.SKU_Id).Price;
      }
    }
  }
}
