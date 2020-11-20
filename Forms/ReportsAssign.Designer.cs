namespace Solum
{
    partial class ReportsAssign
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsAssign));
            this.labelReportsAssigned = new System.Windows.Forms.Label();
            this.labelReportsNotAssigned = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.buttonQuitarTodo = new System.Windows.Forms.Button();
            this.buttonAgregarTodo = new System.Windows.Forms.Button();
            this.buttonQuitar = new System.Windows.Forms.Button();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelEtiqueta = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelReportsAssigned
            // 
            this.labelReportsAssigned.AutoSize = true;
            this.labelReportsAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelReportsAssigned.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelReportsAssigned.Location = new System.Drawing.Point(370, 79);
            this.labelReportsAssigned.Name = "labelReportsAssigned";
            this.labelReportsAssigned.Size = new System.Drawing.Size(135, 17);
            this.labelReportsAssigned.TabIndex = 22;
            this.labelReportsAssigned.Text = "&Reports assigned";
            // 
            // labelReportsNotAssigned
            // 
            this.labelReportsNotAssigned.AutoSize = true;
            this.labelReportsNotAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelReportsNotAssigned.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelReportsNotAssigned.Location = new System.Drawing.Point(8, 79);
            this.labelReportsNotAssigned.Name = "labelReportsNotAssigned";
            this.labelReportsNotAssigned.Size = new System.Drawing.Size(163, 17);
            this.labelReportsNotAssigned.TabIndex = 21;
            this.labelReportsNotAssigned.Text = "&Reports not assigned";
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(370, 99);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(250, 304);
            this.listBox2.TabIndex = 13;
            this.listBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox2_DragDrop);
            this.listBox2.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox2_DragOver);
            this.listBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDown);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(7, 99);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(250, 304);
            this.listBox1.TabIndex = 12;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.listBox1_DragOver);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Cancel);
            this.groupBox2.Controls.Add(this.buttonQuitarTodo);
            this.groupBox2.Controls.Add(this.buttonAgregarTodo);
            this.groupBox2.Controls.Add(this.buttonQuitar);
            this.groupBox2.Controls.Add(this.buttonAgregar);
            this.groupBox2.Location = new System.Drawing.Point(266, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(95, 318);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Cancel.Location = new System.Drawing.Point(10, 265);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 27);
            this.Cancel.TabIndex = 13;
            this.Cancel.Text = "&Close";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // buttonQuitarTodo
            // 
            this.buttonQuitarTodo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonQuitarTodo.Location = new System.Drawing.Point(10, 205);
            this.buttonQuitarTodo.Name = "buttonQuitarTodo";
            this.buttonQuitarTodo.Size = new System.Drawing.Size(75, 27);
            this.buttonQuitarTodo.TabIndex = 12;
            this.buttonQuitarTodo.Text = "<<";
            this.buttonQuitarTodo.UseVisualStyleBackColor = true;
            this.buttonQuitarTodo.Click += new System.EventHandler(this.buttonQuitarTodo_Click);
            // 
            // buttonAgregarTodo
            // 
            this.buttonAgregarTodo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonAgregarTodo.Location = new System.Drawing.Point(10, 145);
            this.buttonAgregarTodo.Name = "buttonAgregarTodo";
            this.buttonAgregarTodo.Size = new System.Drawing.Size(75, 27);
            this.buttonAgregarTodo.TabIndex = 11;
            this.buttonAgregarTodo.Text = ">>";
            this.buttonAgregarTodo.UseVisualStyleBackColor = true;
            this.buttonAgregarTodo.Click += new System.EventHandler(this.buttonAgregarTodo_Click);
            // 
            // buttonQuitar
            // 
            this.buttonQuitar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonQuitar.Location = new System.Drawing.Point(10, 85);
            this.buttonQuitar.Name = "buttonQuitar";
            this.buttonQuitar.Size = new System.Drawing.Size(75, 27);
            this.buttonQuitar.TabIndex = 10;
            this.buttonQuitar.Text = "<";
            this.buttonQuitar.UseVisualStyleBackColor = true;
            this.buttonQuitar.Click += new System.EventHandler(this.buttonQuitar_Click);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonAgregar.Location = new System.Drawing.Point(10, 25);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(75, 27);
            this.buttonAgregar.TabIndex = 9;
            this.buttonAgregar.Text = ">";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNombre);
            this.groupBox1.Controls.Add(this.labelEtiqueta);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 50);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelNombre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelNombre.Location = new System.Drawing.Point(142, 20);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(104, 17);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "labelNombre:";
            // 
            // labelEtiqueta
            // 
            this.labelEtiqueta.AutoSize = true;
            this.labelEtiqueta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelEtiqueta.Location = new System.Drawing.Point(20, 20);
            this.labelEtiqueta.Name = "labelEtiqueta";
            this.labelEtiqueta.Size = new System.Drawing.Size(71, 13);
            this.labelEtiqueta.TabIndex = 0;
            this.labelEtiqueta.Text = "labelEtiqueta:";
            // 
            // ReportsAssign
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(628, 435);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelReportsAssigned);
            this.Controls.Add(this.labelReportsNotAssigned);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportsAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assign Reports";
            this.Load += new System.EventHandler(this.ReportsAssign_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelReportsAssigned;
        private System.Windows.Forms.Label labelReportsNotAssigned;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button buttonQuitarTodo;
        private System.Windows.Forms.Button buttonAgregarTodo;
        private System.Windows.Forms.Button buttonQuitar;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelEtiqueta;

    }
}