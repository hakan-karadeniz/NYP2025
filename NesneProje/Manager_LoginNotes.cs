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
    public partial class Manager_LoginNotes : Form
    {
        public Manager_LoginNotes()
        {
            InitializeComponent();
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=MORTY\\MSSQLSERVER02;Database=NYP2025;Trusted_Connection=True;";

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

                    string sql = "INSERT INTO Lessons_Info (matematik, fizik, kimya,student_no, biyoloji, created_at) " +
                                 "VALUES (@mat, @fizik, @kimya, @no, @biyoloji, @createdAt)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@mat", ders.Matematik);
                        cmd.Parameters.AddWithValue("@fizik", ders.Fizik);
                        cmd.Parameters.AddWithValue("@kimya", ders.Kimya);
                        cmd.Parameters.AddWithValue("@no", ders.Student_No);
                        cmd.Parameters.AddWithValue("@biyoloji", ders.Biyoloji);
                        cmd.Parameters.AddWithValue("@createdAt", ders.CreatedAt);


                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Notlar başarıyla eklendi!");
                        else
                            MessageBox.Show("Ekleme başarısız.");
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
