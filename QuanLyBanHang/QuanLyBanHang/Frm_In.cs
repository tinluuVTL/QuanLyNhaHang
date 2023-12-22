using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class Frm_In : Form
    {
        public Frm_In()
        {
            InitializeComponent();
        }

        private void Frm_In_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }
        public Frm_In(int maSo, DataSet dsin, int manhanbiet)
        {
            InitializeComponent();
            if (manhanbiet == 1)
            {
                InKhuVuc(maSo, dsin);
            }
            if (manhanbiet == 2)
            {
                InNhanVien(maSo, dsin);
            }
            if (manhanbiet == 3)
            {
                InKhachHang(maSo, dsin);
            }
            if (manhanbiet == 4)
            {
                InMatHang(maSo, dsin);
            }
            if (manhanbiet == 5)
            {
                InLoaiHang(maSo, dsin);
            }
            if (manhanbiet == 6)
            {
                InHoaDon(maSo, dsin);
            }
        }
        private void InHoaDon(int maSo, DataSet dsin)
        {
            SqlCommand cmd;
            cmd = new SqlCommand("sp_rptCTDH", dc.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SoHD", SqlDbType.Int).Value = maSo;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            //Khai báo chế độ xử lý báo cáo, trong trường hợp này lấy báo cáo ở local
            rpvBanIn.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //Đường dẫn báo cáo
            rpvBanIn.LocalReport.ReportPath = "rptCTDH.rdlc";
            //Nếu có dữ liệu
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "sp_rptCTDH";
                rds.Value = ds.Tables[0];
                //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                rpvBanIn.LocalReport.DataSources.Clear();
                //Add dữ liệu vào báo cáo
                rpvBanIn.LocalReport.DataSources.Add(rds);
                //Refresh lại báo cáo
                rpvBanIn.RefreshReport();
            }

        }

        private void InLoaiHang(int maSo, DataSet dsin)
        {
            SqlCommand cmd;
            cmd = new SqlCommand("sp_rptLoaiHang", dc.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@MaLH", SqlDbType.Int).Value = maSo;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds = dsin;
            adp.Fill(ds);

            //Khai báo chế độ xử lý báo cáo, trong trường hợp này lấy báo cáo ở local
            rpvBanIn.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //Đường dẫn báo cáo
            rpvBanIn.LocalReport.ReportPath = "rptLoaiHang.rdlc";
            //Nếu có dữ liệu
            if (dsin.Tables[0].Rows.Count > 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "sp_rptLoaiHang";
                rds.Value = dsin.Tables[0];
                //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                rpvBanIn.LocalReport.DataSources.Clear();
                //Add dữ liệu vào báo cáo
                rpvBanIn.LocalReport.DataSources.Add(rds);
                //Refresh lại báo cáo
                rpvBanIn.RefreshReport();
            }
        }

        private void InMatHang(int maSo, DataSet dsin)
        {
            SqlCommand cmd;
            cmd = new SqlCommand("sp_rptMatHang", dc.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaMH", SqlDbType.Int).Value = maSo;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds = dsin;
            adp.Fill(ds);

            //Khai báo chế độ xử lý báo cáo, trong trường hợp này lấy báo cáo ở local
            rpvBanIn.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //Đường dẫn báo cáo
            rpvBanIn.LocalReport.ReportPath = "rptMatHang.rdlc";
            //Nếu có dữ liệu
            if (dsin.Tables[0].Rows.Count > 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "sp_rptMatHang";
                rds.Value = dsin.Tables[0];
                //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                rpvBanIn.LocalReport.DataSources.Clear();
                //Add dữ liệu vào báo cáo
                rpvBanIn.LocalReport.DataSources.Add(rds);
                //Refresh lại báo cáo
                rpvBanIn.RefreshReport();
            }
        }

        private void InKhachHang(int maSo, DataSet dsin)
        {
            SqlCommand cmd;
            cmd = new SqlCommand("sp_rptKhachHang", dc.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = maSo;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds = dsin;
            adp.Fill(ds);

            //Khai báo chế độ xử lý báo cáo, trong trường hợp này lấy báo cáo ở local
            rpvBanIn.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //Đường dẫn báo cáo
            rpvBanIn.LocalReport.ReportPath = "rptKhachHang.rdlc";
            //Nếu có dữ liệu
            if (dsin.Tables[0].Rows.Count > 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "sp_rptKhachHang";
                rds.Value = dsin.Tables[0];
                //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                rpvBanIn.LocalReport.DataSources.Clear();
                //Add dữ liệu vào báo cáo
                rpvBanIn.LocalReport.DataSources.Add(rds);
                //Refresh lại báo cáo
                rpvBanIn.RefreshReport();
            }
        }

        private void InKhuVuc(int SoHD, DataSet dsin)
        {
            SqlCommand cmd;
            cmd = new SqlCommand("sp_rptKhuVuc", dc.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaKV", SqlDbType.Int).Value = SoHD;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds = dsin;
            adp.Fill(ds);

            //Khai báo chế độ xử lý báo cáo, trong trường hợp này lấy báo cáo ở local
            rpvBanIn.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //Đường dẫn báo cáo
            rpvBanIn.LocalReport.ReportPath = "rptKhuVuc.rdlc";
            //Nếu có dữ liệu
            if (dsin.Tables[0].Rows.Count > 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "sp_rptKhuVuc";
                rds.Value = dsin.Tables[0];
                //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                rpvBanIn.LocalReport.DataSources.Clear();
                //Add dữ liệu vào báo cáo
                rpvBanIn.LocalReport.DataSources.Add(rds);
                //Refresh lại báo cáo
                rpvBanIn.RefreshReport();
            }
        }
        private void InNhanVien(int SoHD, DataSet dsin)
        {
            SqlCommand cmd;
            cmd = new SqlCommand("sp_rptNhanVien", dc.cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaKV", SqlDbType.Int).Value = SoHD;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds = dsin;
            adp.Fill(ds);

            //Khai báo chế độ xử lý báo cáo, trong trường hợp này lấy báo cáo ở local
            rpvBanIn.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //Đường dẫn báo cáo
            rpvBanIn.LocalReport.ReportPath = "rptNhanVien.rdlc";
            //Nếu có dữ liệu
            if (dsin.Tables[0].Rows.Count > 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "sp_rptNhanVien";
                rds.Value = dsin.Tables[0];
                //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                rpvBanIn.LocalReport.DataSources.Clear();
                //Add dữ liệu vào báo cáo
                rpvBanIn.LocalReport.DataSources.Add(rds);
                //Refresh lại báo cáo
                rpvBanIn.RefreshReport();
            }
        }


    }
}
