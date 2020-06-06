using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;
using OpenQA.Selenium;

namespace quanlydienthoai
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int cndl=0;
        
        public Window1()
        {
            InitializeComponent();
            
        }
        // © 2020 Copyright by Tiendatmagic - All Rights Reserved | Designed by Tiendatmagic 😂
        private void btnKetnoi_Click(object sender, RoutedEventArgs e)
        {
            try

            {

                using (SqlConnection connection =

                    new SqlConnection(@"Server=DESKTOP-6N9SC5N;Database=quanlydienthoai; Integrated Security=SSPI"))

                {

                    connection.Open();

                }

                MessageBox.Show("Mo va dong co so du lieu thanh cong(KETNOI).");

            }

            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo  ket noi: " + ex.Message);

            }
        }

        private void btnDulieu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-6N9SC5N;Database=quanlydienthoai; Integrated Security=SSPI"))
                using (SqlCommand command =
                    new SqlCommand("select DIENTHOAI.ma, DIENTHOAI.ten, DIENTHOAI.dongia, DIENTHOAI.tonkho, DIENTHOAI.mahang from DIENTHOAI,HANGSX where DIENTHOAI.mahang = HANGSX.mahang and HANGSX.tenhang=" + "'" + cbmakh.Text + "';", connection))

                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(danhsach);
                    }
                }


                
                dulieu.ItemsSource = danhsach.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }

           
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Them_dien_thoai(DienThoai dienthoaii)
        {


        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            

            MessageBoxResult key = MessageBox.Show(
             "Bạn có muốn xóa?",
             "Xóa?",
             MessageBoxButton.YesNo,
             MessageBoxImage.Question,
             MessageBoxResult.No);
            if (key == MessageBoxResult.No)
            {
                return;
            }
            else
            {

                {

                    if (txtma.Text == "")
                    {
                        MessageBox.Show("Không được bỏ trống mã hàng");
                    }

                    else
                    {
                        DienThoai sv = new DienThoai();
                        sv.ma = txtma.Text;
                        sv.tonkho = txttonkho.Text;
                        Xoa_dien_thoai(sv);
                    }
                }  
                        

            }
            
            
        }



        private void Xoa_dien_thoai(DienThoai dienthoaii)
        {
            
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-6N9SC5N;Database=quanlydienthoai; Integrated Security=SSPI"))
                using (SqlCommand command =
                new SqlCommand("SELECT * FROM Dienthoai;", connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                {
                    adapter.FillSchema(danhsach, SchemaType.Source);
                    adapter.Fill(danhsach);
                    //DataRow[] dt = danhsach.Select("ma = '" + dienthoaii.ma + "'");

                    DataRow[] dt = danhsach.Select(
                    "ma = '" + dienthoaii.ma + "'");






                    if ((int)dt[0]["tonkho"] == 0)
                    {



                        MessageBoxResult key = MessageBox.Show(
                        "Bạn muốn xóa dòng điện thoại này khỏi cơ sở dữ liệu?",
                        "Xóa?",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question,
                        MessageBoxResult.No);
                        if (key == MessageBoxResult.No)
                        {
                            return;
                        }
                        else
                        {
                            danhsach.Select("ma = '" + dienthoaii.ma + "'");
                            dt[0].Delete();
                            adapter.Update(dt);
                            MessageBox.Show("Xóa dữ liệu thành công!");
                            dulieu.ItemsSource = danhsach.DefaultView;
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Khong thể xóa vì còn hàng");
                    }
                        
                    
                }

                
               
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }
            
        }

        private void btnCapnhat_Click(object sender, RoutedEventArgs e)
        {
            if (cndl == 1)
            {

                MessageBoxResult key = MessageBox.Show(
                 "Bạn có muốn cập nhật dữ liệu?",
                 "Cập nhật kho",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Question,
                 MessageBoxResult.No);
                if (key == MessageBoxResult.No)
                {
                    return;
                }
                else
                {



                    if (txtma.Text.Length == 0 || txtdongia.Text.Length == 0 || txttonkho.Text.Length == 0)
                    {
                        MessageBox.Show("Không được bỏ trống");
                    }

                    else



                    {
                        int a = int.Parse(txtdongia.Text);
                        int b = int.Parse(txttonkho.Text);

                        if (a < 0 || b < 0)
                        {
                            MessageBox.Show("Không thể nhập số âm");
                        }
                        else
                        {



                            if (a % 1000 != 0)
                            {
                                MessageBox.Show("Đơn giá cần phải chia hết cho 1000", "Dữ liệu lỗi");
                            }
                            else
                            {
                                DienThoai sv = new DienThoai();
                                txtma.MaxLength = 9;
                                sv.ma = txtma.Text;
                                sv.dongia = txtdongia.Text;
                                sv.tonkho = txttonkho.Text;
                                //Cap_nhat_dien_thoai(sv);
                                /*sv.mahang = txtma.Text;
                                sv.dongia = txtdongia.Text;
                                sv.tonkho = txttonkho.Text;*/
                                checktanggiamgia(sv);
                            }                           


                        }

                    }
              
                }               


            }
            
            else
            {
                MessageBox.Show("Dữ liệu bị khóa");
            }   

        }





        private void Cap_nhat_dien_thoai(DienThoai dienthoaii)
        {
            
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-6N9SC5N;Database=quanlydienthoai; Integrated Security=SSPI"))
                using (SqlCommand command =
                new SqlCommand("SELECT * FROM Dienthoai;", connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                {
                    adapter.FillSchema(danhsach, SchemaType.Source);
                    adapter.Fill(danhsach);
                    DataRow[] dt = danhsach.Select(
                    "ma = '" + dienthoaii.ma + "'");
                    dt[0]["dongia"] = dienthoaii.dongia;
                    dt[0]["tonkho"] = dienthoaii.tonkho;
                    
                    adapter.Update(danhsach);                   
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                    dulieu.ItemsSource = danhsach.DefaultView;
                }

    


                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }
            
        }

        private void checktanggiamgia(DienThoai dienthoaii)
        {
            int dongiaa;
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-6N9SC5N;Database=quanlydienthoai; Integrated Security=SSPI"))
                using (SqlCommand command =
                new SqlCommand("SELECT * FROM Dienthoai;", connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                {
                    adapter.FillSchema(danhsach, SchemaType.Source);
                    adapter.Fill(danhsach);
                   
                    DataRow[] dt = danhsach.Select(
                    "ma = '" + dienthoaii.ma + "'");
                    dongiaa = (int)dt[0]["dongia"];
                }

                if (dongiaa > Int32.Parse(txtdongia.Text))
                {
                    //GiamGia(dienthoaii);
                    MessageBoxResult key = MessageBox.Show(
                     "Mặt hàng điện thoại này giảm giá?",
                     "Thông báo",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Question,
                     MessageBoxResult.No);
                    if (key == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        Cap_nhat_dien_thoai(dienthoaii);
                    }
                }
                  
                else
                {
                    
                    MessageBoxResult key = MessageBox.Show(
                     "Mặt hàng điện thoại này tăng giá?",
                     "Thông báo",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Question,
                     MessageBoxResult.No);
                    if (key == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        Cap_nhat_dien_thoai(dienthoaii);
                    }
                }
                    
                    
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi " + ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-6N9SC5N;Database=quanlydienthoai; Integrated Security=SSPI"))
                using (SqlCommand command =
                    new SqlCommand("SELECT tenhang FROM HANGSX; ", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(danhsach);
                    }
                }

                cbmakh.ItemsSource = danhsach.DefaultView;
                cbmakh.DisplayMemberPath = "tenhang";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }

        }

        private void cbmakh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDulieuall_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-6N9SC5N;Database=quanlydienthoai; Integrated Security=SSPI"))
                using (SqlCommand command =
                    new SqlCommand("SELECT * from DIENTHOAI; ", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(danhsach);
                    }
                }
                
                dulieu.ItemsSource = danhsach.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }
        }

        private void ch_cn_Click(object sender, RoutedEventArgs e)
        {
            if (ch_cn.IsChecked == true)

                cndl = 1;

            if (ch_cn.IsChecked == false)

                cndl = 0;

        }

        private void ch_cn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void txtdongia_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
// © 2020 Copyright by Tiendatmagic - All Rights Reserved | Designed by Tiendatmagic 😂