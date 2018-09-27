using MisOfertas.Cqrs.Infrastructure;
using MisOfertas.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Negocio.Features.Login
{
    public class IngresoSistemaQuery
    {
        public class Query : IQuery<Result>
        {
            public string User { get; set; }
            public string Pass { get; set; }
            public Query()
            { }
        }
        public class Result
        {
            public string User { get; set; }
            public string Pass { get; set; }
        }
        public class Handler :
            IQueryHandler<Query, Result>
        {
            IMoContext context;
            //IMediator mediator;

            public Handler(/*IMediator mediator, */IMoContext context)
            {
                //this.context = context;
                //this.mediator = mediator;
            }

            public Result Handle(Query query)
            {
                var result = context.Usuario.Where(x => x.USERNAME == query.User && x.PASSWORD == query.Pass).Select(x => new Result()
                {
                    User = x.USERNAME,
                    Pass = x.PASSWORD
                }).SingleOrDefault();

                return result;
            }
        }
    }
}
