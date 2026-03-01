using System;
using System.Windows.Forms;

namespace MuseumAccounting
{
    public partial class AssetCategoryEditForm : Form
    {
        private int? _categoryId;

        public AssetCategoryEditForm()
        {
            InitializeComponent();
            this.Text = "Добавление категории";
        }

        public AssetCategoryEditForm(int id) : this()
        {
            _categoryId = id;
            this.Text = "Редактирование категории";
            LoadCategory();
        }

        private void LoadCategory()
        {
            try
            {
                using (var context = new MuseumContext())
                {
                    var category = context.AssetCategories.Find(_categoryId);
                    if (category != null)
                    {
                        txtName.Text = category.Name;
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
                    AssetCategory category;
                    if (_categoryId.HasValue)
                    {
                        category = context.AssetCategories.Find(_categoryId);
                        if (category == null)
                        {
                            MessageBox.Show("Запись не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        category = new AssetCategory();
                        context.AssetCategories.Add(category);
                    }

                    category.Name = txtName.Text.Trim();

                    context.SaveChanges();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                if (dbEx.InnerException?.Message.Contains("UNIQUE") == true)
                {
                    MessageBox.Show("Категория с таким названием уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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