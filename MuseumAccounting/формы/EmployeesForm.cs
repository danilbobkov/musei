using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace MuseumAccounting
{
    public partial class EmployeesForm : Form
    {
        private List<Employee> _employees;

        public EmployeesForm()
        {
            InitializeComponent();
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var context = new MuseumContext())
                {
                    _employees = context.Employees.OrderBy(e => e.FullName).ToList();
                    employeesBindingSource.DataSource = _employees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new EmployeeEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow?.DataBoundItem is Employee selected)
            {
                using (var form = new EmployeeEditForm(selected.Id))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow?.DataBoundItem is Employee selected)
            {
                // Проверка наличия связанных основных средств
                using (var context = new MuseumContext())
                {
                    bool hasReferences = context.FixedAssets.Any(f => f.ResponsibleEmployeeId == selected.Id);
                    if (hasReferences)
                    {
                        MessageBox.Show("Невозможно удалить сотрудника, так как он является материально-ответственным лицом для одного или нескольких основных средств.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var result = MessageBox.Show($"Удалить сотрудника {selected.FullName}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var context = new MuseumContext())
                        {
                            var employee = context.Employees.Find(selected.Id);
                            if (employee != null)
                            {
                                context.Employees.Remove(employee);
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
                MessageBox.Show("Выберите сотрудника для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}