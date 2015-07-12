using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Entities;


// Data Access Component Layer for User Management
namespace UserManagement.Data
{
	/// <summary>
	/// User Management Data Access component.
	/// </summary>
  public partial class UserManagementDAC: DataAccessComponent
   {

		/// <summary>
		/// Retrieve the list of users 
		/// </summary>
		/// <returns>Returns a List of Users object.</returns>
      public List<User> GetUsers()
      {
        using (var database = new DbContext(CONNECTION_NAME))
         {
            IQueryable<NewsMedia> query = database.Set<User>();

            return query.ToList();
         }
      }

		/// <summary>
		/// Adds the user 
		/// </summary>
		/// <param name="user">user</param>
		/// <returns>Returns a User object.</returns>
      public User AddUser(User user)
       {
         using (var database = new DbContext(CONNECTION_NAME))
          {
             database.Set<User>().Add(user);

             database.SaveChanges();

             return user;
          }
       }

		/// <summary>
		/// Updates the user 
		/// </summary>
		/// <param name="user">user</param>
		/// <returns>Returns a User object.</returns>
      public User UpdateUser(User user)
       {
         using (var database = new DbContext(CONNECTION_NAME))
          {
             var entryUser = database.Entry<User>(user);
             entryUser.state = EntityState.Unchanged;
             entryMedia.Property("Status").IsModified = true;
             entryMedia.Property("Remarks").IsModified = true;
             entryMedia.Property("IsCompleted").IsModified = true;
             database.SaveChanges();
 
          }
       }
		/// <summary>
		/// Deletes the user 
		/// </summary>
		/// <param name="user">user</param>
		/// <returns>Returns a boolean flag if deleted</returns>
      public Boolean DeleteUser(User user)
       {
          using (var database = new DbContext(CONNECTION_NAME))
          {
             var entryUser = database.Entry<User>(user);
         
             return database.DeleteObject(entryUser);
          }
       }

   }



}