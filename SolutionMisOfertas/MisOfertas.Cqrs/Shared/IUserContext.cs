using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisOfertas.Cqrs.Shared
{
    public interface IUserContext
    {
        string UserLogin { get; }
        string Name { get; }
        int UserId { get; }
        string[] Roles { get; }
        int OwnerId { get; set; }
    }
}
