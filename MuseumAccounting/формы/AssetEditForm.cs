using System;
using System.Linq;
using System.Windows.Forms;

namespace MuseumAccounting
{
    public partial class AssetEditForm : Form
    {
        private int? _assetId;
        private BindingSource categoriesBS = new BindingSource();
        private BindingSource employeesBS = new BindingSource();
        private BindingSource locationsBS = new BindingSource();

        public AssetEditForm()
        {
            InitializeComponent();
            LoadComboBoxes();
            dtpCommissionDate.Value = DateTime.Today;
            SetupStatusCombo();
        }

        public AssetEditForm(int id) : this()
        {
            _assetId = id;
            LoadAsset();
        }

        private void SetupStatusCombo()
        {
            cmbStatus.DataSource = Enum.GetValues(typeof(StatusEnum));
        }

        private void LoadComboBoxes()
        {
            try
            {
                using (var context = new MuseumContext())
                {
                    categoriesBS.DataSource = context.AssetCategories.OrderBy(c => c.Name).ToList();
                    cmbCategory.DataSource = categoriesBS;

                    employeesBS.DataSource = context.Employees.OrderBy(e => e.FullName).ToList();
                    cmbResponsible.DataSource = employeesBS;

                    locationsBS.DataSource = context.Locations.OrderBy(l => l.Name).ToList();
                    cmbLocation.DataSource = locationsBS;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAsset()
        {
            try
            {
                using (var context = new MuseumContext())
                {
                    var asset = context.FixedAssets.Find(_assetId);
                    if (asset != null)
                    {
                        txtInventoryNumber.Text = asset.InventoryNumber;
                        txtName.Text = asset.Name;
                        cmbCategory.SelectedValue = asset.CategoryId;
                        dtpCommissionDate.Value = asset.CommissionDate;
                        txtInitialCost.Text = asset.InitialCost.ToString("F2");
                        cmbResponsible.SelectedValue = asset.ResponsibleEmployeeId;
                        cmbLocation.SelectedValue = asset.LocationId;
                        cmbStatus.SelectedItem = asset.Status;
                        txtNotes.Text = asset.Notes;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtInventoryNumber.Text))
            {
                MessageBox.Show("Инвентарный номер обязателен.", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Наименование обязательно.", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию.", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbResponsible.SelectedItem == null)
            {
                MessageBox.Show("Выберите материально-ответственное лицо.", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtInitialCost.Text, out decimal cost))
            {
                MessageBox.Show("Некорректное значение стоимости.", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new MuseumContext())
                {
                    FixedAsset asset;
                    if (_assetId.HasValue)
                    {
                        asset = context.FixedAssets.Find(_assetId);
                        if (asset == null)
                        {
                            MessageBox.Show("Запись не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        asset = new FixedAsset();
                        context.FixedAssets.Add(asset);
                    }

                    asset.InventoryNumber = txtInventoryNumber.Text.Trim();
                    asset.Name = txtName.Text.Trim();
                    asset.CategoryId = (int)cmbCategory.SelectedValue;
                    asset.CommissionDate = dtpCommissionDate.Value.Date;
                    asset.InitialCost = cost;
                    asset.ResponsibleEmployeeId = (int)cmbResponsible.SelectedValue;
                    asset.LocationId = (int)cmbLocation.SelectedValue;
                    asset.Status = (StatusEnum)cmbStatus.SelectedItem;
                    asset.Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();

                    context.SaveChanges();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                if (dbEx.InnerException?.Message.Contains("UNIQUE") == true)
                    MessageBox.Show("Инвентарный номер должен быть уникальным.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show($"Ошибка сохранения: {dbEx.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AssetEditForm_Load(object sender, EventArgs e)
        {
            // Дополнительная инициализация, если нужно
        }
    }
}