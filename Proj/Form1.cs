using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Proj.Models;

namespace Proj
{
    public partial class Form1 : Form
    {
        // Количество анализируемых завес.
        private int COUNT_Zavesi = -1;

        // Числовая шкала Харрингтона
        private double[] BEGIN_SCALE = new double[5] { 0.8, 0.64, 0.37, 0.2, 0 };
        private double[] STEP_SCALE = new double[5] { 1.0 - 0.8, 0.8 - 0.64, 0.64 - 0.37, 0.37 - 0.2, 0.2 - 0 };

        // Класс базы данных.
        DBDataContext DB = new DBDataContext();

        public Form1()
        {
            InitializeComponent();
        }

        // Переводим качественные оценки в числовую форму по шкале Харригтона
        private double[,] GetHarrington()
        {

            var N = COUNT_Zavesi;
            double[,] values = new double[N, 4];
            var q = DB.Zavesi.ToList().GetRange(0, COUNT_Zavesi);
            for (int o = 0; o < q.Count; o++)
            {
                Zavesi L = q[o];

                //  Цена
                int category = (int)((L.Cost - 200) / 4.0) - 1;
                if (category > 4) category = 4;
                if (category < 0) category = 0;
                double remain = ((int)(L.Cost - 200) / 4.0);
                double cost = BEGIN_SCALE[category] + remain * STEP_SCALE[category];

                //  Мощность
                category = (int)((L.Rashod - 120) / 4) - 1;
                if (category > 4) category = 4;
                if (category < 0) category = 0;
                remain = (int)((L.Rashod - 120) / 4);
                double power = BEGIN_SCALE[category] + remain * STEP_SCALE[category];

                values[o, 0] = cost;
                values[o, 1] = power;
                values[o, 2] = L.Rashod;
                values[o, 3] = L.Par;
            }

            return values;
        }

        private void множествоПаретоToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (COUNT_Zavesi < 1)
            {
                MessageBox.Show("Необходимо выбрать количество альтернатив");
                return;
            }

            var N = COUNT_Zavesi;
            var q = DB.Zavesi.ToList().GetRange(0, COUNT_Zavesi);

            // Начальное множество.
            SetBegin();
        
            // Переводим качественные оценки в числовую форму по шкале Харригтона
            double[,] values = GetHarrington();
            SetGrid(values, N);

            MessageBox.Show("Перевели качественные оценки в числовую форму по шкале Харригтона.");


            // Составляем множество Парето-оптимальных решений
            // все остальные - бесперспективные!


            // Представим рассмотренную процедуру отбора в виде алгоритма.Пусть
            // множество возможных альтернатив Y состоит из конечного числа альтернатив и
            // имеет вид: Y = {y1,y2,...yN}

            // Необходимо сформировать новое множество
            // альтернатив P(Y) путем исключения альтернатив, 
            // которые не превосходят ни по одному критерию остальные альтернативы.
            int kol = N; // kol будет меняться.
            int[] PY = new int[kol];

            // PY2 - бесперспективные альтернативы
            List<int> PY2 = new List<int>();



            // Шаг_1. Вначале положим P(Y) = Y , i = 1, j = 2. Т.е.текущее множество
            // парето - оптимальных альтернатив совпадает с исходным множеством.
            for (int k = 0; k < kol; k++)
            {
                PY[k] = k;
            }
            int i = 0;
            int j = 1;


        Шаг_2:

            // Шаг_2. Проверяем неравенства yi >= yj по всем критериям. 
            // Если оно истинно, то удаляем из P(Y) альтернативу yj и переходим к Шагу_4.
            // В противном случае перейти к Шагу_3. 

            // N - всего альтернатив, 4 - критерия
            if (Test(values, N, 4, PY[i], PY[j])) // yi >= yj
            {
                // Добавляем бесперспективную
                PY2.Add(PY[j]);

                // Удаляем альтернативу yj
                for (int k = j; k < kol - 1; k++)
                {
                    PY[k] = PY[k + 1];
                }
                kol--;

                goto Шаг_4;
            }

