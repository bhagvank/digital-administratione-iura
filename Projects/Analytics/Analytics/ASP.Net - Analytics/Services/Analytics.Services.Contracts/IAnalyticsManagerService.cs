using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using Analytics.Entities;

namespace Analytics.Services.Contracts
{

    /// <summary>
    /// Service Contract for Analytics Manager Service
    /// </summary>
    [ServiceContract]
    public interface IAnalyticsManagerService
     {
       	[OperationContract]
       List<NewsMedia> GetNewsMediaList(DateTime date);

     }



}