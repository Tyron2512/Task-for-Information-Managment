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
    public partial class FormLocation : Form
    {
        private readonly DB _db;

        public FormLocation(DB db)
        {
            InitializeComponent();
            _db = db;
            InitializeUI();
            LoadLocations();
        }

        private void InitializeUI()
        {
            this.Text = "Управление местами";
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
            addButton.Click += (s, e) => AddLocation(dataGridView);
            var editButton = new Button { Text = "Редактировать" };
            editButton.Click += (s, e) => EditLocation(dataGridView);
            var deleteButton = new Button { Text = "Удалить" };
            deleteButton.Click += (s, e) => DeleteLocation(dataGridView);
            panel.Controls.AddRange(new Control[] { addButton, editButton, deleteButton });
            this.Controls.Add(panel);
        }

        private void LoadLocations()
        {
            var dataGridView = this.Controls.OfType<DataGridView>().First();
            dataGridView.DataSource = _db.GetLocations();
        }

        private void AddLocation(DataGridView dataGridView)
        {
            var form = new Form
            {
                Text = "Добавить место",
                Size = new System.Drawing.Size(300, 250)
            };
            var panel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Dock = DockStyle.Fill, AutoSize = true };
            var location = new Location();

            var lblRoomName = new Label { Text = "Название помещения:", AutoSize = true };
            var txtRoomName = new TextBox { Width = 200 };
            txtRoomName.TextChanged += (s, e) => location.RoomName = txtRoomName.Text;

            var lblBuilding = new Label { Text = "Корпус:", AutoSize = true };
            var txtBuilding = new TextBox { Width = 200 };
            txtBuilding.TextChanged += (s, e) => location.Building = txtBuilding.Text;

            var lblFloor = new Label { Text = "Этаж:", AutoSize = true };
            var txtFloor = new TextBox { Width = 200 };
            txtFloor.TextChanged += (s, e) => location.Floor = int.TryParse(txtFloor.Text, out int floor) ? floor : (int?)null;

            var btnSave = new Button { Text = "Сохранить", Width = 100 };
            btnSave.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty(location.RoomName))
                {
                    MessageBox.Show("Заполните название помещения.", "Ошибка");
                    return;
                }
                _db.AddLocation(location);
                form.DialogResult = DialogResult.OK;
                form.Close();
            };

            panel.Controls.AddRange(new Control[] { lblRoomName, txtRoomName, lblBuilding, txtBuilding, lblFloor, txtFloor, btnSave });
            form.Controls.Add(panel);
            if (form.ShowDialog() == DialogResult.OK)
                LoadLocations();
        }

        private void EditLocation(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var location = (Location)dataGridView.SelectedRows[0].DataBoundItem;
                var form = new Form
                {
                    Text = "Редактировать место",
                    Size = new System.Drawing.Size(300, 250)
                };
                var panel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, Dock = DockStyle.Fill, AutoSize = true };

                var lblRoomName = new Label { Text = "Название помещения:", AutoSize = true };
                var txtRoomName = new TextBox { Width = 200, Text = location.RoomName };
                txtRoomName.TextChanged += (s, e) => location.RoomName = txtRoomName.Text;

                var lblBuilding = new Label { Text = "Корпус:", AutoSize = true };
                var txtBuilding = new TextBox { Width = 200, Text = location.Building };
                txtBuilding.TextChanged += (s, e) => location.Building = txtBuilding.Text;

                var lblFloor = new Label { Text = "Этаж:", AutoSize = true };
                var txtFloor = new TextBox { Width = 200, Text = location.Floor?.ToString() };
                txtFloor.TextChanged += (s, e) => location.Floor = int.TryParse(txtFloor.Text, out int floor) ? floor : (int?)null;

                var btnSave = new Button { Text = "Сохранить", Width = 100 };
                btnSave.Click += (s, e) =>
                {
                    if (string.IsNullOrEmpty(location.RoomName))
                    {
                        MessageBox.Show("Заполните название помещения.", "Ошибка");
                        return;
                    }
                    _db.UpdateLocation(location);
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                };

                panel.Controls.AddRange(new Control[] { lblRoomName, txtRoomName, lblBuilding, txtBuilding, lblFloor, txtFloor, btnSave });
                form.Controls.Add(panel);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadLocations();
            }
        }

        private void DeleteLocation(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var location = (Location)dataGridView.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show("Удалить место?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        _db.DeleteLocation(location.Id);
                        LoadLocations();
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
