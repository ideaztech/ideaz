using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Web.Security;
using System.Collections;

namespace Solum
{
    public partial class ReportsAssign : Form
    {
        private bool flag = false;
        private List<SirLib.wsir_Reportes_info> wsir_Reportes_infoList;
        private string reportName, reportDescription;
        //private int index = 0;

        private bool touchOriented;

        string strConnectionString, name, target;//, etiquetaDestino, nombreDestino;
        //Dictionary<int, string, string> reportsoriginalValues = new Dictionary<int, string, string>();
        ArrayList arrayListReportsUnAssigned, arrayListReportsAssigned;


        public ReportsAssign(bool TouchOriented,
                string StrConnectionString,
                string Target
            )
        {
            InitializeComponent();
            touchOriented = TouchOriented;
            strConnectionString = StrConnectionString;
            target = Target;
        }

        private void ReportsAssign_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                //toolStripButtonVirtualKb.Visible = true;
                buttonAgregar.Height = 50;//OK.Height * 2;
                buttonQuitar.Height = 50;//buttonSelAll.Height * 2;
                buttonAgregarTodo.Height = 50;//buttonApply.Height * 2;
                buttonQuitarTodo.Height = 50;//buttonApply.Height * 2;
                Cancel.Height = 50;//Cancel.Height * 2;
            }

            if (target == "user")
            {
                labelEtiqueta.Text = "User:";
                name = SirLib.Usuarios.userName;

            }
            else
            {
                labelEtiqueta.Text = "Role:";
                name = SirLib.Grupos.roleName;
            }

            labelNombre.Text = name;

            //originalValues.Clear();
            arrayListReportsUnAssigned = new ArrayList();
            arrayListReportsUnAssigned.Clear();
            listBox1.Items.Clear();
            arrayListReportsAssigned = new ArrayList();
            arrayListReportsAssigned.Clear();
            listBox2.Items.Clear();

            buttonAgregar.Enabled = false;
            buttonAgregarTodo.Enabled = true;

            buttonQuitar.Enabled = false;
            buttonQuitarTodo.Enabled = true;

            //reports not assigned
            bindListBox(listBox1);
            //if (listBox1.SelectedIndex < 0)
                //buttonAgregar.Enabled = false;
            if (listBox1.Items.Count < 1)
                buttonAgregarTodo.Enabled = false;

