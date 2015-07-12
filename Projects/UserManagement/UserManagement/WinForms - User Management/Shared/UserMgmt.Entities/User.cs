using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace UserManagement.Entities
{
	/// <summary>
	/// Represents a row of User data.
	/// </summary>
   [DataContract]
   public partial class User
   {
       public User()
       {

       }

		/// <summary>
		/// Gets or sets a long value for the UserID column.
		/// </summary>
       [DataMember]
       [Browsable(false)]
        public long UserID { get; set;}

		/// <summary>
		/// Gets or sets a Date value for the CreatedDate column.
		/// </summary>
       [DataMember]
       public DateTime CreatedDate {get; set;}

		/// <summary>
		/// Gets or sets a String value for the UserName column.
		/// </summary>
       [DataMember]
       public string UserName { get; set;}

		/// <summary>
		/// Gets or sets a String value for the Name column.
		/// </summary>
       [DataMember]
       public string Name { get; set;}

   }



}