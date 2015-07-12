
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using WindowsMediaLib;


// DRM layer for managing news media rights
namespace YoutubeIntegration.DRM
{
	/// <summary>
	/// DRM Header Query
	/// </summary>
	public class DRMHeaderQuery
	{

		IWMMetadataEditor m_pEditor;
		IWMMetadataEditor2 m_pEditor2;
		IWMDRMEditor m_pDRMEditor;

		//------------------------------------------------------------------------------
		// Name: CDRMHeaderQuery(()
		// Desc: Constructor.
		//------------------------------------------------------------------------------
		public DRMHeaderQuery()
		{
			WMUtils.WMCreateEditor(out m_pEditor);

			m_pEditor2 = (IWMMetadataEditor2)m_pEditor;

			m_pDRMEditor = (IWMDRMEditor)m_pEditor;
		}

		//------------------------------------------------------------------------------
		// Name: ~CDRMHeaderQuery(()
		// Desc: Destructor.
		//------------------------------------------------------------------------------
		~DRMHeaderQuery()
		{
			Close();

			if (m_pEditor != null)
			{
				Marshal.ReleaseComObject(m_pEditor);
				m_pEditor = null;
			}
		}

		//------------------------------------------------------------------------------
		// Name: Open()
		// Desc: Create the editor and open the file.
		//------------------------------------------------------------------------------
		public void Open(string fileName)
		{
			//
			//	We want to use OpenEx so that we can specify FILE_SHARE_READ access flag
			//	There is no need to lock the file, because we are only reading an attribute from it.
			//
			//	Otherwise, IWMMetadataEditor::Open() could well be used instead of this
			//	(also skipping the QI step for IWMMetadataEditor2)
			//

			m_pEditor2.OpenEx(fileName, MetaDataAccess.Read, MetaDataShare.Read);

		}

		//------------------------------------------------------------------------------
		// Name: Close()
		// Desc: Closes the file.
		//------------------------------------------------------------------------------//------------------------------------------------------------------------------
		public void Close()
		{
			m_pEditor.Close();
		}

		//------------------------------------------------------------------------------
		// Name: QueryProperty()
		// Desc: Gets the specified DRM property.
		//------------------------------------------------------------------------------
		private void QueryProperty(string propertyName, out byte[] pValue, out AttrDataType Wmt)
		{
			// variables to hold the query results after QueryProperty is called
			short wValueLength;

			if (null == m_pDRMEditor)
			{
				throw new Exception("Invalid request");
			}

			pValue = null;
			wValueLength = 0;

			m_pDRMEditor.GetDRMProperty(propertyName,
				out Wmt,
				pValue,
				ref wValueLength);

			pValue = new byte[wValueLength];

			m_pDRMEditor.GetDRMProperty(propertyName,
				out Wmt,
				pValue,
				ref wValueLength);
		}

		//------------------------------------------------------------------------------
		// Name: PrintProperty()
		// Desc: Display the specified property.
		//------------------------------------------------------------------------------
		public string GetPropertyAsString(string pwszPropertyName)
		{
			byte [] pValue;
			AttrDataType Wmt;

			QueryProperty(pwszPropertyName, out pValue, out Wmt);

			string sRet = null;

			switch (Wmt)
			{
			case AttrDataType.STRING:
				{
					sRet = Encoding.Unicode.GetString(pValue);
					break;
				}
			case AttrDataType.BOOL:
				{
					sRet = BitConverter.ToBoolean(pValue, 0).ToString();
					break;
				}
			case AttrDataType.WORD:
				{
					sRet = BitConverter.ToInt16(pValue, 0).ToString();
					break;
				}
			case AttrDataType.DWORD:
				{
					sRet = BitConverter.ToInt32(pValue, 0).ToString();
					break;
				}
			case AttrDataType.QWORD:
				{
					sRet = BitConverter.ToInt64(pValue, 0).ToString();
					break;
				}
			case AttrDataType.GUID:
				{
					sRet = new Guid(pValue).ToString();
					break;
				}
			case AttrDataType.BINARY:
				{
					if (pwszPropertyName.StartsWith(Constants.g_wszWMDRM_LicenseState))
					{
						LicenseStateData sd = new LicenseStateData(pValue);
						sRet = GetStringFromLicense(pwszPropertyName.Substring(Constants.g_wszWMDRM_LicenseState.Length), sd);
					}
					else
					{
						sRet = "Query successful, but cannot format for display";
					}
					break;
				}
			default:
				{
					sRet = "Query successful, but cannot format for display";
					break;
				}
			}
			return sRet;
		}

