using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_for_Information_Managment
{
    public partial class FormEmployee : Form
    {
        private readonly DB _db;

        public FormEmployee(DB db)
        {
            InitializeComponent();
            _db = db;
            InitializeUI();
            LoadEmployees();
        }

        private void InitializeUI()
        {
            this.Text = "Управление сотрудниками";
            this.Size = new System.Drawing.Size(600, 400);
            var dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dataGridView);

            var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40 };
            var addButton = new Button { Text = "Добавить" };
            addButton.Click += (s, e) => AddEmployee(dataGridView);
            var editButton = new Button { Text = "Редактировать" };
            editButton.Click += (s, e) => EditEmployee(dataGridView);
            var deleteButton = new Button { Text = "Удалить" };
            deleteButton.Click += (s, e) => DeleteEmployee(dataGridView);
            panel.Controls.AddRange(new Control[] { addButton, editButton, deleteButton });
            this.Controls.Add(panel);
        }

        private void LoadEmployees()
        {
            var dataGridView = this.Controls.OfType<DataGridView>().First();
            dataGridView.DataSource = _db.GetEmployees();
        }

        private void AddEmployee(DataGridView dataGridView)
        {
            var form = new Form
            {
                Text = "Добавить сотрудника",
                Size = new System.Drawing.Size(300, 300)
            };
            var panel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Dock = DockStyle.Fill, AutoSize = true };
            var employee = new Employee();

            var lblFullName = new Label { Text = "ФИО:", AutoSize = true };
            var txtFullName = new TextBox { Width = 200 };
            txtFullName.TextChanged += (s, e) => employee.FullName = txtFullName.Text;

            var lblPosition = new Label { Text = "Должность:", AutoSize = true };
            var txtPosition = new TextBox { Width = 200 };
            txtPosition.TextChanged += (s, e) => employee.Position = txtPosition.Text;

            var lblEmail = new Label { Text = "Email:", AutoSize = true };
            var txtEmail = new TextBox { Width = 200 };
            txtEmail.TextChanged += (s, e) => employee.Email = txtEmail.Text;

            var lblPhone = new Label { Text = "Телефон:", AutoSize = true };
            var txtPhone = new TextBox { Width = 200 };
            txtPhone.TextChanged += (s, e) => employee.Phone = txtPhone.Text;

            var btnSave = new Button { Text = "Сохранить", Width = 100 };
            btnSave.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty(employee.FullName))
                {
                    MessageBox.Show("Заполните ФИО.", "Ошибка");
                    return;
                }
                _db.AddEmployee(employee);
                form.DialogResult = DialogResult.OK;
                form.Close();
            };

            panel.Controls.AddRange(new Control[] { lblFullName, txtFullName, lblPosition, txtPosition, lblEmail, txtEmail, lblPhone, txtPhone, btnSave });
            form.Controls.Add(panel);
            if (form.ShowDialog() == DialogResult.OK)
                LoadEmployees();
        }

        private void EditEmployee(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var employee = (Employee)dataGridView.SelectedRows[0].DataBoundItem;
                var form = new Form
                {
                    Text = "Редактировать сотрудника",
                    Size = new System.Drawing.Size(300, 300)
                };
                var panel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Dock = DockStyle.Fill, AutoSize = true };

                var lblFullName = new Label { Text = "ФИО:", AutoSize = true };
                var txtFullName = new TextBox { Width = 200, Text = employee.FullName };
                txtFullName.TextChanged += (s, e) => employee.FullName = txtFullName.Text;

                var lblPosition = new Label { Text = "Должность:", AutoSize = true };
                var txtPosition = new TextBox { Width = 200, Text = employee.Position };
                txtPosition.TextChanged += (s, e) => employee.Position = txtPosition.Text;

                var lblEmail = new Label { Text = "Email:", AutoSize = true };
                var txtEmail = new TextBox { Width = 200, Text = employee.Email };
                txtEmail.TextChanged += (s, e) => employee.Email = txtEmail.Text;

                var lblPhone = new Label { Text = "Телефон:", AutoSize = true };
                var txtPhone = new TextBox { Width = 200, Text = employee.Phone };
                txtPhone.TextChanged += (s, e) => employee.Phone = txtPhone.Text;

                var btnSave = new Button { Text = "Сохранить", Width = 100 };
                btnSave.Click += (s, e) =>
                {
                    if (string.IsNullOrEmpty(employee.FullName))
                    {
                        MessageBox.Show("Заполните ФИО.", "Ошибка");
                        return;
                    }
                    _db.UpdateEmployee(employee);
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                };

                panel.Controls.AddRange(new Control[] { lblFullName, txtFullName, lblPosition, txtPosition, lblEmail, txtEmail, lblPhone, txtPhone, btnSave });
                form.Controls.Add(panel);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadEmployees();
            }
        }

        private void DeleteEmployee(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var employee = (Employee)dataGridView.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show("Удалить сотрудника?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        _db.DeleteEmployee(employee.Id);
                        LoadEmployees();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка");
                    }
                }
            }
        }
    }
}
