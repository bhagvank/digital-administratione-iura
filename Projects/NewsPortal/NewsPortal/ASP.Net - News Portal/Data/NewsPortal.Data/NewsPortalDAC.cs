using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Entities;

//Data Access Layer for NewsPortal
namespace NewsPortal.Data
{
	/// <summary>
	/// NewsPortal Data Access Component
	/// </summary>
   public partial class NewsPortalDAC : DataAccessComponent
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