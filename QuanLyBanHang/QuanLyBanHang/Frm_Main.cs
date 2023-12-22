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
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            dc.ketnoi();
        }

        private void mnKhuVuc_Click(object sender, EventArgs e)
        {
            Frm_KhuVuc frm_KhuVuc = new Frm_KhuVuc();
            frm_KhuVuc.ShowDialog();
        }

        private void mnMatHang_Click(object sender, EventArgs e)
        {
            Frm_MatHang frm_MatHang = new Frm_MatHang();
            frm_MatHang.ShowDialog();
        }

        private void mnNhanVien_Click(object sender, EventArgs e)
        {
            Frm_NhanVien frm_NhanVien = new Frm_NhanVien();
            frm_NhanVien.ShowDialog();
        }

        private void mnKhachHang_Click(object sender, EventArgs e)
        {

            Frm_KhachHang frm_KhachHang = new Frm_KhachHang();
            frm_KhachHang.ShowDialog();
        }

        private void mnLoaiHang_Click(object sender, EventArgs e)
        {
            Frm_LoaiHang frm_LoaiHang = new Frm_LoaiHang();
            frm_LoaiHang.ShowDialog();
        }

        private void mnHoaDon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon frm_HoaDon = new Frm_HoaDon();
            frm_HoaDon.ShowDialog();
        }
    }
}
public static class dc
{
    public static SqlDataAdapter da;
    public static SqlDataAdapter daCha;
    public static SqlDataAdapter daCon;
    public static DataTable dt = new DataTable();
    public static SqlCommand cmd;
    public static SqlCommand cmdCha;
    public static SqlCommand cmdCon;
    public static SqlCommandBuilder cmb;
    public static BindingSource bs = new BindingSource();
    public static DataSet ds;
    public static SqlCommandBuilder cb;
    public static SqlConnection cnn = new SqlConnection();
    public static string connectionstring;
    public static void ketnoi()
    {
        try
        {
            connectionstring = "server = .";
            connectionstring += ";database=HoaDon";
            connectionstring += ";integrated security=true";
            dc.cnn.ConnectionString = connectionstring;
            dc.cnn.Open();
        }
        catch (Exception e)
        {
            MessageBox.Show("Loi ket noi " + e.Message);
        }
    }
}