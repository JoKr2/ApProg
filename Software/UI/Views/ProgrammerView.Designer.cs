namespace ApProg.UI.Views
{
    partial class ProgrammerView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnReadDevice = new System.Windows.Forms.Button();
            this.btnWriteDevice = new System.Windows.Forms.Button();
            this.btnEraseDevice = new System.Windows.Forms.Button();
            this.btnReadAppId = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnReadDevId = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 6;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.Controls.Add(this.btnReadDevice, 5, 1);
            this.tableLayout.Controls.Add(this.btnWriteDevice, 4, 1);
            this.tableLayout.Controls.Add(this.btnEraseDevice, 3, 1);
            this.tableLayout.Controls.Add(this.btnReadAppId, 2, 1);
            this.tableLayout.Controls.Add(this.btnConnect, 0, 0);
            this.tableLayout.Controls.Add(this.btnFile, 5, 0);
            this.tableLayout.Controls.Add(this.txtFile, 1, 0);
            this.tableLayout.Controls.Add(this.btnReadDevId, 1, 1);
            this.tableLayout.Controls.Add(this.txtMessage, 0, 2);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 3;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.Size = new System.Drawing.Size(496, 294);
            this.tableLayout.TabIndex = 0;
            // 
            // btnReadDevice
            // 
            this.btnReadDevice.Location = new System.Drawing.Point(421, 31);
            this.btnReadDevice.Name = "btnReadDevice";
            this.btnReadDevice.Size = new System.Drawing.Size(72, 54);
            this.btnReadDevice.TabIndex = 7;
            this.btnReadDevice.Text = "Read\r\nDevice";
            this.btnReadDevice.UseVisualStyleBackColor = true;
            this.btnReadDevice.Click += new System.EventHandler(this.OnReadDeviceClick);
            // 
            // btnWriteDevice
            // 
            this.btnWriteDevice.Location = new System.Drawing.Point(340, 31);
            this.btnWriteDevice.Name = "btnWriteDevice";
            this.btnWriteDevice.Size = new System.Drawing.Size(75, 54);
            this.btnWriteDevice.TabIndex = 6;
            this.btnWriteDevice.Text = "Write\r\nDevice";
            this.btnWriteDevice.UseVisualStyleBackColor = true;
            this.btnWriteDevice.Click += new System.EventHandler(this.OnWriteDeviceClick);
            // 
            // btnEraseDevice
            // 
            this.btnEraseDevice.Location = new System.Drawing.Point(259, 31);
            this.btnEraseDevice.Name = "btnEraseDevice";
            this.btnEraseDevice.Size = new System.Drawing.Size(75, 54);
            this.btnEraseDevice.TabIndex = 5;
            this.btnEraseDevice.Text = "Erase\r\nDevice";
            this.btnEraseDevice.UseVisualStyleBackColor = true;
            this.btnEraseDevice.Click += new System.EventHandler(this.OnEraseDevicClick);
            // 
            // btnReadAppId
            // 
            this.btnReadAppId.Location = new System.Drawing.Point(178, 31);
            this.btnReadAppId.Name = "btnReadAppId";
            this.btnReadAppId.Size = new System.Drawing.Size(75, 54);
            this.btnReadAppId.TabIndex = 4;
            this.btnReadAppId.Text = "Read\r\nApplication Id";
            this.btnReadAppId.UseVisualStyleBackColor = true;
            this.btnReadAppId.Click += new System.EventHandler(this.OnReadAppIdClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConnect.Location = new System.Drawing.Point(3, 3);
            this.btnConnect.Name = "btnConnect";
            this.tableLayout.SetRowSpan(this.btnConnect, 2);
            this.btnConnect.Size = new System.Drawing.Size(88, 82);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.OnBtnConnectClick);
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFile.Location = new System.Drawing.Point(421, 3);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(72, 22);
            this.btnFile.TabIndex = 1;
            this.btnFile.Text = "Load";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.OnBtnFileClick);
            // 
            // txtFile
            // 
            this.tableLayout.SetColumnSpan(this.txtFile, 4);
            this.txtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtFile.Location = new System.Drawing.Point(97, 3);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(311, 22);
            this.txtFile.TabIndex = 2;
            this.txtFile.Text = "...";
            // 
            // btnReadDevId
            // 
            this.btnReadDevId.Location = new System.Drawing.Point(97, 31);
            this.btnReadDevId.Name = "btnReadDevId";
            this.btnReadDevId.Size = new System.Drawing.Size(75, 54);
            this.btnReadDevId.TabIndex = 3;
            this.btnReadDevId.Text = "Read \r\nDevice Id";
            this.btnReadDevId.UseVisualStyleBackColor = true;
            this.btnReadDevId.Click += new System.EventHandler(this.OnReadDevIdClick);
            // 
            // txtMessage
            // 
            this.tableLayout.SetColumnSpan(this.txtMessage, 6);
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(3, 91);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(490, 200);
            this.txtMessage.TabIndex = 8;
            this.txtMessage.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // ProgrammerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 294);
            this.Controls.Add(this.tableLayout);
            this.Name = "ProgrammerView";
            this.Text = "ProgrammerView";
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnReadDevice;
        private System.Windows.Forms.Button btnWriteDevice;
        private System.Windows.Forms.Button btnEraseDevice;
        private System.Windows.Forms.Button btnReadAppId;
        private System.Windows.Forms.Button btnReadDevId;
        private System.Windows.Forms.TextBox txtMessage;
    }
}

