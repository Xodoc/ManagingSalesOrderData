namespace ManagingSalesOrderData.Shared.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public List<WindowDto> Windows { get; set; }
    }
}
