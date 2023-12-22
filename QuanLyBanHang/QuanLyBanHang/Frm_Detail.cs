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
    public partial class Frm_Detail : Form
    {
        private BindingSource formDataSource;
        public Frm_Detail(BindingSource dataSource, DataTable dt)
        {
            InitializeComponent();
            formDataSource = dataSource;
            txtSoHD.DataBindings.Clear();
            txtMaMH.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            txtDGBan.DataBindings.Clear();
            txtSoHD.DataBindings.Add("Text", formDataSource, dt.Columns[0].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaMH.DataBindings.Add("Text", formDataSource, dt.Columns[1].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtSoLuong.DataBindings.Add("Text", formDataSource, dt.Columns[2].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
            txtDGBan.DataBindings.Add("Text", formDataSource, dt.Columns[3].ColumnName, true, DataSourceUpdateMode.OnPropertyChanged);
       
        }

        private void btnUpDate_Click(object sender, EventArgs e)
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
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
