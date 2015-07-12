using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using YoutubeIntegration.Business;
using YoutubeIntegration.Entities;
using YoutubeIntegration.Services.Contracts;

//Services Layer for Youtube Integration
namespace YoutubeIntegration.Services
{

	/// <summary>
	/// Youtube Integration  Service.
	/// </summary>
   	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,ConcurrencyMode = ConcurrencyMode.Multiple)]

     public class YoutubeIntegrationService:IYoutubeIntegrationService
      {

		/// <summary>
		/// Gets the list of News Media
		/// </summary>
		/// <param name="date">created date.</param>
		/// <returns>Returns the list of List<NewsMedia>.</returns>
         public List<NewsMedia> GetNewsMediaList(DateTime date)
          {
             YoutubeIntegrationComponent yic = new YoutubeIntegrationComponent();

             return yic.GetNewsMediaList(date);
          }

		/// <summary>
		/// Append NewsMedia With ASF (Advanced Systems Format)
		/// </summary>
		/// <param name="newsmedia">NewsMedia</param>
		/// <returns>Returns News Media Appended with ASF</returns>
		public NewsMedia AppendASF (NewsMedia media)
		{
			string locationURL = media.LocationURL;

			MediaStreamASF mediaStream = new MediaStreamASF ();
			mediaStream.AppendASF (locationURL,media.LicenseURL,media.LicenseIssuerURL);

			return media;

		}
      }


}