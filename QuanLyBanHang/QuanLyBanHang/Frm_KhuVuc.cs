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
    public partial class Frm_KhuVuc : Form
    {
        public Frm_KhuVuc()
        {
            InitializeComponent();
        }

        private void Frm_KhuVuc_Load(object sender, EventArgs e)
        {

            KetNoi();
            TaoBang("KhuVuc");
            DieuKien();
            Them_Cbosapxep();
            stutrip.Items[0].Text = "Tổng số Khu vực :  " + ds.Tables["KhuVuc"].Rows.Count.ToString();
       
        }
        public static SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlCommandBuilder cmb;
        DataSet ds = new DataSet();
        DataSet dsin = new DataSet();
        SqlDataAdapter daNhanvien;
        DataTable dtNhanvien = new DataTable();
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
            bs.DataSource = ds.Tables["KhuVuc"];
            dgvKhuVuc.DataSource = bs;
            cmd = new SqlCommand("SELECT MaNV, CONVERT(nvarchar,MaNV)+ ' ' + Ho + ' ' +Ten as Hoten FROM NhanVien", cnn);
            daNhanvien = new SqlDataAdapter();
            daNhanvien.SelectCommand = cmd;
            daNhanvien.Fill(dtNhanvien);
            txtMaKV.DataBindings.Clear();
            txtTenKV.DataBindings.Clear();
            cbbMaNVQL.DataBindings.Clear();
            txtMaKV.DataBindings.Add("Text", bs, ds.Tables[0].Columns[0].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenKV.DataBindings.Add("Text", bs, ds.Tables[0].Columns[1].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            cbbMaNVQL.DataSource = dtNhanvien;
            cbbMaNVQL.DisplayMember = dtNhanvien.Columns[1].ColumnName;
            cbbMaNVQL.ValueMember = dtNhanvien.Columns[0].ColumnName;
            cbbMaNVQL.DataBindings.Add("SelectedValue", bs, ds.Tables[0].Columns[2].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void Them_Cbosapxep()
        {
            int i, n;
            n = ds.Tables[0].Columns.Count;
            for (i = 0; i < n; i++)
            {
                cboCaccot.Items.Add(ds.Tables["KhuVuc"].Columns[i].ColumnName);
            }
            cboCaccot.Text = ds.Tables["KhuVuc"].Columns[0].ColumnName;
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
                ds.Tables[0].DefaultView.RowFilter = "TenKV like '%" + txtTimkiem.Text + "%'";
                DataTable dt = ds.Tables[0].DefaultView.ToTable();
                if (dsin.Tables.Contains("KhuVuc"))
                {
                    dsin.Tables["KhuVuc"].Clear();
                    dsin.Tables["KhuVuc"].Merge(dt);
                }
                else
                {
                    dt.TableName = "KhuVuc";
                    dsin.Tables.Add(dt);
                }
            }
            Frm_In Frm = new Frm_In(int.Parse(txtMaKV.Text), dsin, 1);
            Frm.Show();
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = ds.Tables["KhuVuc"].GetChanges();
            //Nếu có sự thay đổi sẽ phát sinh các lệnh cập nhật
            if (tbl == null)
                MessageBox.Show("Dữ liệu chưa thay đổi");
            else
            {
                cmb = new SqlCommandBuilder(da);
                da.Update(ds, "KhuVuc");
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
                ds.Tables[0].DefaultView.RowFilter = "TenKV like '%" + txtTimkiem.Text + "%'";
                St = "Số khu vực tìm thấy được: " + ds.Tables[0].DefaultView.Count.ToString();
                St = St + "/" + ds.Tables["KhuVuc"].Rows.Count.ToString();
                stutrip.Items[0].Text = St;
            }
            else { a = 0; }
        }
    }
}
