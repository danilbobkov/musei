namespace MuseumAccounting
{
    partial class AssetEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblInventoryNumber;
        private System.Windows.Forms.TextBox txtInventoryNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCommissionDate;
        private System.Windows.Forms.DateTimePicker dtpCommissionDate;
        private System.Windows.Forms.Label lblInitialCost;
        private System.Windows.Forms.TextBox txtInitialCost;
        private System.Windows.Forms.Label lblResponsible;
        private System.Windows.Forms.ComboBox cmbResponsible;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
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
            this.lblInventoryNumber = new System.Windows.Forms.Label();
            this.txtInventoryNumber = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCommissionDate = new System.Windows.Forms.Label();
            this.dtpCommissionDate = new System.Windows.Forms.DateTimePicker();
            this.lblInitialCost = new System.Windows.Forms.Label();
            this.txtInitialCost = new System.Windows.Forms.TextBox();
            this.lblResponsible = new System.Windows.Forms.Label();
            this.cmbResponsible = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblInventoryNumber
            this.lblInventoryNumber.AutoSize = true;
            this.lblInventoryNumber.Location = new System.Drawing.Point(12, 15);
            this.lblInventoryNumber.Name = "lblInventoryNumber";
            this.lblInventoryNumber.Size = new System.Drawing.Size(82, 13);
            this.lblInventoryNumber.TabIndex = 0;
            this.lblInventoryNumber.Text = "Инв. номер: *";

            // txtInventoryNumber
            this.txtInventoryNumber.Location = new System.Drawing.Point(120, 12);
            this.txtInventoryNumber.Name = "txtInventoryNumber";
            this.txtInventoryNumber.Size = new System.Drawing.Size(250, 20);
            this.txtInventoryNumber.TabIndex = 1;

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 45);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(86, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Наименование: *";

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(400, 20);
            this.txtName.TabIndex = 3;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 75);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 13);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Категория: *";

            // cmbCategory
            this.cmbCategory.DisplayMember = "Name";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(120, 72);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(250, 21);
            this.cmbCategory.TabIndex = 5;
            this.cmbCategory.ValueMember = "Id";

            // lblCommissionDate
            this.lblCommissionDate.AutoSize = true;
            this.lblCommissionDate.Location = new System.Drawing.Point(12, 105);
            this.lblCommissionDate.Name = "lblCommissionDate";
            this.lblCommissionDate.Size = new System.Drawing.Size(76, 13);
            this.lblCommissionDate.TabIndex = 6;
            this.lblCommissionDate.Text = "Дата ввода: *";

            // dtpCommissionDate
            this.dtpCommissionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCommissionDate.Location = new System.Drawing.Point(120, 102);
            this.dtpCommissionDate.Name = "dtpCommissionDate";
            this.dtpCommissionDate.Size = new System.Drawing.Size(120, 20);
            this.dtpCommissionDate.TabIndex = 7;

            // lblInitialCost
            this.lblInitialCost.AutoSize = true;
            this.lblInitialCost.Location = new System.Drawing.Point(12, 135);
            this.lblInitialCost.Name = "lblInitialCost";
            this.lblInitialCost.Size = new System.Drawing.Size(74, 13);
            this.lblInitialCost.TabIndex = 8;
            this.lblInitialCost.Text = "Стоимость: *";

            // txtInitialCost
            this.txtInitialCost.Location = new System.Drawing.Point(120, 132);
            this.txtInitialCost.Name = "txtInitialCost";
            this.txtInitialCost.Size = new System.Drawing.Size(120, 20);
            this.txtInitialCost.TabIndex = 9;

            // lblResponsible
            this.lblResponsible.AutoSize = true;
            this.lblResponsible.Location = new System.Drawing.Point(12, 165);
            this.lblResponsible.Name = "lblResponsible";
            this.lblResponsible.Size = new System.Drawing.Size(40, 13);
            this.lblResponsible.TabIndex = 10;
            this.lblResponsible.Text = "МОЛ: *";

            // cmbResponsible
            this.cmbResponsible.DisplayMember = "FullName";
            this.cmbResponsible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsible.FormattingEnabled = true;
            this.cmbResponsible.Location = new System.Drawing.Point(120, 162);
            this.cmbResponsible.Name = "cmbResponsible";
            this.cmbResponsible.Size = new System.Drawing.Size(250, 21);
            this.cmbResponsible.TabIndex = 11;
            this.cmbResponsible.ValueMember = "Id";

            // lblLocation
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(12, 195);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(88, 13);
            this.lblLocation.TabIndex = 12;
            this.lblLocation.Text = "Местоположение:";

            // cmbLocation
            this.cmbLocation.DisplayMember = "Name";
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(120, 192);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(250, 21);
            this.cmbLocation.TabIndex = 13;
            this.cmbLocation.ValueMember = "Id";

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 225);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 13);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Статус:";

            // cmbStatus
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(120, 222);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 15;

            // lblNotes
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(12, 255);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(62, 13);
            this.lblNotes.TabIndex = 16;
            this.lblNotes.Text = "Примечание:";

            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(120, 252);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(400, 80);
            this.txtNotes.TabIndex = 17;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(260, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(360, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // AssetEditForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(534, 392);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.cmbResponsible);
            this.Controls.Add(this.lblResponsible);
            this.Controls.Add(this.txtInitialCost);
            this.Controls.Add(this.lblInitialCost);
            this.Controls.Add(this.dtpCommissionDate);
            this.Controls.Add(this.lblCommissionDate);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtInventoryNumber);
            this.Controls.Add(this.lblInventoryNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssetEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование основного средства";
            this.Load += new System.EventHandler(this.AssetEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}