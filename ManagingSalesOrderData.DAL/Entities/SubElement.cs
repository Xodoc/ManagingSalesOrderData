namespace ManagingSalesOrderData.DAL.Entities
{
    public sealed class SubElement
    {
        public int Id { get; set; }

        public int Element { get; set; }

        public string Type { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public ICollection<Window> Windows { get; set; }
    }
}
