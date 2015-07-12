using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NewsPortal.Entities;
using NewsPortal.Data;
using System.Transactions;
using System.Linq;



//Business Layer for News Portal
namespace NewsPortal.Business
{
	/// <summary>
	/// NewsPortal Manager Business Component
	/// </summary>
  public partial class NewsPortalManagerComponent
   {
		/// <summary>
		/// Gets the list of News Media
		/// </summary>
		/// <param name="date">created date.</param>
		/// <returns>Returns the list of List<NewsMedia>.</returns>
      	public List<NewsMedia> GetNewsMediaList(DateTime date)
         {

           List<NewsMedia> result = default(List<NewsMedia>);
           var newsPortalManagerDAC = new NewsPortalManagerDAC();

           result = newsPortalManagerDAC.Select(date);

           return result;
         }


   }

}