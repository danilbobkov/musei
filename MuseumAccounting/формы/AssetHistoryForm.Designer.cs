namespace MuseumAccounting
{
    partial class AssetHistoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovementDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReason;

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
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.colMovementDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOldLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();

            // dgvHistory
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoGenerateColumns = false;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMovementDate,
                this.colOldLocation,
                this.colNewLocation,
                this.colReason
            });
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(684, 361);
            this.dgvHistory.TabIndex = 0;

            // colMovementDate
            this.colMovementDate.DataPropertyName = "MovementDate";
            this.colMovementDate.HeaderText = "Дата";
            this.colMovementDate.Name = "colMovementDate";
            this.colMovementDate.ReadOnly = true;
            this.colMovementDate.Width = 130;
            this.colMovementDate.DefaultCellStyle.Format = "g";

            // colOldLocation
            this.colOldLocation.DataPropertyName = "OldLocationName";
            this.colOldLocation.HeaderText = "Старое место";
            this.colOldLocation.Name = "colOldLocation";
            this.colOldLocation.ReadOnly = true;
            this.colOldLocation.Width = 150;

            // colNewLocation
            this.colNewLocation.DataPropertyName = "NewLocationName";
            this.colNewLocation.HeaderText = "Новое место";
            this.colNewLocation.Name = "colNewLocation";
            this.colNewLocation.ReadOnly = true;
            this.colNewLocation.Width = 150;

            // colReason
            this.colReason.DataPropertyName = "Reason";
            this.colReason.HeaderText = "Причина";
            this.colReason.Name = "colReason";
            this.colReason.ReadOnly = true;
            this.colReason.Width = 200;

            // AssetHistoryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.dgvHistory);
            this.Name = "AssetHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "История перемещений";
            this.Load += new System.EventHandler(this.AssetHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
        }
    }
}