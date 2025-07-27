using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

class NTFSDeletedFileRecovery
{
    #region kernel32.dll
    // P/Invoke declarations
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
    static extern bool ReadFile(
        SafeFileHandle hFile,
        byte[] lpBuffer,
        int nNumberOfBytesToRead,
        out int lpNumberOfBytesRead,
        IntPtr lpOverlapped);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool SetFilePointerEx(
        SafeFileHandle hFile,
        long liDistanceToMove,
        out long lpNewFilePointer,
        uint dwMoveMethod);

    // Constants
    const uint GENERIC_READ = 0x80000000;
    const uint FILE_SHARE_READ = 0x00000001;
    const uint FILE_SHARE_WRITE = 0x00000002;
    const uint OPEN_EXISTING = 3;
    const uint FILE_BEGIN = 0;

    // Struct for FILE_RECORD_HEADER (simplified)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct FILE_RECORD_HEADER
    {
        public uint Signature; // 'FILE'
        public ushort UpdateSeqOffset;
        public ushort UpdateSeqSize;
        public ulong LogSeqNumber;
        public ushort SequenceNumber;
        public ushort HardLinkCount;
        public ushort FirstAttrOffset;
        public ushort Flags;
        public uint UsedSize;
        public uint AllocatedSize;
        public ulong BaseRecord;
        public ushort NextAttrID;
        public ushort Align;
        public uint MFTRecordNumber;
    }

    #endregion

    #region Funciones de recuperación
    public static string ScanAndRecoverMFT(string driveLetter)
    {
        string descripcion = (Environment.NewLine + "Escanea el volumen NTFS en busca de registros MFT eliminados y los recupera.");
        string volume = @"\\.\C:";
        descripcion += (Environment.NewLine + $"[*] Accediendo al volumen: {volume}");

         SafeFileHandle diskHandle = CreateFile(
            volume,
            GENERIC_READ,
            FILE_SHARE_READ | FILE_SHARE_WRITE,
            IntPtr.Zero,
            OPEN_EXISTING,
            0,
            IntPtr.Zero);

        if (diskHandle.IsInvalid)
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                descripcion += Environment.NewLine + ($"Unidad detectada: {drive.Name} - Tipo: {drive.DriveType} - Formato: {drive.DriveFormat}");
            }

            descripcion +=  ObtenerDescripcionDeErrorAlAbrirDisco(diskHandle);
            descripcion += (Environment.NewLine + "[-] No se pudo abrir el volumen. Ejecuta como Administrador.");
            return descripcion;
        }
        

        const long maxMFTSize = 1024L * 1024 * 512; // Leer hasta 512MB del disco
        const int sectorSize = 1024;
        byte[] buffer = new byte[sectorSize];

        descripcion += (Environment.NewLine + "[*] Escaneando en busca de registros MFT eliminados...");

        for (long offset = 0; offset < maxMFTSize; offset += sectorSize)
        {
            SetFilePointerEx(diskHandle, offset, out _, FILE_BEGIN);

            if (!ReadFile(diskHandle, buffer, buffer.Length, out int bytesRead, IntPtr.Zero) || bytesRead < 4)
                continue;

            if (buffer[0] == 'F' && buffer[1] == 'I' && buffer[2] == 'L' && buffer[3] == 'E')
            {
                IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                FILE_RECORD_HEADER header = Marshal.PtrToStructure<FILE_RECORD_HEADER>(ptr);

                bool inUse = (header.Flags & 0x01) != 0;

                if (!inUse)
                {
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"recovered_{header.MFTRecordNumber}.bin");
                    File.WriteAllBytes(outputPath, buffer);
                    descripcion += (Environment.NewLine + $"[+] Archivo eliminado recuperado: {outputPath} ({header.UsedSize} bytes)");
                }
            }
        }

        descripcion += (Environment.NewLine + "[*] Escaneo finalizado.");

        return descripcion;
    }
    #endregion

    #region Funciones Privadas

    private static string ObtenerDescripcionDeErrorAlAbrirDisco(SafeFileHandle diskHandle)
    {

        if (diskHandle.IsInvalid)
        {
            String descripcionError = string.Empty;
            int errorCode = Marshal.GetLastWin32Error();
            descripcionError =  Environment.NewLine +  $"Error Codigo: {errorCode}" + Environment.NewLine + "[-] Error al abrir el disco: {new System.ComponentModel.Win32Exception(errorCode).Message}";
        
            if (errorCode == 5)
            {
                descripcionError += Environment.NewLine + "[-] Asegúrate de ejecutar la aplicación como Administrador.";
            }
            else if (errorCode == 32)
            {
                descripcionError += Environment.NewLine + "[-] El disco está en uso por otro proceso.";
            }
            else if (errorCode == 3)
            {
                descripcionError += Environment.NewLine + "[-] El volumen no existe o no está disponible.";
            }
            else if (errorCode == 1008)
            {
                descripcionError += Environment.NewLine + "An attempt was made to reference a token that does not exist.";
                descripcionError += Environment.NewLine + "Este error generalmente ocurre cuando:";
                descripcionError += Environment.NewLine + "1. El proceso no tiene los privilegios necesarios para acceder al volumen raw.";
                descripcionError += Environment.NewLine + "2. Estás intentando abrir \\\\.\\C: u otro volumen protegido por el sistema operativo.";
                descripcionError += Environment.NewLine + "3. El programa requiere elevación, pero Windows aún bloquea el acceso por seguridad (aún como admin).";

            }

        }
        if (diskHandle.IsClosed)
        {
            return Environment.NewLine + "[-] El handle del disco está cerrado.";
        }
      
        return string.Empty;
    }
    #endregion
}