        // Шаг_3:

            // Шаг_3. Проверяем неравенства yj >= i по всем критериям. 
            // Если оно истинно, то удаляем из P(Y) альтернативу yi и переходим к Шагу_4.
            // В противном случае перейти к Шагу_4. 

            if (Test(values, N, 4, PY[j], PY[i])) // yi >= yj
            {
                // Добавляем бесперспективную
                PY2.Add(PY[i]);

                // Удаляем альтернативу yj
                for (int k = i; k < kol - 1; k++)
                {
                    PY[k] = PY[k + 1];
                }
                kol--;
            }

        Шаг_4:


            // Шаг_4. Если j < N, то j = j + 1 и вернуться на Шаг_2. 
            // В противном случае перейти к Шагу_5. 

            if (j < kol - 1)
            {
                j++;
                goto Шаг_2;
            }


        // Шаг_5:

            // Шаг_5. Если i < N - 1, то i = i + 1, j = i  + 1 
            // и вернуться на Шаг_2. 
            // В противном случае закончить вычисления, так как 
            // множество парето-оптимальных альтернатив сформировано.

            if (i < kol - 2)
            {
                i++;
                j = i + 1;
                goto Шаг_2;
            }

            // Множество оптимальных сформировано в PY (номера альтернатив)
            // Множество бесперспективных в PY2 (номера альтернатив)
            List<Zavesi> q2 = new List<Zavesi>();
            PY2.ForEach(k => q2.Add(q[k]));
            SetGrid(q2);

            MessageBox.Show("Бесперспективные альтернативы (по множеству Парето).");

        }


        // Сравнение альтернатив a и b по всем критериям одновременно.
        private bool Test (double[,] values, int N, int countCriteria, int a, int b)
        {
            int k = 0;
            while (k < countCriteria && values[a, k] >= values[b, k])
            {
                k++;
            }

            return k >= countCriteria;
        }

        private void лучшаяАльтернативаМетодомАнализаИерархийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (COUNT_Zavesi < 1)
            {
                MessageBox.Show("Необходимо выбрать количество альтернатив");
                return;
            }

            var N = COUNT_Zavesi;
            var q = DB.Zavesi.ToList().GetRange(0, COUNT_Zavesi);
            int E = 2; // Количество экспертов

            MessageBox.Show("Определяем значимость критериев методом Ранга для " + E + "-х экспертов.");

            // Параметры:
            // - количество экспертов
            // -  список названий критериев
            var f = new Form2(E, new string[] { "Стоимость", "Мощность", "Расход", "Пар" });
            if (f.ShowDialog() != DialogResult.OK)
            {
                f.Dispose();
                return;
            }

            double[] VC = f.vi; // Веса всех критериев

            f.Dispose();



            // Начальное множество.
            SetBegin();

            // Переводим качественные оценки в числовую форму по шкале Харригтона
            double[,] values = GetHarrington();
            SetGrid(values, N);
            MessageBox.Show("Перевели качественные оценки в числовую форму по шкале Харригтона. " +
                " На основе этих оценок составляем оценки предпочтения альтернатив по каждому из критериев.");

            var names = DB.Zavesi.Select(p => p.Name).ToList().GetRange(0, COUNT_Zavesi);


            // Веса всех альтерантив
            double[,] VA = new double[4, N];

            var f1 = new Form3(names, values, 0, "Стоимость");
            f1.ShowDialog();
            for (int i = 0; i < N; i++)
            {
                VA[0, i] = f1.vi[i];
            }
            f1.Dispose();

            f1 = new Form3(names, values, 1, "Мощность");
            f1.ShowDialog();
            for (int i = 0; i < N; i++)
            {
                VA[1, i] = f1.vi[i];
            }
            f1.Dispose();

