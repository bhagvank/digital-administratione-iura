using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using YoutubeIntegration.Entities;

//Service Contract Layer for Youtube Integration
namespace YoutubeIntegration.Services.Contracts
{
    /// <summary>
    /// Service Contract for Youtube Integration Service
    /// </summary>
    [ServiceContract]
    public interface IYoutubeIntegrationService
     {
        [OperationContract]
        List<NewsMedia> GetNewsMediaList(DateTime date);

		[OperationContract]
		NewsMedia AppendASF(NewsMedia media);
     }

}