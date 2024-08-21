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
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(TheContext context) : base(context)
        {
        }
    }
}
