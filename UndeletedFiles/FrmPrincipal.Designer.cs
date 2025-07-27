namespace UndeletedFiles
{
    partial class undeleteFilesForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.principalTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tituloLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buscarFicherosEliminadosButton = new System.Windows.Forms.Button();
            this.descripcionDelProcesoTextBox = new System.Windows.Forms.TextBox();
            this.principalTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // principalTableLayoutPanel
            // 
            this.principalTableLayoutPanel.ColumnCount = 1;
            this.principalTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.principalTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.principalTableLayoutPanel.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.principalTableLayoutPanel.Controls.Add(this.descripcionDelProcesoTextBox, 0, 1);
            this.principalTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.principalTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.principalTableLayoutPanel.Name = "principalTableLayoutPanel";
            this.principalTableLayoutPanel.RowCount = 3;
            this.principalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.76471F));
            this.principalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 367F));
            this.principalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.principalTableLayoutPanel.Size = new System.Drawing.Size(960, 450);
            this.principalTableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5869F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.4131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Controls.Add(this.tituloLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(954, 37);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tituloLabel
            // 
            this.tituloLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tituloLabel.AutoSize = true;
            this.tituloLabel.Location = new System.Drawing.Point(104, 0);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(770, 37);
            this.tituloLabel.TabIndex = 3;
            this.tituloLabel.Text = "Ejemplo basico de como recuperar ficheros eliminados mediante P/Invoke con tecnol" +
    "ogía .Net\r\nPara correcto funcionamiento ejecutar como Administrador.\r\n\r\n\r\n\r\n";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.02519F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.97481F));
            this.tableLayoutPanel2.Controls.Add(this.buscarFicherosEliminadosButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 413);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(954, 34);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buscarFicherosEliminadosButton
            // 
            this.buscarFicherosEliminadosButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buscarFicherosEliminadosButton.Location = new System.Drawing.Point(671, 3);
            this.buscarFicherosEliminadosButton.Name = "buscarFicherosEliminadosButton";
            this.buscarFicherosEliminadosButton.Size = new System.Drawing.Size(280, 28);
            this.buscarFicherosEliminadosButton.TabIndex = 0;
            this.buscarFicherosEliminadosButton.Text = "Buscar Ficheros eliminados";
            this.buscarFicherosEliminadosButton.UseVisualStyleBackColor = true;
            this.buscarFicherosEliminadosButton.Click += new System.EventHandler(this.buscarFicherosEliminadosButton_Click);
            // 
            // descripcionDelProcesoTextBox
            // 
            this.descripcionDelProcesoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descripcionDelProcesoTextBox.Location = new System.Drawing.Point(3, 46);
            this.descripcionDelProcesoTextBox.Multiline = true;
            this.descripcionDelProcesoTextBox.Name = "descripcionDelProcesoTextBox";
            this.descripcionDelProcesoTextBox.Size = new System.Drawing.Size(954, 361);
            this.descripcionDelProcesoTextBox.TabIndex = 2;
            // 
            // undeleteFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 450);
            this.Controls.Add(this.principalTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "undeleteFilesForm";
            this.Text = "Undelete Files";
            this.principalTableLayoutPanel.ResumeLayout(false);
            this.principalTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel principalTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buscarFicherosEliminadosButton;
        private System.Windows.Forms.TextBox descripcionDelProcesoTextBox;
    }
}

