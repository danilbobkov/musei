using System;
using System.Windows.Forms;

namespace MuseumAccounting
{
    public partial class LocationEditForm : Form
    {
        private int? _locationId;

        public LocationEditForm()
        {
            InitializeComponent();
            this.Text = "Добавление местоположения";
        }

        public LocationEditForm(int id) : this()
        {
            _locationId = id;
            this.Text = "Редактирование местоположения";
            LoadLocation();
        }

        private void LoadLocation()
        {
            try
            {
                using (var context = new MuseumContext())
                {
                    var location = context.Locations.Find(_locationId);
                    if (location != null)
                    {
                        txtName.Text = location.Name;
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
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Название обязательно для заполнения.", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new MuseumContext())
                {
                    Location location;
                    if (_locationId.HasValue)
                    {
                        location = context.Locations.Find(_locationId);
                        if (location == null)
                        {
                            MessageBox.Show("Запись не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        location = new Location();
                        context.Locations.Add(location);
                    }

                    location.Name = txtName.Text.Trim();

                    context.SaveChanges();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                if (dbEx.InnerException?.Message.Contains("UNIQUE") == true)
                {
                    MessageBox.Show("Местоположение с таким названием уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Ошибка сохранения: {dbEx.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
    }
}