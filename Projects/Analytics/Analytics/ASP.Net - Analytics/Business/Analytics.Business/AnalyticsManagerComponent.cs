using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Analytics.Entities;
using Analytics.Data;
using System.Transactions;
using System.Linq;


//Business Component Layer for Analytics
namespace Analytics.Business
{
	/// <summary>
	/// Analytics Manager Business component.
	/// </summary>
  public partial class AnalyticsManagerComponent
   {

		/// <summary>
		/// Gets the List of News Media created on a date
		/// </summary>
		/// <param name="date"> date value.</param>
		/// <returns>Returns a List<NewsMedia> object.</returns>
      	public List<NewsMedia> GetNewsMediaList(DateTime date)
         {

           List<NewsMedia> result = default(List<NewsMedia>);
           var analyticsManagerDAC = new AnalyticsManagerDAC();

           result = analyticsManagerDAC.Select(date);

           return result;
         }


   }

}