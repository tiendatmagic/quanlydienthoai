using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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



namespace quanlydienthoai
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string strconnect()
        {
            string strConnect = "Server=" + txb_Sever.Text + ";Database=" + txb_Database.Text +
                ";User Id=" + txb_User.Text + ";Password=" + txb_Password.Password + ";Integrated Security=SSPI";

            return strConnect;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            canceButton();
        }

        private void Connection(object sender, RoutedEventArgs e)
        {
            
                string connectionString = ConfigurationManager.ConnectionStrings["qldt"].ConnectionString;
                if (checkconnection.duplicateErrors(strconnect()))
                {
                   

                    MessageBox.Show("Kết nối thành công");
                    Window1 window1 = new Window1();
                    window1.Show();
                    this.Close();


                }


                else
                    MessageBox.Show("Kết Nối không thành công, hãy kiểm tra lại");
            

        }

        private void canceButton()
        {
            MessageBoxResult key = MessageBox.Show(
             "Bạn có muốn thoát?",
             "Thoát?",
             MessageBoxButton.YesNo,
             MessageBoxImage.Question,
             MessageBoxResult.No);
            if (key == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }


    }
}
// © 2020 Copyright by Tiendatmagic - All Rights Reserved | Designed by Tiendatmagic 😂