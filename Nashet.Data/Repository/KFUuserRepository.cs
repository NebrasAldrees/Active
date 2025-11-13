using Microsoft.EntityFrameworkCore;
using Nashet.Data.Models;
using Nashet.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Data.Repository
{
    public class KFUuserRepository :BaseRepository<tblKFUuser>
    {
        public KFUuserRepository(NashetContext dbContext) : base(dbContext)
        {
            
        }
        public virtual async Task<IList<tblKFUuser>> GetAllKFUuser()
        {
            return await dbSet.Where(user => user.IsDeleted == false).ToListAsync();
        }
        public virtual async Task<tblKFUuser> GetKFUuserByUsername(string Username)
        {
            return await dbSet.Where(user => user.IsDeleted == false && user.Username == Username)
                .SingleOrDefaultAsync();
        }
        //public virtual async Task<tblKFUuser> CheckUser(string usernameOrEmail, string password)
        //{
        //    try
        //    {
        //        Console.WriteLine($"Searching KFU user by: {usernameOrEmail}");

        //        // البحث بالاسم أو الإيميل
        //        var user = await dbSet
        //            .SingleOrDefaultAsync(u =>
        //                (u.Username == usernameOrEmail || u.UserEmail == usernameOrEmail) &&
        //                !u.IsDeleted);

        //        if (user != null)
        //        {
        //            Console.WriteLine($"User found: {user.Username}, Email: {user.UserEmail}");
        //            if (user.Password == password)
        //            {
        //                Console.WriteLine("Password matches!");
        //                return user;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Password does not match!");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("No user found with this username/email");
        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in CheckUser: {ex.Message}");
        //        return null;
        //    }
        //}
        public virtual async Task<tblKFUuser> CheckUser(string username, string password)
        {
            return await dbSet.SingleOrDefaultAsync(user => user.Username == username && user.Password == password);
        }
        public virtual async Task<tblKFUuser> CheckUserByEmail(string email, string password)
        {
            return await dbSet.SingleOrDefaultAsync(user =>
                user.UserEmail == email &&
                user.Password == password &&
                !user.IsDeleted);
        }
        public virtual async Task<int> InsertKfuUser(tblKFUuser KFUuser)
        {
            try
            {
                await InsertAsync(KFUuser);
                return 1;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error inserting system:{ex.Message}");
                return 0;
            }
        }
        public virtual async Task<tblKFUuser> checkUser(string Username, string Password)
        {
            return await dbSet.Where(user => user.Username == Username && user.Password == Password).SingleOrDefaultAsync();

        }

    }
}
