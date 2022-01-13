namespace Proj
{
    partial class Form1
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Udel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Air = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBegin = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.оптимизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.однокритериальнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.многокритериальнаяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.бесперспективныеАльтернативыпоМножествуПаретоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лучшаяАльтернативаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.завесToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name0,
            this.Cost,
            this.Udel,
            this.Pak,
            this.Air});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 24);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(800, 426);
            this.grid.TabIndex = 0;
            this.grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValueChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "Column1";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Name0
            // 
            this.Name0.HeaderText = "Название модели завесы";
            this.Name0.Name = "Name0";
            this.Name0.ReadOnly = true;
            this.Name0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Name0.Width = 150;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Стоимость, бел.руб.";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Udel
            // 
            this.Udel.HeaderText = "Мощность, кВт";
            this.Udel.Name = "Udel";
            this.Udel.ReadOnly = true;
            this.Udel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pak
            // 
            this.Pak.HeaderText = "Часовой расход воздуха, м.куб/ч.";
            this.Pak.Name = "Pak";
            this.Pak.ReadOnly = true;
            this.Pak.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Air
            // 
            this.Air.HeaderText = "Необходимость пара";
            this.Air.Name = "Air";
            this.Air.ReadOnly = true;
            this.Air.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оптимизацияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuBegin,
            this.завесToolStripMenuItem,
            this.Menu100,
            this.toolStripMenuItem1,
            this.MenuClose});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // MenuBegin
            // 
            this.MenuBegin.Name = "MenuBegin";
            this.MenuBegin.Size = new System.Drawing.Size(180, 22);
            this.MenuBegin.Text = "20 завес";
            this.MenuBegin.Click += new System.EventHandler(this.MenuBegin_Click);
            // 
            // Menu100
            // 
            this.Menu100.Name = "Menu100";
            this.Menu100.Size = new System.Drawing.Size(180, 22);
            this.Menu100.Text = "100 завес";
            this.Menu100.Click += new System.EventHandler(this.Menu100_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // MenuClose
            // 
            this.MenuClose.Name = "MenuClose";
            this.MenuClose.Size = new System.Drawing.Size(180, 22);
            this.MenuClose.Text = "Выход";
            this.MenuClose.Click += new System.EventHandler(this.MenuClose_Click);
            // 
            // оптимизацияToolStripMenuItem
            // 
            this.оптимизацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.однокритериальнаяToolStripMenuItem,
            this.многокритериальнаяToolStripMenuItem1});
            this.оптимизацияToolStripMenuItem.Name = "оптимизацияToolStripMenuItem";
            this.оптимизацияToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оптимизацияToolStripMenuItem.Text = "Оптимизация";
            // 
            // однокритериальнаяToolStripMenuItem
            // 
            this.однокритериальнаяToolStripMenuItem.Name = "однокритериальнаяToolStripMenuItem";
            this.однокритериальнаяToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.однокритериальнаяToolStripMenuItem.Text = "Однокритериальная";
            this.однокритериальнаяToolStripMenuItem.Click += new System.EventHandler(this.MenuOne_Click);
            // 
            // многокритериальнаяToolStripMenuItem1
            // 
            this.многокритериальнаяToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.бесперспективныеАльтернативыпоМножествуПаретоToolStripMenuItem,
            this.лучшаяАльтернативаToolStripMenuItem});
            this.многокритериальнаяToolStripMenuItem1.Name = "многокритериальнаяToolStripMenuItem1";
            this.многокритериальнаяToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.многокритериальнаяToolStripMenuItem1.Text = "Многокритериальная";
            // 
            // бесперспективныеАльтернативыпоМножествуПаретоToolStripMenuItem
            // 
            this.бесперспективныеАльтернативыпоМножествуПаретоToolStripMenuItem.Name = "бесперспективныеАльтернативыпоМножествуПаретоToolStripMenuItem";
            this.бесперспективныеАльтернативыпоМножествуПаретоToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.бесперспективныеАльтернативыпоМножествуПаретоToolStripMenuItem.Text = "Бесперспективные альтернативы";
            this.бесперспективныеАльтернативыпоМножествуПаретоToolStripMenuItem.Click += new System.EventHandler(this.множествоПаретоToolStripMenuItem_Click);
            // 
            // лучшаяАльтернативаToolStripMenuItem
            // 
            this.лучшаяАльтернативаToolStripMenuItem.Name = "лучшаяАльтернативаToolStripMenuItem";
            this.лучшаяАльтернативаToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.лучшаяАльтернативаToolStripMenuItem.Text = "Лучшая альтернатива";
            this.лучшаяАльтернативаToolStripMenuItem.Click += new System.EventHandler(this.лучшаяАльтернативаМетодомАнализаИерархийToolStripMenuItem_Click);
            // 
            // завесToolStripMenuItem
            // 
            this.завесToolStripMenuItem.Name = "завесToolStripMenuItem";
            this.завесToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.завесToolStripMenuItem.Text = "50 завес";
            this.завесToolStripMenuItem.Click += new System.EventHandler(this.завесToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оптимизация выбора тепловой завесы";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuClose;
        private System.Windows.Forms.ToolStripMenuItem MenuBegin;
        private System.Windows.Forms.ToolStripMenuItem Menu100;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem оптимизацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem однокритериальнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem многокритериальнаяToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem бесперспективныеАльтернативыпоМножествуПаретоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лучшаяАльтернативаToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Udel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pak;
        private System.Windows.Forms.DataGridViewTextBoxColumn Air;
        private System.Windows.Forms.ToolStripMenuItem завесToolStripMenuItem;
    }
}

