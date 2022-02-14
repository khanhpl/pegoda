﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class OrderItemRepository : IOrderItemRepository<OrderItem>
    {
        private readonly DataContext _context;
        public OrderItemRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<OrderItem> Create(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task<bool> Delete(Guid id)
        {
            OrderItem orderItem = await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
            if (orderItem == null)
            {
                return false;
            }
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public List<OrderItem> GetAll()
        {
            return _context.OrderItems.ToList();
        }

        public async Task<OrderItem> GetById(Guid id)
        {
            OrderItem orderItem = await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
            if (orderItem == null)
            {
                return null;
            }
            return orderItem;
        }

        public async Task<bool> Update(OrderItem newOrderItem)
        {
            OrderItem orderItem = await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == newOrderItem.Id);
            if (orderItem == null)
            {
                return false;
            }
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
