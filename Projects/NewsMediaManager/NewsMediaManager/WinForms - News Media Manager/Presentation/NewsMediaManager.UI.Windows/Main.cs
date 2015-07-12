using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewsMediaManager.Entities;
using NewsMediaManager.UI.Process;
using System.Diagnostics;

//Windows Forms for News Media Manager
//
namespace NewsMediaManager.UI.Windows
{

	/// <summary>
	/// Windows Form for News Media Manager
	/// </summary>
   public partial class Main : Form
    {

       public Main()
        {
           InitializeComponent();
           LoadNewsMedia();
           
        }

       private void LoadNewsMedia()
        {

        }
    }



}