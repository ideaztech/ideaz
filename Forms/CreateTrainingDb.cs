using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using SirLib;

namespace Solum
{
    public partial class CreateTrainingDb : Form
    {
        string version;
        public bool dbCreated = false;
        public CreateTrainingDb(string Version)
        {
            InitializeComponent();
            version = Version;
        }

        private void CreateTrainingDb_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                OK.Height = OK.Height * 2;
                Cancel.Height = Cancel.Height * 2;
            }

            labelNombreServidor.Text += " "+Properties.Settings.Default.SQLServidorNombre;

        }

        private void OK_Click(object sender, EventArgs e)
        {
            string strConnectionString = Properties.Settings.Default.WsirConnectionString;
            //check if exists

            bool trainingDbExists  = Funciones.DatabaseExists(strConnectionString, "Solum_Training");

            SqlConnection connection = new SqlConnection(strConnectionString);
            SqlCommand command = new SqlCommand("USE Master", connection);    //queryString, connection);
            connection.Open();

            if (trainingDbExists)
            {
                DialogResult result = MessageBox.Show("Training Database already exists, do you want to re-create it?", "", MessageBoxButtons.YesNo);
                //
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    connection.Close();
                    return;
                }

                if (checkBoxDropConnections.Checked)
                {
                    command.CommandText = "IF DB_ID (N'Solum_Training') IS NOT NULL ALTER DATABASE Solum_Training SET SINGLE_USER WITH ROLLBACK IMMEDIATE; ";
                    command.ExecuteNonQuery();
                }

                //drop database
                command.CommandText = "DROP DATABASE Solum_Training";
                command.ExecuteNonQuery();

            }

            this.Cursor = Cursors.WaitCursor;

            // Barra de progreso
            progressBar1.Minimum = 1;
            progressBar1.Maximum = 100;
            progressBar1.Value = 1;
            progressBar1.Step = 10;



            //create training database
            progressBar1.PerformStep();
            command.CommandText =
                "CREATE DATABASE Solum_Training; " +
                " ";

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            progressBar1.PerformStep();
            string script1 = Properties.Resources._1_CrearTablas.Replace("[Solum]", "[Solum_Training]");
            script1 = script1.Replace("FOREIGN KEY REFERENCES dbo.aspnet_Users(UserId)", "");

            //create tables
            if (!SirLib.Empresas.CrearTablas(
                connection,
                command,
                version,
                script1, //Properties.Resources._1_CrearTablas.Replace("[Solum]", "[Solum_Training]"),
                Properties.Resources._2_CrearStoredProcedures.Replace("[Solum]", "[Solum_Training]"),
                Properties.Resources._4_CrearTrainingData.Replace("[Solum]", "[Solum_Training]"),
                null
                ))
            {
                this.Cursor = Cursors.Default;
                //CajaDeMensaje.Show("", "Error creating main database's tables, please review connections and try again.", "", CajaDeMensajeImagen.Error);
                MessageBox.Show("Error creating main database's tables, please review connections and try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Call Close when done reading.
                progressBar1.PerformStep();
                connection.Close();
                return;
            }

            //create data
            //progressBar1.PerformStep();
            //strConnectionString = strConnectionString.Replace("Solum;", "Solum_Training;");
            //Main.CreateData(strConnectionString, true);

            // Call Close when done reading.
            progressBar1.PerformStep();
            connection.Close();
            progressBar1.Value = progressBar1.Maximum;
            this.Cursor = Cursors.Default;
            dbCreated = true;
            MessageBox.Show("Ready!");
            Close();

        }


    }
}
