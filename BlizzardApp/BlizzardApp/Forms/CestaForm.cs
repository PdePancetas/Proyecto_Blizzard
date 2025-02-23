using Microsoft.Extensions.Logging.Abstractions;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlizzardApp.Forms
{
    public partial class CestaForm : Form
    {
       

        public CestaForm()
        {
            InitializeComponent();
            RecargarCesta();
        }

        private void CestaForm_Load(object sender, EventArgs e)
        {

        }

        public void AddJuego(string juego)
        {
            Videojuego vjuego = Func.getJuego(juego) as Videojuego;
            Console.WriteLine(vjuego.Id);
            Usuario user = Func.getUser(LoggedUser.User.Nombre, LoggedUser.User.Password);

            AnadirACesta(user, vjuego);
            RecargarCesta();
        }


        private void AnadirACesta(Usuario user, Videojuego juego)
        {
            using (MySqlConnection connection = Func.Conectar_BD())
            {
                
                string checkQuery = "SELECT COUNT(*) FROM videojogos WHERE id = @idJogo";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    connection.Open();
                    checkCmd.Parameters.AddWithValue("@idJogo", juego.Id);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count == 0)
                    {
                        Console.WriteLine("El juego con ID " + juego.Id + " no existe en la base de datos.");
                        return;
                    }
                }
            }
            string sql = "INSERT INTO cestajogos_usuario (idUsuario, idJogo) VALUES (@idUsuario, @idJogo)";

            using (MySqlConnection connection2 = Func.Conectar_BD())
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection2))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", LoggedUser.User.Id);
                    cmd.Parameters.AddWithValue("@idJogo", juego.Id);

                    try
                    {
                        connection2.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al asociar juego con usuario: {ex.Message}");
                        
                    }
                }
            }

            RecargarCesta();
        }

        public void RecargarCesta()
        {
            try
            {
                FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)this.catalogo.Controls[0];
                flowLayoutPanel.Controls.Clear();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            CargarVideojuegos();
        }

        private void MostrarMensajeSinVideojuegos()
        {
            Label lblMensaje = new Label();
            lblMensaje.Text = "Aún no hay videojuegos en el catálogo.";
            lblMensaje.Dock = DockStyle.Fill;
            lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblMensaje.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);

            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)this.catalogo.Controls[0];
            flowLayoutPanel.Controls.Add(lblMensaje);
        }

        private void CargarVideojuegos()
        {
            string query = @"
            SELECT v.*
            FROM cestajogos_usuario cesta
            JOIN videojogos v ON cesta.idJogo = v.id
            LEFT JOIN jogosComprados jc ON cesta.idUsuario = jc.idUsuario AND cesta.idJogo = jc.idJogo
            WHERE cesta.idUsuario = @idUsuario AND jc.idJogo IS NULL";

            using (MySqlConnection connection = Func.Conectar_BD())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idUsuario", LoggedUser.User.Id);

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MostrarMensajeSinVideojuegos();
                        return;
                    }

                    while (reader.Read())
                    {
                        string titulo = reader["titulo"].ToString();
                        decimal precio_original = Convert.ToDecimal(reader["precio_original"]);
                        byte[] imagenBytes = reader["img_src"] as byte[];

                        AgregarVideojuego(titulo, precio_original, imagenBytes);
                    }
                }
            }
        }


        private void AgregarVideojuego(string titulo, decimal precio_original, byte[] imagenBytes)
        {
            
            VideojuegoUserControl videojuegoControl = new VideojuegoUserControl(titulo, precio_original, imagenBytes);
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)this.catalogo.Controls[0];
            flowLayoutPanel.Controls.Add(videojuegoControl);
        }

        public void EliminarDeCesta(string juego)
        {
            
            Videojuego vjuego = Func.getJuego(juego) as Videojuego;
            if (vjuego == null)
            {
                Console.WriteLine("El juego no existe.");
                return;
            }

            string sql = "DELETE FROM cestajogos_usuario WHERE idUsuario = @idUsuario AND idJogo = @idJogo";

            using (MySqlConnection connection = Func.Conectar_BD())
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", LoggedUser.User.Id);
                    cmd.Parameters.AddWithValue("@idJogo", vjuego.Id);

                    try
                    {
                        connection.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine($"El juego {juego} ha sido eliminado de la cesta.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró el juego en la cesta.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al eliminar juego de la cesta: {ex.Message}");
                    }
                }
            }

            RecargarCesta();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            ComprarJuegos();
            MessageBox.Show("Has comprado los juegos!");
            Home.biblioForm.CargarBiblioteca();
        }

        private void ComprarJuegos()
        {
            using (MySqlConnection connection = Func.Conectar_BD())
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction(); 

                try
                {
                    
                    string insertQuery = @"
                    INSERT INTO jogosComprados (idUsuario, idJogo)
                    SELECT idUsuario, idJogo 
                    FROM cestajogos_usuario 
                    WHERE idUsuario = @idUsuario";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection, transaction))
                    {
                        insertCmd.Parameters.AddWithValue("@idUsuario", LoggedUser.User.Id);
                        int juegosComprados = insertCmd.ExecuteNonQuery();
                        Console.WriteLine($"{juegosComprados} juegos comprados.");
                    }

                    
                    string deleteQuery = "DELETE FROM cestajogos_usuario WHERE idUsuario = @idUsuario";

                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection, transaction))
                    {
                        deleteCmd.Parameters.AddWithValue("@idUsuario", LoggedUser.User.Id);
                        deleteCmd.ExecuteNonQuery();
                    }

                    transaction.Commit(); 

                    
                    RecargarCesta();
                    Home.biblioForm.CargarBiblioteca();
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); 
                    Console.WriteLine($"Error al comprar juegos: {ex.Message}");
                }
            }
        }


    }
}
