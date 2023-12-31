﻿using System;
using System.Collections.Generic;
using Domain;
using Repository;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<EmailMessage> _mailRepository;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Cart> cartRepository, IRepository<Order> orderRepository, IRepository<EmailMessage> mailRepository)
        {
            _mailRepository = mailRepository;
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;

        }
        
        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        
        
        public Order GetOrderById(Guid id)
        {
            return _orderRepository.Get(id);
        }
        public Order CreateOrder(Cart cart)
        {
            var order = _orderRepository.Insert(new Order
            {
                Id = cart.Id,
                OrderItems = cart.CartItems,
                User = cart.User,
                TotalPrice = cart.TotalPrice
            });
            _cartRepository.Delete(cart);
            
            EmailMessage emailMessage = new EmailMessage
            {
                Subject = "Order Confirmation",
                Content = "Your order has been confirmed",
                MailTo = cart.User.Email,
                Status = false
            };
            _mailRepository.Insert(emailMessage);
            
            return order;
        }
    }
}