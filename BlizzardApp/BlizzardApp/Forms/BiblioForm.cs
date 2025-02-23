using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlizzardApp.Forms
{
    public partial class BiblioForm: Form
    {
        public BiblioForm()
        {
            InitializeComponent();
        }
        private void BiblioForm_Load(object sender, EventArgs e)
        {
            CargarBiblioteca();
        }

        public void CargarBiblioteca()
        {
            
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)this.catalogo.Controls[0];
            flowLayoutPanel.Controls.Clear();

            
            string query = @"
            SELECT v.*
            FROM jogosComprados jc
            JOIN videojogos v ON jc.idJogo = v.id
            WHERE jc.idUsuario = @idUsuario";

            using (MySqlConnection connection = Func.Conectar_BD())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", LoggedUser.User.Id);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MostrarMensajeSinJuegos(); 
                            return;
                        }

                        while (reader.Read())
                        {
                            string titulo = reader["titulo"].ToString();
                            decimal precio = Convert.ToDecimal(reader["precio_original"]);
                            byte[] imagenBytes = reader["img_src"] as byte[];

                            
                            AgregarJuegoBiblioteca(titulo, precio, imagenBytes);
                        }
                    }
                }
            }
        }

        private void MostrarMensajeSinJuegos()
        {
            Label lblMensaje = new Label();
            lblMensaje.Text = "Aún no tienes videojuegos comprados.";
            lblMensaje.Dock = DockStyle.Fill;
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            lblMensaje.Font = new Font("Arial", 14, FontStyle.Bold);

            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)this.catalogo.Controls[0];
            flowLayoutPanel.Controls.Add(lblMensaje);
        }

        private void AgregarJuegoBiblioteca(string titulo, decimal precio, byte[] imagenBytes)
        {
            VideojuegoUserControl videojuegoControl = new VideojuegoUserControl(titulo, precio, imagenBytes);
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)this.catalogo.Controls[0];
            flowLayoutPanel.Controls.Add(videojuegoControl);
        }

    }
}
