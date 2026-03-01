namespace MuseumAccounting
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem местоположенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категорииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инвентаризационнаяВедомостьToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageAssets;
        private System.Windows.Forms.DataGridView dgvFixedAssets;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAddAsset;
        private System.Windows.Forms.Button btnEditAsset;
        private System.Windows.Forms.Button btnMoveAsset;
        private System.Windows.Forms.Button btnWriteOffAsset;
        private System.Windows.Forms.Button btnHistoryAsset;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.BindingSource fixedAssetsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponsible;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInitialCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommissionDate;

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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.местоположенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инвентаризационнаяВедомостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageAssets = new System.Windows.Forms.TabPage();
            this.dgvFixedAssets = new System.Windows.Forms.DataGridView();
            this.colInventoryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInitialCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommissionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAddAsset = new System.Windows.Forms.Button();
            this.btnEditAsset = new System.Windows.Forms.Button();
            this.btnMoveAsset = new System.Windows.Forms.Button();
            this.btnWriteOffAsset = new System.Windows.Forms.Button();
            this.btnHistoryAsset = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.fixedAssetsBindingSource = new System.Windows.Forms.BindingSource(this.components);

            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixedAssets)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fixedAssetsBindingSource)).BeginInit();
            this.SuspendLayout();

            // menuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.файлToolStripMenuItem,
                this.справочникиToolStripMenuItem,
                this.отчётыToolStripMenuItem
            });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(984, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";

            // файлToolStripMenuItem
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.выходToolStripMenuItem
            });
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";

            // выходToolStripMenuItem
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ВыходToolStripMenuItem_Click);

            // справочникиToolStripMenuItem
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.сотрудникиToolStripMenuItem,
                this.местоположенияToolStripMenuItem,
                this.категорииToolStripMenuItem
            });
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";

            // сотрудникиToolStripMenuItem
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.СотрудникиToolStripMenuItem_Click);

            // местоположенияToolStripMenuItem
            this.местоположенияToolStripMenuItem.Name = "местоположенияToolStripMenuItem";
            this.местоположенияToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.местоположенияToolStripMenuItem.Text = "Местоположения";
            this.местоположенияToolStripMenuItem.Click += new System.EventHandler(this.МестоположенияToolStripMenuItem_Click);

            // категорииToolStripMenuItem
            this.категорииToolStripMenuItem.Name = "категорииToolStripMenuItem";
            this.категорииToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.категорииToolStripMenuItem.Text = "Категории";
            this.категорииToolStripMenuItem.Click += new System.EventHandler(this.КатегорииToolStripMenuItem_Click);

            // отчётыToolStripMenuItem
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.инвентаризационнаяВедомостьToolStripMenuItem
            });
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";

            // инвентаризационнаяВедомостьToolStripMenuItem
            this.инвентаризационнаяВедомостьToolStripMenuItem.Name = "инвентаризационнаяВедомостьToolStripMenuItem";
            this.инвентаризационнаяВедомостьToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.инвентаризационнаяВедомостьToolStripMenuItem.Text = "Инвентаризационная ведомость";
            this.инвентаризационнаяВедомостьToolStripMenuItem.Click += new System.EventHandler(this.ИнвентаризационнаяВедомостьToolStripMenuItem_Click);

            // tabControl
            this.tabControl.Controls.Add(this.tabPageAssets);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(984, 537);
            this.tabControl.TabIndex = 1;

            // tabPageAssets
            this.tabPageAssets.Controls.Add(this.dgvFixedAssets);
            this.tabPageAssets.Controls.Add(this.panelButtons);
            this.tabPageAssets.Controls.Add(this.panelSearch);
            this.tabPageAssets.Location = new System.Drawing.Point(4, 22);
            this.tabPageAssets.Name = "tabPageAssets";
            this.tabPageAssets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAssets.Size = new System.Drawing.Size(976, 511);
            this.tabPageAssets.TabIndex = 0;
            this.tabPageAssets.Text = "Основные средства";
            this.tabPageAssets.UseVisualStyleBackColor = true;

            // dgvFixedAssets
            this.dgvFixedAssets.AllowUserToAddRows = false;
            this.dgvFixedAssets.AllowUserToDeleteRows = false;
            this.dgvFixedAssets.AutoGenerateColumns = false;
            this.dgvFixedAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFixedAssets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colInventoryNumber,
                this.colName,
                this.colCategory,
                this.colResponsible,
                this.colLocation,
                this.colStatus,
                this.colInitialCost,
                this.colCommissionDate
            });
            this.dgvFixedAssets.DataSource = this.fixedAssetsBindingSource;
            this.dgvFixedAssets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFixedAssets.Location = new System.Drawing.Point(3, 36);
            this.dgvFixedAssets.Name = "dgvFixedAssets";
            this.dgvFixedAssets.ReadOnly = true;
            this.dgvFixedAssets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFixedAssets.Size = new System.Drawing.Size(970, 428);
            this.dgvFixedAssets.TabIndex = 0;

            // colInventoryNumber
            this.colInventoryNumber.DataPropertyName = "InventoryNumber";
            this.colInventoryNumber.HeaderText = "Инв. номер";
            this.colInventoryNumber.Name = "colInventoryNumber";
            this.colInventoryNumber.ReadOnly = true;
            this.colInventoryNumber.Width = 120;

            // colName
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Наименование";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;

            // colCategory
            this.colCategory.DataPropertyName = "Category.Name";
            this.colCategory.HeaderText = "Категория";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 120;

            // colResponsible
            this.colResponsible.DataPropertyName = "ResponsibleEmployee.FullName";
            this.colResponsible.HeaderText = "МОЛ";
            this.colResponsible.Name = "colResponsible";
            this.colResponsible.ReadOnly = true;
            this.colResponsible.Width = 150;

            // colLocation
            this.colLocation.DataPropertyName = "Location.Name";
            this.colLocation.HeaderText = "Местоположение";
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            this.colLocation.Width = 150;

            // colStatus
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Статус";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 80;

            // colInitialCost
            this.colInitialCost.DataPropertyName = "InitialCost";
            this.colInitialCost.HeaderText = "Стоимость";
            this.colInitialCost.Name = "colInitialCost";
            this.colInitialCost.ReadOnly = true;
            this.colInitialCost.DefaultCellStyle.Format = "N2";
            this.colInitialCost.Width = 100;

            // colCommissionDate
            this.colCommissionDate.DataPropertyName = "CommissionDate";
            this.colCommissionDate.HeaderText = "Дата ввода";
            this.colCommissionDate.Name = "colCommissionDate";
            this.colCommissionDate.ReadOnly = true;
            this.colCommissionDate.DefaultCellStyle.Format = "d";
            this.colCommissionDate.Width = 90;

            // panelButtons
            this.panelButtons.Controls.Add(this.btnAddAsset);
            this.panelButtons.Controls.Add(this.btnEditAsset);
            this.panelButtons.Controls.Add(this.btnMoveAsset);
            this.panelButtons.Controls.Add(this.btnWriteOffAsset);
            this.panelButtons.Controls.Add(this.btnHistoryAsset);
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(3, 464);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(970, 44);
            this.panelButtons.TabIndex = 1;

            // btnAddAsset
            this.btnAddAsset.Location = new System.Drawing.Point(3, 6);
            this.btnAddAsset.Name = "btnAddAsset";
            this.btnAddAsset.Size = new System.Drawing.Size(95, 32);
            this.btnAddAsset.TabIndex = 0;
            this.btnAddAsset.Text = "Добавить";
            this.btnAddAsset.UseVisualStyleBackColor = true;
            this.btnAddAsset.Click += new System.EventHandler(this.BtnAddAsset_Click);

            // btnEditAsset
            this.btnEditAsset.Location = new System.Drawing.Point(104, 6);
            this.btnEditAsset.Name = "btnEditAsset";
            this.btnEditAsset.Size = new System.Drawing.Size(95, 32);
            this.btnEditAsset.TabIndex = 1;
            this.btnEditAsset.Text = "Изменить";
            this.btnEditAsset.UseVisualStyleBackColor = true;
            this.btnEditAsset.Click += new System.EventHandler(this.BtnEditAsset_Click);

            // btnMoveAsset
            this.btnMoveAsset.Location = new System.Drawing.Point(205, 6);
            this.btnMoveAsset.Name = "btnMoveAsset";
            this.btnMoveAsset.Size = new System.Drawing.Size(95, 32);
            this.btnMoveAsset.TabIndex = 2;
            this.btnMoveAsset.Text = "Переместить";
            this.btnMoveAsset.UseVisualStyleBackColor = true;
            this.btnMoveAsset.Click += new System.EventHandler(this.BtnMoveAsset_Click);

            // btnWriteOffAsset
            this.btnWriteOffAsset.Location = new System.Drawing.Point(306, 6);
            this.btnWriteOffAsset.Name = "btnWriteOffAsset";
            this.btnWriteOffAsset.Size = new System.Drawing.Size(95, 32);
            this.btnWriteOffAsset.TabIndex = 3;
            this.btnWriteOffAsset.Text = "Списать";
            this.btnWriteOffAsset.UseVisualStyleBackColor = true;
            this.btnWriteOffAsset.Click += new System.EventHandler(this.BtnWriteOffAsset_Click);

            // btnHistoryAsset
            this.btnHistoryAsset.Location = new System.Drawing.Point(407, 6);
            this.btnHistoryAsset.Name = "btnHistoryAsset";
            this.btnHistoryAsset.Size = new System.Drawing.Size(140, 32);
            this.btnHistoryAsset.TabIndex = 4;
            this.btnHistoryAsset.Text = "История перемещений";
            this.btnHistoryAsset.UseVisualStyleBackColor = true;
            this.btnHistoryAsset.Click += new System.EventHandler(this.BtnHistoryAsset_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(553, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 32);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // panelSearch
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(3, 3);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(970, 33);
            this.panelSearch.TabIndex = 2;

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(3, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 20);
            this.txtSearch.TabIndex = 0;

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(309, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            // fixedAssetsBindingSource


            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Учёт основных средств музея";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixedAssets)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fixedAssetsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}