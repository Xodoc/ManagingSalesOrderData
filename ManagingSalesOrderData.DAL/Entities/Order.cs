namespace ManagingSalesOrderData.DAL.Entities
{
    public sealed class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public ICollection<Window> Windows { get; set; }
    }
}
