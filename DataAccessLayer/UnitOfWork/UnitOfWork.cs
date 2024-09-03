using Amazon.Data;
using DataAccessLayer.IterfacesRepositories;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable // IDisposable is used to free unmanaged resources 
    {
        private readonly TheContext _context;
        private IProductRepository? _productRepository;
        private ICategoryRepository? _categoryRepository;
        private IOrderItemRepository? _orderItemRepository;
        private IOrderRepository? _orderRepository;
        private IReviewRepository? _reviewRepository;
        private IPaymentRepository? _paymentRepository;

        public UnitOfWork(TheContext context)
        {
            _context = context;
        }
        public ICategoryRepository CategoryRepository => _categoryRepository??= new CategoryRepository(_context);

        public IProductRepository ProductRepository => _productRepository??= new ProductRepository(_context);

        public IPaymentRepository PaymentRepository => _paymentRepository??= new PaymentRepository(_context);

        public IOrderRepository OrderRepository => _orderRepository??= new OrderRepository(_context);

        public IOrderItemRepository OrderItemRepository => _orderItemRepository??= new OrderItemRepository(_context);

        public IReviewRepository ReviewRepository => _reviewRepository??= new ReviewRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
