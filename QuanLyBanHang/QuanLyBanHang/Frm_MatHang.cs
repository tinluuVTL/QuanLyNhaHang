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
    public partial class Frm_MatHang : Form
    {
        public Frm_MatHang()
        {
            InitializeComponent();
        }

        private void Frm_MatHang_Load(object sender, EventArgs e)
        {
            KetNoi();
            TaoBang("MatHang");
            DieuKien();
            Them_Cbosapxep();
            stutrip.Items[0].Text = "Tổng số mặt hàng:  " + ds.Tables["MatHang"].Rows.Count.ToString();
       
        }
        public static SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlCommandBuilder cmb;
        DataSet ds = new DataSet();
        SqlDataAdapter daLoaiHang;
        DataTable dtLoaiHang = new DataTable();
        public static void KetNoi()
        {
            string connectionstring;
            try
            {
                connectionstring = "server=.";
                connectionstring += ";database=HoaDon";
                connectionstring += ";integrated security=true";
                cnn.ConnectionString = connectionstring;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi " + ex.Message);
            }
        }

        private void TaoBang(String bang)
        {
            cmd = new SqlCommand("select * from " + bang, cnn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, bang);
        }
        private void DieuKien()
        {
            bs.DataSource = ds.Tables["MatHang"];
            dgvMatHang.DataSource = bs;
            cmd = new SqlCommand("SELECT MaLH, CONVERT(nvarchar,MaLH)+ ' ' +TenLH as Hoten FROM LoaiHang", cnn);
            daLoaiHang = new SqlDataAdapter();
            daLoaiHang.SelectCommand = cmd;
            daLoaiHang.Fill(dtLoaiHang);

            //
            txtMaMH.DataBindings.Clear();
            txtTenMH.DataBindings.Clear();
            txtDonViTinh.DataBindings.Clear();
            txtDonGia.DataBindings.Clear();
            txtSoTon.DataBindings.Clear();
            cbbMaLH.DataBindings.Clear();
            txtMaMH.DataBindings.Add("Text", bs, ds.Tables[0].Columns[0].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenMH.DataBindings.Add("Text", bs, ds.Tables[0].Columns[1].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtDonViTinh.DataBindings.Add("Text", bs, ds.Tables[0].Columns[2].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtDonGia.DataBindings.Add("Text", bs, ds.Tables[0].Columns[3].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTon.DataBindings.Add("Text", bs, ds.Tables[0].Columns[4].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            cbbMaLH.DataSource = dtLoaiHang;
            cbbMaLH.DisplayMember = dtLoaiHang.Columns[1].ColumnName;
            cbbMaLH.ValueMember = dtLoaiHang.Columns[0].ColumnName;
            cbbMaLH.DataBindings.Add("SelectedValue", bs, ds.Tables[0].Columns[5].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void Them_Cbosapxep()
        {
            int i, n;
            n = ds.Tables[0].Columns.Count;
            for (i = 0; i < n; i++)
            {
                cboCaccot.Items.Add(ds.Tables["MatHang"].Columns[i].ColumnName);
            }
            cboCaccot.Text = ds.Tables["MatHang"].Columns[0].ColumnName;
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {

            if (btnCheck.Text == "DESC")
                btnCheck.Text = "ASC";
            else
                btnCheck.Text = "DESC";
        }
        DataSet dsin = new DataSet();
        int a = 0;
        private void btnIn_Click(object sender, EventArgs e)
        {

            if (a == 1)
            {
                ds.Tables[0].DefaultView.RowFilter = "TenMH like '%" + txtTimkiem.Text + "%'";
                DataTable dt = ds.Tables[0].DefaultView.ToTable();
                if (dsin.Tables.Contains("MatHang"))
                {
                    dsin.Tables["MatHang"].Clear();
                    dsin.Tables["MatHang"].Merge(dt);
                }
                else
                {
                    dt.TableName = "MatHang";
                    dsin.Tables.Add(dt);
                }

            }

            Frm_In Frm = new Frm_In(int.Parse(txtMaMH.Text), dsin, 4);
            Frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = ds.Tables["MatHang"].GetChanges();
            //Nếu có sự thay đổi sẽ phát sinh các lệnh cập nhật
            if (tbl == null)
                MessageBox.Show("Dữ liệu chưa thay đổi");
            else
            {
                cmb = new SqlCommandBuilder(da);
                da.Update(ds, "MatHang");
                MessageBox.Show("Có " + tbl.Rows.Count + " dòng đã được cập nhật");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCheck_TextChanged(object sender, EventArgs e)
        {
            string direc = btnCheck.Text;
            ds.Tables[0].DefaultView.Sort = String.Format("[{0}] {1}", cboCaccot.Text, direc);
   
        }

        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            String St;
            if (e.KeyChar == 13)
            {
                a = 1;
                ds.Tables[0].DefaultView.RowFilter = "TenMH like '%" + txtTimkiem.Text + "%'";
                St = "Số mặt hàng tìm thấy được: " + ds.Tables[0].DefaultView.Count.ToString();
                St = St + "/" + ds.Tables["MatHang"].Rows.Count.ToString();
                stutrip.Items[0].Text = St;
            }
            else { a = 0; }
        }
    }
}
