using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using Analytics.Business;
using Analytics.Entities;
using Analytics.Services.Contracts;

//Service Component Layer for Analytics
namespace Analytics.Services
{

	/// <summary>
	/// Analytics Manager service component.
	/// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,ConcurrencyMode = ConcurrencyMode.Multiple)]

  public class  AnalyticsManagerService:IAnalyticsManagerService
   {

		/// <summary>
		/// Gets the List of News Media created on a date
		/// </summary>
		/// <param name="date"> date value.</param>
		/// <returns>Returns a List<NewsMedia> object.</returns>
        public List<NewsMedia> GetNewsMediaList(DateTime date)
        {
           NewsPortalManagerComponent npmc = new NewsPortalManagerComponent();

           return npmc.GetNewsMediaList(date);
        }


   }



}