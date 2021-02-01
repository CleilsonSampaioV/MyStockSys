using MyStockSys.Domain.Interfaces.Command;
using System.Threading.Tasks;

namespace MyStockSys.Domain.Interfaces.Handler
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
