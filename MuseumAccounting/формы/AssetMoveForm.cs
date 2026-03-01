using System;
using System.Linq;
using System.Windows.Forms;

namespace MuseumAccounting
{
    public partial class AssetMoveForm : Form
    {
        private int _assetId;
        private FixedAsset _asset;

        public AssetMoveForm(int assetId)
        {
            InitializeComponent();
            _assetId = assetId;
            dtpMoveDate.Value = DateTime.Now;
        }

        private void AssetMoveForm_Load(object sender, EventArgs e)
        {
            LoadAssetAndLocations();
        }

        private void LoadAssetAndLocations()
        {
            try
            {
                using (var context = new MuseumContext())
                {
                    _asset = context.FixedAssets.Find(_assetId);
                    if (_asset == null)
                    {
                        MessageBox.Show("Основное средство не найдено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                        return;
                    }

                    lblAssetInfo.Text = $"Перемещение: {_asset.InventoryNumber} - {_asset.Name} (текущее место: {_asset.Location?.Name ?? "не указано"})";

                    var locations = context.Locations.OrderBy(l => l.Name).ToList();
                    cmbNewLocation.DataSource = locations;
                    cmbNewLocation.DisplayMember = "Name";
                    cmbNewLocation.ValueMember = "Id";

                    // Исключаем текущее местоположение? Можно оставить, но предупредим.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            if (cmbNewLocation.SelectedItem == null)
            {
                MessageBox.Show("Выберите новое местоположение.", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int newLocationId = (int)cmbNewLocation.SelectedValue;
            if (newLocationId == _asset.LocationId)
            {
                MessageBox.Show("Новое местоположение совпадает с текущим. Перемещение не требуется.", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new MuseumContext())
                {
                    // Загружаем ОС с отслеживанием
                    var asset = context.FixedAssets.Find(_assetId);
                    if (asset == null)
                    {
                        MessageBox.Show("Основное средство не найдено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Создаём запись о перемещении
                    var movement = new AssetMovement
                    {
                        FixedAssetId = asset.Id,
                        MovementDate = dtpMoveDate.Value,
                        OldLocationId = asset.LocationId,
                        NewLocationId = newLocationId,
                        Reason = string.IsNullOrWhiteSpace(txtReason.Text) ? null : txtReason.Text.Trim()
                    };
                    context.AssetMovements.Add(movement);

                    // Обновляем местоположение ОС
                    asset.LocationId = newLocationId;

                    context.SaveChanges();
                    MessageBox.Show("Перемещение выполнено успешно.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при перемещении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}