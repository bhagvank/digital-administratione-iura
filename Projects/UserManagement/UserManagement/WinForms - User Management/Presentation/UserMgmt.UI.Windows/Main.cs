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
using UserManagement.Entities;
using UserManagement.UI.Process;
using System.Diagnostics;

namespace UserManagement.UI.Windows
{
  public partial class Main : Form
  {
     public Main()
      {
        InitializeComponent();
        LoadUsers();
      }

     private void LoadUsers()
      {

      }
  }


}