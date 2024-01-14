using ManagingSalesOrderData.BLL.Interfaces;
using ManagingSalesOrderData.BLL.Validators.CustomExceptions;

namespace ManagingSalesOrderData.BLL.Validators
{
    public class Validator : IValidator
    {
        public void ValidateDto<T>(T dto, params string[] dtoProps)
        {
            if (dto is null)
                throw new ValidatorException("Incorrect data sent");

            foreach (var prop in dtoProps)
            {
                if (string.IsNullOrWhiteSpace(prop))
                    throw new ValidatorException("Incorrect data sent");
            }
        }
    }
}
