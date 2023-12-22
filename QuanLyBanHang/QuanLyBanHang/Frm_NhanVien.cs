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
    public partial class Frm_NhanVien : Form
    {
        public Frm_NhanVien()
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
                ds.Tables[0].DefaultView.RowFilter = "Ten like '%" + txtTimkiem.Text + "%'";
                DataTable dt = ds.Tables[0].DefaultView.ToTable();
                if (dsin.Tables.Contains("NhanVien"))
                {
                    dsin.Tables["NhanVien"].Clear();
                    dsin.Tables["NhanVien"].Merge(dt);
                }
                else
                {
                    dt.TableName = "NhanVien";
                    dsin.Tables.Add(dt);
                }

            }

            Frm_In Frm = new Frm_In(int.Parse(txtMaNV.Text), dsin, 2);
            Frm.Show();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = ds.Tables["NhanVien"].GetChanges();
            //Nếu có sự thay đổi sẽ phát sinh các lệnh cập nhật
            if (tbl == null)
                MessageBox.Show("Dữ liệu chưa thay đổi");
            else
            {
                cmb = new SqlCommandBuilder(da);
                da.Update(ds, "NhanVien");
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
                ds.Tables[0].DefaultView.RowFilter = "Ten like '%" + txtTimkiem.Text + "%'";
                St = "Số nhân viên tìm thấy được: " + ds.Tables[0].DefaultView.Count.ToString();
                St = St + "/" + ds.Tables["NhanVien"].Rows.Count.ToString();
                stutrip.Items[0].Text = St;
            }
            else { a = 0; }
        }

        private void btnCheck_TextChanged(object sender, EventArgs e)
        {
            string direc = btnCheck.Text;
            ds.Tables[0].DefaultView.Sort = String.Format("[{0}] {1}", cboCaccot.Text, direc);
      
        }

        private void Frm_NhanVien_Load(object sender, EventArgs e)
        {
            KetNoi();
            TaoBang("NhanVien");
            DieuKien();
            Them_Cbosapxep();
            stutrip.Items[0].Text = "Tổng số nhân viên  :  " + ds.Tables["NhanVien"].Rows.Count.ToString();
       
        }
        public static SqlConnection cnn = new SqlConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        private SqlCommandBuilder cmb;
        SqlDataAdapter daKhuVuc;
        DataTable dtKhuVuc = new DataTable();
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
            bs.DataSource = ds.Tables["NhanVien"];
            dgvNhanVien.DataSource = bs;
            cmd = new SqlCommand("SELECT MaKV, CONVERT(nvarchar,MaKV)+ ' ' +TenKV as Hoten FROM KhuVuc", cnn);
            daKhuVuc = new SqlDataAdapter();
            daKhuVuc.SelectCommand = cmd;
            daKhuVuc.Fill(dtKhuVuc);

            //

            txtMaNV.DataBindings.Clear();
            txtHo.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            txtNu.DataBindings.Clear();
            txtLuongCB.DataBindings.Clear();
            txtCongViec.DataBindings.Clear();
            cbbMaKV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", bs, ds.Tables[0].Columns[0].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtHo.DataBindings.Add("Text", bs, ds.Tables[0].Columns[1].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtTen.DataBindings.Add("Text", bs, ds.Tables[0].Columns[2].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtNu.DataBindings.Add("Text", bs, ds.Tables[0].Columns[3].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtLuongCB.DataBindings.Add("Text", bs, ds.Tables[0].Columns[4].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtCongViec.DataBindings.Add("Text", bs, ds.Tables[0].Columns[5].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            cbbMaKV.DataSource = dtKhuVuc;
            cbbMaKV.DisplayMember = dtKhuVuc.Columns[1].ColumnName;
            cbbMaKV.ValueMember = dtKhuVuc.Columns[0].ColumnName;
            cbbMaKV.DataBindings.Add("SelectedValue", bs, ds.Tables[0].Columns[6].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void Them_Cbosapxep()
        {
            int i, n;
            n = ds.Tables[0].Columns.Count;
            for (i = 0; i < n; i++)
            {
                cboCaccot.Items.Add(ds.Tables["NhanVien"].Columns[i].ColumnName);
            }
            cboCaccot.Text = ds.Tables["NhanVien"].Columns[0].ColumnName;
        }

    }
}