		private string GetStringFromLicense(string propertyString, LicenseStateData licenseStateData)
		{
			// These are my best guesses about about how to format this data.  MSDN
			// is pretty vague about the whole thing.
			DateTime d1, d2;
			string sReturn = "";

			for (int x = 0; x < licenseStateData.dwNumStates; x++)
			{
				switch (sd.stateData[x].dwCategory)
				{
				case LicenseStateCategory .NoRight:
					sReturn += string.Format("{0} not permitted.", propertyString);
					break;

				case LicenseStateCategory.UnLimited:
					sReturn += string.Format("{0} unlimited.", propertyString);
					break;

				case LicenseStateCategory.Count:
					sReturn += string.Format("{0} valid {1} times.", propertyString, licenseStateData.stateData[x].dwCount[0]);
					break;

				case LicenseStateCategory.From:
					d1 = FileTimeToDateTime(licenseStateData.stateData[x].datetime[0]);

					sReturn += string.Format("{0} valid from {1}.", propertyString, d1.ToShortDateString());
					break;

				case LicenseStateCategory.Until:
					d1 = FileTimeToDateTime(licenseStateData.stateData[x].datetime[0]);

					sReturn += string.Format("{0} valid until {1}.", propertyString, d1.ToShortDateString());
					break;

				case LicenseStateCategory.FromUntil:
					d1 = FileTimeToDateTime(licenseStateData.stateData[x].datetime[0]);
					d2 = FileTimeToDateTime(licenseStateData.stateData[x].datetime[1]);

					sReturn += string.Format("{0} valid from {1} to {2}.", propertyString, d1.ToShortDateString(), d2.ToShortDateString());
					break;

				case LicenseStateCategory.CountFrom:
					d1 = FileTimeToDateTime(licenseStateData.stateData[x].datetime[0]);

					sReturn += string.Format("{0} valid {1} times from {2}.", propertyString, licenseStateData.stateData[x].dwCount[0], d1.ToShortDateString());
					break;

				case LicenseStateCategory.CountUntil:
					d1 = FileTimeToDateTime(licenseStateData.stateData[x].datetime[0]);

					sReturn += string.Format("{0} valid {1} times until {2}.", propertyString, licenseStateData.stateData[x].dwCount[0], d1.ToShortDateString());
					break;

				case LicenseStateCategory.CountFromUntil:
					d1 = FileTimeToDateTime(licenseStateData.stateData[x].datetime[0]);
					d2 = FileTimeToDateTime(licenseStateData.stateData[x].datetime[1]);

					sReturn += string.Format("{0} valid {1} times from {2} to {3}.", propertyString, licenseStateData.stateData[x].dwCount[0], d1.ToShortDateString(), d2.ToShortDateString());
					break;

				case LicenseStateCategory.ExpirationAfterFristUse:
					sReturn += string.Format("{0} valid for {1} hours from first use.", propertyString, licenseStateData.stateData[x].dwCount[0]);
					break;

				default:
					sReturn += "Unrecognized state category";
					break;
				}

				if (x != sd.dwNumStates - 1)
				{
					sRet += "\n";
				}
			}

			return sRet;
		}

		private DateTime FileTimeToDateTime(long l)
		{
			return new DateTime(1601, 1, 1).Add(new TimeSpan(l));
		}

		#region IDisposable Members

		public void Dispose()
		{
			if (m_pEditor != null)
			{
				Marshal.ReleaseComObject(m_pEditor);
				m_pEditor = null;
			}
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
