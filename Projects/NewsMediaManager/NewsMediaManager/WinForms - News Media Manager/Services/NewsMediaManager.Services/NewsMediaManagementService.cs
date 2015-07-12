using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using NewsMediaManager.Business;
using NewsMediaManager.Entities;
using NewsMediaManager.Services.Contracts;
using NewsMediaManager.DRM;


// Service Component Layer for external consumers
namespace NewsMediaManager.Services
{

	/// <summary>
	/// NewsMedia Management service component.
	/// </summary>

      [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,ConcurrencyMode = ConcurrencyMode.Multiple)]

      public class NewsMediaManagementService:INewsMediaManagementService
       {


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
        
		/// <summary>
		/// Retrieve List of News Media 
		/// </summary>
		/// <param name="date">Created Date</param>
		/// <returns>Returns a List of News Media</returns>
         public List<NewsMedia> GetNewsMediaList(DateTime date)
          {

              NewsMediaManagementComponent nmmc = new NewsMediaManagementComponent();

              return nmmc.GetNewsMediaList(date);

          }

		/// <summary>
		/// Store News Media Content 
		/// </summary>
		/// <param name="newsMedia">newsMedia</param>
		/// <returns>Returns the news media content</returns>
          public NewsMedia StoreNewsMedia(NewsMedia newsMedia)
           {
              NewsMediaManagementComponent nmmc = new NewsMediaManagementComponent();

              return nmmc.StoreNewsMedia(newsMedia);

           }

		/// <summary>
		/// Update News Media Content 
		/// </summary>
		/// <param name="newsMedia">newsMedia</param>
		/// <returns>Returns the news media content</returns>
          public NewsMedia UpdateNewsMedia(NewsMedia newsMedia)
           {
              NewsMediaManagementComponent nmmc = new NewsMediaManagementComponent();

              return nmmc.UpdateNewsMedia(newsMedia);
           }

		/// <summary>
		/// Deletes the News Media Content 
		/// </summary>
		/// <param name="newsMedia">newsMedia</param>
		/// <returns>Returns the flag if deleted</returns>
          public Boolean DeleteNewsMedia(NewsMedia newsMedia)
           {
              NewsMediaManagementComponent nmmc = new NewsMediaManagementComponent();

              return nmmc.DeleteNewsMedia(newsMedia);

           }
 
       }





}