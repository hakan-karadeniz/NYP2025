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
using System.Xml.Linq;

namespace NesneProje
{
    public partial class Manager_NewStudent : Form
    {
        public Manager_NewStudent()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=MORTY\\MSSQLSERVER02;Database=NYP2025;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    Student std = new Student
                    {
                        Student_No = Convert.ToInt32(textBox_stdNo.Text),
                        Student_Name = textBox_stdName.Text,
                        Student_Surname = textBox_stdSurname.Text,
                        Student_Tc = textBox_stdTc.Text,
                        Student_VeliNo = textBox_stdVeliNo.Text,
                        Student_Class = textBox_stdClass.Text,
                        Student_Sube = textBox_stdSube.Text,

                    };

                    conn.Open();

                    string sql = "INSERT INTO Student_Info (student_name, student_surname, student_tc, student_no, student_veliNo, student_class, student_sube, created_at) " +
                        "VALUES (@name, @surname, @tc, @no, @veliTel, @sinif, @sube, @createdAt)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", std.Student_Name);
                        cmd.Parameters.AddWithValue("@surname", std.Student_Surname);
                        cmd.Parameters.AddWithValue("@tc", std.Student_Tc);
                        cmd.Parameters.AddWithValue("@no", std.Student_No);
                        cmd.Parameters.AddWithValue("@veliTel", std.Student_VeliNo);
                        cmd.Parameters.AddWithValue("@sinif", std.Student_Class);
                        cmd.Parameters.AddWithValue("@sube", std.Student_Sube);
                        cmd.Parameters.AddWithValue("@createdAt", std.CreatedAt);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Öğrenci başarıyla eklendi!");
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
