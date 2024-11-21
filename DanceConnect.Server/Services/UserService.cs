﻿using DanceConnect.Server.DataContext;
using DanceConnect.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DanceConnect.Server.Services
{
    public class UserService : IUserService
    {
        private readonly DanceConnectContext _context;

        public UserService(DanceConnectContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
