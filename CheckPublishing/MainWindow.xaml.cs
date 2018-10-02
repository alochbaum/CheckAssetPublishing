using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckPublishing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Asset> lAss = new List<Asset>();
        public MainWindow()
        {
            InitializeComponent();
            // Adding the version number to the title
            MainWin.Title = Assembly.GetExecutingAssembly().GetName().Version +
                " Program checks Asset Publishing in XMS and EXMS databases.";
        }

        private void btTestXMS_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Length > 2) {
                DataAccess db = new DataAccess();
                lAss= db.GetDAssets(tbName.Text,"XMS");
                tbOut.Text =  lAss[0].master_state.ToString();
                Result.Content = $"XMS type {lAss[0].asset_type}";
            } else
            {
                MessageBox.Show("In asset name type the name of a clip or image");
            }
        }

        private void btTestEXMS_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Length > 2)
            {
                DataAccess db = new DataAccess();
                lAss = db.GetDAssets(tbName.Text, "EXMS", tbIP.Text);
                tbOut2.Text = lAss[0].master_state.ToString();
                Result.Content = $"EXMS type {lAss[0].asset_type}";
            }
            else
            {
                MessageBox.Show("In asset name type the name of a clip or image");
            }
        }

        private void btnAppData_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", AppDomain.CurrentDomain.BaseDirectory + "\\CheckPublishing.exe.config");
        }
    }
}
