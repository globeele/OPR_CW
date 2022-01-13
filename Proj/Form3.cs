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
    public partial class Form3 : Form
    {

        // Количество альтернатив
        int count;

        // Веса альтернатив.
        public double[] vi;

        private string criteria;

        // Параметры:
        // names - список названий альтернатив
        // values - таблица оценок по шкале Харрингтона для каждого критерия
        // num - номер критерия (номер столбца в таблице) - выбирается только один критерий, т.е. один столбец

        public Form3(List<string> names, double[,] values, int num, string criteria) 
        {
            InitializeComponent();

            // Заголовок.
            Text += " " + criteria;
            this.criteria = criteria;

            // Количество альтернатив.
            count = names.Count;


            grid.RowCount = count + 1;
            grid.ColumnCount = count + 1;

            for (int k = 0; k < count; k++)
            {
                grid[0, k].Value = names[k];
                grid.Columns[k + 1].HeaderText = names[k];
                grid.Columns[k + 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                grid[k + 1, k].Value = 1.0;
            }

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    grid[j + 1, i].Value = values [i, num] > values[j, num] ? 0.9 : 0.1;
                }
            }

        }

        private void MenuNext_Click(object sender, EventArgs e)
        {
            // Цены альтернатив.
            double[] ci = new double[count];

            // Веса альтернатив.
            vi = new double[count];

            // Сумма цен альтернатив.
            double C = 0.0;


            // ci 
            for (int i = 0; i < count; i++) // по всем строкам
            {
                ci[i] = 1.0;
                for (int j = 0; j < count; j++) // по всем столбцам
                {
                    string str = grid[j + 1, i].Value.ToString();
                    double value = double.Parse(str);
                    ci[i] *= value;
                }
                ci[i] = Math.Pow(ci[i], 1.0 / (double)count);
            }


            // C - сумма всех оценок
            for (int i = 0; i < count; i++)
            {
                C += ci[i];
            }


            // vi - веса альтернатив.
            for (int i = 0; i < count; i++)
            {
                vi[i] = ci[i] / C;
            }

            // О всех весах.
            string allV = "Веса альтернатив по критерию " + criteria + " : \n\n";
            for (int i = 0; i < count && i < 20; i++)
            {
                allV += grid[0, i].Value + ": " + "\t" + Math.Round(vi[i], 3) + "\n";
            }
            if (count >= 20)
            {
                allV += " ... ";
            }
            MessageBox.Show(allV);
            Close();
        }
    }
}
