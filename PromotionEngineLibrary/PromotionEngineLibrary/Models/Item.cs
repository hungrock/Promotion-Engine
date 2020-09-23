namespace PromotionEngineLibrary
{
  public class Item
  {
    public Item()
    { }

    public Item(Item item)
    {
      SKU = item.SKU;
      Quantity = item.Quantity;
      Price = item.Price;
    }

    public SKU SKU { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public char SKU_Id => SKU.Id;
  }
}