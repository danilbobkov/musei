using System;
using System.Linq;
using System.Windows.Forms;

namespace MuseumAccounting
{
    public partial class AssetCategoriesForm : Form
    {
        public AssetCategoriesForm()
        {
            InitializeComponent();
        }

        private void AssetCategoriesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var context = new MuseumContext())
                {
                    var categories = context.AssetCategories.OrderBy(c => c.Name).ToList();
                    categoriesBindingSource.DataSource = categories;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AssetCategoryEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow?.DataBoundItem is AssetCategory selected)
            {
                using (var form = new AssetCategoryEditForm(selected.Id))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите категорию для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow?.DataBoundItem is AssetCategory selected)
            {
                // Проверка наличия связанных основных средств
                using (var context = new MuseumContext())
                {
                    bool hasFixedAssets = context.FixedAssets.Any(f => f.CategoryId == selected.Id);
                    if (hasFixedAssets)
                    {
                        MessageBox.Show("Невозможно удалить категорию, так как она используется в основных средствах.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var result = MessageBox.Show($"Удалить категорию \"{selected.Name}\"?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var context = new MuseumContext())
                        {
                            var category = context.AssetCategories.Find(selected.Id);
                            if (category != null)
                            {
                                context.AssetCategories.Remove(category);
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
                MessageBox.Show("Выберите категорию для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}