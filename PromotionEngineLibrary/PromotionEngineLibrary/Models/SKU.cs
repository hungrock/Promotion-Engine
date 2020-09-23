namespace PromotionEngineLibrary
{
  public class SKU
  {
    public char Id { get; set; }
    public double ListPrice { get; set; }

    override public string ToString()
    {
      return Id.ToString();
    }
  }
}