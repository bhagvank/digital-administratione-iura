using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using System.Runtime.InteropServices;
using WindowsMediaLib;

//DRM components for managing news media rights
namespace NewsMediaManager.DRM
{
	/// <summary>
	/// Media Stream
	/// </summary>
	public class MediaStream : IStream, COMBase
	{
		BinaryReader media_File;

		public MediaStream ()
		{
		}

		~MediaStream()
		{
			Close();
		}

		/// <summary>
		/// Opens a news media file  
		/// </summary>
		/// <param name="locationURL">location of the content</param>
		public void Open(string locationURL)
		{
			Close();

			//
			// Open the file
			//
			media_File = new BinaryReader(new FileStream(locationURL, FileMode.Open, FileAccess.Read));
		}

		/// <summary>
		/// Closes a news media file  
		/// </summary>

		public void Close()
		{
			if (media_File != null)
			{
				media_File.Close();
				media_File = null;
			}
		}

		#region IStream Members

		public void Clone(out IStream istream)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void Commit(int commitFlags)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void CopyTo(IStream istream, long nBytes, IntPtr readPcb, IntPtr writtenPcb)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void LockRegion(long offset, long sizeCB, int lockType)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void Read(byte[] vector, int sizeCB, IntPtr readPCB)
		{
			if (null == media_File)
			{
				throw new COMException("File not open", E_Unexpected);
			}
			int i = media_File.Read(vector, 0, sizeCB);

			if (readPCB != IntPtr.Zero)
			{
				Marshal.WriteInt32(readPCB, i);
			}
		}

		public void Revert()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void Seek(long moveLibdl, int origin, IntPtr newPosition)
		{
			if (null == media_File)
			{
				throw new COMException("File not open", E_Unexpected);
			}

			long length = media_File.BaseStream.Seek(moveLibdl, (SeekOrigin)origin);
		}

		public void SetSize(long libNewSize)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void Stat(out System.Runtime.InteropServices.ComTypes.STATSTG pstat, int statFlag)
		{
			if (1 != statFlag)
			{
				throw new COMException("Bad arg to Stat", E_InvalidArgument);
			}

			if (null == media_File)
			{
				throw new COMException("File not open", E_Unexpected);
			}

			pstat = new System.Runtime.InteropServices.ComTypes.STATSTG();
			pstat.cbSize = media_file.BaseStream.Length;
			pstat.type = 2;

		}

		public void UnlockRegion(long offset, long lenCB, int lockType)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void Write(byte[] vector, int lenCB, IntPtr writtenPCB)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion
	}
}

