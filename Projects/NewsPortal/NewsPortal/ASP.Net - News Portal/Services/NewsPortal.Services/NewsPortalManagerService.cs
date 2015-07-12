using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using NewsPortal.Business;
using NewsPortal.Entities;
using NewsPortal.Services.Contracts;

//Services Layer for News Portal
namespace NewsPortal.Services
{
	/// <summary>
	/// NewsPortal Manager Service Component
	/// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,ConcurrencyMode = ConcurrencyMode.Multiple)]

  public class  NewsPortalManagerService:INewsPortalManagerService
   {

		/// <summary>
		/// Gets the list of News Media
		/// </summary>
		/// <param name="date">created date.</param>
		/// <returns>Returns the list of List<NewsMedia>.</returns>
        public List<NewsMedia> GetNewsMediaList(DateTime date)
        {
           NewsPortalManagerComponent npmc = new NewsPortalManagerComponent();

           return npmc.GetNewsMediaList(date);
        }


   }



}