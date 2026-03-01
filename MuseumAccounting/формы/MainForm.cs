using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace MuseumAccounting
{
    public partial class MainForm : Form
    {
        private List<FixedAsset> _allAssets; // для фильтрации без повторных запросов

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAssets();
        }

        private void LoadAssets()
        {
            try
            {
                using (var context = new MuseumContext())
                {
                    // Загружаем ОС с включением связанных данных
                    var assets = context.FixedAssets
                        .Include(f => f.Category)
                        .Include(f => f.ResponsibleEmployee)
                        .Include(f => f.Location)
                        .ToList();
                    _allAssets = assets;
                    fixedAssetsBindingSource.DataSource = _allAssets;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                fixedAssetsBindingSource.DataSource = _allAssets;
            }
            else
            {
                var filtered = _allAssets.Where(f =>
                    f.InventoryNumber.ToLower().Contains(searchText) ||
                    f.Name.ToLower().Contains(searchText)).ToList();
                fixedAssetsBindingSource.DataSource = filtered;
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAssets();
            txtSearch.Clear();
        }

        private void BtnAddAsset_Click(object sender, EventArgs e)
        {
            using (var form = new AssetEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAssets(); // обновляем список после добавления
                }
            }
        }

        private void BtnEditAsset_Click(object sender, EventArgs e)
        {
            if (dgvFixedAssets.CurrentRow?.DataBoundItem is FixedAsset selectedAsset)
            {
                using (var form = new AssetEditForm(selectedAsset.Id))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAssets();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите основное средство для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnMoveAsset_Click(object sender, EventArgs e)
        {
            if (dgvFixedAssets.CurrentRow?.DataBoundItem is FixedAsset selectedAsset)
            {
                using (var form = new AssetMoveForm(selectedAsset.Id))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAssets(); // обновляем после перемещения (изменяется LocationId)
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите основное средство для перемещения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnWriteOffAsset_Click(object sender, EventArgs e)
        {
            if (dgvFixedAssets.CurrentRow?.DataBoundItem is FixedAsset selectedAsset)
            {
                // Проверяем, не списано ли уже
                if (selectedAsset.Status == StatusEnum.Списано)
                {
                    MessageBox.Show("Данное основное средство уже списано.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var result = MessageBox.Show($"Списать основное средство с инв. номером {selectedAsset.InventoryNumber}?",
                    "Подтверждение списания", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var context = new MuseumContext())
                        {
                            var asset = context.FixedAssets.Find(selectedAsset.Id);
                            if (asset != null)
                            {
                                asset.Status = StatusEnum.Списано;
                                context.SaveChanges();
                                LoadAssets();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при списании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите основное средство для списания.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnHistoryAsset_Click(object sender, EventArgs e)
        {
            if (dgvFixedAssets.CurrentRow?.DataBoundItem is FixedAsset selectedAsset)
            {
                var form = new AssetHistoryForm(selectedAsset.Id);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите основное средство для просмотра истории.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void СотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new EmployeesForm())
            {
                form.ShowDialog();
            }
        }

        private void МестоположенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new LocationsForm())
            {
                form.ShowDialog();
            }
        }

        private void КатегорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AssetCategoriesForm())
            {
                form.ShowDialog();
            }
        }

        private void ИнвентаризационнаяВедомостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Простой отчёт: группировка по МОЛ или местоположению
            // Для упрощения выведем в отдельной форме DataGridView с группировкой
            var reportForm = new Form
            {
                Text = "Инвентаризационная ведомость",
                Size = new System.Drawing.Size(800, 600),
                StartPosition = FormStartPosition.CenterParent
            };
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GroupName", HeaderText = "Группировка", Width = 200 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "InventoryNumber", HeaderText = "Инв. номер", Width = 120 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Наименование", Width = 200 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CategoryName", HeaderText = "Категория", Width = 120 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ResponsibleName", HeaderText = "МОЛ", Width = 150 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LocationName", HeaderText = "Местоположение", Width = 150 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Статус", Width = 80 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "InitialCost", HeaderText = "Стоимость", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CommissionDate", HeaderText = "Дата ввода", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "d" } });

            // Выбор группировки через простой ComboBox на форме
            var panel = new Panel { Dock = DockStyle.Top, Height = 40 };
            var combo = new ComboBox { Location = new System.Drawing.Point(10, 10), Width = 200 };
            combo.Items.AddRange(new object[] { "По материально-ответственным лицам", "По местоположению" });
            combo.SelectedIndex = 0;
            panel.Controls.Add(combo);
            var btnLoad = new Button { Text = "Загрузить", Location = new System.Drawing.Point(220, 8), Width = 100 };
            panel.Controls.Add(btnLoad);

            reportForm.Controls.Add(dgv);
            reportForm.Controls.Add(panel);

            btnLoad.Click += (s, args) =>
            {
                try
                {
                    using (var context = new MuseumContext())
                    {
                        var assets = context.FixedAssets
                            .Include(f => f.Category)
                            .Include(f => f.ResponsibleEmployee)
                            .Include(f => f.Location)
                            .ToList();

                        List<ReportItem> reportItems;
                        if (combo.SelectedIndex == 0) // по МОЛ
                        {
                            reportItems = assets.SelectMany(a => new[] {
                                new ReportItem
                                {
                                    GroupName = a.ResponsibleEmployee?.FullName ?? "Не указан",
                                    InventoryNumber = a.InventoryNumber,
                                    Name = a.Name,
                                    CategoryName = a.Category?.Name,
                                    ResponsibleName = a.ResponsibleEmployee?.FullName,
                                    LocationName = a.Location?.Name,
                                    Status = a.Status.ToString(),
                                    InitialCost = a.InitialCost,
                                    CommissionDate = a.CommissionDate
                                }
                            }).OrderBy(r => r.GroupName).ToList();
                        }
                        else // по местоположению
                        {
                            reportItems = assets.SelectMany(a => new[] {
                                new ReportItem
                                {
                                    GroupName = a.Location?.Name ?? "Не указано",
                                    InventoryNumber = a.InventoryNumber,
                                    Name = a.Name,
                                    CategoryName = a.Category?.Name,
                                    ResponsibleName = a.ResponsibleEmployee?.FullName,
                                    LocationName = a.Location?.Name,
                                    Status = a.Status.ToString(),
                                    InitialCost = a.InitialCost,
                                    CommissionDate = a.CommissionDate
                                }
                            }).OrderBy(r => r.GroupName).ToList();
                        }

                        dgv.DataSource = reportItems;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка формирования отчёта: {ex.Message}");
                }
            };

            reportForm.ShowDialog();
        }

        // Вспомогательный класс для отчёта
        private class ReportItem
        {
            public string GroupName { get; set; }
            public string InventoryNumber { get; set; }
            public string Name { get; set; }
            public string CategoryName { get; set; }
            public string ResponsibleName { get; set; }
            public string LocationName { get; set; }
            public string Status { get; set; }
            public decimal InitialCost { get; set; }
            public DateTime CommissionDate { get; set; }
        }
    }
}