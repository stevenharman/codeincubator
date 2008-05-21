namespace MvcApplication.Models
{
    public class ProductManager
    {
        public static void DoublePrice(IProduct product)
        {
            product.Price *= 2;
        }
    }
}