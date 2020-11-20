using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32.SafeHandles;
using System.IO;
using System.Runtime.InteropServices;

using Microsoft.VisualBasic;
using System.Windows.Forms;

using SirLib.Hid;

namespace Solum
{
    public class SirLibHid
    {

        ///  <summary>
        ///  Uses a series of API calls to locate a HID-class device
        ///  by its Vendor ID and Product ID.
        ///  </summary>
        ///          
        ///  <returns>
        ///   True if the device is detected, False if not detected.
        ///  </returns>

        public static Boolean FindTheHid(
            int myVendorID
            , int myProductID
            , ref IntPtr FrmMyHandle
            , ref IntPtr deviceNotificationHandle
            , ref Boolean exclusiveAccess
            , ref String hidUsage
            , ref Boolean myDeviceDetected
            , ref String myDevicePathName
            , ref FileStream fileStreamDeviceData
            , ref SafeFileHandle hidHandle
            , ref DeviceManagement MyDeviceManagement
            , ref Hid MyHid
            , ref string message
            , ref string txtInputReportBufferSize
            )
        {
            Boolean deviceFound = false;
            String[] devicePathName = new String[128];
            Guid hidGuid = Guid.Empty;
            Int32 memberIndex = 0;
            //Int32 myProductID = 0;
            //Int32 myVendorID = 0;
            Boolean success = false;

            try
            {
                myDeviceDetected = false;
                CloseCommunications(
                    ref myDeviceDetected
                    , ref fileStreamDeviceData
                    , ref hidHandle
                    );

                //  Get the device's Vendor ID and Product ID

                //myVendorID = Main.CardReader_VID;
                //myProductID = Main.CardReader_PID;

                //  ***
                //  API function: 'HidD_GetHidGuid
                //  Purpose: Retrieves the interface class GUID for the HID class.
                //  Accepts: 'A System.Guid object for storing the GUID.
                //  ***

                Hid.HidD_GetHidGuid(ref hidGuid);

                //  Fill an array with the device path names of all attached HIDs.
                deviceFound = MyDeviceManagement.FindDeviceFromGuid(hidGuid, ref devicePathName);

                //  If there is at least one HID, attempt to read the Vendor ID and Product ID
                //  of each device until there is a match or all devices have been examined.

                if (deviceFound)
                {
                    memberIndex = 0;

                    do
                    {
                        //  ***
                        //  API function:
                        //  CreateFile

                        //  Purpose:
                        //  Retrieves a handle to a device.

                        //  Accepts:
                        //  A device path name returned by SetupDiGetDeviceInterfaceDetail
                        //  The type of access requested (read/write).
                        //  FILE_SHARE attributes to allow other processes to access the device while this handle is open.
                        //  A Security structure or IntPtr.Zero. 
                        //  A creation disposition value. Use OPEN_EXISTING for devices.
                        //  Flags and attributes for files. Not used for devices.
                        //  Handle to a template file. Not used.

                        //  Returns: a handle without read or write access.
                        //  This enables obtaining information about all HIDs, even system
                        //  keyboards and mice. 
                        //  Separate handles are used for reading and writing.
                        //  ***

                        // Open the handle without read/write access to enable getting information about any HID, even system keyboards and mice.
                        hidHandle = FileIO.CreateFile(devicePathName[memberIndex], 0, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, 0, 0);

                        if (!hidHandle.IsInvalid)
                        {
                            //  The returned handle is valid, 
                            //  so find out if this is the device we're looking for.

                            //  Set the Size property of DeviceAttributes to the number of bytes in the structure.

                            MyHid.DeviceAttributes.Size = Marshal.SizeOf(MyHid.DeviceAttributes);

                            //  ***
                            //  API function:
                            //  HidD_GetAttributes

                            //  Purpose:
                            //  Retrieves a HIDD_ATTRIBUTES structure containing the Vendor ID, 
                            //  Product ID, and Product Version Number for a device.

                            //  Accepts:
                            //  A handle returned by CreateFile.
                            //  A pointer to receive a HIDD_ATTRIBUTES structure.

                            //  Returns:
                            //  True on success, False on failure.
                            //  ***                            

                            success = Hid.HidD_GetAttributes(hidHandle, ref MyHid.DeviceAttributes);

                            if (success)
                            {

                                //  Find out if the device matches the one we're looking for.
                                if ((MyHid.DeviceAttributes.VendorID == myVendorID) && (MyHid.DeviceAttributes.ProductID == myProductID))
                                {
                                    //  Display the information in form's list box.
                                    message = "was found.";

                                    myDeviceDetected = true;

                                    //  Save the DevicePathName for OnDeviceChange().
                                    myDevicePathName = devicePathName[memberIndex];
                                }
                                else
                                {
                                    //  It's not a match, so close the handle.

                                    myDeviceDetected = false;
                                    hidHandle.Close();
                                }
                            }
                            else
                            {
                                //  There was a problem in retrieving the information.

                                //Debug.WriteLine("  Error in filling HIDD_ATTRIBUTES structure.");
                                myDeviceDetected = false;
                                hidHandle.Close();
                            }
                        }

                        //  Keep looking until we find the device or there are no devices left to examine.

                        memberIndex = memberIndex + 1;
                    }
                    while (!((myDeviceDetected || (memberIndex == devicePathName.Length))));
                }

                if (myDeviceDetected)
                {
                    //  The device was detected.
                    //  Register to receive notifications if the device is removed or attached.

                    success = MyDeviceManagement.RegisterForDeviceNotifications(myDevicePathName, FrmMyHandle, hidGuid, ref deviceNotificationHandle);

                    //  Learn the capabilities of the device.

                    MyHid.Capabilities = MyHid.GetDeviceCapabilities(hidHandle);

                    if (success)
                    {
                        //  Find out if the device is a system mouse or keyboard.

                        hidUsage = MyHid.GetHidUsage(MyHid.Capabilities);

                        //  Get the Input report buffer size.

                        GetInputReportBufferSize(
                            ref exclusiveAccess
                            , ref hidHandle
                            , ref MyHid
                            , ref txtInputReportBufferSize
                            );

                        //Close the handle and reopen it with read/write access.

                        hidHandle.Close();
                        hidHandle = FileIO.CreateFile(myDevicePathName, FileIO.GENERIC_READ | FileIO.GENERIC_WRITE, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, 0, 0);

                        if (hidHandle.IsInvalid)
                        {
                            exclusiveAccess = true;
                        }
                        else
                        {
                            if (MyHid.Capabilities.InputReportByteLength > 0)
                            {
                                //  Set the size of the Input report buffer. 

                                Byte[] inputReportBuffer = null;
                                inputReportBuffer = new Byte[MyHid.Capabilities.InputReportByteLength];

                                fileStreamDeviceData = new FileStream(hidHandle, FileAccess.Read | FileAccess.Write, inputReportBuffer.Length, false);
                            }

                            if (MyHid.Capabilities.OutputReportByteLength > 0)
                            {
                                Byte[] outputReportBuffer = null;
                                outputReportBuffer = new Byte[MyHid.Capabilities.OutputReportByteLength];
                            }

                            //  Flush any waiting reports in the input buffer. (optional)

                            MyHid.FlushQueue(hidHandle);
                        }
                    }
                }
                else
                {
                    //  The device wasn't detected.
                    myDeviceDetected = false;
                    message = "not found.";

                }

                return myDeviceDetected;
            }

            catch (Exception ex)
            {
                DisplayException("FindTheHid", ex);
                //throw;
            }

            return false;
        }


