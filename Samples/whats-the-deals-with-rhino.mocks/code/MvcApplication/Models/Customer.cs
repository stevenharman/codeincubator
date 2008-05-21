namespace MvcApplication.Models
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        private readonly Logger _logger;

        public Customer(int Id, Logger logger)
        {
            this.Id = Id;
            _logger = logger;
        }

        // I would never really do this! Evar!
        public void Save()
        {
            _logger.Log(this.Id);
        }
    }
}