using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace OneDesktop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        

       

       

        private void Music_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"C:\Program Files\Windows Media Player\wmplayer.exe";
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process pro = Process.Start(info);
            pro.WaitForExit();  
        }

        private void Music_btn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wmplayer.exe"); 

        }
        private void Game_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"C:\Users\gucai\Desktop\OneDesktop\2048\bin\Debug\My2048.exe";
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process pro = Process.Start(info);
            pro.WaitForExit();  
        }
        private void Game_btn_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"C:\Users\gucai\Desktop\OneDesktop\2048\bin\Debug\My2048.exe";
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process pro = Process.Start(info);
            pro.WaitForExit();  

        }


        private void Map_Click(object sender, EventArgs e)
        {
            new Map().Show();
            

        }

        private void Map_btn_Click(object sender, EventArgs e)
        {
            new Map().Show();
         

        }

        private void News_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"C:\Users\gucai\Desktop\OneDesktop\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\WindowsFormsApplication1.exe";
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process pro = Process.Start(info);
            pro.WaitForExit();  
        }

        private void News_btn_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"C:\Users\gucai\Desktop\OneDesktop\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\WindowsFormsApplication1.exe";
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process pro = Process.Start(info);
            pro.WaitForExit();  
        }

        private void Collection_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe"); 
        }

        private void Collection_btn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe"); 
           
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }
    }
}
