using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using NewsPortal.Entities;

//Services Contracts layer for NewsPortal
namespace NewsPortal.Services.Contracts
{

    /// <summary>
    /// Service Contract for News Portal Manager Service
    /// </summary>
    [ServiceContract]
    public interface INewsPortalManagerService
     {
       	[OperationContract]
       List<NewsMedia> GetNewsMediaList(DateTime date);

     }



}