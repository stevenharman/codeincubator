namespace MvcApplication.Models
{
    public abstract class ProductBase
    {
        public abstract string Name { get; set; }

        public abstract decimal Price { get; set; }

        public abstract void Save();
    }
}