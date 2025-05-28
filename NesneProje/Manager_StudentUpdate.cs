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
    public partial class Manager_StudentUpdate : Form
    {
        public Manager_StudentUpdate()
        {
            InitializeComponent();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Manager_Page anasayfa = new Manager_Page();
            anasayfa.Show();
            this.Hide();
        }

        string connectionString = "Server=MORTY\\MSSQLSERVER02;Database=NYP2025;Trusted_Connection=True;";

        private void button_update_Click(object sender, EventArgs e)
        {
            DateTime updatedAt = DateTime.Now;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    Student std = new Student
                    {
                        Student_No = Convert.ToInt32(textBox_stdno.Text),
                        Student_Name = textBox_stdname.Text,
                        Student_Surname = textBox_stdsurname.Text,
                        Student_Tc = textBox_stdtc.Text,
                        Student_VeliNo = textBox_stdvelino.Text,
                        Student_Class = textBox_stdclass.Text,
                        Student_Sube = textBox_stdsube.Text,

                    };

                    conn.Open();

                    string sql = @"UPDATE Student_Info SET student_name = @name, student_surname = @surname, student_tc = @tc,
                          student_veliNo = @veliTel, student_class = @sinif, student_sube = @sube, updated_at = @updatedAt
                          WHERE student_no = @no";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", std.Student_Name);
                        cmd.Parameters.AddWithValue("@surname", std.Student_Surname);
                        cmd.Parameters.AddWithValue("@tc", std.Student_Tc);
                        cmd.Parameters.AddWithValue("@veliTel", std.Student_VeliNo);
                        cmd.Parameters.AddWithValue("@sinif", std.Student_Class);
                        cmd.Parameters.AddWithValue("@sube", std.Student_Sube);
                        cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                        cmd.Parameters.AddWithValue("@no", std.Student_No);

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

        private void button_getir_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT student_name, student_surname, student_tc, student_veliNo, student_class, student_sube FROM Student_Info WHERE student_no = @no";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@no", textBox_stdno.Text);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())  
                        {
                            textBox_stdname.Text = reader["student_name"].ToString();
                            textBox_stdsurname.Text = reader["student_surname"].ToString();
                            textBox_stdtc.Text = reader["student_tc"].ToString();
                            textBox_stdvelino.Text = reader["student_veliNo"].ToString();
                            textBox_stdclass.Text = reader["student_class"].ToString();
                            textBox_stdsube.Text = reader["student_sube"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Bu numaraya sahip öğrenci bulunamadı.");
                        }
                    }
                    textBox_stdname.Enabled = true;
                    textBox_stdsurname.Enabled = true;
                    textBox_stdtc.Enabled = true;
                    textBox_stdvelino.Enabled = true;
                    textBox_stdclass.Enabled = true;
                    textBox_stdsube.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
