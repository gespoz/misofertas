using System;
using System.Diagnostics;
using SimpleInjector;

namespace MisOfertas.Cqrs.Infrastructure
{
    public sealed class Mediator : IMediator
    {
        private readonly Container container;

        public Mediator(Container container)
        {
            this.container = container;
        }

        [DebuggerStepThrough]
        public void Command(ICommand command)
        {
            var handlerType =
                typeof(ICommandHandler<>).MakeGenericType(command.GetType());

            dynamic handler = container.GetInstance(handlerType);

            handler.Handle((dynamic)command);
        }

        public TResult Query<TResult>(IQuery<TResult> query)
        {
            var handlerType =
                typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = container.GetInstance(handlerType);

            return handler.Handle((dynamic)query);
        }
    }
}
