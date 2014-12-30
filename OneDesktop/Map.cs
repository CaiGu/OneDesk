using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneDesktop
{
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
      
        }

        private void Map_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://map.baidu.com");
        }
    }
}
