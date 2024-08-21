using Amazon.Data;
using Amazon.Models;
using DataAccessLayer.IterfacesRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(TheContext context) : base(context)
        {
        }
    }
}
