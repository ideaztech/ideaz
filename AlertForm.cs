﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Solum
{
    public partial class AlertForm : Form
    {

        #region PROPERTIES

        public string FormTitle
        {
            set { this.Text = value; }
        }
        public string Message
        {
            set { labelMessage.Text = value; }
        }

        public string Percentage
        {
            set { labelPercentage.Text = value; }
        }


        public int ProgressMinimum
        {
            set { progressBar1.Minimum = value; }
        }

        public int ProgressMaximum
        {
            set { progressBar1.Maximum = value; }
        }

        public int ProgressValue
        {
            set { progressBar1.Value = value; }
        }

        public int ProgressStep
        {
            set { progressBar1.Step = value; }
        }

        public bool EnableCancel
        {
            set { buttonCancel.Enabled = value; }
        }


        #endregion

        #region METHODS

        public AlertForm()
        {
            InitializeComponent();
        }

        #endregion

        #region EVENTS

        public event EventHandler<EventArgs> Canceled;

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Create a copy of the event to work with
            EventHandler<EventArgs> ea = Canceled;
            /* If there are no subscribers, eh will be null so we need to check
             * to avoid a NullReferenceException. */
            if (ea != null)
                ea(this, e);
        }

        #endregion

    }
}