            f1 = new Form3(names, values, 2, "Расход");
            f1.ShowDialog();
            for (int i = 0; i < N; i++)
            {
                VA[2, i] = f1.vi[i];
            }
            f1.Dispose();

            f1 = new Form3(names, values, 3, "Пар");
            f1.ShowDialog();
            for (int i = 0; i < N; i++)
            {
                VA[3, i] = f1.vi[i];
            }
            f1.Dispose();

            // Подсчитываем количественный индикатор важности каждой из
            // альтернатив и определяем лучшую альтернативу(по максимальному значению).
            // Для этого находим произведение веса альтернативы на вес соответствующего критерия 
            // для всех критериев и суммируем соответствующие значения для каждой альтернативы.

            double[] VI = new double[N];
            for (int i = 0; i < N; i++)
            {
                VI[i] = 0;
                for (int j = 0; j < 4; j++)
                {
                    VI[i] += VC[j] * VA[j, i];
                }
            }

            int MX = 0;
            for (int i = 1; i < N; i++)
            {
                if (VI[i] > VI[MX])
                {
                    MX = i;
                }
            }

            MessageBox.Show("Лучше альтернативой по мнению экспертов является: " + names[MX]);
            
            SetBegin();
            grid.ClearSelection();
            grid.Rows[MX].Selected = true;
        }

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Menu100_Click(object sender, EventArgs e)
        {
            COUNT_Zavesi = 100;            
            
            Random rand = new Random();

            // Добавляем альтернативы.
            if (DB.Zavesi.ToList().Count < COUNT_Zavesi)
            {
                for (int i = 0; i < COUNT_Zavesi; i++)
                {
                    DB.Zavesi.InsertOnSubmit(new Zavesi
                    {
                        Name = "Завеса" + i,
                        Cost = rand.NextDouble() * 1000.0,
                        Power = rand.NextDouble() * 300.0,
                        Rashod = rand.NextDouble() * 2200.0,
                        Par = rand.Next() % 2
                    });
                    DB.SubmitChanges();
                }
            }


            SetBegin();
        }


        private void SetGrid(List<Zavesi> L)
        {
            grid.Rows.Clear();
            grid.RowCount = L.Count;
            for (int i = 0; i < L.Count; i++)
            {
                Zavesi l = L[i];
                grid[0, i].Value = l.Id;
                grid[1, i].Value = l.Name;
                grid[2, i].Value = l.Cost;
                grid[3, i].Value = l.Power;
                grid[4, i].Value = l.Rashod;
                grid[5, i].Value = l.Par == 1 ? "Да" : "Нет";
            }
        }
        private void SetGrid(double[,] values, int N)
        {
            for (int i = 0; i < N; i++)
            {
                grid[2, i].Value = values[i, 0];
                grid[3, i].Value = values[i, 1];
                grid[4, i].Value = values[i, 2];
                grid[5, i].Value = values[i, 3];
            }
        }
        private void SetBegin()
        {
            var q = DB.Zavesi.ToList().GetRange(0, COUNT_Zavesi);
            SetGrid(q);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }
        private void MenuBegin_Click(object sender, EventArgs e)
        {
            COUNT_Zavesi = 20;
            SetBegin();
        }
        private void MenuOne_Click(object sender, EventArgs e)
        {
            if (COUNT_Zavesi < 1)
            {
                MessageBox.Show("Необходимо выбрать количество альтернатив");
                return;
            }

            // Существует также ограничение по общей стоимости (не более 400 руб.)
            // и мощности (не более 120).
            // Для однокритериальной задачи:
            // критерий – Расход, 


            var q = DB.Zavesi.Where(p => p.Cost <= 400 && p.Power <= 120.0 && p.Id <= COUNT_Zavesi).OrderBy(p => p.Rashod).ToList();
            SetGrid(q);
        }
        private void MenuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void завесToolStripMenuItem_Click(object sender, EventArgs e)
        {
            COUNT_Zavesi = 50;
            SetBegin();
        }
    }
}
