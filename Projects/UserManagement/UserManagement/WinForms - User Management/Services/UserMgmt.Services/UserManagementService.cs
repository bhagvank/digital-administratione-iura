using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using UserManagement.Business;
using UserManagement.Entities;
using UserManagement.Services.Contracts;

// Services Layer related to  User Management - For Consumers
namespace UserManagement.Services
{

	/// <summary>
	/// User Management Service component.
	/// </summary>
      [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,ConcurrencyMode = ConcurrencyMode.Multiple)]

      public class UserManagementService:IUserManagementService
       {

		/// <summary>
		/// Retrieve the list of users 
		/// </summary>
		/// <returns>Returns a List of Users object.</returns>
           public List<User> GetUsers()
            {
               UserManagementComponent umc = new UserManagementComponent();

               return umc.GetUsers();
            }
		/// <summary>
		/// Adds the user 
		/// </summary>
		/// <param name="user">user</param>
		/// <returns>Returns a User object.</returns>
           public User AddUser(User user)
            {
               UserManagementComponent umc = new UserManagementComponent();
    
               return umc.AddUser(user);
            }

		/// <summary>
		/// Updates the user 
		/// </summary>
		/// <param name="user">user</param>
		/// <returns>Returns a User object.</returns>
           public User UpdateUser(User user)
            {
                UserManagementComponent umc = new UserManagementComponent();

                return umc.UpdateUser(user);
            }
		/// <summary>
		/// Deletes the user 
		/// </summary>
		/// <param name="user">user</param>
		/// <returns>Returns a boolean flag if deleted</returns>
           public Boolean DeleteUser(User user)
            {
               UserManagementComponent umc = new UserManagementComponent();

               return umc.DeleteUser(user);

            }


       }

}