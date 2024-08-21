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
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(TheContext context) : base(context)
        {
        }
    }
}
