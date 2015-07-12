using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analytics.Entities;

//Data Access Layer for Analytics
namespace Analytics.Data
{

	/// <summary>
	/// Analytics data access component
	/// </summary>
   public partial class AnalyticsDAC : DataAccessComponent
    {
		/// <summary>
		/// Gets the List of News Media created on a date
		/// </summary>
		/// <param name="date"> date value.</param>
		/// <returns>Returns a List<NewsMedia> object.</returns>
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