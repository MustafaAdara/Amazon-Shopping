using Amazon.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IterfacesRepositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
    }
}
