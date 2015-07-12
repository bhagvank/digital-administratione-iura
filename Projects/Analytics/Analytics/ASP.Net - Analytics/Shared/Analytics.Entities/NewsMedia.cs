using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Analytics.Entities
{
	/// <summary>
	/// Represents a row of NewsMedia data.
	/// </summary>
      [DataContract]
      public partial class NewsMedia
      {
         public NewsMedia()
          {
 
          }

		/// <summary>
		/// Gets or sets a long value for the NewsMediaID column.
		/// </summary>
          [DataMember]
          [Browsable(false)]
          public long NewsMediaID { get; set;}


		/// <summary>
		/// Gets or sets a Guid value for the CategoryID column.
		/// </summary>
          [DataMember]
          public Guid CategoryID { get; set;}

		/// <summary>
		/// Gets or sets a Date value for the CreatedDate column.
		/// </summary>
          [DataMember]
          public DateTime CreatedDate {get; set;}

		/// <summary>
		/// Gets or sets a string value for the Status column.
		/// </summary>
          [DataMember]
          public string Status { get; set;}

		/// <summary>
		/// Gets or sets a string value for the LocationURL column.
		/// </summary>
          [DataMember]
          public string LocationURL {get; set;}
		/// <summary>
		/// Gets or sets a string value for the LicenseURL column.
		/// </summary>
		[DataMember]
		public string LicenseURL { get; set; }

		/// <summary>
		/// Gets or sets a string value for the LicenseURL column.
		/// </summary>
		[DataMember]
		public string LicenseIssuerURL { get; set; }

      }



}