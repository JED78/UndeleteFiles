using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndeletedFiles
{
    public partial class undeleteFilesForm : Form
    {
        #region Constantes y Variables

        // P/Invoke Declarations
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool DeviceIoControl(
            SafeFileHandle hDevice,
            uint dwIoControlCode,
            ref MFT_ENUM_DATA inBuffer,
            uint nInBufferSize,
            byte[] outBuffer,
            uint nOutBufferSize,
            out uint bytesReturned,
            IntPtr overlapped);

        // Structs
        [StructLayout(LayoutKind.Sequential)]
        struct MFT_ENUM_DATA
        {
            public ulong StartFileReferenceNumber;
            public long LowUsn;
            public long HighUsn;
        }

        // Constants
        const uint FSCTL_ENUM_USN_DATA = 0x000900b3;
        const uint GENERIC_READ = 0x80000000;
        const uint FILE_SHARE_READ = 0x00000001;
        const uint FILE_SHARE_WRITE = 0x00000002;
        const uint OPEN_EXISTING = 3;
        const int USN_PAGE_SIZE = 65536;

        #endregion

        #region Constructor
        public undeleteFilesForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Funciones Privadas

        #region Eventos de los botones

        /// <summary>
        /// Función que se ejecuta al pulsar el botón de buscar ficheros eliminados.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void buscarFicherosEliminadosButton_Click(object sender, EventArgs e)
        {
            descripcionDelProcesoTextBox.Text += Environment.NewLine + ("Unidades disponibles con formato NTFS:");

            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.DriveFormat == "NTFS")
                {
                    descripcionDelProcesoTextBox.Text += Environment.NewLine + ($"- {drive.Name} (Tipo: {drive.DriveType})");
                    descripcionDelProcesoTextBox.Text += Environment.NewLine;
                    descripcionDelProcesoTextBox.Text += Environment.NewLine + ($"Iniciando Proceso. Esto puede tardar varios minutos.");
                    descripcionDelProcesoTextBox.Text += NTFSDeletedFileRecovery.ScanAndRecoverMFT(drive.Name);
                }
            }

            
        }

        #endregion
        #endregion
    }
}
