using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository; 

        public OrdersController(IOrderRepository orderRepository,ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAllCustomers(), "CustomerId", "CustomerName");
            ViewData["ProductId"] = new SelectList(_productRepository.GetAllProducts(), "ProductId", "ProductName");
            return View(_orderRepository.GetAllOrderrs().ToList());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);

        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAllCustomers(), "CustomerId", "CustomerName");
            ViewData["ProductId"] = new SelectList(_productRepository.GetAllProducts(), "ProductId", "ProductName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
           _orderRepository.AddOrder(order);
            return RedirectToAction("Index");
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAllCustomers(), "CustomerId", "CustomerName");
            ViewData["ProductId"] = new SelectList(_productRepository.GetAllProducts(), "ProductId", "ProductName");
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }
            try
            {
                _orderRepository.UpdateOrder(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!OrderExists(order.OrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            _orderRepository.RemoveOrder(order);
            return RedirectToAction("Index"); 
        }

        private bool OrderExists(int id)
        {
            return _orderRepository.GetOrderById(id) != null;
        }
    }
}
