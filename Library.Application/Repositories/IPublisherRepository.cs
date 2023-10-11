using Library.Application.Repositories.Base;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Repositories
{
    public interface IPublisherRepository : IBaseRepository<OrderItem>
    {
    }
}
