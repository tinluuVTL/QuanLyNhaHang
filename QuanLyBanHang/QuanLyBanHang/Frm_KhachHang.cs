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
    public partial class Frm_KhachHang : Form
    {
        public Frm_KhachHang()
        {
            InitializeComponent();
        }

        private void Frm_KhachHang_Load(object sender, EventArgs e)
        {
            KetNoi();
            TaoBang("KhachHang");
            DieuKien();
            Them_Cbosapxep();
            stutrip.Items[0].Text = "Tổng số khách hàng :  " + ds.Tables["KhachHang"].Rows.Count.ToString();
      
        }

        public static SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlCommandBuilder cmb;
        DataSet ds = new DataSet();
        DataSet dsin = new DataSet();
        int a = 0;
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
            bs.DataSource = ds.Tables["KhachHang"];
            dgvKhachHang.DataSource = bs;

            //

            txtMaKH.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            txtDCKH.DataBindings.Clear();
            txtDTKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", bs, ds.Tables[0].Columns[0].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenKH.DataBindings.Add("Text", bs, ds.Tables[0].Columns[1].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtDCKH.DataBindings.Add("Text", bs, ds.Tables[0].Columns[2].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtDTKH.DataBindings.Add("Text", bs, ds.Tables[0].Columns[3].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void Them_Cbosapxep()
        {
            int i, n;
            n = ds.Tables[0].Columns.Count;
            for (i = 0; i < n; i++)
            {
                cboCaccot.Items.Add(ds.Tables["KhachHang"].Columns[i].ColumnName);
            }
            cboCaccot.Text = ds.Tables["KhachHang"].Columns[0].ColumnName;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (a == 1)
            {
                ds.Tables[0].DefaultView.RowFilter = "TenKH like '%" + txtTimkiem.Text + "%'";
                DataTable dt = ds.Tables[0].DefaultView.ToTable();
                if (dsin.Tables.Contains("KhachHang"))
                {
                    dsin.Tables["KhachHang"].Clear();
                    dsin.Tables["KhachHang"].Merge(dt);
                }
                else
                {
                    dt.TableName = "KhachHang";
                    dsin.Tables.Add(dt);
                }
            }

            Frm_In Frm = new Frm_In(int.Parse(txtMaKH.Text), dsin, 3);
            Frm.Show();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (btnCheck.Text == "DESC")
                btnCheck.Text = "ASC";
            else
                btnCheck.Text = "DESC";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = ds.Tables["KhachHang"].GetChanges();
            //Nếu có sự thay đổi sẽ phát sinh các lệnh cập nhật
            if (tbl == null)
                MessageBox.Show("Dữ liệu chưa thay đổi");
            else
            {
                cmb = new SqlCommandBuilder(da);
                da.Update(ds, "KhachHang");
                MessageBox.Show("Có " + tbl.Rows.Count + " dòng đã được cập nhật");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            String St;
            if (e.KeyChar == 13)
            {
                a = 1;
                ds.Tables[0].DefaultView.RowFilter = "TenKH like '%" + txtTimkiem.Text + "%'";
                St = "Số khách hàng tìm thấy được: " + ds.Tables[0].DefaultView.Count.ToString();
                St = St + "/" + ds.Tables["KhachHang"].Rows.Count.ToString();
                stutrip.Items[0].Text = St;
            }
            else { a = 0; }
        }

        private void btnCheck_TextChanged(object sender, EventArgs e)
        {
            string direc = btnCheck.Text;
            ds.Tables[0].DefaultView.Sort = String.Format("[{0}] {1}", cboCaccot.Text, direc);
   
        }
    }
}