        /// <summary>
        /// Close the handle and FileStreams for a device.
        /// </summary>
        /// 
        public static  void CloseCommunications(
            ref Boolean myDeviceDetected
            , ref FileStream fileStreamDeviceData
            , ref SafeFileHandle hidHandle
            )
        {
            if (fileStreamDeviceData != null)
            {
                fileStreamDeviceData.Close();
            }

            if ((hidHandle != null) && (!(hidHandle.IsInvalid)))
            {
                hidHandle.Close();
            }

            // The next attempt to communicate will get new handles and FileStreams.
            myDeviceDetected = false;
        }

        ///  <summary>
        ///  Finds and displays the number of Input buffers
        ///  (the number of Input reports the host will store). 
        ///  </summary>

        public static void GetInputReportBufferSize(
            ref Boolean exclusiveAccess
            , ref SafeFileHandle hidHandle
            , ref Hid MyHid
            , ref string txtInputReportBufferSize
            
            )
        {
            Int32 numberOfInputBuffers = 0;
            Boolean success;

            try
            {
                //  Get the number of input buffers.

                success = MyHid.GetNumberOfInputBuffers(hidHandle, ref numberOfInputBuffers);

                //  Display the result in the text box.

                txtInputReportBufferSize = Convert.ToString(numberOfInputBuffers);
            }
            catch (Exception ex)
            {
                DisplayException("GetInputReportBufferSize", ex);
                //throw;
            }
        }


        ///  <summary>
        ///  Provides a central mechanism for exception handling.
        ///  Displays a message box that describes the exception.
        ///  </summary>
        ///  
        ///  <param name="moduleName"> the module where the exception occurred. </param>
        ///  <param name="e"> the exception </param>

        public static void DisplayException(String moduleName, Exception e)
        {
            String message = null;
            String caption = null;

            //  Create an error message.

            message = "Exception: " + e.Message + ControlChars.CrLf + "Module: " + moduleName + ControlChars.CrLf + "Method: " + e.TargetSite.Name;

            caption = "Unexpected Exception";

            MessageBox.Show(message, caption, MessageBoxButtons.OK);
            //Debug.Write(message);
        }


    }
}
