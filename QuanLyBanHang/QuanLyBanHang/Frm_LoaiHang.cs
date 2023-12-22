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
    public partial class Frm_LoaiHang : Form
    {
        public Frm_LoaiHang()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (btnCheck.Text == "DESC")
                btnCheck.Text = "ASC";
            else
                btnCheck.Text = "DESC";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (a == 1)
            {
                ds.Tables[0].DefaultView.RowFilter = "TenLH like '%" + txtTimkiem.Text + "%'";
                DataTable dt = ds.Tables[0].DefaultView.ToTable();
                if (dsin.Tables.Contains("LoaiHang"))
                {
                    dsin.Tables["LoaiHang"].Clear();
                    dsin.Tables["LoaiHang"].Merge(dt);
                }
                else
                {
                    dt.TableName = "LoaiHang";
                    dsin.Tables.Add(dt);
                }

            }

            Frm_In Frm = new Frm_In(1, dsin, 5);
            Frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = ds.Tables["LoaiHang"].GetChanges();
            //Nếu có sự thay đổi sẽ phát sinh các lệnh cập nhật
            if (tbl == null)
                MessageBox.Show("Dữ liệu chưa thay đổi");
            else
            {
                cmb = new SqlCommandBuilder(da);
                da.Update(ds, "LoaiHang");
                MessageBox.Show("Có " + tbl.Rows.Count + " dòng đã được cập nhật");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void Frm_LoaiHang_Load(object sender, EventArgs e)
        {

            KetNoi();
            TaoBang("LoaiHang");
            DieuKien();
            Them_Cbosapxep();
            stutrip.Items[0].Text = "Tổng số loại hàng :  " + ds.Tables["LoaiHang"].Rows.Count.ToString();
        
        }
        public static SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlCommandBuilder cmb;
        DataSet ds = new DataSet();
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
            bs.DataSource = ds.Tables["LoaiHang"];
            dgvLoaiHang.DataSource = bs;

            txtMaLH.DataBindings.Clear();
            txtTenLH.DataBindings.Clear();
            txtMaLH.DataBindings.Add("Text", bs, ds.Tables[0].Columns[0].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenLH.DataBindings.Add("Text", bs, ds.Tables[0].Columns[1].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);

        }
        private void Them_Cbosapxep()
        {
            int i, n;
            n = ds.Tables[0].Columns.Count;
            for (i = 0; i < n; i++)
            {
                cboCaccot.Items.Add(ds.Tables["LoaiHang"].Columns[i].ColumnName);
            }
            cboCaccot.Text = ds.Tables["LoaiHang"].Columns[0].ColumnName;
        }

        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            String St;
            if (e.KeyChar == 13)
            {
                a = 1;
                ds.Tables[0].DefaultView.RowFilter = "TenLH like '%" + txtTimkiem.Text + "%'";
                St = "Số loại hàng tìm thấy được: " + ds.Tables[0].DefaultView.Count.ToString();
                St = St + "/" + ds.Tables["LoaiHang"].Rows.Count.ToString();
                stutrip.Items[0].Text = St;
            }
            else { a = 0; }
        }
        DataSet dsin = new DataSet();
        int a = 0;
        private void btnCheck_TextChanged(object sender, EventArgs e)
        {
            string direc = btnCheck.Text;
            ds.Tables[0].DefaultView.Sort = String.Format("[{0}] {1}", cboCaccot.Text, direc);
      
        }

    }
}
