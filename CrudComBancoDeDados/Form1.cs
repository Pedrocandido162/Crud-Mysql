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
using MySql.Data.MySqlClient;

namespace CrudComBancoDeDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CadastrarButton_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=cadastro;password=;port=3306;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand comand = connection.CreateCommand();
                comand.CommandText = "INSERT INTO pessoas (id, email, senha) VALUES (@id, @email, @senha)"; ;
                comand.Parameters.AddWithValue("@id", textId.Text);
                comand.Parameters.AddWithValue("@email", textEmail.Text);
                comand.Parameters.AddWithValue("@senha", textSenha.Text);
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /*private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/

  

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=cadastro;password=;port=3306;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand comand = connection.CreateCommand();
                comand.CommandText = "UPDATE pessoas SET email = @email, senha = @senha WHERE id = @id "; ;
                comand.Parameters.AddWithValue("@email", textEmail.Text);
                comand.Parameters.AddWithValue("@senha", textSenha.Text);
                comand.Parameters.AddWithValue("@id", textId.Text);
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void textExibir_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=cadastro;password=;port=3306;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try {
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM pessoas", connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDados.DataSource = dt;
            
            } catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally { connection.Close(); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=cadastro;password=;port=3306;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand comand = connection.CreateCommand();
                comand.CommandText = "DELETE FROM pessoas WHERE id =@id";
                comand.Parameters.AddWithValue("@id",textId.Text);
                comand.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally { connection.Close(); }

        }

        private void buttonConsulta_Click(object sender, EventArgs e)
        {
                 string connectionString = "server=localhost;user=root;database=cadastro;password=;port=3306;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand comand = connection.CreateCommand();
                comand.CommandText = "SELECT * FROM pessoas WHERE id =@id";
                comand.Parameters.AddWithValue("@id",textId.Text);
                MySqlDataReader dr;
                dr = comand.ExecuteReader();
                while (dr.Read())
                {
                    textEmail.Text = Convert.ToString(dr["email"]);
                 
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally { connection.Close(); }

        
        }
    }
}
               /*MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM users";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MessageBox.Show(reader["name"] + " - " + reader["email"]);
                }*/