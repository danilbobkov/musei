using System;
using System.Linq;
using System.Windows.Forms;

namespace MuseumAccounting
{
    public partial class LocationsForm : Form
    {
        public LocationsForm()
        {
            InitializeComponent();
        }

        private void LocationsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var context = new MuseumContext())
                {
                    var locations = context.Locations.OrderBy(l => l.Name).ToList();
                    locationsBindingSource.DataSource = locations;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new LocationEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLocations.CurrentRow?.DataBoundItem is Location selected)
            {
                using (var form = new LocationEditForm(selected.Id))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите местоположение для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLocations.CurrentRow?.DataBoundItem is Location selected)
            {
                // Проверка наличия связанных основных средств
                using (var context = new MuseumContext())
                {
                    bool hasFixedAssets = context.FixedAssets.Any(f => f.LocationId == selected.Id);
                    if (hasFixedAssets)
                    {
                        MessageBox.Show("Невозможно удалить местоположение, так как оно используется в основных средствах.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    bool hasMovements = context.AssetMovements.Any(m => m.OldLocationId == selected.Id || m.NewLocationId == selected.Id);
                    if (hasMovements)
                    {
                        MessageBox.Show("Невозможно удалить местоположение, так как оно используется в истории перемещений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var result = MessageBox.Show($"Удалить местоположение \"{selected.Name}\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var context = new MuseumContext())
                        {
                            var location = context.Locations.Find(selected.Id);
                            if (location != null)
                            {
                                context.Locations.Remove(location);
                                context.SaveChanges();
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите местоположение для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}