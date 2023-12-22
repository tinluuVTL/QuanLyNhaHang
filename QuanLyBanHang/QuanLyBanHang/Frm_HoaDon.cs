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
    public partial class Frm_HoaDon : Form
    {
        public Frm_HoaDon()
        {
            InitializeComponent();
        }
        SqlDataAdapter daKhachHang;
        DataTable dtKhachHang = new DataTable();
        SqlDataAdapter daNhanvien;
        DataTable dtNhanvien = new DataTable();

        private void Frm_HoaDon_Load(object sender, EventArgs e)
        {
            bs.BindingComplete += new BindingCompleteEventHandler(bs_BindingComplete);
            Datquanhe("HoaDon", "CTDH");
            dc.cb = new SqlCommandBuilder(dc.daCon);
            BuocCacDieuKien();
        }

        private void Datquanhe(string bangchinh, string bangphu)
        {

            dc.cmdCha = new SqlCommand("Select * from " + bangchinh, dc.cnn);
            dc.daCha = new SqlDataAdapter(dc.cmdCha);
            dc.cmdCon = new SqlCommand("Select * from " + bangphu, dc.cnn);
            dc.daCon = new SqlDataAdapter(dc.cmdCon);
            dc.ds = new DataSet();
            dc.daCha.Fill(dc.ds, bangchinh);
            dc.daCon.Fill(dc.ds, bangphu);
        }
        private void BuocCacDieuKien()
        {
            bs.DataSource = dc.ds.Tables["CTDH"];
            dgvCTDH.DataSource = bs;

            dc.cmd = new SqlCommand("SELECT MaKH, CONVERT(nvarchar,MaKH)+ ' ' +TenKH as Hoten FROM KhachHang", dc.cnn);
            daKhachHang = new SqlDataAdapter();
            daKhachHang.SelectCommand = dc.cmd;
            daKhachHang.Fill(dtKhachHang);

            dc.cmd = new SqlCommand("SELECT MaNV, CONVERT(nvarchar,MaNV)+ ' ' + Ho + ' ' +Ten as Hoten FROM NhanVien", dc.cnn);
            daNhanvien = new SqlDataAdapter();
            daNhanvien.SelectCommand = dc.cmd;
            daNhanvien.Fill(dtNhanvien);


            txtSoHD.DataBindings.Add("Text", dc.ds, "HoaDon.SoHD");
            txtNgayGiao.DataBindings.Add("Text", dc.ds, "HoaDon.NgayHD");
            txtNgayHD.DataBindings.Add("Text", dc.ds, "HoaDon.NgayGiao");
            cbbMaNV.DataSource = dtNhanvien;
            cbbMaNV.DisplayMember = dtNhanvien.Columns[1].ColumnName;
            cbbMaNV.ValueMember = dtNhanvien.Columns[0].ColumnName;
            cbbMaNV.DataBindings.Add("SelectedValue", dc.ds, "HoaDon.MaNV");
            // txtMaNV.DataBindings.Add("Text", dc.ds, "HoaDon.MaNV");
            cbbMaKH.DataSource = dtKhachHang;
            cbbMaKH.DisplayMember = dtKhachHang.Columns[1].ColumnName;
            cbbMaKH.ValueMember = dtKhachHang.Columns[0].ColumnName;
            cbbMaKH.DataBindings.Add("SelectedValue", dc.ds, "HoaDon.MaKH");


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = dc.ds.Tables["CTDH"].GetChanges();
            //Nếu có sự thay đổi sẽ phát sinh các lệnh cập nhật
            if (tbl == null)
                MessageBox.Show("Dữ liệu chưa thay đổi");
            else
            {
                dc.cmb = new SqlCommandBuilder(dc.daCon);
                dc.daCon.Update(dc.ds, "CTDH");
                MessageBox.Show("Có " + tbl.Rows.Count + " dòng đã được cập nhật");

            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            Frm_Detail frm = new Frm_Detail(bs, dc.ds.Tables[1]);
            frm.Show();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Frm_In Frm = new Frm_In(int.Parse(txtSoHD.Text), dc.ds, 6);
            Frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.BindingContext[dc.ds, dc.ds.Tables[0].TableName].Position = 0;
    
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            this.BindingContext[dc.ds, dc.ds.Tables[0].TableName].Position--;
      
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.BindingContext[dc.ds, dc.ds.Tables[0].TableName].Position++;
      
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int Vitri_cuoi = this.BindingContext[dc.ds, dc.ds.Tables[0].TableName].Count - 1;
            this.BindingContext[dc.ds, dc.ds.Tables[0].TableName].Position = Vitri_cuoi;
     
        }

        private void bs_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate
                && e.Exception == null)
            {

                e.Binding.BindingManagerBase.EndCurrentEdit();
            }
        }

    }
}
