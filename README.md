# UndeleteFiles

**UndeleteFiles** es una herramienta escrita en **.NET C#** que permite recuperar archivos eliminados en sistemas de archivos **NTFS** mediante llamadas nativas a funciones del sistema operativo usando **P/Invoke**. Es útil para la recuperación básica de datos eliminados accidentalmente desde el entorno gráfico de Windows.

---

## 🧩 Descripción

Esta aplicación aprovecha la interoperabilidad con la API nativa de Windows (Win32) para acceder a metadatos de archivos eliminados aún presentes en el sistema de archivos NTFS, permitiendo su restauración antes de que el espacio sea sobrescrito.

---

## ⚙️ Características

- Recuperación de archivos eliminados en unidades NTFS.
- Escaneo de entradas no referenciadas (MFT).
- Interfaz gráfica basada en **Windows Forms**.
- Uso de `P/Invoke` para acceder a funciones del sistema de bajo nivel.
- No requiere herramientas externas o dependencias de pago.

---

## 🛠 Requisitos

- Sistema operativo: **Windows 10/11** con particiones NTFS.
- [.NET Framework 4.x] o [.NET 6+] compatible con WinForms.
- Permisos de administrador (recomendado) para acceso completo al disco.

---

## 🔧 Instalación

```bash
git clone https://github.com/JED78/UndeleteFiles.git
cd UndeleteFiles
