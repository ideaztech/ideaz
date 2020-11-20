namespace Solum
{
    partial class CreateTrainingDb
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTrainingDb));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelMensaje = new System.Windows.Forms.Label();
            this.labelServidor = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.labelNombreServidor = new System.Windows.Forms.Label();
            this.checkBoxDropConnections = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressBar1.Location = new System.Drawing.Point(36, 224);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(479, 22);
            this.progressBar1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelMensaje);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.panel2.Location = new System.Drawing.Point(36, 79);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(479, 121);
            this.panel2.TabIndex = 29;
            // 
            // labelMensaje
            // 
            this.labelMensaje.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelMensaje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMensaje.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelMensaje.Location = new System.Drawing.Point(0, 0);
            this.labelMensaje.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMensaje.Name = "labelMensaje";
            this.labelMensaje.Size = new System.Drawing.Size(479, 121);
            this.labelMensaje.TabIndex = 0;
            this.labelMensaje.Text = "This Database is for training purpose only,  please make sure nobody is using it " +
    "if you are re-creating the database.";
            this.labelMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelServidor
            // 
            this.labelServidor.AutoSize = true;
            this.labelServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelServidor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelServidor.Location = new System.Drawing.Point(190, 37);
            this.labelServidor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelServidor.Name = "labelServidor";
            this.labelServidor.Size = new System.Drawing.Size(0, 17);
            this.labelServidor.TabIndex = 25;
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OK.Location = new System.Drawing.Point(152, 287);
            this.OK.Margin = new System.Windows.Forms.Padding(4);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(115, 28);
            this.OK.TabIndex = 27;
            this.OK.Text = "&Create";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Cancel.Location = new System.Drawing.Point(290, 287);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(115, 28);
            this.Cancel.TabIndex = 28;
            this.Cancel.Text = "&Close";
            // 
            // labelNombreServidor
            // 
            this.labelNombreServidor.AutoSize = true;
            this.labelNombreServidor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelNombreServidor.Location = new System.Drawing.Point(41, 40);
            this.labelNombreServidor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombreServidor.Name = "labelNombreServidor";
            this.labelNombreServidor.Size = new System.Drawing.Size(75, 13);
            this.labelNombreServidor.TabIndex = 24;
            this.labelNombreServidor.Text = " &Server Name:";
            // 
            // checkBoxDropConnections
            // 
            this.checkBoxDropConnections.AutoSize = true;
            this.checkBoxDropConnections.Checked = true;
            this.checkBoxDropConnections.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDropConnections.Enabled = false;
            this.checkBoxDropConnections.Location = new System.Drawing.Point(36, 254);
            this.checkBoxDropConnections.Name = "checkBoxDropConnections";
            this.checkBoxDropConnections.Size = new System.Drawing.Size(148, 17);
            this.checkBoxDropConnections.TabIndex = 30;
            this.checkBoxDropConnections.Text = "&Drop existing connections";
            this.checkBoxDropConnections.UseVisualStyleBackColor = true;
            // 
            // CreateTrainingDb
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(547, 363);
            this.Controls.Add(this.checkBoxDropConnections);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelServidor);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.labelNombreServidor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateTrainingDb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Creating Training Database";
            this.Load += new System.EventHandler(this.CreateTrainingDb_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelMensaje;
        private System.Windows.Forms.Label labelServidor;
        private System.Windows.Forms.Button OK;
        internal System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label labelNombreServidor;
        private System.Windows.Forms.CheckBox checkBoxDropConnections;

    }
}