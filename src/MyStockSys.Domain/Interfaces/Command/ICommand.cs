using Flunt.Validations;

namespace MyStockSys.Domain.Interfaces.Command
{
    public interface ICommand : IValidatable
    {
        void Validate();
    }
}
