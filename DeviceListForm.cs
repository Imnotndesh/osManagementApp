using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;

namespace winOsManagement
{
    public partial class DeviceListForm : Form
    {
        private ListView devicesList;

        private const int DIGCF_PRESENT = 0x02;
        private const int DIGCF_ALLCLASSES = 0x04;
        private const uint SPDRP_DEVICEDESC = 0x00000000;
        private const uint SPDRP_FRIENDLYNAME = 0x0000000C;

        [StructLayout(LayoutKind.Sequential)]
        private struct SP_DEVINFO_DATA
        {
            public int cbSize;
            public Guid ClassGuid;
            public int DevInst;
            public IntPtr Reserved;
        }

        // P/Invoke functions
        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern IntPtr SetupDiGetClassDevs(IntPtr classGuid, string enumerator, IntPtr hwndParent, int flags);

        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiEnumDeviceInfo(IntPtr deviceInfoSet, int memberIndex, ref SP_DEVINFO_DATA deviceInfoData);

        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiGetDeviceRegistryProperty(
            IntPtr deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            uint property,
            out uint propertyRegDataType,
            StringBuilder propertyBuffer,
            uint propertyBufferSize,
            out uint requiredSize);

        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiDestroyDeviceInfoList(IntPtr deviceInfoSet);
        public DeviceListForm()
        {
            InitializeComponent();
            devicesList = new ListView
            {
                Dock = DockStyle.Top,
                View = View.Details,
                Height = 300,
            };
            devicesList.Columns.Add("Device Name",250);
            devicesList.Columns.Add("Device Description", 300);
            Controls.Add(devicesList);
            FillListWithDevices();
        }
        private void FillListWithDevices()
        {
            devicesList.Items.Clear();
            IntPtr deviceInfoSet = SetupDiGetClassDevs(IntPtr.Zero, "USB", IntPtr.Zero, DIGCF_PRESENT | DIGCF_ALLCLASSES);
            if (deviceInfoSet == IntPtr.Zero)
            {
                MessageBox.Show("Failed to retrieve device list");
                return;
            }
            try
            {
                SP_DEVINFO_DATA deviceInfoData = new SP_DEVINFO_DATA();
                deviceInfoData.cbSize = Marshal.SizeOf(deviceInfoData);
                int deviceIndex = 0;
                

                while (SetupDiEnumDeviceInfo(deviceInfoSet,deviceIndex, ref deviceInfoData))
                {
                    deviceIndex++;
                    string deviceName = GetDeviceProperty(deviceInfoSet, deviceInfoData, SPDRP_DEVICEDESC) ?? "Unknown Device";
                    string deviceDescription = GetDeviceProperty(deviceInfoSet, deviceInfoData, SPDRP_FRIENDLYNAME) ?? "No Description";

                    // Add device information to ListView
                    ListViewItem item = new ListViewItem(deviceName);
                    item.SubItems.Add(deviceDescription);

                    devicesList.Items.Add(item);
                }
            }
            finally
            {
                SetupDiDestroyDeviceInfoList(deviceInfoSet);
            }
        }
        private string GetDeviceProperty(IntPtr deviceInfoSet, SP_DEVINFO_DATA deviceInfoData, uint property)
        {
            StringBuilder propertyBuffer = new StringBuilder(256);
            uint requiredSize = 0;

            bool success = SetupDiGetDeviceRegistryProperty(
                deviceInfoSet,
                ref deviceInfoData,
                property,
                out _,
                propertyBuffer,
                (uint)propertyBuffer.Capacity,
                out requiredSize);

            return success ? propertyBuffer.ToString() : null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillListWithDevices();
        }

        private bool ejectDevice(string deviceName)
        {
            try
            {
                // Use WMI to find and disable (eject) the device with the specified name
                using (var searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'"))
                {
                    foreach (ManagementObject device in searcher.Get())
                    {
                        if (device["Model"]?.ToString() == deviceName)
                        {
                            device.InvokeMethod("Disable", null); // Triggers safe removal
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error ejecting device: {ex.Message}");
            }

            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (devicesList.SelectedItems.Count > 0)
            {
                var selectedDeviceName = devicesList.SelectedItems[0].Text;
                bool success = ejectDevice(selectedDeviceName);
                if (success)
                {
                    MessageBox.Show("Device ejected successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to eject the device.");
                }
                FillListWithDevices();
            }
            else
            {
                MessageBox.Show("Please select a device to eject.");
            }
        }

    }
}
