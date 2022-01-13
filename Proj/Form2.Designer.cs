namespace Proj
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabs = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuReady = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExample = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 24);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(800, 426);
            this.tabs.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuReady,
            this.MenuExample,
            this.MenuCancel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuReady
            // 
            this.MenuReady.Name = "MenuReady";
            this.MenuReady.Size = new System.Drawing.Size(57, 20);
            this.MenuReady.Text = "Готово";
            this.MenuReady.Click += new System.EventHandler(this.MenuReady_Click);
            // 
            // MenuExample
            // 
            this.MenuExample.Name = "MenuExample";
            this.MenuExample.Size = new System.Drawing.Size(64, 20);
            this.MenuExample.Text = "Пример";
            this.MenuExample.Click += new System.EventHandler(this.MenuExample_Click);
            // 
            // MenuCancel
            // 
            this.MenuCancel.Name = "MenuCancel";
            this.MenuCancel.Size = new System.Drawing.Size(73, 20);
            this.MenuCancel.Text = "Отменить";
            this.MenuCancel.Click += new System.EventHandler(this.MenuCancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Определяем значимость критериев методом Ранга";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuReady;
        private System.Windows.Forms.ToolStripMenuItem MenuExample;
        private System.Windows.Forms.ToolStripMenuItem MenuCancel;
    }
}