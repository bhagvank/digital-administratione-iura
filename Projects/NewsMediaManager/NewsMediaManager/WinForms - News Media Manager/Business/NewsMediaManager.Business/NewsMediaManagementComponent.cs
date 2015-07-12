using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NewsMediaManager.Entities;
using NewsMediaManager.Data;
using System.Transactions;
using System.Linq;


// 
// Business Component for News Media Management
//This layer interacts with Data package components
//
namespace NewsMediaManager.Business
{
	/// <summary>
	/// News Media Management business component.
	/// </summary>
   public partial class NewsMediaManagementComponent
    {

		/// <summary>
		/// Retrieve List of News Media 
		/// </summary>
		/// <param name="date">Created Date</param>
		/// <returns>Returns a List of News Media</returns>
          public List<NewsMedia> GetNewsMediaList(DateTime date)
           {

             List<NewsMedia> result = default(List<NewsMedia>);
             var newsMediaManagementDAC = new NewsMediaManagementDAC();

             result = newsMediaManagementDAC.Select(date);

             return result;
           }


		/// <summary>
		/// Store News Media Content 
		/// </summary>
		/// <param name="newsMedia">newsMedia</param>
		/// <returns>Returns the news media content</returns>
          public NewsMedia StoreNewsMedia(NewsMedia newsMedia)
           {
                 var newsMediaManagementDAC = new NewsMediaManagementDAC();

                 using (TransactionScope ts =
	                new TransactionScope(TransactionScopeOption.Required))
	            {

                 newsMediaManagementDAC.Create(newsMedia);

                 ts.Complete();

                }

                 return newsMedia;

           }
		/// <summary>
		/// Update News Media Content 
		/// </summary>
		/// <param name="newsMedia">newsMedia</param>
		/// <returns>Returns the news media content</returns>
          public NewsMedia UpdateNewsMedia(NewsMedia newsMedia)
           {
                var newsMediaManagementDAC = new NewsMediaManagementDAC();

                using (TransactionScope ts =
	                new TransactionScope(TransactionScopeOption.Required))
	            {
                   newsMediaManagementDAC.Update(newsMedia);

                   ts.Complete();
                }
                return newsMedia;
   
           }
      
		/// <summary>
		/// Deletes the News Media Content 
		/// </summary>
		/// <param name="newsMedia">newsMedia</param>
		/// <returns>Returns the flag if deleted</returns>
          public Boolean DeleteNewsMedia(NewsMedia newsMedia)
           {
               var newsMediaManagementDAC = new NewsMediaManagementDAC();
      
               Boolean returnFlag = newsMediaManagementDAC.Delete(newsMedia);

               return returnFlag;
 
           }

    }




}