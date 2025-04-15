namespace Task_for_Information_Managment
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSort = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.buttonDeleteScaner = new System.Windows.Forms.Button();
            this.buttonEditScaner = new System.Windows.Forms.Button();
            this.buttonAddScaner = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewDB = new System.Windows.Forms.DataGridView();
            this.ID_Scanner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResolutionDPI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarrantyEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panelSort.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Jonova", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(613, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сканнеры";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelSort);
            this.panel1.Controls.Add(this.panelButtons);
            this.panel1.Controls.Add(this.dataGridViewDB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 1;
            // 
            // panelSort
            // 
            this.panelSort.Controls.Add(this.button13);
            this.panelSort.Controls.Add(this.button12);
            this.panelSort.Controls.Add(this.buttonDeleteScaner);
            this.panelSort.Controls.Add(this.buttonEditScaner);
            this.panelSort.Controls.Add(this.buttonAddScaner);
            this.panelSort.Controls.Add(this.label3);
            this.panelSort.Location = new System.Drawing.Point(3, 43);
            this.panelSort.Name = "panelSort";
            this.panelSort.Size = new System.Drawing.Size(770, 60);
            this.panelSort.TabIndex = 3;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(635, 29);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(132, 23);
            this.button13.TabIndex = 10;
            this.button13.Text = "Причина поломки";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(507, 29);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(122, 23);
            this.button12.TabIndex = 9;
            this.button12.Text = "Дата поломки";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteScaner
            // 
            this.buttonDeleteScaner.Location = new System.Drawing.Point(362, 29);
            this.buttonDeleteScaner.Name = "buttonDeleteScaner";
            this.buttonDeleteScaner.Size = new System.Drawing.Size(139, 23);
            this.buttonDeleteScaner.TabIndex = 8;
            this.buttonDeleteScaner.Text = "Удалить запись";
            this.buttonDeleteScaner.UseVisualStyleBackColor = true;
            // 
            // buttonEditScaner
            // 
            this.buttonEditScaner.Location = new System.Drawing.Point(214, 29);
            this.buttonEditScaner.Name = "buttonEditScaner";
            this.buttonEditScaner.Size = new System.Drawing.Size(142, 23);
            this.buttonEditScaner.TabIndex = 7;
            this.buttonEditScaner.Text = "Изменить запись";
            this.buttonEditScaner.UseVisualStyleBackColor = true;
            // 
            // buttonAddScaner
            // 
            this.buttonAddScaner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddScaner.Location = new System.Drawing.Point(9, 29);
            this.buttonAddScaner.Name = "buttonAddScaner";
            this.buttonAddScaner.Size = new System.Drawing.Size(199, 23);
            this.buttonAddScaner.TabIndex = 6;
            this.buttonAddScaner.Text = "Добавить запись";
            this.buttonAddScaner.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Jonova", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Фильтры";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.label2);
            this.panelButtons.Controls.Add(this.button3);
            this.panelButtons.Controls.Add(this.button2);
            this.panelButtons.Controls.Add(this.button1);
            this.panelButtons.Location = new System.Drawing.Point(0, 109);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(165, 314);
            this.panelButtons.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Jonova", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 138);
            this.label2.TabIndex = 3;
            this.label2.Text = "Таблицы\r\nБазы\r\nДанных";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 137);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 54);
            this.button3.TabIndex = 2;
            this.button3.Text = "Сканнеры";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 54);
            this.button2.TabIndex = 1;
            this.button2.Text = "Отчетственные лица";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Аудитории";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDB
            // 
            this.dataGridViewDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Scanner,
            this.InventoryNumber,
            this.Model,
            this.SerialNumber,
            this.ResolutionDPI,
            this.ScanType,
            this.PurchaseDate,
            this.WarrantyEnd,
            this.Status,
            this.LocationID,
            this.EmployeeID});
            this.dataGridViewDB.Location = new System.Drawing.Point(171, 109);
            this.dataGridViewDB.Name = "dataGridViewDB";
            this.dataGridViewDB.Size = new System.Drawing.Size(605, 317);
            this.dataGridViewDB.TabIndex = 1;
            // 
            // ID_Scanner
            // 
            this.ID_Scanner.HeaderText = "ID Сканера";
            this.ID_Scanner.Name = "ID_Scanner";
            this.ID_Scanner.ReadOnly = true;
            // 
            // InventoryNumber
            // 
            this.InventoryNumber.HeaderText = "Инвентарный номер";
            this.InventoryNumber.Name = "InventoryNumber";
            this.InventoryNumber.ReadOnly = true;
            // 
            // Model
            // 
            this.Model.HeaderText = "Модель";
            this.Model.Name = "Model";
            // 
            // SerialNumber
            // 
            this.SerialNumber.HeaderText = "Серийный номер";
            this.SerialNumber.Name = "SerialNumber";
            // 
            // ResolutionDPI
            // 
            this.ResolutionDPI.HeaderText = "Разрешение (DPI)";
            this.ResolutionDPI.Name = "ResolutionDPI";
            // 
            // ScanType
            // 
            this.ScanType.HeaderText = "Тип сканирования";
            this.ScanType.Name = "ScanType";
            // 
            // PurchaseDate
            // 
            this.PurchaseDate.HeaderText = "Дата приобретения";
            this.PurchaseDate.Name = "PurchaseDate";
            // 
            // WarrantyEnd
            // 
            this.WarrantyEnd.HeaderText = "Дата окончания гарантии";
            this.WarrantyEnd.Name = "WarrantyEnd";
            // 
            // Status
            // 
            this.Status.HeaderText = "Состояние";
            this.Status.Name = "Status";
            // 
            // LocationID
            // 
            this.LocationID.HeaderText = "Расположение";
            this.LocationID.Name = "LocationID";
            // 
            // EmployeeID
            // 
            this.EmployeeID.HeaderText = "Ответственное лицо";
            this.EmployeeID.Name = "EmployeeID";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSort.ResumeLayout(false);
            this.panelSort.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewDB;
        private System.Windows.Forms.Panel panelSort;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button buttonDeleteScaner;
        private System.Windows.Forms.Button buttonEditScaner;
        private System.Windows.Forms.Button buttonAddScaner;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Scanner;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResolutionDPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScanType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarrantyEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
    }
}

