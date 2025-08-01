using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClosedXML.Excel;
using System.IO;


namespace Task_for_Information_Managment
{
    public partial class FormReport : Form
    {
        private readonly DB _db;
        private readonly string _query;
        private readonly string _title;

        public FormReport(DB db, string query, string title)
        {
            InitializeComponent();
            _db = db;
            _query = query;
            _title = title;
            InitializeUI();
            LoadReport();
        }

        private void InitializeUI()
        {
            this.Text = _title;
            this.Size = new System.Drawing.Size(800, 600);
            var dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dataGridView);

            var panel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40 };
            var exportButton = new Button { Text = "Экспорт в Excel" };
            exportButton.Click += ExportToExcel;
            panel.Controls.Add(exportButton);
            this.Controls.Add(panel);
        }

        private void LoadReport()
        {
            var dataGridView = this.Controls.OfType<DataGridView>().First();
            dataGridView.DataSource = _db.GetReport(_query);
        }

        private void ExportToExcel(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog { Filter = "Excel Files|*.xlsx", FileName = $"{_title}.xlsx" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var dt = _db.GetReport(_query);
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add(_title);
                            worksheet.Cell(1, 1).InsertTable(dt);
                            workbook.SaveAs(saveFileDialog.FileName);
                        }
                        MessageBox.Show("Отчет успешно экспортирован!", "Успех");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка");
                    }
                }
            }
        }
    }
}
