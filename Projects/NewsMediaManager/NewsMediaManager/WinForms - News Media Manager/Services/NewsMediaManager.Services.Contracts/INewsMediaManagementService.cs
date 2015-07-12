using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using NewsMediaManager.Entities;


namespace NewsMediaManager.Services.Contracts
{
    /// <summary>
    /// Service Contract for News Media Management Service
    /// </summary>
    [ServiceContract]
    public interface INewsMediaManagementService
    {

		[OperationContract]
		NewsMedia AppendASF (NewsMedia media);

        [OperationContract]
        List<NewsMedia> GetNewsMediaList(DateTime date);

        [OperationContract]
        NewsMedia StoreNewsMedia(NewsMedia newsMedia);

        [OperationContract]
        NewsMedia UpdateNewsMedia(NewsMedia newsMedia);

        [OperationContract]
        Boolean DeleteNewsMedia(NewsMedia newsMedia);

    }



}