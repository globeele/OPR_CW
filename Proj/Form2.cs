using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj
{
    public partial class Form2 : Form
    {


        // Веса критериев.
        public double[] vi;


        // Список таблиц для экспертов.
        private List<DataGridView> L = new List<DataGridView>();

        // Количество критериев
        private int countCriteria;

        // Изменение ячейки (true - если ячейка редактируется)
        private bool change = false;

        // Параметры:
        // E - количество экспертов
        // names - список критериев
        public Form2(int E, string[] names) // Количество экспертов
        {
            InitializeComponent();

            // Количество критериев.
            countCriteria = names.Length;


            for (int i = 0; i < E; i++)
            {
                tabs.TabPages.Add((i + 1) + " эксперт");

                var t = tabs.TabPages[i];
                var grid = new DataGridView();

                grid.Name = "grid" + i;
                grid.Dock = DockStyle.Fill;
                grid.RowCount = countCriteria + 1;
                grid.ColumnCount = 2; // Одна колонка для названия критерия. Вторая колонка - для балла эксперта.

                for (int k = 0; k < countCriteria; k++)
                {
                    grid[0, k].Value = names[k];
                }

                grid.Columns[0].HeaderText = "Критерий";
                grid.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

                grid.AllowUserToAddRows = false;
                grid.AllowUserToDeleteRows = false;

                // Обработчик
                grid.CellValueChanged += new DataGridViewCellEventHandler(this.grid_CellValueChanged);

                L.Add(grid);
                t.Controls.Add(grid);
            }
        }

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (change)
            {
                return;
            }

            change = true;

            double V;          
            var g = L[tabs.SelectedIndex];
            int c = e.ColumnIndex;

            int r = e.RowIndex;
            var edit = g.EditingControl;

            String value = g[c, r].Value.ToString();

            if (!double.TryParse(value, out V))
            {
                g[c, r].Value = "";
            }

            change = false;
        }

        private void MenuCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void MenuExample_Click(object sender, EventArgs e)
        {
            var r = new Random();

            for (int k = 0; k < tabs.TabCount; k++) // По всем экспертам (таблицам)
            {
                var g = L[k];
                tabs.SelectedIndex = k;    
                for (int i = 0; i < countCriteria; i++)
                {
                    g[1, i].Value = r.Next() % 10;
                }
            }
        }

        private void MenuReady_Click(object sender, EventArgs e)
        {
            // Цены критериев.
            double[] ci = new double[countCriteria];

            // Веса криетриев.
            vi = new double[countCriteria];

            // Сумма цен критерив.
            double C = 0.0;


            // ci для нескольких экспертов.
            // Алгоритм отличается от алгоритма для одного эксперта.
            for (int i = 0; i < countCriteria; i++) // по всем строкам
            {
                ci[i] = 0.0;
                    for (int k = 0; k < tabs.TabCount; k++) // по всем экспертам
                    {
                        var g = L[k];
                        double value = 0.0;

                        if (g[1, i].Value == null)
                        {
                            MessageBox.Show("Ошибка ввода исходных данных в таблице для эксперта - " + (k + 1));
                            return;
                        }


                        string str = g[1, i].Value.ToString();
                        if (double.TryParse(str, out value))
                        {
                            if (value < 0 || value > 10)
                            {
                                MessageBox.Show("Ошибка ввода исходных данных ('" + str + "') в таблице для эксперта - " + (k + 1));
                                return;
                            }

                            ci[i] += value;
                        }
                        else
                        {
                            MessageBox.Show("Ошибка ввода исходных данных ('" + str + "') в таблице для эксперта - " + (k + 1));
                            return;
                        }
                    }
            }


            // C - сумма всех оценок
            for (int i = 0; i < countCriteria; i++)
            {
                C += ci[i];
            }


            // vi - веса альтернатив.
            for (int i = 0; i < countCriteria; i++)
            {
                vi[i] = ci[i] / C;
            }

            // О всех весах.
            string allV = "Веса критериев: \n\n";
            for (int i = 0; i < countCriteria; i++)
            {
                allV += L[0][0, i].Value + ": "  + "\t" + Math.Round(vi[i], 3) + "\n";
            }
            MessageBox.Show(allV);


            DialogResult = DialogResult.OK;
            Close();
        }
    }
}