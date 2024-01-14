namespace ManagingSalesOrderData.BLL.Interfaces
{
    public interface IValidator
    {
        void ValidateDto<T>(T dto, params string[] dtoProps);
    }
}
