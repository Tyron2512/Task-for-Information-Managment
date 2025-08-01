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
    public partial class FormRepair : Form
    {
        private readonly DB _db;

        public FormRepair(DB db)
        {
            InitializeComponent();
            _db = db;
            InitializeUI();
            LoadRepairs();
        }

        private void InitializeUI()
        {
            this.Text = "Управление ремонтами";
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
            addButton.Click += (s, e) => AddRepair(dataGridView);
            var editButton = new Button { Text = "Редактировать" };
            editButton.Click += (s, e) => EditRepair(dataGridView);
            var deleteButton = new Button { Text = "Удалить" };
            deleteButton.Click += (s, e) => DeleteRepair(dataGridView);
            panel.Controls.AddRange(new Control[] { addButton, editButton, deleteButton });
            this.Controls.Add(panel);
        }

        private void LoadRepairs()
        {
            var dataGridView = this.Controls.OfType<DataGridView>().First();
            dataGridView.DataSource = _db.GetRepairs();
        }

        private void AddRepair(DataGridView dataGridView)
        {
            var form = new Form
            {
                Text = "Добавить ремонт",
                Size = new System.Drawing.Size(300, 300)
            };
            var panel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Dock = DockStyle.Fill, AutoSize = true };
            var repair = new Repair();

            var lblScanner = new Label { Text = "Сканер:", AutoSize = true };
            var cmbScanner = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbScanner.DataSource = _db.GetScanners();
            cmbScanner.DisplayMember = "InventoryNumber";
            cmbScanner.ValueMember = "Id";
            cmbScanner.SelectedIndexChanged += (s, e) => repair.ScannerId = cmbScanner.SelectedValue != null ? (int)cmbScanner.SelectedValue : 0;

            var lblRepairDate = new Label { Text = "Дата ремонта:", AutoSize = true };
            var dtpRepairDate = new DateTimePicker { Width = 200 };
            dtpRepairDate.ValueChanged += (s, e) => repair.RepairDate = dtpRepairDate.Value;

            var lblIssue = new Label { Text = "Описание проблемы:", AutoSize = true };
            var txtIssue = new TextBox { Width = 200 };
            txtIssue.TextChanged += (s, e) => repair.IssueDescription = txtIssue.Text;

            var lblStatus = new Label { Text = "Статус:", AutoSize = true };
            var txtStatus = new TextBox { Width = 200 };
            txtStatus.TextChanged += (s, e) => repair.RepairStatus = txtStatus.Text;

            var btnSave = new Button { Text = "Сохранить", Width = 100 };
            btnSave.Click += (s, e) =>
            {
                if (repair.ScannerId == 0 || string.IsNullOrEmpty(repair.IssueDescription))
                {
                    MessageBox.Show("Выберите сканер и укажите описание проблемы.", "Ошибка");
                    return;
                }
                _db.AddRepair(repair);
                form.DialogResult = DialogResult.OK;
                form.Close();
            };

            panel.Controls.AddRange(new Control[] { lblScanner, cmbScanner, lblRepairDate, dtpRepairDate, lblIssue, txtIssue, lblStatus, txtStatus, btnSave });
            form.Controls.Add(panel);
            if (form.ShowDialog() == DialogResult.OK)
                LoadRepairs();
        }

        private void EditRepair(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var repair = (Repair)dataGridView.SelectedRows[0].DataBoundItem;
                var form = new Form
                {
                    Text = "Редактировать ремонт",
                    Size = new System.Drawing.Size(300, 300)
                };
                var panel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Dock = DockStyle.Fill, AutoSize = true };

                var lblScanner = new Label { Text = "Сканер:", AutoSize = true };
                var cmbScanner = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
                cmbScanner.DataSource = _db.GetScanners();
                cmbScanner.DisplayMember = "InventoryNumber";
                cmbScanner.ValueMember = "Id";
                cmbScanner.SelectedValue = repair.ScannerId;
                cmbScanner.SelectedIndexChanged += (s, e) => repair.ScannerId = cmbScanner.SelectedValue != null ? (int)cmbScanner.SelectedValue : 0;

                var lblRepairDate = new Label { Text = "Дата ремонта:", AutoSize = true };
                var dtpRepairDate = new DateTimePicker { Width = 200, Value = repair.RepairDate };
                dtpRepairDate.ValueChanged += (s, e) => repair.RepairDate = dtpRepairDate.Value;

                var lblIssue = new Label { Text = "Описание проблемы:", AutoSize = true };
                var txtIssue = new TextBox { Width = 200, Text = repair.IssueDescription };
                txtIssue.TextChanged += (s, e) => repair.IssueDescription = txtIssue.Text;

                var lblStatus = new Label { Text = "Статус:", AutoSize = true };
                var txtStatus = new TextBox { Width = 200, Text = repair.RepairStatus };
                txtStatus.TextChanged += (s, e) => repair.RepairStatus = txtStatus.Text;

                var btnSave = new Button { Text = "Сохранить", Width = 100 };
                btnSave.Click += (s, e) =>
                {
                    if (repair.ScannerId == 0 || string.IsNullOrEmpty(repair.IssueDescription))
                    {
                        MessageBox.Show("Выберите сканер и укажите описание проблемы.", "Ошибка");
                        return;
                    }
                    _db.UpdateRepair(repair);
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                };

                panel.Controls.AddRange(new Control[] { lblScanner, cmbScanner, lblRepairDate, dtpRepairDate, lblIssue, txtIssue, lblStatus, txtStatus, btnSave });
                form.Controls.Add(panel);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadRepairs();
            }
        }

        private void DeleteRepair(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var repair = (Repair)dataGridView.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show("Удалить ремонт?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _db.DeleteRepair(repair.Id);
                    LoadRepairs();
                }
            }
        }
    }
}
