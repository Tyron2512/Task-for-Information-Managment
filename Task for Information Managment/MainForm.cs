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
    using System;
    using System.Windows.Forms;


        public partial class FormMain : Form
        {
            private readonly DB _db = new DB();

            public FormMain()
            {
                InitializeComponent();
                InitializeUI();
                LoadScanners();
            }

            private void InitializeUI()
            {
                // MenuStrip
                var menuStrip = new MenuStrip();
                var fileMenu = new ToolStripMenuItem("Файл");
                var exitItem = new ToolStripMenuItem("Выход");
                exitItem.Click += (s, e) => Application.Exit();
                fileMenu.DropDownItems.Add(exitItem);

                var dataMenu = new ToolStripMenuItem("Данные");
                var scannersItem = new ToolStripMenuItem("Сканеры");
                scannersItem.Click += (s, e) => LoadScanners();
                var employeesItem = new ToolStripMenuItem("Сотрудники");
                employeesItem.Click += (s, e) => ShowEmployees();
                var locationsItem = new ToolStripMenuItem("Места");
                locationsItem.Click += (s, e) => ShowLocations();
                var repairsItem = new ToolStripMenuItem("Ремонты");
                repairsItem.Click += (s, e) => ShowRepairs();
                dataMenu.DropDownItems.AddRange(new[] { scannersItem, employeesItem, locationsItem, repairsItem });

                var reportsMenu = new ToolStripMenuItem("Отчеты");
                var byLocationItem = new ToolStripMenuItem("По местам");
                byLocationItem.Click += (s, e) => ShowReport("SELECT s.*, l.room_name FROM scanners s JOIN locations l ON s.location_id = l.id", "Отчет по местам");
                var byEmployeeItem = new ToolStripMenuItem("По сотрудникам");
                byEmployeeItem.Click += (s, e) => ShowReport("SELECT s.*, e.full_name FROM scanners s JOIN employees e ON s.employee_id = e.id", "Отчет по сотрудникам");
                var byConditionItem = new ToolStripMenuItem("По состоянию");
                byConditionItem.Click += (s, e) => ShowReport("SELECT * FROM scanners WHERE condition = 'исправен'", "Отчет по исправным сканерам");
                var byAmortizationItem = new ToolStripMenuItem("По амортизации");
                byAmortizationItem.Click += (s, e) => ShowReport("SELECT * FROM scanners WHERE date_registered + interval '1 month' * amortization_term <= CURRENT_DATE", "Отчет по амортизации");
                reportsMenu.DropDownItems.AddRange(new[] { byLocationItem, byEmployeeItem, byConditionItem, byAmortizationItem });

                var helpMenu = new ToolStripMenuItem("Справка");
                var aboutItem = new ToolStripMenuItem("О программе");
                aboutItem.Click += (s, e) => MessageBox.Show("Информационная система учета сканеров\nРазработчик: [Ваше ФИО]\nГруппа: [Ваша группа]", "О программе");
                var helpItem = new ToolStripMenuItem("Справка");
                helpItem.Click += (s, e) => MessageBox.Show("Система для учета сканеров. Используйте меню для управления данными и отчетами.", "Справка");
                var manualItem = new ToolStripMenuItem("Руководство пользователя");
                manualItem.Click += (s, e) => ShowUserManual();
                helpMenu.DropDownItems.AddRange(new[] { aboutItem, helpItem, manualItem });

                menuStrip.Items.AddRange(new[] { fileMenu, dataMenu, reportsMenu, helpMenu });
                this.MainMenuStrip = menuStrip;
                this.Controls.Add(menuStrip);

                // DataGridView
                var dataGridView = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    AutoGenerateColumns = true,
                    AllowUserToAddRows = false
                };
                this.Controls.Add(dataGridView);

                // Search Panel
                var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40 };
                var searchBox = new TextBox { Width = 200 };
                var searchButton = new Button { Text = "Поиск" };
                searchButton.Click += (s, e) => dataGridView.DataSource = _db.SearchScanners(searchBox.Text);
                var addButton = new Button { Text = "Добавить" };
                addButton.Click += (s, e) => AddScanner(dataGridView);
                var editButton = new Button { Text = "Редактировать" };
                editButton.Click += (s, e) => EditScanner(dataGridView);
                var deleteButton = new Button { Text = "Удалить" };
                deleteButton.Click += (s, e) => DeleteScanner(dataGridView);
                panel.Controls.AddRange(new Control[] { new Label { Text = "Поиск:", AutoSize = true }, searchBox, searchButton, addButton, editButton, deleteButton });
                this.Controls.Add(panel);
            }

            private void LoadScanners()
            {
                var dataGridView = this.Controls.OfType<DataGridView>().First();
                dataGridView.DataSource = _db.GetScanners();
            }

            private void AddScanner(DataGridView dataGridView)
            {
                var form = new FormScanner(_db);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadScanners();
            }

            private void EditScanner(DataGridView dataGridView)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    var scanner = (Scanner)dataGridView.SelectedRows[0].DataBoundItem;
                    var form = new FormScanner(_db, scanner);
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadScanners();
                }
            }

            private void DeleteScanner(DataGridView dataGridView)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    var scanner = (Scanner)dataGridView.SelectedRows[0].DataBoundItem;
                    if (MessageBox.Show("Удалить сканер?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _db.DeleteScanner(scanner.Id);
                        LoadScanners();
                    }
                }
            }

            private void ShowEmployees()
            {
                var form = new FormEmployee(_db);
                form.ShowDialog();
            }

            private void ShowLocations()
            {
                var form = new FormLocation(_db);
                form.ShowDialog();
            }

            private void ShowRepairs()
            {
                var form = new FormRepair(_db);
                form.ShowDialog();
            }

            private void ShowReport(string query, string title)
            {
                var form = new FormReport(_db, query, title);
                form.ShowDialog();
            }

            private void ShowUserManual()
            {
                MessageBox.Show("Руководство пользователя:\n1. Используйте меню 'Данные' для управления сканерами, сотрудниками, местами и ремонтами.\n2. Меню 'Отчеты' для создания отчетов.\n3. Используйте поиск для фильтрации сканеров.", "Руководство пользователя");
            }
        }
    
}
