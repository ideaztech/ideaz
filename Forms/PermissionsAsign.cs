using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Solum
{
    public partial class PermissionsAsign : Form
    {

        string strConnectionString, name, target;//, etiquetaDestino, nombreDestino;
        Dictionary<string, bool> originalValues = new Dictionary<string, bool>();

        public PermissionsAsign(
                string StrConnectionString,
                string Target
            )
        {
            InitializeComponent();

            strConnectionString = StrConnectionString;
            target = Target;

        }

        private void PermissionsAsign_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TouchOriented)
            {
                //toolStripButtonVirtualKb.Visible = true;
                OK.Height = 60;//OK.Height * 2;
                buttonSelAll.Height = 60;//buttonSelAll.Height * 2;
                Cancel.Height = 60;//Cancel.Height * 2;
                buttonApply.Height = 60;//buttonApply.Height * 2;
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
            tabControl2.SelectedIndex=0;


            originalValues.Clear();

            //pos
            checkBoxPosCreateChit.Checked = StoreOriginalValue("SolCreateChit");
            checkBoxPosDeleteChit.Checked = StoreOriginalValue("SolDeleteChit");
            checkBoxPosLookupChit.Checked = StoreOriginalValue("SolLookupChit");
            checkBoxPosOpenChit.Checked = StoreOriginalValue("SolOpenChit");
            checkBoxPosCashOutOrder.Checked = StoreOriginalValue("SolCashOutOrder");
            checkBoxPosUnpayOrder.Checked = StoreOriginalValue("SolUnpayOrder");
            checkBoxPutOnAccountButton.Checked = StoreOriginalValue("SolPutOnAccountButton");
            checkBoxVoidOrder.Checked = StoreOriginalValue("SolVoidOrder");

            //shipments
            checkBoxShipShipping.Checked = StoreOriginalValue("SolShipping");
            checkBoxShipCreateContainer.Checked = StoreOriginalValue("SolCreateContainer");
            checkBoxShipModifyContainer.Checked = StoreOriginalValue("SolModifyContainer");
            checkBoxShipViewContainer.Checked = StoreOriginalValue("SolViewContainer");
            checkBoxShipCreateShipment.Checked = StoreOriginalValue("SolCreateShipment");
            checkBoxShipViewShipment.Checked = StoreOriginalValue("SolViewShipment");
            checkBoxShipUnshipShipment.Checked = StoreOriginalValue("SolUnshipShipment");
            checkBoxShipLookupShipment.Checked = StoreOriginalValue("SolLookupShipment");
            checkBoxAdjustShipment.Checked = StoreOriginalValue("SolAdjustShipment");
            checkBoxVoidShipment.Checked = StoreOriginalValue("SolVoidShipment");
            checkBoxVoidStaged.Checked = StoreOriginalValue("SolVoidStaged");

            //Inventory
            checkBoxInvViewProducts.Checked = StoreOriginalValue("SolViewProducts");
            checkBoxInvCreateProductAdjustment.Checked = StoreOriginalValue("SolCreateProductAdjustment");
            checkBoxInvViewSupplies.Checked = StoreOriginalValue("SolViewSupplies");
            checkBoxInvCreateSupplyAdjustment.Checked = StoreOriginalValue("SolCreateSupplyAdjustment");
            checkBoxInvPrintInventory.Checked = StoreOriginalValue("SolPrintInventory");

            //Accounting
            checkBoxAccOpenCashier.Checked = StoreOriginalValue("SolOpenCashier");
            checkBoxAccAddFloat.Checked = StoreOriginalValue("SolAddFloat");
            checkBoxAccCloseCashier.Checked = StoreOriginalValue("SolCloseCashier");
            checkBoxAccAddExpenses.Checked = StoreOriginalValue("SolAddExpenses");
            checkBoxAccViewCustomer.Checked = StoreOriginalValue("SolViewCustomer");
            checkBoxAccEditCustomer.Checked = StoreOriginalValue("SolEditCustomer");
            checkBoxAccViewEntries.Checked = StoreOriginalValue("SolViewEntries");
            checkBoxAccEditEntries.Checked = StoreOriginalValue("SolEditEntries");

            //catalogs
            checkBoxCatSolCatA.Checked = StoreOriginalValue("SolAddCatalogues");
            checkBoxCatSolCatB.Checked = StoreOriginalValue("SolEditCatalogues");

            //Tools
            checkBoxTooGeUsuariosABC.Checked = StoreOriginalValue("GeUsuariosABC");
            checkBoxTooGeGruposABC.Checked = StoreOriginalValue("GeGruposABC");
            checkBoxTooGeCambiarEmpresa.Checked = StoreOriginalValue("GeCambiarEmpresa");
            checkBoxTooGeRecuperar.Checked = StoreOriginalValue("GeRecuperar");
            checkBoxTooGeRespaldar.Checked = StoreOriginalValue("GeRespaldar");
            checkBoxtOOGeCierreAnual.Checked = StoreOriginalValue("GeCierreAnual");

            checkBoxTooSolCambiarOpciones.Checked = StoreOriginalValue("SolCambiarOpciones");
            checkBoxTooUpdateVersion.Checked = StoreOriginalValue("SolUpdateVersion");
            //checkBoxTooViewHelp;

            checkBoxTooEmailNotification.Checked = StoreOriginalValue("SolUserEmail");
            checkBoxTooTrainingMode.Checked = StoreOriginalValue("SolUseTraining");



        }

        private bool StoreOriginalValue(string permission)
        {
            bool flag;
            if (target == "user")
                flag = SirLib.wsir_PermisosEnUsers.Existe(strConnectionString, permission, name);
            else
                flag = SirLib.wsir_PermisosEnRoles.Existe(strConnectionString, permission, name);

            originalValues.Add(permission, flag);
            return flag;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            UpdatePermissions();
            Close();

        }

        private void UpdatePermissions()
        {
            this.Cursor = Cursors.WaitCursor;
            //App
            UpdatePermissionIfChanged(checkBoxPosCreateChit.Checked, "SolCreateChit");

            //pos
            UpdatePermissionIfChanged(checkBoxPosCreateChit.Checked, "SolCreateChit");
            UpdatePermissionIfChanged(checkBoxPosDeleteChit.Checked, "SolDeleteChit");
            UpdatePermissionIfChanged(checkBoxPosLookupChit.Checked, "SolLookupChit");
            UpdatePermissionIfChanged(checkBoxPosOpenChit.Checked, "SolOpenChit");
            UpdatePermissionIfChanged(checkBoxPosCashOutOrder.Checked, "SolCashOutOrder");
            UpdatePermissionIfChanged(checkBoxPosUnpayOrder.Checked, "SolUnpayOrder");
            UpdatePermissionIfChanged(checkBoxPutOnAccountButton.Checked, "SolPutOnAccountButton");
            UpdatePermissionIfChanged(checkBoxVoidOrder.Checked, "SolVoidOrder");

            //shipments
            UpdatePermissionIfChanged(checkBoxShipShipping.Checked, "SolShipping");
            UpdatePermissionIfChanged(checkBoxShipCreateContainer.Checked, "SolCreateContainer");
            UpdatePermissionIfChanged(checkBoxShipModifyContainer.Checked, "SolModifyContainer");
            UpdatePermissionIfChanged(checkBoxShipViewContainer.Checked, "SolViewContainer");
            UpdatePermissionIfChanged(checkBoxShipCreateShipment.Checked, "SolCreateShipment");
            UpdatePermissionIfChanged(checkBoxShipViewShipment.Checked, "SolViewShipment");
            UpdatePermissionIfChanged(checkBoxShipUnshipShipment.Checked, "SolUnshipShipment");
            UpdatePermissionIfChanged(checkBoxShipLookupShipment.Checked, "SolLookupShipment");
            UpdatePermissionIfChanged(checkBoxAdjustShipment.Checked, "SolAdjustShipment");
            UpdatePermissionIfChanged(checkBoxVoidShipment.Checked, "SolVoidShipment");
            UpdatePermissionIfChanged(checkBoxVoidStaged.Checked, "SolVoidStaged");

            //Inventory
            UpdatePermissionIfChanged(checkBoxInvViewProducts.Checked, "SolViewProducts");
            UpdatePermissionIfChanged(checkBoxInvCreateProductAdjustment.Checked, "SolCreateProductAdjustment");
            UpdatePermissionIfChanged(checkBoxInvViewSupplies.Checked, "SolViewSupplies");
            UpdatePermissionIfChanged(checkBoxInvCreateSupplyAdjustment.Checked, "SolCreateSupplyAdjustment");
            UpdatePermissionIfChanged(checkBoxInvPrintInventory.Checked, "SolPrintInventory");

            //Accounting
            UpdatePermissionIfChanged(checkBoxAccOpenCashier.Checked, "SolOpenCashier");
            UpdatePermissionIfChanged(checkBoxAccAddFloat.Checked, "SolAddFloat");
            UpdatePermissionIfChanged(checkBoxAccCloseCashier.Checked, "SolCloseCashier");
            UpdatePermissionIfChanged(checkBoxAccAddExpenses.Checked, "SolAddExpenses");
            UpdatePermissionIfChanged(checkBoxAccViewCustomer.Checked, "SolViewCustomer");
            UpdatePermissionIfChanged(checkBoxAccEditCustomer.Checked, "SolEditCustomer");
            UpdatePermissionIfChanged(checkBoxAccViewEntries.Checked, "SolViewEntries");
            UpdatePermissionIfChanged(checkBoxAccEditEntries.Checked, "SolEditEntries");

            //catalogs
            UpdatePermissionIfChanged(checkBoxCatSolCatA.Checked, "SolAddCatalogues");
            UpdatePermissionIfChanged(checkBoxCatSolCatB.Checked, "SolEditCatalogues");

            //Tools
            UpdatePermissionIfChanged(checkBoxTooGeUsuariosABC.Checked, "GeUsuariosABC");
            UpdatePermissionIfChanged(checkBoxTooGeGruposABC.Checked, "GeGruposABC");
            UpdatePermissionIfChanged(checkBoxTooGeCambiarEmpresa.Checked, "GeCambiarEmpresa");
            UpdatePermissionIfChanged(checkBoxTooGeRecuperar.Checked, "GeRecuperar");
            UpdatePermissionIfChanged(checkBoxTooGeRespaldar.Checked, "GeRespaldar");
            UpdatePermissionIfChanged(checkBoxtOOGeCierreAnual.Checked, "GeCierreAnual");
            UpdatePermissionIfChanged(checkBoxTooSolCambiarOpciones.Checked, "SolCambiarOpciones");
            UpdatePermissionIfChanged(checkBoxTooUpdateVersion.Checked, "SolUpdateVersion");
            //checkBoxTooViewHelp;
            UpdatePermissionIfChanged(checkBoxTooEmailNotification.Checked, "SolUserEmail");
            UpdatePermissionIfChanged(checkBoxTooTrainingMode.Checked, "SolUseTraining");


            this.Cursor = Cursors.Default;
        }


        private void UpdatePermissionIfChanged(bool lastValue, string permission)
        {
            short res = 0;
            if (lastValue != originalValues[permission])
            {
                if (lastValue)
                {
                    if (target == "user")
                        res = SirLib.wsir_PermisosEnUsers.Agregar(strConnectionString, permission, name);
                    else
                        res = SirLib.wsir_PermisosEnRoles.Agregar(strConnectionString, permission, name);
                }
                else
                {
                    if (target == "user")
                        res = SirLib.wsir_PermisosEnUsers.Borrar(strConnectionString, permission, name);
                    else
                        res = SirLib.wsir_PermisosEnRoles.Borrar(strConnectionString, permission, name);
                }
            }

        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            UpdatePermissions();

        }

        private void buttonSelAll_Click(object sender, EventArgs e)
        {
            if (buttonSelAll.Text == "&Select all")
            {
                buttonSelAll.Text = "&Unselect all";
                SelectPermissions(true);
            }
            else
            {
                buttonSelAll.Text = "&Select all";
                SelectPermissions(false);
            }

        }


        private void SelectPermissions(bool flag)
        {
            //pos
            checkBoxPosCreateChit.Checked = flag;
            checkBoxPosDeleteChit.Checked = flag;
            checkBoxPosLookupChit.Checked = flag;
            checkBoxPosOpenChit.Checked = flag;
            checkBoxPosCashOutOrder.Checked = flag;
            checkBoxPosUnpayOrder.Checked = flag;
            checkBoxPutOnAccountButton.Checked = flag;
            checkBoxVoidOrder.Checked = flag;

            //shipments
            checkBoxShipShipping.Checked = flag;
            checkBoxShipCreateContainer.Checked = flag;
            checkBoxShipModifyContainer.Checked = flag;
            checkBoxShipViewContainer.Checked = flag;
            checkBoxShipCreateShipment.Checked = flag;
            checkBoxShipViewShipment.Checked = flag;
            checkBoxShipUnshipShipment.Checked = flag;
            checkBoxShipLookupShipment.Checked = flag;
            checkBoxAdjustShipment.Checked = flag;
            checkBoxVoidShipment.Checked = flag;
            checkBoxVoidStaged.Checked = flag;

            //Inventory
            checkBoxInvViewProducts.Checked = flag;
            checkBoxInvCreateProductAdjustment.Checked = flag;
            checkBoxInvViewSupplies.Checked = flag;
            checkBoxInvCreateSupplyAdjustment.Checked = flag;
            checkBoxInvPrintInventory.Checked = flag;

            //Accounting
            checkBoxAccOpenCashier.Checked = flag;
            checkBoxAccAddFloat.Checked = flag;
            checkBoxAccCloseCashier.Checked = flag;
            checkBoxAccAddExpenses.Checked = flag;
            checkBoxAccViewCustomer.Checked = flag;
            checkBoxAccEditCustomer.Checked = flag;
            checkBoxAccViewEntries.Checked = flag;
            checkBoxAccEditEntries.Checked = flag;

            //catalogs
            checkBoxCatSolCatA.Checked = flag;
            checkBoxCatSolCatB.Checked = flag;

            //Tools
            checkBoxTooGeUsuariosABC.Checked = flag;
            checkBoxTooGeGruposABC.Checked = flag;
            checkBoxTooGeCambiarEmpresa.Checked = flag;
            checkBoxTooGeRecuperar.Checked = flag;
            checkBoxTooGeRespaldar.Checked = flag;
            checkBoxtOOGeCierreAnual.Checked = flag;
            checkBoxTooSolCambiarOpciones.Checked = flag;
            checkBoxTooUpdateVersion.Checked = flag;
            //checkBoxTooViewHelp;
            checkBoxTooEmailNotification.Checked = flag;

        }

    }
}
