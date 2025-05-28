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

namespace NesneProje
{
    public partial class Manager_NotesUpdates : Form
    {
        public Manager_NotesUpdates()
        {
            InitializeComponent();
        }
        string connectionString = "Server=MORTY\\MSSQLSERVER02;Database=NYP2025;Trusted_Connection=True;";

        private void button_getir_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT matematik, fizik, kimya, biyoloji FROM Lessons_Info WHERE student_no = @no";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@no", textBox_stdNo.Text);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            textBox_matematik.Text = reader["matematik"].ToString();
                            textBox_fizik.Text = reader["fizik"].ToString();
                            textBox_kimya.Text = reader["kimya"].ToString();
                            textBox_biyoloji.Text = reader["biyoloji"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Bu numaraya sahip öğrenci bulunamadı.");
                        }
                    }
                    textBox_matematik.Enabled = true;
                    textBox_fizik.Enabled = true;
                    textBox_kimya.Enabled = true;
                    textBox_biyoloji.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            DateTime updatedAt = DateTime.Now;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    Lessons ders = new Lessons
                    {
                        Matematik = Convert.ToDouble(textBox_matematik.Text),
                        Fizik = Convert.ToDouble(textBox_fizik.Text),
                        Kimya = Convert.ToDouble(textBox_kimya.Text),
                        Biyoloji = Convert.ToDouble(textBox_biyoloji.Text),
                        Student_No = Convert.ToInt32(textBox_stdNo.Text)
                    };

                    conn.Open();

                    string sql = @"UPDATE Lessons_Info SET matematik = @mat, fizik = @fizik, kimya = @kimya, biyoloji = @biyoloji, updated_at = @updatedAt  
                           WHERE student_no = @no"; 

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@mat", ders.Matematik);
                        cmd.Parameters.AddWithValue("@fizik", ders.Fizik);
                        cmd.Parameters.AddWithValue("@kimya", ders.Kimya);
                        cmd.Parameters.AddWithValue("@no", ders.Student_No);
                        cmd.Parameters.AddWithValue("@biyoloji", ders.Biyoloji);
                        cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                        int control = cmd.ExecuteNonQuery();

                        if (control > 0)
                            MessageBox.Show("Öğrenci bilgileri başarıyla güncellendi.\nGüncellenme Tarihi: " + updatedAt.ToString("g"));
                        else
                            MessageBox.Show("Bu numaraya sahip öğrenci bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Manager_Page anasayfa = new Manager_Page();
            anasayfa.Show();
            this.Hide();
        }
    }
}
