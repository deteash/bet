using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bets
{
    public partial class Form1 : Form
    {
        List<line> lines;
        List<result> results;
        public Form1()
        {
            InitializeComponent();
            checkedListBox1.SetItemChecked(0, true);
            checkedListBox1.SetItemChecked(1, true);
            checkedListBox1.SetItemChecked(2, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lines = new List<line>();
                results = new List<result>();
                Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = ObjExcel.Workbooks.Open(openFileDialog1.FileName, 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
                ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();
                int read = (int)numericReadLines.Value;
                progressBar1.Visible = true;
                progressBar1.Maximum = read;
                string pattern1 = "yyyy-MM-dd HH:mm";
                string pattern2 = "dd.MM.yyyy HH:mm";
                string pattern3 = "dd.MM.yyyy H:mm";
                for (int i = 1; i < read + 1; i++)
                {
                    line ln = new line();
                    result res = new result();
                    bool write = false;
                    progressBar1.Value = i;
                    for (int j = 1; j < 14; j++)
                    {
                        string x = ObjWorkSheet.Cells[i, j].Text;
                        if (x != "-")
                        {
                            if (j == 1 && x.Contains(':'))//read data and score
                            {
                                DateTime.TryParseExact(ParseDate.CutScore(x), pattern1, System.Globalization.CultureInfo.InvariantCulture,
                                                    System.Globalization.DateTimeStyles.None, out res.data);
                                res.score1 = ParseDate.ParseScore1(x);
                                res.score2 = ParseDate.ParseScore2(x);
                                res.team1 = ObjWorkSheet.Cells[i, j + 1].Text;
                                res.team2 = ObjWorkSheet.Cells[i, j + 2].Text;
                                results.Add(res);
                                label5.Text = results.Count() + " событий";
                            }
                            else if (j == 2 && x != string.Empty && x != "Команда 1")
                            { ln.team1 = x; }
                            else if (j == 3 && x != string.Empty && x != "Команда 2")
                            { ln.team2 = x; }
                            else if (j == 4 && x != string.Empty && x != "П1")
                            { ln.win1 = Convert.ToDouble(x); }
                            else if (j == 5 && x != string.Empty && x != "X")
                            { ln.x = Convert.ToDouble(x); }
                            else if (j == 6 && x != string.Empty && x != "П2")
                            { ln.win2 = Convert.ToDouble(x); }
                            else if (j == 7 && x != string.Empty && x != "Фора")
                            { ln.fora1 = Convert.ToDouble(x); }
                            else if (j == 8 && x != string.Empty && x != "Кф1")
                            { ln.fora1k = Convert.ToDouble(x); }
                            else if (j == 9 && x != string.Empty && x != "Кф2")
                            { ln.fora2k = Convert.ToDouble(x); }
                            else if (j == 10 && x != string.Empty && x != "Тотал")
                            { ln.total = Convert.ToDouble(x); }
                            else if (j == 11 && x != string.Empty && x != "Бол")
                            { ln.totalb = Convert.ToDouble(x); }
                            else if (j == 12 && x != string.Empty && x != "Мен")
                            { ln.totalm = Convert.ToDouble(x); }

                            else if (j == 13 && x.Contains(':'))//read scan
                            {
                                DateTime.TryParseExact(x, pattern2, System.Globalization.CultureInfo.InvariantCulture,
                                                    System.Globalization.DateTimeStyles.None, out ln.data);
                                DateTime.TryParseExact(x, pattern3, System.Globalization.CultureInfo.InvariantCulture,
                                                    System.Globalization.DateTimeStyles.None, out ln.data);
                                write = true;
                            }
                        }
                    }
                    if (write)
                    {
                        lines.Add(ln);
                        label6.Text = lines.Count() + " линий";
                    }
                }
                progressBar1.Visible = false;
                label8.Visible = true;
                stopwatch.Stop();
                label3.Visible = true;
                label3.Text = (stopwatch.ElapsedMilliseconds / 1000).ToString() + " seconds";
                ObjExcel.Quit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int nbets = Convert.ToInt32(numericBets.Value);
            if (results == null || nbets > results.Count())
            {
                MessageBox.Show("Не найдено столько событий!");
                return;
            }
            int hours = (int)numericHours.Value;
            List<result> mres = new List<result>();
            List<int> mass = new List<int>();
            dataGridView1.RowCount = nbets;
            int sumbet = 0;
            int winbet = 0;
            for (int m = 0; m < 9; m++)
            {
                for (int t = 0; t < nbets; t++)
                {
                    dataGridView1.Rows[t].Cells[m].Value = 0;
                }
            }
            Random rand = new Random();
            while (mres.Count() < nbets)
            {
                int rnd = rand.Next(0, results.Count());
                if (!mres.Contains(results.ElementAt(rnd)))
                    mres.Add(results.ElementAt(rnd));
            }
            int currentRow = 0;
            for (int i = 0; i < mres.Count(); i++)
            {
                List<line> thisline = new List<line>();
                foreach (line ln in lines)
                {
                    int hrs = (mres[i].data - ln.data).Hours + (mres[i].data - ln.data).Days * 24;
                    if (mres[i].team1 == ln.team1 && mres[i].team2 == ln.team2 && hrs < hours)
                    {
                        thisline.Add(ln); // выбираем подходящие лайны к выбранным событиям
                    }
                }

                bool checkListAccepted = false;
                int bet = rand.Next(7);
                while (!checkListAccepted)
                {
                    bet = rand.Next(7);
                    if (bet <= 2 && checkedListBox1.GetItemChecked(0))
                        checkListAccepted = true;
                    if (bet >= 5 && checkedListBox1.GetItemChecked(2))
                        checkListAccepted = true;
                    if (bet >= 3 && checkedListBox1.GetItemChecked(1) && bet <= 4)
                        checkListAccepted = true;
                }
                int betline = rand.Next(thisline.Count());

                if (thisline.Count() != 0)
                {
                    dataGridView1.Rows[currentRow].Cells[0].Value = thisline[betline].team1;
                    dataGridView1.Rows[currentRow].Cells[1].Value = thisline[betline].team2;
                    dataGridView1.Rows[currentRow].Cells[2].Value = mres[i].score1;
                    dataGridView1.Rows[currentRow].Cells[3].Value = mres[i].score2;
                    sumbet = sumbet + 1000;
                    switch (bet)
                    {
                        case 0:
                            if (thisline[betline].win1 == 0)
                            {
                                sumbet = sumbet - 1000;
                                if (checkBoxAll.Checked)
                                    i--;
                                break;
                            }
                            dataGridView1.Rows[currentRow].Cells[4].Value = "П1";
                            dataGridView1.Rows[currentRow].Cells[6].Value = thisline[betline].win1;
                            if (mres[i].score1 > mres[i].score2)
                            {
                                dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
                                winbet = (winbet + Convert.ToInt32(thisline[betline].win1 * 1000));
                                dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].win1 * 1000);
                            }
                            else
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.OrangeRed;
                            currentRow++;
                            break;
                        case 1:
                            if (thisline[betline].x == 0)
                            {
                                sumbet = sumbet - 1000;
                                if (checkBoxAll.Checked)
                                    i--;
                                break;
                            }
                            dataGridView1.Rows[currentRow].Cells[4].Value = "X";
                            dataGridView1.Rows[currentRow].Cells[6].Value = thisline[betline].x;
                            if (mres[i].score1 == mres[i].score2 && thisline[betline].x != 0)
                            {
                                dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
                                winbet = (winbet + Convert.ToInt32(thisline[betline].x * 1000));
                                dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].x * 1000);
                            }
                            else
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.OrangeRed;
                            currentRow++;
                            break;
                        case 2:
                            if (thisline[betline].win2 == 0)
                            {
                                sumbet = sumbet - 1000;
                                if (checkBoxAll.Checked)
                                    i--;
                                break;
                            }
                            dataGridView1.Rows[currentRow].Cells[4].Value = "П2";
                            dataGridView1.Rows[currentRow].Cells[6].Value = thisline[betline].win2;
                            if (mres[i].score2 > mres[i].score1 && thisline[betline].win2 != 0)
                            {
                                dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
                                winbet = (winbet + Convert.ToInt32(thisline[betline].win2 * 1000));
                                dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].win2 * 1000);
                            }
                            else
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.OrangeRed;
                            currentRow++;
                            break;
                        case 3:
                            if (thisline[betline].fora1k == 0)
                            {
                                sumbet = sumbet - 1000;
                                if (checkBoxAll.Checked)
                                    i--;
                                break;
                            }
                            dataGridView1.Rows[currentRow].Cells[4].Value = "Фора1";
                            dataGridView1.Rows[currentRow].Cells[6].Value = thisline[betline].fora1k;
                            dataGridView1.Rows[currentRow].Cells[5].Value = thisline[betline].fora1;
                            if (thisline[betline].total.ToString().Contains("25") || thisline[betline].total.ToString().Contains("75"))
                            {
                                if (mres[i].score1 - mres[i].score2 + thisline[betline].fora1 + 0.25 > 0) // 1:2 vs 0.75 - win
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
                                    winbet = (winbet + Convert.ToInt32(thisline[betline].fora1k * 1000));
                                    dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].fora1k * 1000);
                                }
                                else if (mres[i].score1 - mres[i].score2 + thisline[betline].fora1 + 0.25 == 0) // 1:2 vs 0.75 - расход 1/2 + проеб
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = "1/2";
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Orange;
                                    winbet = (winbet + 1000 / 2);
                                    dataGridView1.Rows[currentRow].Cells[8].Value = 500;
                                }
                                else if (mres[i].score1 - mres[i].score2 + thisline[betline].fora1 - 0.25 == 0) // 1:2 vs 1.25 - расход 1/2 + win 1/2 
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = "+3/4";
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LightYellow;
                                    winbet = (winbet + Convert.ToInt32(thisline[betline].fora1k * 1000 / 2) + 1000 / 2);
                                    dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].fora1k * 1000 / 2) + 1000 / 2;
                                }
                                else
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.OrangeRed;
                            }
                            else if (mres[i].score1 - mres[i].score2 + thisline[betline].fora1 > 0)
                            {
                                dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
                                winbet = (winbet + Convert.ToInt32(thisline[betline].fora1k * 1000));
                                dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].fora1k * 1000);
                            }
                            else if (mres[i].score1 - mres[i].score2 + thisline[betline].fora1 == 0)
                            {
                                dataGridView1.Rows[currentRow].Cells[7].Value = "P";
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Yellow;
                                winbet = (winbet + 1000);
                                dataGridView1.Rows[currentRow].Cells[8].Value = 1000;
                            }
                            else
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.OrangeRed;
                            currentRow++;
                            break;
                        case 4:
                            if (thisline[betline].fora2k == 0)
                            {
                                sumbet = sumbet - 1000;
                                if (checkBoxAll.Checked)
                                    i--;
                                break;
                            }
                            dataGridView1.Rows[currentRow].Cells[4].Value = "Фора2";
                            dataGridView1.Rows[currentRow].Cells[6].Value = thisline[betline].fora2k;
                            dataGridView1.Rows[currentRow].Cells[5].Value = thisline[betline].fora1;

                            if (thisline[betline].total.ToString().Contains("25") || thisline[betline].total.ToString().Contains("75"))
                            {
                                if (mres[i].score2 - mres[i].score1 + thisline[betline].fora1 + 0.25 > 0) // 2:1 vs 0.75 - win
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
                                    winbet = (winbet + Convert.ToInt32(thisline[betline].fora2k * 1000));
                                    dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].fora2k * 1000);
                                }
                                else if (mres[i].score2 - mres[i].score1 + thisline[betline].fora1 + 0.25 == 0) // 2:1 vs 0.75 - расход 1/2 + проеб
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = "1/2";
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Orange;
                                    winbet = (winbet + 1000 / 2);
                                    dataGridView1.Rows[currentRow].Cells[8].Value = 500;
                                }
                                else if (mres[i].score2 - mres[i].score1 + thisline[betline].fora1 - 0.25 == 0) // 2:1 vs 1.25 - расход 1/2 + win 1/2 
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = "+3/4";
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LightYellow;
                                    winbet = (winbet + Convert.ToInt32(thisline[betline].fora2k * 1000 / 2) + 1000 / 2);
                                    dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].fora2k * 1000 / 2) + 1000 / 2;
                                }
                                else
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.OrangeRed;
                            }
                            else if (mres[i].score2 - mres[i].score1 + thisline[betline].fora1 > 0)
                            {
                                dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
                                winbet = (winbet + Convert.ToInt32(thisline[betline].fora2k * 1000));
                                dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].fora2k * 1000);
                            }
                            else if (mres[i].score2 - mres[i].score1 + thisline[betline].fora1 == 0)
                            {
                                dataGridView1.Rows[currentRow].Cells[7].Value = "P";
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Yellow;
                                winbet = (winbet + 1000);
                                dataGridView1.Rows[currentRow].Cells[8].Value = 1000;
                            }
                            else
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.OrangeRed;
                            currentRow++;
                            break;
                        case 5:
                            if (thisline[betline].totalb == 0)
                            {
                                sumbet = sumbet - 1000;
                                if (checkBoxAll.Checked)
                                    i--;
                                break;
                            }
                            dataGridView1.Rows[currentRow].Cells[4].Value = "ТБ";
                            dataGridView1.Rows[currentRow].Cells[6].Value = thisline[betline].totalb;
                            dataGridView1.Rows[currentRow].Cells[5].Value = thisline[betline].total;
                            if (thisline[betline].total.ToString().Contains("25") || thisline[betline].total.ToString().Contains("75"))
                            {
                                if (mres[i].score1 + mres[i].score2 > thisline[betline].total + 0.25) // 3 vs 2.25 - win
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
                                    winbet = (winbet + Convert.ToInt32(thisline[betline].totalb * 1000));
                                    dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].totalb * 1000);
                                }
                                else if (mres[i].score1 + mres[i].score2 == thisline[betline].total - 0.25) // 2 vs 2.25 - расход 1/2 + проеб
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = "1/2";
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Orange;
                                    winbet = (winbet + 1000 / 2);
                                    dataGridView1.Rows[currentRow].Cells[8].Value = 500;
                                }
                                else if (mres[i].score1 + mres[i].score2 == thisline[betline].total + 0.25) // 3 vs 2.75 - расход 1/2 + win 1/2 
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = "3/4";
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LightYellow;
                                    winbet = (winbet + Convert.ToInt32(thisline[betline].totalb * 1000 / 2) + 1000 / 2);
                                    dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].totalb * 1000 / 2) + 1000 / 2;
                                }
                                else
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.OrangeRed;
                            }
                            else if (mres[i].score1 + mres[i].score2 > thisline[betline].total)
                            {
                                dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
                                winbet = (winbet + Convert.ToInt32(thisline[betline].totalb * 1000));
                                dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].totalb * 1000);
                            }
                            else if (mres[i].score1 + mres[i].score2 == thisline[betline].total)
                            {
                                dataGridView1.Rows[currentRow].Cells[7].Value = "P";
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Yellow;
                                dataGridView1.Rows[currentRow].Cells[8].Value = 1000;
                                winbet = winbet + 1000;
                            }
                            else
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.OrangeRed;
                            currentRow++;
                            break;
                        case 6:
                            dataGridView1.Rows[currentRow].Cells[4].Value = "ТМ";
                            dataGridView1.Rows[currentRow].Cells[6].Value = thisline[betline].totalm;
                            dataGridView1.Rows[currentRow].Cells[5].Value = thisline[betline].total;
                            if (thisline[betline].totalm == 0)
                            {
                                sumbet = sumbet - 1000;
                                if (checkBoxAll.Checked)
                                    i--;
                                break;
                            }
                            if (thisline[betline].total.ToString().Contains("25") || thisline[betline].total.ToString().Contains("75"))
                            {
                                if (mres[i].score1 + mres[i].score2 < thisline[betline].total - 0.25) // 2 vs 2.75 win
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
                                    winbet = (winbet + Convert.ToInt32(thisline[betline].totalm * 1000));
                                    dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].totalm * 1000);
                                }
                                else if (mres[i].score1 + mres[i].score2 == thisline[betline].total + 0.25) // 3 vs 2.75 - расход 1/2 + проеб
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = "1/2";
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Orange;
                                    winbet = (winbet + 1000 / 2);
                                    dataGridView1.Rows[currentRow].Cells[8].Value = 500;
                                }
                                else if (mres[i].score1 + mres[i].score2 == thisline[betline].total - 0.25) // 2 vs 2.25 - расход 1/2 + win 1/2 
                                {
                                    dataGridView1.Rows[currentRow].Cells[7].Value = "3/4";
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LightYellow;
                                    winbet = (winbet + Convert.ToInt32(thisline[betline].totalm * 1000 / 2) + 1000 / 2);
                                    dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].totalm * 1000 / 2) + 1000 / 2;
                                }
                                else
                                    dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.OrangeRed;
                            }
                            else if (mres[i].score1 + mres[i].score2 < thisline[betline].total)
                            {
                                dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
                                winbet = (winbet + Convert.ToInt32(thisline[betline].totalm * 1000));
                                dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(thisline[betline].totalm * 1000);
                            }
                            else if (mres[i].score1 + mres[i].score2 == thisline[betline].total) // 2 vs 2
                            {
                                dataGridView1.Rows[currentRow].Cells[7].Value = "P";
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Yellow;
                                dataGridView1.Rows[currentRow].Cells[8].Value = 1000;
                                winbet = winbet + 1000;
                            }
                            else
                                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.OrangeRed;
                            currentRow++;
                            break;
                    }
                }
            }
            labelbets.Visible = true;
            labelwins.Visible = true;
            labelroipers.Visible = true;
            labelroi.Visible = true;
            labelbets.Text = "поставлено " + sumbet.ToString();
            for (int i = dataGridView1.Rows.Count-1; i >= 0; i--)
            {
                DataGridViewRow dr = dataGridView1.Rows[i];
                if (i >= currentRow)
                    dataGridView1.Rows.Remove(dr);
            }
            labelwins.Text = "выйграно " + winbet.ToString();
            double roi = (Convert.ToDouble(winbet) - Convert.ToDouble(sumbet)) / Convert.ToDouble(sumbet);
            labelroipers.Text = roi.ToString("0.000");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll.CheckState.Equals(CheckState.Checked))
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemChecked(i, true);
            }
        }
    }

}
