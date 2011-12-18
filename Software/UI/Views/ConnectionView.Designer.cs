using System.Windows.Forms;

namespace ApProg.UI.Views
{
    partial class ConnectionView
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
            this.myLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lbPortId = new System.Windows.Forms.Label();
            this.lbBaudRate = new System.Windows.Forms.Label();
            this.lbData = new System.Windows.Forms.Label();
            this.lbParity = new System.Windows.Forms.Label();
            this.cbPortId = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.cbData = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbStop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.myLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // myLayout
            // 
            this.myLayout.ColumnCount = 2;
            this.myLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.myLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.myLayout.Controls.Add(this.lbPortId, 0, 0);
            this.myLayout.Controls.Add(this.lbBaudRate, 0, 1);
            this.myLayout.Controls.Add(this.lbData, 0, 2);
            this.myLayout.Controls.Add(this.lbParity, 0, 3);
            this.myLayout.Controls.Add(this.cbPortId, 1, 0);
            this.myLayout.Controls.Add(this.btnOk, 0, 5);
            this.myLayout.Controls.Add(this.btnCancel, 1, 5);
            this.myLayout.Controls.Add(this.cbBaudRate, 1, 1);
            this.myLayout.Controls.Add(this.cbData, 1, 2);
            this.myLayout.Controls.Add(this.cbParity, 1, 3);
            this.myLayout.Controls.Add(this.cbStop, 1, 4);
            this.myLayout.Controls.Add(this.label1, 0, 4);
            this.myLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayout.Location = new System.Drawing.Point(0, 0);
            this.myLayout.Name = "myLayout";
            this.myLayout.Padding = new System.Windows.Forms.Padding(10);
            this.myLayout.RowCount = 6;
            this.myLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.myLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.myLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.myLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.myLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.myLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.myLayout.Size = new System.Drawing.Size(228, 190);
            this.myLayout.TabIndex = 0;
            // 
            // lbPortId
            // 
            this.lbPortId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbPortId.AutoSize = true;
            this.lbPortId.Location = new System.Drawing.Point(13, 17);
            this.lbPortId.Name = "lbPortId";
            this.lbPortId.Size = new System.Drawing.Size(29, 13);
            this.lbPortId.TabIndex = 2;
            this.lbPortId.Text = "Port:";
            // 
            // lbBaudRate
            // 
            this.lbBaudRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbBaudRate.AutoSize = true;
            this.lbBaudRate.Location = new System.Drawing.Point(13, 44);
            this.lbBaudRate.Name = "lbBaudRate";
            this.lbBaudRate.Size = new System.Drawing.Size(56, 13);
            this.lbBaudRate.TabIndex = 3;
            this.lbBaudRate.Text = "Baud rate:";
            // 
            // lbData
            // 
            this.lbData.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbData.AutoSize = true;
            this.lbData.Location = new System.Drawing.Point(13, 71);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(33, 13);
            this.lbData.TabIndex = 4;
            this.lbData.Text = "Data:";
            // 
            // lbParity
            // 
            this.lbParity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbParity.AutoSize = true;
            this.lbParity.Location = new System.Drawing.Point(13, 98);
            this.lbParity.Name = "lbParity";
            this.lbParity.Size = new System.Drawing.Size(36, 13);
            this.lbParity.TabIndex = 5;
            this.lbParity.Text = "Parity:";
            // 
            // cbPortId
            // 
            this.cbPortId.FormattingEnabled = true;
            this.cbPortId.Location = new System.Drawing.Point(117, 13);
            this.cbPortId.Name = "cbPortId";
            this.cbPortId.Size = new System.Drawing.Size(98, 21);
            this.cbPortId.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(24, 151);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(125, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Location = new System.Drawing.Point(117, 40);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(98, 21);
            this.cbBaudRate.TabIndex = 7;
            // 
            // cbData
            // 
            this.cbData.FormattingEnabled = true;
            this.cbData.Location = new System.Drawing.Point(117, 67);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(98, 21);
            this.cbData.TabIndex = 8;
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(117, 94);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(98, 21);
            this.cbParity.TabIndex = 9;
            // 
            // cbStop
            // 
            this.cbStop.FormattingEnabled = true;
            this.cbStop.Location = new System.Drawing.Point(117, 121);
            this.cbStop.Name = "cbStop";
            this.cbStop.Size = new System.Drawing.Size(98, 21);
            this.cbStop.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Stop bits:";
            // 
            // ConnectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 190);
            this.Controls.Add(this.myLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConnectionView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectionView Settings";
            this.TopMost = true;
            this.myLayout.ResumeLayout(false);
            this.myLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel myLayout;
        private Button btnOk;
        private Button btnCancel;
        private Label lbPortId;
        private Label lbBaudRate;
        private Label lbData;
        private Label lbParity;
        private ComboBox cbPortId;
        private ComboBox cbBaudRate;
        private ComboBox cbData;
        private ComboBox cbParity;
        private ComboBox cbStop;
        private Label label1;
    }
}