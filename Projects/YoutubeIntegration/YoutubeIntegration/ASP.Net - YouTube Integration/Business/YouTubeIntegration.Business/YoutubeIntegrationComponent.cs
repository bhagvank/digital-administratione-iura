using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using YoutubeIntegration.Entities;
using YoutubeIntegration.Data;
using System.Transactions;
using System.Linq;

//Business Component Layer for Youtube Integration
namespace YoutubeIntegration.Business
{
	/// <summary>
	/// Youtube Integration  component.
	/// </summary>
   public partial class YoutubeIntegrationComponent
    {
		/// <summary>
		/// Gets the list of News Media
		/// </summary>
		/// <param name="date">created date.</param>
		/// <returns>Returns the list of List<NewsMedia>.</returns>
		public List<NewsMedia> GetNewsMedia(DateTime date)
		{
			List<NewsMedia> result = default(List<NewsMedia>);
			var youtubeIntegrationDAC = new YoutubeIntegrationDAC ();

			result = youtubeIntegrationDAC.Select(date);

			return result;
		}
    }



}