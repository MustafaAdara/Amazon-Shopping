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
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(TheContext context) : base(context)
        {
        }
    }
}
