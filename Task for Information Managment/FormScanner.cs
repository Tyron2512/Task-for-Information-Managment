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
    public partial class FormScanner : Form
    {
        private readonly DB _db;
        private readonly Scanner _scanner;

        public FormScanner(DB db, Scanner scanner = null)
        {
            InitializeComponent();
            _db = db;
            _scanner = scanner ?? new Scanner();
            InitializeUI();
            if (scanner != null) FillFields();
        }

        private void InitializeUI()
        {
            this.Text = _scanner.Id == 0 ? "Добавить сканер" : "Редактировать сканер";
            this.Size = new System.Drawing.Size(400, 500);
            var panel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Dock = DockStyle.Fill, AutoSize = true };

            var lblInvNumber = new Label { Text = "Инвентарный номер:", AutoSize = true };
            var txtInvNumber = new TextBox { Width = 200 };
            txtInvNumber.TextChanged += (s, e) => _scanner.InventoryNumber = txtInvNumber.Text;

            var lblModel = new Label { Text = "Модель:", AutoSize = true };
            var txtModel = new TextBox { Width = 200 };
            txtModel.TextChanged += (s, e) => _scanner.Model = txtModel.Text;

            var lblSerial = new Label { Text = "Серийный номер:", AutoSize = true };
            var txtSerial = new TextBox { Width = 200 };
            txtSerial.TextChanged += (s, e) => _scanner.SerialNumber = txtSerial.Text;

            var lblRegDate = new Label { Text = "Дата регистрации:", AutoSize = true };
            var dtpRegDate = new DateTimePicker { Width = 200 };
            dtpRegDate.ValueChanged += (s, e) => _scanner.DateRegistered = dtpRegDate.Value;

            var lblUseDate = new Label { Text = "Дата ввода в эксплуатацию:", AutoSize = true };
            var dtpUseDate = new DateTimePicker { Width = 200, Format = DateTimePickerFormat.Custom, CustomFormat = " " };
            dtpUseDate.ValueChanged += (s, e) => _scanner.DateInUse = dtpUseDate.Text == " " ? (DateTime?)null : dtpUseDate.Value;

            var lblAmort = new Label { Text = "Срок амортизации (мес):", AutoSize = true };
            var txtAmort = new TextBox { Width = 200 };
            txtAmort.TextChanged += (s, e) => _scanner.AmortizationTerm = int.TryParse(txtAmort.Text, out int term) ? term : (int?)null;

            var lblCondition = new Label { Text = "Состояние:", AutoSize = true };
            var cmbCondition = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCondition.Items.AddRange(new[] { "исправен", "неисправен", "в ремонте" });
            cmbCondition.SelectedIndexChanged += (s, e) => _scanner.Condition = cmbCondition.SelectedItem?.ToString();

            var lblLocation = new Label { Text = "Место:", AutoSize = true };
            var cmbLocation = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbLocation.DataSource = _db.GetLocations();
            cmbLocation.DisplayMember = "RoomName";
            cmbLocation.ValueMember = "Id";
            cmbLocation.SelectedIndexChanged += (s, e) => _scanner.LocationId = cmbLocation.SelectedValue != null ? (int?)cmbLocation.SelectedValue : null;

            var lblEmployee = new Label { Text = "Сотрудник:", AutoSize = true };
            var cmbEmployee = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbEmployee.DataSource = _db.GetEmployees();
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "Id";
            cmbEmployee.SelectedIndexChanged += (s, e) => _scanner.EmployeeId = cmbEmployee.SelectedValue != null ? (int?)cmbEmployee.SelectedValue : null;

            var btnSave = new Button { Text = "Сохранить", Width = 100 };
            btnSave.Click += BtnSave_Click;
            var btnCancel = new Button { Text = "Отмена", Width = 100 };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            panel.Controls.AddRange(new Control[] {
                lblInvNumber, txtInvNumber, lblModel, txtModel, lblSerial, txtSerial,
                lblRegDate, dtpRegDate, lblUseDate, dtpUseDate, lblAmort, txtAmort,
                lblCondition, cmbCondition, lblLocation, cmbLocation, lblEmployee, cmbEmployee,
                btnSave, btnCancel
            });

            this.Controls.Add(panel);
        }

        private void FillFields()
        {
            var txtInvNumber = this.Controls.OfType<FlowLayoutPanel>().First().Controls.OfType<TextBox>().ElementAt(0);
            txtInvNumber.Text = _scanner.InventoryNumber;
            var txtModel = this.Controls.OfType<FlowLayoutPanel>().First().Controls.OfType<TextBox>().ElementAt(1);
            txtModel.Text = _scanner.Model;
            var txtSerial = this.Controls.OfType<FlowLayoutPanel>().First().Controls.OfType<TextBox>().ElementAt(2);
            txtSerial.Text = _scanner.SerialNumber;
            var dtpRegDate = this.Controls.OfType<FlowLayoutPanel>().First().Controls.OfType<DateTimePicker>().ElementAt(0);
            dtpRegDate.Value = _scanner.DateRegistered;
            var dtpUseDate = this.Controls.OfType<FlowLayoutPanel>().First().Controls.OfType<DateTimePicker>().ElementAt(1);
            dtpUseDate.Text = _scanner.DateInUse?.ToString() ?? " ";
            var txtAmort = this.Controls.OfType<FlowLayoutPanel>().First().Controls.OfType<TextBox>().ElementAt(3);
            txtAmort.Text = _scanner.AmortizationTerm?.ToString();
            var cmbCondition = this.Controls.OfType<FlowLayoutPanel>().First().Controls.OfType<ComboBox>().ElementAt(0);
            cmbCondition.SelectedItem = _scanner.Condition;
            var cmbLocation = this.Controls.OfType<FlowLayoutPanel>().First().Controls.OfType<ComboBox>().ElementAt(1);
            cmbLocation.SelectedValue = _scanner.LocationId ?? -1;
            var cmbEmployee = this.Controls.OfType<FlowLayoutPanel>().First().Controls.OfType<ComboBox>().ElementAt(2);
            cmbEmployee.SelectedValue = _scanner.EmployeeId ?? -1;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_scanner.InventoryNumber) || string.IsNullOrEmpty(_scanner.Model))
            {
                MessageBox.Show("Заполните обязательные поля: Инвентарный номер и Модель.", "Ошибка");
                return;
            }

            try
            {
                if (_scanner.Id == 0)
                    _db.AddScanner(_scanner);
                else
                    _db.UpdateScanner(_scanner);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка");
            }
        }
    }
}
