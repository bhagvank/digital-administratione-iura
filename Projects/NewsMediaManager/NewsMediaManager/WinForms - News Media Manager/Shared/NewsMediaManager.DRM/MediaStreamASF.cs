using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using WindowsMediaLib;
using WindowsMediaLib.Defs;

//DRM components for managing rights of news media
namespace NewsMediaManager.DRM
{
	/// <summary>
	/// MediaStream appended with ASF.
	/// </summary>
	public class MediaStreamASF
	{
		private int mFrameRate = 10; // # of Frames Per Second
		private BinaryWriter mediaWriter;
		public MediaStreamASF ()
		{
		}

		public void AppendASF(string locationURL,string licenseURL, string  licenseIssuerURL)
		{
			string header = string.Format(@"{0}\{1:00000000}.jpg", "asf", 1);
			Bitmap mBitmap = new Bitmap (header);

			FileStream writeStream = new FileStream (locationURL, FileMode.OpenOrCreate);

			mediaWriter = new BinaryWriter (writeStream);

			Initialize (mBitmap,licenseURL,licenseIssuerURL);

			mediaWriter.Close ();
		}

		/// <summary>
		/// Read the properties of the first bitmap to finish initializing the writer.
		/// </summary>
		/// <param name="bitmap">First bitmap</param>
		private void Initialize(Bitmap mBitmap,string licenseURL,string licenseIssuerURL)
		{
			AMMediaType mtype = new AMMediaType();
		
			VideoInfoHeader videoInfoHeader = new VideoInfoHeader();

			// Create the VideoInfoHeader using info from the bitmap
			videoInfoHeader.BmiHeader.Size = Marshal.SizeOf(typeof(BitmapInfoHeader));
			videoInfoHeader.BmiHeader.Width = mBitmap.Width;
			videoInfoHeader.BmiHeader.Height = mBitmap.Height;
			videoInfoHeader.BmiHeader.Planes = 1;                

			// compression thru clrimportant don't seem to be used. Init them anyway
			videoInfoHeader.BmiHeader.Compression = 0;
			videoInfoHeader.BmiHeader.ImageSize = 0;
			videoInfoHeader.BmiHeader.XPelsPerMeter = 0;
			videoInfoHeader.BmiHeader.YPelsPerMeter = 0;
			videoInfoHeader.BmiHeader.ClrUsed = 0;
			videoInfoHeader.BmiHeader.ClrImportant = 0;

			switch(hBitmap.PixelFormat)
			{
			case PixelFormat.Format32bppRgb:
				mtype.subType = MediaSubType.RGB32;
				videoInfoHeader.BmiHeader.BitCount = 32;
				break;
			case PixelFormat.Format24bppRgb:
				mtype.subType = MediaSubType.RGB24;
				videoInfo.BmiHeader.BitCount = 24;
				break;
			case PixelFormat.Format16bppRgb555:
				mtype.subType = MediaSubType.RGB555;
				videoInfo.BmiHeader.BitCount = 16;
				break;
			default:
				throw new Exception("Unrecognized Pixelformat in bitmap");
			}

			videoInfoHeader.SrcRect = new Rectangle(0, 0, mBitmap.Width, mBitmap.Height);
			videoInfoHeader.TargetRect = videoInfoHeader.SrcRect;
			videoInfo.BmiHeader.ImageSize = mBitmap.Width * mBitmap.Height * (videoInfoHeader.BmiHeader.BitCount / 8);
			videoInfo.BitRate = videoInfoHeader.BmiHeader.ImageSize * mFrameRate;
			videoInfo.BitErrorRate = 0;
			videoInfo.AvgTimePerFrame = 10000 * 1000 / mFrameRate;

			mtype.majorType = MediaType.Video;
			mtype.fixedSizeSamples = true;
			mtype.temporalCompression = false;
			mtype.sampleSize = mediaHeader.ImageSize;
			mtype.formatType = FormatType.VideoInfo;
			mtype.unkPtr = IntPtr.Zero;
			mtype.formatSize = Marshal.SizeOf(typeof(VideoInfoHeader));

			GCHandle gHandle = GCHandle.Alloc(mediaHeader, GCHandleType.Pinned);

			try
			{
				// Set the inputprops using the structures
				mtype.formatPtr = gHandle.AddrOfPinnedObject();

			
			}
			finally
			{
				gHan.Free();
				mt.formatPtr = IntPtr.Zero;
			}


			byte[] bytes = (byte[])mtype;
			mediaWriter.Write ( bytes);

		}

	}
}

