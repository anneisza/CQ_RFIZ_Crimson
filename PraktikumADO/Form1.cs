using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PraktikumADO
{
    public partial class Form1 : Form
    {
        //Deklarasi variabel koneksi
        SqlConnection conn;
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        //Method koneksi database
        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=RIZA\\RIZAFI;Initial Catalog=DBAkademikADO;Integrated Security=True"
                );
        }

        //Praktikum 1 : Tombol koneksi
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                MessageBox.Show("Koneksi ke database berhasil");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Praktikum 2 : Tombol Hitung Mahasiswa
        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            try{
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM Mahasiswa";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        //Praktikum 3 : Hitung Mata Kuliah
        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM MataKuliah";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //PraktikumADO 4 : Update Data (ExecuteNonQuery)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "UPDATE Mahasiswa SET Alamat = 'Yogyakarta' WHERE NIM = '23110100001'";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh: " + hasil);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Latihan 1: Tombol Hitung Dosen
        private void btnHitungDosen_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "SELECT COUNT(*) FROM Dosen";
                cmd = new SqlCommand(query, conn);
                int jumlah = (int)cmd.ExecuteScalar();
                txtHasil.Text = jumlah.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Latihan 2 : Tombol Update SKS
        private void btnUpdateSKS_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();
                string query = "UPDATE MataKuliah SET SKS = 4 WHERE KodeMK = 'IF210101'";
                cmd = new SqlCommand(query, conn);
                int hasil = cmd.ExecuteNonQuery();
                MessageBox.Show("Jumlah baris terpengaruh: " + hasil);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
