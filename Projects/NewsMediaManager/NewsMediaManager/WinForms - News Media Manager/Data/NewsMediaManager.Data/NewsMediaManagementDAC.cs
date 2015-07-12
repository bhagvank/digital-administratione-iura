using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsMediaManager.Entities;


// 
// Data Access Component for News Media Management
//This layer interacts with Entity Framework
//
namespace NewsMediaManager.Data
{
	/// <summary>
	/// News Media Management Data Access component.
	/// </summary>
    public partial class NewsMediaManagerDAC : DataAccessComponent
    {
		/// <summary>
		/// Retrieve List of News Media 
		/// </summary>
		/// <param name="date">Created Date</param>
		/// <returns>Returns a List of News Media</returns>
         public List<NewsMedia> Select(DateTime date)
          {
              using (var database = new DbContext(CONNECTION_NAME))
               {
                   IQueryable<NewsMedia> query = database.Set<NewsMedia>();

                   query = AppendFilters(query,date);

                   return query.ToList();
               }
 
          }

		/// <summary>
		/// Create News Media Content 
		/// </summary>
		/// <param name="newsMedia">newsMedia</param>
		/// <returns>Returns the news media content</returns>
         public NewsMedia Create(NewsMedia newsMedia)
         {
            using(var database = new DbContext(CONNECTION_NAME))
             {
                database.Set<NewsMedia>().Add(newsMedia);
                database.SaveChanges();

                return newsMedia;
             }

         }

		/// <summary>
		/// Update News Media Content 
		/// </summary>
		/// <param name="newsMedia">newsMedia</param>
		/// <returns>Returns the news media content</returns>
        public NewsMedia Update(NewsMedia newsMedia)
         {
             using (var database = new DbContext(CONNECTION_NAME))
              {
                 var entryMedia = database.Entry<NewsMedia>(newsMedia);

                 entryMedia.State = EntityState.Unchanged;

                 entryMedia.Property("Status").IsModified = true;

                 entryMedia.Property("Remarks").IsModified = true;

                 entryMedia.Property("IsCompleted").IsModified = true;

                 database.SaveChanges();

              }

         }

		/// <summary>
		/// Deletes the News Media Content 
		/// </summary>
		/// <param name="newsMedia">newsMedia</param>
		/// <returns>Returns the flag if deleted</returns>
        public Boolean Delete(NewsMedia newsMedia)
         {
             using (var database = new DbContext(CONNECTION_NAME))
             {
                var entryMedia = database.Entry<NewsMedia>(newsMedia);

                return database.DeleteObject(entryMedia);
             }

         }


    }




}