            //reports assigned
            bindReportesInRolesUsers(listBox2);
            //if (listBox2.SelectedIndex < 0)
            //    buttonQuitar.Enabled = false;
            if (listBox2.Items.Count < 1)
                buttonQuitarTodo.Enabled = false;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.buttonAgregar, "Add");
            toolTip1.SetToolTip(this.buttonQuitar, "Remove");
            toolTip1.SetToolTip(this.buttonAgregarTodo, "Add all");
            toolTip1.SetToolTip(this.buttonQuitarTodo, "Remove all");


        }

        private void bindListBox(ListBox lista)
        {
            //try
            //{
                //List<SirLib.wsir_Reportes_info> wsir_Reportes_infoList;    // = new List<Sol_EmployeeLookup>();
                wsir_Reportes_infoList = SirLib.wsir_Reportes.LeerRegistros(strConnectionString);
                foreach (SirLib.wsir_Reportes_info ri in wsir_Reportes_infoList)
                {
                    if (target == "user")
                        flag = SirLib.wsir_ReportesEnUsers.Existe(strConnectionString,
                        ri.ReporteNombre,
                        labelNombre.Text);
                    else
                        flag = SirLib.wsir_ReportesEnRoles.Existe(strConnectionString,
                        ri.ReporteNombre,
                        labelNombre.Text);

                    if(flag)
                        continue;
                    lista.Items.Add(ri.Descripcion);
                    arrayListReportsUnAssigned.Add(ri);
                }
            //}
            //catch
            //{
            //    //
            //}
        }

        private void bindReportesInRolesUsers(ListBox lista)
        {
            bool flag;
            try
            {
                //List<SirLib.wsir_Reportes_info> wsir_Reportes_infoList;    // = new List<Sol_EmployeeLookup>();
                wsir_Reportes_infoList = SirLib.wsir_Reportes.LeerRegistros(strConnectionString);
                foreach (SirLib.wsir_Reportes_info ri in wsir_Reportes_infoList)
                {
                    if (target == "user")
                        flag = SirLib.wsir_ReportesEnUsers.Existe(strConnectionString,
                        ri.ReporteNombre,
                        labelNombre.Text);
                    else
                        flag = SirLib.wsir_ReportesEnRoles.Existe(strConnectionString,
                        ri.ReporteNombre,
                        labelNombre.Text);

                    if (!flag)
                        continue;
                    lista.Items.Add(ri.Descripcion);
                    arrayListReportsAssigned.Add(ri);
                }
            }
            catch
            {
                //
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            AddReport(listBox1.SelectedIndex);
        }

        private void AddReport(int index)
        {
            if (index < 0)
                return;
            //try
            //{

                reportName = ((SirLib.wsir_Reportes_info)this.arrayListReportsUnAssigned[index]).ReporteNombre;  //(string)listBox1.SelectedItem;
                reportDescription = ((SirLib.wsir_Reportes_info)this.arrayListReportsUnAssigned[index]).Descripcion;
                if (target == "user")
                    SirLib.wsir_ReportesEnUsers.Agregar(strConnectionString,
                        reportName,
                        labelNombre.Text);
                else
                    SirLib.wsir_ReportesEnRoles.Agregar(strConnectionString,
                        reportName,
                        labelNombre.Text);

                listBox1.Items.Remove(reportDescription);
                listBox2.Items.Add(reportDescription);
                arrayListReportsAssigned.Add(arrayListReportsUnAssigned[index]);
                arrayListReportsUnAssigned.RemoveAt(index);
                buttonQuitarTodo.Enabled = true;
                try
                {
                    listBox1.SelectedIndex = 0;
                }
                catch
                {
                    buttonAgregar.Enabled = false;

                }
                listBox1.Focus();
                if (listBox1.Items.Count < 1)
                    buttonAgregarTodo.Enabled = false;

            //}
            //catch
            //{
            //    //
            //}

        }

        private void buttonQuitar_Click(object sender, EventArgs e)
        {
            RemoveReport(listBox2.SelectedIndex);
        }

        private void RemoveReport(int index)
        {
            if (index < 0)
                return;
            //try
            //{
            reportName = ((SirLib.wsir_Reportes_info)this.arrayListReportsAssigned[index]).ReporteNombre;  //(string)listBox1.SelectedItem;
            reportDescription = ((SirLib.wsir_Reportes_info)this.arrayListReportsAssigned[index]).Descripcion;
            if (target == "user")
                SirLib.wsir_ReportesEnUsers.Borrar(strConnectionString,
                    reportName,
                    labelNombre.Text);
            else
                SirLib.wsir_ReportesEnRoles.Borrar(strConnectionString,
                    reportName,
                    labelNombre.Text);

            listBox1.Items.Add(reportDescription);
            listBox2.Items.Remove(reportDescription);
            arrayListReportsUnAssigned.Add(arrayListReportsAssigned[index]);
            arrayListReportsAssigned.RemoveAt(index);
            buttonAgregarTodo.Enabled = true;
            try
            {
                listBox2.SelectedIndex = 0;
            }
            catch
            {
                buttonQuitar.Enabled = false;
            }

            listBox2.Focus();

            if (listBox2.Items.Count < 1)
                buttonQuitarTodo.Enabled = false;


            //}
            //catch
            //{
            //    //
            //}
        }

        private void buttonAgregarTodo_Click(object sender, EventArgs e)
        {
            try
            {
                while (listBox1.Items.Count>0 )  //object o in listBox1.Items)
                {
                    AddReport(0);

                }
                //listBox1.Items.Clear();
                buttonAgregar.Enabled = false;
                buttonAgregarTodo.Enabled = false;
                buttonQuitarTodo.Enabled = true;
            }
            catch
            {
                //
            }

        }

        private void buttonQuitarTodo_Click(object sender, EventArgs e)
        {
            try
            {
                while (listBox2.Items.Count > 0)  //object o in listBox1.Items)
                {
                    RemoveReport(0);

                }
                //listBox2.Items.Clear();
                buttonQuitar.Enabled = false;
                buttonAgregarTodo.Enabled = true;
                buttonQuitarTodo.Enabled = false;
            }
            catch
            {
                //
            }


        }

        //************
        //DRAG AND DROP -- esta deshabilitado porque falla
        // *********
        // listBox1
        // *********

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox1.Items.Count == 0)
                return;
            try
            {
                string s = listBox1.Items[listBox1.IndexFromPoint(e.X, e.Y)].ToString();
                DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);

                if (dde1 == DragDropEffects.All)
                {
                    listBox1.Items.RemoveAt(listBox2.IndexFromPoint(e.X, e.Y));
                    if (listBox2.Items.Count < 1)
                        buttonAgregarTodo.Enabled = false;
                }
                else
                    buttonAgregar.Enabled = true;
            }
            catch
            {
                //
            }

        }


        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            buttonQuitar.Enabled = false;
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string reportName = (string)e.Data.GetData(DataFormats.StringFormat);
                SirLib.wsir_ReportesEnUsers.Borrar(strConnectionString,
                        reportName,
                        labelNombre.Text);

                listBox1.Items.Add(reportName);
                buttonAgregarTodo.Enabled = true;

            }

        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

        }

        // *********
        // listBox2
        // *********
        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox2.Items.Count == 0)
                return;
            try
            {
                string s = listBox2.Items[listBox2.IndexFromPoint(e.X, e.Y)].ToString();
                DragDropEffects dde1 = DoDragDrop(s, DragDropEffects.All);

                if (dde1 == DragDropEffects.All)
                {
                    listBox2.Items.RemoveAt(listBox1.IndexFromPoint(e.X, e.Y));
                    if (listBox2.Items.Count < 1)
                        buttonQuitarTodo.Enabled = false;
                }
                else
                    buttonQuitar.Enabled = true;
            }
            catch
            {
                //
            }

        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            buttonAgregar.Enabled = false;
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string reportName = (string)e.Data.GetData(DataFormats.StringFormat);
                SirLib.wsir_ReportesEnUsers.Agregar(strConnectionString,
                        reportName,
                        labelNombre.Text);
                listBox2.Items.Add(reportName);
                buttonQuitarTodo.Enabled = true;

            }

        }

        private void listBox2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

        }




    }
}
