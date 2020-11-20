
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


using System.Globalization;
using Solum.Forms;
//using System.Net.Mail;


namespace Solum
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //SirLib.CultureManager.ApplicationUICulture = new CultureInfo("en"); //CultureInfo.CurrentCulture;
            //SirLib.CultureManager.ApplicationUICulture = new CultureInfo("en-us"); //CultureInfo.CurrentCulture;
            //SirLib.CultureManager.ApplicationUICulture = new CultureInfo("es-mx");

            SirLib.CultureManager.ApplicationUICulture = new CultureInfo("en-us");

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            //#if (!DEBUG)
            //SirLib.ExcepcionesNoControladas.Controlar("Solum", true);
            //#endif
            //System.Windows.Forms.Application.Run(new Main());
            ////Application.Run(new Form1());
            ////Application.Run(new FormKeypad());

            SingleInstance.SingleApplication.Run(new Main());
            //SingleInstance.SingleApplication.Run(new Form1());
        }
    }

}
