namespace MuseumAccounting
{
    partial class AssetMoveForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblAssetInfo;
        private System.Windows.Forms.Label lblNewLocation;
        private System.Windows.Forms.ComboBox cmbNewLocation;
        private System.Windows.Forms.Label lblMoveDate;
        private System.Windows.Forms.DateTimePicker dtpMoveDate;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAssetInfo = new System.Windows.Forms.Label();
            this.lblNewLocation = new System.Windows.Forms.Label();
            this.cmbNewLocation = new System.Windows.Forms.ComboBox();
            this.lblMoveDate = new System.Windows.Forms.Label();
            this.dtpMoveDate = new System.Windows.Forms.DateTimePicker();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblAssetInfo
            this.lblAssetInfo.AutoSize = true;
            this.lblAssetInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAssetInfo.Location = new System.Drawing.Point(12, 9);
            this.lblAssetInfo.Name = "lblAssetInfo";
            this.lblAssetInfo.Size = new System.Drawing.Size(0, 15);
            this.lblAssetInfo.TabIndex = 0;

            // lblNewLocation
            this.lblNewLocation.AutoSize = true;
            this.lblNewLocation.Location = new System.Drawing.Point(12, 40);
            this.lblNewLocation.Name = "lblNewLocation";
            this.lblNewLocation.Size = new System.Drawing.Size(110, 13);
            this.lblNewLocation.TabIndex = 1;
            this.lblNewLocation.Text = "Новое местоположение: *";

            // cmbNewLocation
            this.cmbNewLocation.DisplayMember = "Name";
            this.cmbNewLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewLocation.FormattingEnabled = true;
            this.cmbNewLocation.Location = new System.Drawing.Point(130, 37);
            this.cmbNewLocation.Name = "cmbNewLocation";
            this.cmbNewLocation.Size = new System.Drawing.Size(250, 21);
            this.cmbNewLocation.TabIndex = 2;
            this.cmbNewLocation.ValueMember = "Id";

            // lblMoveDate
            this.lblMoveDate.AutoSize = true;
            this.lblMoveDate.Location = new System.Drawing.Point(12, 70);
            this.lblMoveDate.Name = "lblMoveDate";
            this.lblMoveDate.Size = new System.Drawing.Size(82, 13);
            this.lblMoveDate.TabIndex = 3;
            this.lblMoveDate.Text = "Дата перемещения:";

            // dtpMoveDate
            this.dtpMoveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMoveDate.Location = new System.Drawing.Point(130, 67);
            this.dtpMoveDate.Name = "dtpMoveDate";
            this.dtpMoveDate.Size = new System.Drawing.Size(120, 20);
            this.dtpMoveDate.TabIndex = 4;

            // lblReason
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(12, 100);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(52, 13);
            this.lblReason.TabIndex = 5;
            this.lblReason.Text = "Причина:";

            // txtReason
            this.txtReason.Location = new System.Drawing.Point(130, 97);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(350, 20);
            this.txtReason.TabIndex = 6;

            // btnMove
            this.btnMove.Location = new System.Drawing.Point(240, 130);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(120, 30);
            this.btnMove.TabIndex = 7;
            this.btnMove.Text = "Выполнить перемещение";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.BtnMove_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(370, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // AssetMoveForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(494, 172);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.dtpMoveDate);
            this.Controls.Add(this.lblMoveDate);
            this.Controls.Add(this.cmbNewLocation);
            this.Controls.Add(this.lblNewLocation);
            this.Controls.Add(this.lblAssetInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssetMoveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Перемещение основного средства";
            this.Load += new System.EventHandler(this.AssetMoveForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}