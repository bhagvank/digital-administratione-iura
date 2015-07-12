using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserManagement.Entities;
using UserManagement.Data;
using System.Transactions;
using System.Linq;


// Business Component Layer for User Management
namespace UserManagement.Business
{
	/// <summary>
	/// User Management component.
	/// </summary>
   public partial class UserManagementComponent
    {

		/// <summary>
		/// Retrieve the list of users 
		/// </summary>
		/// <returns>Returns a List of Users object.</returns>
      public List<User> GetUsers()
      {
         List<User> result = default(List<User>);
 
         var userManagementDAC = new UserManagementDAC();

         result = userManagementDAC.GetUsers();

         return result;
       
      }

		/// <summary>
		/// Adds the user 
		/// </summary>
		/// <param name="user">user</param>
		/// <returns>Returns a User object.</returns>
      public User AddUser(User user)
       {
          var userManagementDAC = new UserManagementDAC();

          using (TransactionScope ts =
              new TransactionScope(TransactionScopeOption.Required))
          {

             userManagement.AddUser(user);

             ts.Complete();

          }

          return user;
       }
		/// <summary>
		/// Updates the user 
		/// </summary>
		/// <param name="user">user</param>
		/// <returns>Returns a User object.</returns>
      public User UpdateUser(User user)
       {
          var userManagementDAC = new UserManagementDAC();

          using (TransactionScope ts =
              new TransactionScope(TransactionScopeOption.Required))
          {
            userManagement.UpdateUser(user);
            ts.Complete();
          }       
          return user;
       }
		/// <summary>
		/// Deletes the user 
		/// </summary>
		/// <param name="user">user</param>
		/// <returns>Returns a boolean flag if deleted</returns>
      public Boolean DeleteUser(User user)
       {
          var userManagementDAC = new UserManagementDAC();

          Boolean returnFlag = userManagementDAC.Delete(user);

          return returnFlag;
       }

    }
}