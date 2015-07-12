using System;
using System.Drawing;
using System.Drawing.Imaging;


//DRM layer for managing news media rights
namespace NewsMediaManager.DRM
{
	public class MediaHeader
	{
		public MediaHeader ()
		{
		}

		public long Size { get; set;}

		public long Width { get; set;}

		public long Height { get; set;}

		public int Planes { get; set;}

		public int Compression { get; set;}

		public int ImageSize { get; set;}

		public int XPelsPerMeter { get; set;}

		public int YPelsPerMeter { get; set;}

		public int ClrUsed { get; set;}

		public int ClrImportant { get; set;}
			
		public int BitCount { get; set;}

		public Rectangle SrcRect { get; set; }

		public Rectangle TargetRect { get; set; }

		public int BitRate { get; set; }

		public int BitErrorRate { get; set; }

		public long AvgTimePerFrame { get; set; }

		public bool FixedSizeSamples { get; set; }

		public bool TemporalCompression { get; set; }

		public int SampleSize { get; set; }

		public int UnkPtr { get; set; }

		public int FormatSize { get; set; }

		public string LicenseAcquisitionURL { get; set; }

		public string LicenseIssuerURL { get; set; }

	}
}

