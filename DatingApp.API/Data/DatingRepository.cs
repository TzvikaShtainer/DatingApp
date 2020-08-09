using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Helpers;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;
        public DatingRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<PageList<User>> GetUsers(UserParams userPramas)
        {
            var users = _context.Users.Include(p => p.Photos).AsQueryable(); // הפך להזקווריאבל בשביל שנוכל להשוות בשורה שאחרי

            users = users.Where(u => u.Id != userPramas.UserId);

            users = users.Where(u => u.Gender == userPramas.Gender);

            if(userPramas.MinAge != 18 || userPramas.MaxAge != 99)
            {
                var minDob = DateTime.Today.AddYears(-userPramas.MaxAge -1);
                var maxDob = DateTime.Today.AddYears(-userPramas.MinAge -1);

                users = users.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);
            }

            return await PageList<User>.CreateAsync(users, userPramas.PageNumber, userPramas.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}