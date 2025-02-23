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
            // Limpiar el catálogo antes de recargar los juegos
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)this.catalogo.Controls[0];
            flowLayoutPanel.Controls.Clear();

            // Consulta SQL para obtener los juegos comprados desde jogosComprados
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
                            MostrarMensajeSinJuegos(); // Muestra un mensaje si la biblioteca está vacía
                            return;
                        }

                        while (reader.Read())
                        {
                            string titulo = reader["titulo"].ToString();
                            decimal precio = Convert.ToDecimal(reader["precio_original"]);
                            byte[] imagenBytes = reader["img_src"] as byte[];

                            // Agregar cada juego al catálogo de la biblioteca
                            AgregarJuegoBiblioteca(titulo, precio, imagenBytes);
                        }
                    }
                }
            }
        }


        // Método para mostrar un mensaje si la biblioteca está vacía
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

        // Método para agregar los juegos a la biblioteca
        private void AgregarJuegoBiblioteca(string titulo, decimal precio, byte[] imagenBytes)
        {
            // Crear un nuevo control de videojuego
            VideojuegoUserControl videojuegoControl = new VideojuegoUserControl(titulo, precio, imagenBytes);

            // Agregarlo al FlowLayoutPanel
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)this.catalogo.Controls[0];
            flowLayoutPanel.Controls.Add(videojuegoControl);
        }

    }
}
