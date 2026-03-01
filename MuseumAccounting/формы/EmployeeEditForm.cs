using System;
using System.Windows.Forms;

namespace MuseumAccounting
{
    public partial class EmployeeEditForm : Form
    {
        private int? _employeeId;

        // Конструктор для добавления
        public EmployeeEditForm()
        {
            InitializeComponent();
            this.Text = "Добавление сотрудника";
        }

        // Конструктор для редактирования
        public EmployeeEditForm(int id) : this()
        {
            _employeeId = id;
            this.Text = "Редактирование сотрудника";
            LoadEmployee();
        }

        private void LoadEmployee()
        {
            try
            {
                using (var context = new MuseumContext())
                {
                    var employee = context.Employees.Find(_employeeId);
                    if (employee != null)
                    {
                        txtFullName.Text = employee.FullName;
                        txtPosition.Text = employee.Position;
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
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Поле ФИО обязательно для заполнения.", "Валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new MuseumContext())
                {
                    Employee employee;
                    if (_employeeId.HasValue)
                    {
                        employee = context.Employees.Find(_employeeId);
                        if (employee == null)
                        {
                            MessageBox.Show("Сотрудник не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        employee = new Employee();
                        context.Employees.Add(employee);
                    }

                    employee.FullName = txtFullName.Text.Trim();
                    employee.Position = string.IsNullOrWhiteSpace(txtPosition.Text) ? null : txtPosition.Text.Trim();

                    context.SaveChanges();
                    DialogResult = DialogResult.OK;
                    Close();
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