using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Cqrs.Infrastructure
{
    public interface IMediator
    {
        // Query process
        TResult Query<TResult>(IQuery<TResult> query);

        // Command process
        void Command(ICommand command);
    }
}
