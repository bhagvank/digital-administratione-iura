using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeIntegration.Entities;


//Data Access Layer for Youtube Integration
namespace YoutubeIntegration.Data
{

	/// <summary>
	/// Youtube Integration  Data Access component.
	/// </summary>
    public partial class YoutubeIntegrationDAC : DataAccessComponent
    {
		/// <summary>
		/// Gets the list of News Media
		/// </summary>
		/// <param name="date">created date.</param>
		/// <returns>Returns the list of List<NewsMedia>.</returns>
         public List<NewsMedia> Select(DateTime date)
          {
              using (var database = new DbContext(CONNECTION_NAME))
               {
                   IQueryable<NewsMedia> query = database.Set<NewsMedia>();

                   query = AppendFilters(query,date);

                   return query.ToList();
               }
 
          }
	}
}