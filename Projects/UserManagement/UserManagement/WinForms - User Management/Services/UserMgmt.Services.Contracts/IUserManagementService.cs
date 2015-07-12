using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using UserManagement.Entities;

// Services Contracts  related to  User Management - For Consumers
namespace UserManagement.Services.Contracts
{
	/// <summary>
	/// Service contract for User Management Service.
	/// </summary>
    [ServiceContract]
    public interface IUserManagementService
     {

        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        User AddUser(User user);

        [OperationContract]
        User UpdateUser(User user);

        [OperationContract]
        Boolean DeleteUser(User user);



     }



}