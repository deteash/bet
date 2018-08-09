using log4net;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace bets
{
    public partial class Form1 : Form
    {
        private List<result> results;
        List<double> roiList;
        Random rand;
        private int sumbet = 0;
        private int winbet = 0;
        Microsoft.Office.Interop.Excel.Application ObjExcel;
        Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
        List<TestParametrs> testParametrs;
        TestParametrs currentTestParametrs;
        
        public static readonly ILog log = LogManager.GetLogger(typeof(Program));


        public Form1()
        {
            InitializeComponent();
            checkedListBox1.SetItemChecked(0, true);
            checkedListBox1.SetItemChecked(1, true);
            checkedListBox1.SetItemChecked(2, true);
            infoWindow.Visible = false;
            tabControlDanilo.Visible = false;
            log4net.Config.XmlConfigurator.Configure();
            testParametrs = new List<TestParametrs>();
            currentTestParametrs = new TestParametrs();
            roiList = new List<double>();
            rand = new Random();
            this.ShowInTaskbar = true;
            log.Info("Form INIT");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectXls();
        }

        private void SelectXls()
        {
            log.Info("Reading xls");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                ObjWorkBook = ObjExcel.Workbooks.Open(openFileDialog1.FileName, 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
            }
        }

        public void ReadXml()
        { 
            if (ObjWorkSheet == null)
            {
                MessageBox.Show("Файл не выбран!");
                return;
            }
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            int read = (int)numericReadLines.Value;
            results = new List<result>();
            int linesCount = 0;
            bool skipLines = false;
            progressBar1.Visible = true;
            progressBar1.Maximum = read;
            string pattern1 = "yyyy-MM-dd HH:mm";
            string pattern2 = "dd.MM.yyyy HH:mm";
            string pattern3 = "dd.MM.yyyy H:mm";
            result res = new result();
            for (int i = 1; i < read + 1; i++)
            {
                line ln = new line();
                bool writeLn = false;
                progressBar1.Value = i;
                for (int j = 1; j < 14; j++)
                {
                    string x = ObjWorkSheet.Cells[i, j].Text;
                    if (x != "-")
                    {
                        if (j == 1 && x.Contains(':'))//read data and score
                        {
                            DateTime data = new DateTime();
                            if (DateTime.TryParseExact(ParseDate.CutScore(x), pattern1, System.Globalization.CultureInfo.InvariantCulture,
                                                System.Globalization.DateTimeStyles.None, out data))
                            {
                                res = new result
                                {
                                    data = data,
                                    score1 = ParseDate.ParseScore1(x),
                                    score2 = ParseDate.ParseScore2(x)
                                };
                                if (skipLines) 
                                    skipLines = false;
                            }
                            else
                            {
                                skipLines = true;
                                log.Warn("Bad result detected on line " + i);
                            }
                        }
                        else if (j == 2 && x != string.Empty && x != "Команда 1")
                        {
                            if (!x.Contains("Corners"))
                            {
                                ln.team1 = x;
                                if (res.team1 == null)
                                    res.team1 = x;
                            }
                            else
                            {
                                i = SkipCorners(ObjWorkSheet, i);
                                j = 13;
                            }
                        }
                        else if (j == 2 && x == string.Empty)
                            {
                            i = SkipEmptyLines(ObjWorkSheet, i);
                            j = 13;
                        }
                        else if (j == 3 && x != string.Empty && x != "Команда 2" && !x.Contains("Corners"))
                        {
                            ln.team2 = x;
                            if (res.team2 == null)
                            {
                                res.team2 = x;
                                results.Add(res);
                                label5.Text = results.Count() + " событий";
                            }
                        }
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

                        else if (j == 13 && x.Contains(':') && !skipLines)//read scan
                        {
                            if (!DateTime.TryParseExact(x, pattern2, System.Globalization.CultureInfo.InvariantCulture,
                                                System.Globalization.DateTimeStyles.None, out ln.data))
                                DateTime.TryParseExact(x, pattern3, System.Globalization.CultureInfo.InvariantCulture,
                                                    System.Globalization.DateTimeStyles.None, out ln.data);
                            ln.margin = ((1 / ln.win1 + 1 / ln.win2 + 1 / ln.x) - 1) * 100;
                            writeLn = true;
                        }
                    }
                }
                if (writeLn)
                {
                    ln.hourDiff = (res.data - ln.data).Hours + (res.data - ln.data).Days * 24;
                    res.lines.Add(ln);
                    linesCount++;
                    label6.Text = linesCount + " линий";
                }
            }
            progressBar1.Visible = false;
            label8.Visible = true;
            stopwatch.Stop();
            ObjWorkSheet = null;
            ObjWorkBook.Close();
            ObjExcel.Quit();
            label3.Visible = true;
            label3.Text = (stopwatch.ElapsedMilliseconds / 1000).ToString() + " seconds";
        }

        private int SkipEmptyLines(Worksheet objWorkSheet, int i)
        {
            string x = ObjWorkSheet.Cells[i, 2].Text;
            while (x.Equals(string.Empty))
            {
                i++;
                x = ObjWorkSheet.Cells[i, 2].Text;
                if (i > (int)numericReadLines.Value)
                    return (int)numericReadLines.Value;
            }
            return i;
        }

        private void button2_Click(object sender, EventArgs e)//button bet
        {
            PlaceBets(false);
        }

        private void PlaceBets(bool autoMode)
        {
            if (!autoMode)
            {
                testParametrs.Clear();
                SaveTestParametrs();
            }
            int nbets = currentTestParametrs.bets;
            int guys = currentTestParametrs.btimes;

            log.Info("##################### NEW BETS ###########################");
            log.Info("BET pressed " + nbets + " bets " + guys + " times");
            List<double> rakeList = new List<double>();
            List<int> allowedBetsList = ReadAllowedBets();
            log.Info("allowed bet are: " + string.Join(", ", allowedBetsList.ToArray()));
            int hoursTo = currentTestParametrs.hoursTo;
            int hoursFrom = currentTestParametrs.hoursFrom;
            dataGridView1.Rows.Clear();
            roiList.Clear();
            int currentGuy = 0;
            sumbet = 0;
            winbet = 0;
            labelroi.Visible = false;
            labelrakeavg.Visible = false;
            labelroipers.Visible = false;
            labelrake.Visible = false;

            while (currentGuy < guys)
            {
                log.Info("guy # " + currentGuy + " starts bets");
                int guyWinBet = 0;
                int guySumBet = 0;
                dataGridView1.RowCount = nbets;
                if (results == null || nbets > results.Count())
                {
                    MessageBox.Show("Не найдено столько событий!");
                    log.Warn("bets>events");
                    return;
                }
                List<int> betEventIndexes = new List<int>();
                while (betEventIndexes.Count() < nbets)
                {
                    int rnd = rand.Next(0, results.Count());
                    if (!betEventIndexes.Contains(rnd))
                    {
                        betEventIndexes.Add(rnd);
                    }
                }
                log.Info("guy # " + currentGuy + " selects events: " + string.Join(", ", betEventIndexes.ToArray()));
                int currentRow = 0;
                for (int i = 0; i < betEventIndexes.Count(); i++)
                {
                    log.Info("handling selected resulr # " + i);
                    List<int> suitableLineIndexes = new List<int>();
                    foreach (line ln in results[i].lines)
                    {
                        if (ln.hourDiff >= hoursFrom && ln.hourDiff <= hoursTo)
                        {
                            suitableLineIndexes.Add(results[i].lines.IndexOf(ln));
                        }
                    }
                    
                    if (suitableLineIndexes.Count() == 0)
                    {
                        log.Warn("GUY # " + currentGuy + " CAN'T FIND A LINE FOR EVENT # " + i + " (" + results[i].team1 + " vs " + results[i].team2 + ")");
                    }
                    else
                    {
                        int betline;
                        if (currentTestParametrs.freshLine)
                        {
                            betline = 0;
                        }
                        else
                        {
                            betline = rand.Next(suitableLineIndexes.Count());
                        }
                        int bet = 404;
                        while (!allowedBetsList.Contains(bet))
                        {
                            bet = rand.Next(7);
                        }
                        if (currentTestParametrs.daniloStyle) // Danilich style
                        {
                           double coeffMore = currentTestParametrs.daniloCoeff;
                            if (bet < 3)
                            {
                                if (results[i].lines[betline].win2 > results[i].lines[betline].win1 && results[i].lines[betline].win2 > coeffMore)
                                    bet = 2;
                                else if (results[i].lines[betline].win1 > results[i].lines[betline].win2 && results[i].lines[betline].win1 > coeffMore)
                                    bet = 0;
                                else
                                {
                                    bet = 404;
                                    log.Warn("DANILICH SKIP coz win1=" + results[i].lines[betline].win1 + " win2=" + results[i].lines[betline].win2 + " team1= " + results[i].lines[betline].team1 + " team2= " + results[i].lines[betline].team2);
                                }
                            }
                            else if (bet == 3 || bet == 4)
                            {
                                if (results[i].lines[betline].fora1k > results[i].lines[betline].fora2k && results[i].lines[betline].fora1k > coeffMore)
                                    bet = 3;
                                else if (results[i].lines[betline].fora2k > results[i].lines[betline].fora1k && results[i].lines[betline].fora2k > coeffMore)
                                    bet = 4;
                                else
                                {
                                    bet = 404;
                                    log.Warn("DANILICH SKIP coz fora1k=" + results[i].lines[betline].fora1k + " fora2k=" + results[i].lines[betline].fora2k);
                                }
                            }
                            else if (bet == 5 || bet == 6)
                            {
                                if (results[i].lines[betline].totalb > results[i].lines[betline].totalm && results[i].lines[betline].totalb > coeffMore)
                                    bet = 5;
                                else if (results[i].lines[betline].totalm > results[i].lines[betline].totalb && results[i].lines[betline].totalm > coeffMore)
                                    bet = 6;
                                else
                                {
                                    bet = 404;
                                    log.Warn("DANILICH SKIP coz totalb=" + results[i].lines[betline].totalb + " totalm=" + results[i].lines[betline].totalb);
                                }

                            }
                            else
                                bet = 404;
                        }
                        if (currentTestParametrs.Naverochku)//Naverochku no fully implemented
                        {
                            if (bet == 0 && results[i].lines[betline].win2 < results[i].lines[betline].win1)
                                bet = 2;
                            else if (bet == 2 && results[i].lines[betline].win1 <= results[i].lines[betline].win2)
                                bet = 0;
                        }
                        if (bet != 404)
                        {
                            dataGridView1.Rows[currentRow].Cells[0].Value = results[i].lines[betline].team1;
                            dataGridView1.Rows[currentRow].Cells[1].Value = results[i].lines[betline].team2;
                            dataGridView1.Rows[currentRow].Cells[2].Value = results[i].score1;
                            dataGridView1.Rows[currentRow].Cells[3].Value = results[i].score2;
                            log.Info("guy # " + currentGuy + " wants to bet on " + bet + " in line # " + betline);
                            guySumBet = guySumBet + 1000;
                        }
                        switch (bet) // handle bet
                        {
                            case 0:
                                if (results[i].lines[betline].win1 == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (currentTestParametrs.moreBets)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                if (results[i].score1 > results[i].score2)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(results[i].lines[betline].win1 * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].win1 * 1000));
                                }
                                else
                                {
                                    markAsLoose(currentRow);
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "П1";
                                dataGridView1.Rows[currentRow].Cells[6].Value = results[i].lines[betline].win1;
                                rakeList.Add(results[i].lines[betline].margin);
                                currentRow++;
                                break;
                            case 1:
                                if (results[i].lines[betline].x == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (currentTestParametrs.moreBets)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                if (results[i].score1 == results[i].score2)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(results[i].lines[betline].x * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].x * 1000));
                                }
                                else
                                {
                                    markAsLoose(currentRow);
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "X";
                                dataGridView1.Rows[currentRow].Cells[6].Value = results[i].lines[betline].x;
                                rakeList.Add(results[i].lines[betline].margin);
                                currentRow++;
                                break;
                            case 2:
                                if (results[i].lines[betline].win2 == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (currentTestParametrs.moreBets)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }

                                if (results[i].score2 > results[i].score1 && results[i].lines[betline].win2 != 0)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(results[i].lines[betline].win2 * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].win2 * 1000));
                                }
                                else
                                {
                                    markAsLoose(currentRow);
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "П2";
                                dataGridView1.Rows[currentRow].Cells[6].Value = results[i].lines[betline].win2;
                                rakeList.Add(results[i].lines[betline].margin);
                                currentRow++;
                                break;
                            case 3:
                                if (results[i].lines[betline].fora1k == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (currentTestParametrs.moreBets)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "Фора1";
                                dataGridView1.Rows[currentRow].Cells[6].Value = results[i].lines[betline].fora1k;
                                dataGridView1.Rows[currentRow].Cells[5].Value = results[i].lines[betline].fora1;
                                if (results[i].lines[betline].fora1.ToString().Contains("25") || results[i].lines[betline].fora1.ToString().Contains("75"))
                                {
                                    int foraWins = 0;
                                    int foraReturn = 0;
                                    double tWin = 0;
                                    if (results[i].score1 - results[i].score2 + results[i].lines[betline].fora1 + 0.25 > 0) // 1:2 vs 0.75 - win
                                    {
                                        foraWins++;
                                        guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].fora1k * 1000 / 2));
                                        tWin += Convert.ToInt32(results[i].lines[betline].fora1k * 1000 / 2);
                                    }
                                    if (results[i].score1 - results[i].score2 + results[i].lines[betline].fora1 - 0.25 > 0) // 1:2 vs 0.75 - win
                                    {
                                        foraWins++;
                                        guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].fora1k * 1000 / 2));
                                        tWin += Convert.ToInt32(results[i].lines[betline].fora1k * 1000 / 2);
                                    }
                                    if (results[i].score1 - results[i].score2 + results[i].lines[betline].fora1 + 0.25 == 0) // 1:2 vs 0.75 - win
                                    {
                                        foraReturn++;
                                        guyWinBet += 1000 / 2;
                                        tWin += 1000 / 2;
                                    }
                                    if (results[i].score1 - results[i].score2 + results[i].lines[betline].fora1 - 0.25 == 0) // 1:2 vs 0.75 - win
                                    {
                                        foraReturn++;
                                        guyWinBet += 1000 / 2;
                                        tWin += 1000 / 2;
                                    }
                                    fora2575(currentRow, foraWins, foraReturn);
                                    dataGridView1.Rows[currentRow].Cells[8].Value = tWin;
                                }
                                else if (results[i].score1 - results[i].score2 + results[i].lines[betline].fora1 > 0)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(results[i].lines[betline].fora1k * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].fora1k * 1000));
                                }
                                else if (results[i].score1 - results[i].score2 + results[i].lines[betline].fora1 == 0)
                                {
                                    markAsReturn(currentRow);
                                    guyWinBet = (guyWinBet + 1000);
                                }
                                else
                                    markAsLoose(currentRow);
                                currentRow++;
                                break;
                            case 4:
                                if (results[i].lines[betline].fora2k == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (currentTestParametrs.moreBets)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "Фора2";
                                dataGridView1.Rows[currentRow].Cells[6].Value = results[i].lines[betline].fora2k;
                                dataGridView1.Rows[currentRow].Cells[5].Value = results[i].lines[betline].fora1;

                                if (results[i].lines[betline].fora1.ToString().Contains("25") || results[i].lines[betline].fora1.ToString().Contains("75"))
                                {
                                    int foraWins = 0;
                                    int foraReturn = 0;
                                    double tWin = 0;
                                    if (results[i].score2 - results[i].score1 + results[i].lines[betline].fora1 + 0.25 > 0) // 1:2 vs 0.75 - win
                                    {
                                        foraWins++;
                                        guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].fora2k * 1000 / 2));
                                        tWin += Convert.ToInt32(results[i].lines[betline].fora2k * 1000 / 2);
                                    }
                                    if (results[i].score2 - results[i].score1 + results[i].lines[betline].fora1 - 0.25 > 0) // 1:2 vs 0.75 - win
                                    {
                                        foraWins++;
                                        guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].fora2k * 1000 / 2));
                                        tWin += Convert.ToInt32(results[i].lines[betline].fora2k * 1000 / 2);
                                    }
                                    if (results[i].score2 - results[i].score1 + results[i].lines[betline].fora1 + 0.25 == 0) // 1:2 vs 0.75 - win
                                    {
                                        foraReturn++;
                                        guyWinBet += 1000 / 2;
                                        tWin += 1000 / 2;
                                    }
                                    if (results[i].score2 - results[i].score1 + results[i].lines[betline].fora1 - 0.25 == 0) // 1:2 vs 0.75 - win
                                    {
                                        foraReturn++;
                                        guyWinBet += 1000 / 2;
                                        tWin += 1000 / 2;
                                    }
                                    fora2575(currentRow, foraWins, foraReturn);
                                    dataGridView1.Rows[currentRow].Cells[8].Value = tWin;
                                }

                                else if (results[i].score2 - results[i].score1 + results[i].lines[betline].fora1 > 0)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(results[i].lines[betline].fora2k * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].fora2k * 1000));
                                }
                                else if (results[i].score2 - results[i].score1 + results[i].lines[betline].fora1 == 0)
                                {
                                    markAsReturn(currentRow);
                                    guyWinBet = (guyWinBet + 1000);
                                }
                                else
                                    markAsLoose(currentRow);
                                currentRow++;
                                break;
                            case 5: // ТБ
                                if (results[i].lines[betline].totalb == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (currentTestParametrs.moreBets)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                if (results[i].lines[betline].total.ToString().Contains("25") || results[i].lines[betline].total.ToString().Contains("75"))
                                {
                                    if (results[i].score1 + results[i].score2 > results[i].lines[betline].total + 0.25) // 3 vs 2.25 - win
                                    {
                                        markAsWin(currentRow, Convert.ToInt32(results[i].lines[betline].totalb * 1000));
                                        guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].totalb * 1000));
                                    }
                                    else if (results[i].score1 + results[i].score2 == results[i].lines[betline].total - 0.25) // 2 vs 2.25 - расход 1/2 + проеб
                                    {
                                        dataGridView1.Rows[currentRow].Cells[7].Value = "1/2";
                                        dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Orange;
                                        guyWinBet = (guyWinBet + 1000 / 2);
                                        dataGridView1.Rows[currentRow].Cells[8].Value = 500;
                                    }
                                    else if (results[i].score1 + results[i].score2 == results[i].lines[betline].total + 0.25) // 3 vs 2.75 - расход 1/2 + win 1/2 
                                    {
                                        dataGridView1.Rows[currentRow].Cells[7].Value = "3/4";
                                        dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LightYellow;
                                        guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].totalb * 1000 / 2) + 1000 / 2);
                                        dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(results[i].lines[betline].totalb * 1000 / 2) + 1000 / 2;
                                    }
                                    else
                                        markAsLoose(currentRow);
                                }
                                else if (results[i].score1 + results[i].score2 > results[i].lines[betline].total)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(results[i].lines[betline].totalb * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].totalb * 1000));
                                }
                                else if (results[i].score1 + results[i].score2 == results[i].lines[betline].total)
                                {
                                    markAsReturn(currentRow);
                                    guyWinBet = guyWinBet + 1000;
                                }
                                else
                                {
                                    markAsLoose(currentRow);
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "ТБ";
                                dataGridView1.Rows[currentRow].Cells[6].Value = results[i].lines[betline].totalb;
                                dataGridView1.Rows[currentRow].Cells[5].Value = results[i].lines[betline].total;
                                currentRow++;
                                break;
                            case 6:
                                dataGridView1.Rows[currentRow].Cells[4].Value = "ТМ";
                                dataGridView1.Rows[currentRow].Cells[6].Value = results[i].lines[betline].totalm;
                                dataGridView1.Rows[currentRow].Cells[5].Value = results[i].lines[betline].total;
                                if (results[i].lines[betline].totalm == 0)
                                {

                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (currentTestParametrs.moreBets)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                if (results[i].lines[betline].total.ToString().Contains("25") || results[i].lines[betline].total.ToString().Contains("75"))
                                {
                                    if (results[i].score1 + results[i].score2 < results[i].lines[betline].total - 0.25) // 2 vs 2.75 win
                                    {
                                        markAsWin(currentRow, Convert.ToInt32(results[i].lines[betline].totalm * 1000));
                                        guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].totalm * 1000));
                                    }
                                    else if (results[i].score1 + results[i].score2 == results[i].lines[betline].total + 0.25) // 3 vs 2.75 - расход 1/2 + проеб
                                    {
                                        dataGridView1.Rows[currentRow].Cells[7].Value = "1/2";
                                        dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Orange;
                                        guyWinBet = (guyWinBet + 1000 / 2);
                                        dataGridView1.Rows[currentRow].Cells[8].Value = 500;
                                    }
                                    else if (results[i].score1 + results[i].score2 == results[i].lines[betline].total - 0.25) // 2 vs 2.25 - расход 1/2 + win 1/2 
                                    {
                                        dataGridView1.Rows[currentRow].Cells[7].Value = "3/4";
                                        dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LightYellow;
                                        guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].totalm * 1000 / 2) + 1000 / 2);
                                        dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(results[i].lines[betline].totalm * 1000 / 2) + 1000 / 2;
                                    }
                                    else
                                        markAsLoose(currentRow);
                                }
                                else if (results[i].score1 + results[i].score2 < results[i].lines[betline].total)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(results[i].lines[betline].totalm * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(results[i].lines[betline].totalm * 1000));
                                }
                                else if (results[i].score1 + results[i].score2 == results[i].lines[betline].total) // 2 vs 2
                                {
                                    markAsReturn(currentRow);
                                    guyWinBet = guyWinBet + 1000;
                                }
                                else
                                    markAsLoose(currentRow);
                                currentRow++;
                                break;
                                /*case 404:
                                    log.Warn("SKIPED coz tried to bet 404-bet");
                                    break;*/
                        }
                    }
                }
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow dr = dataGridView1.Rows[i];
                    if (i >= currentRow)
                    {
                        dataGridView1.Rows.Remove(dr);
                    }
                }

                log.Info("guy # " + currentGuy + " placed " + guySumBet + ", wins " + guyWinBet + " and finished with roi = " + RoiResults(guyWinBet, guySumBet));
                roiList.Add(RoiResults(guyWinBet, guySumBet));
                sumbet += guySumBet;
                winbet += guyWinBet;
                currentGuy++;
            }
            if (infoWindow.Visible)//refresh info window
                ShowInfo();
            labelroipers.Text = roiList.Average().ToString("0.0");
            log.Info("beting finished with roi = " + roiList.Average().ToString("0.0"));
            rakeList.Clear();
            allowedBetsList.Clear();
            if (rakeList.Count != 0)
                labelrakeavg.Text = rakeList.Average().ToString("0.000");
            if(autoMode)
            {
                File.AppendAllText(@"file.txt", "avgRoi = " + roiList.Average().ToString("0.0"));
            }
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


        private void radioButtonDanilich_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(0, true);

        }

        private void radioButtonNaverochku_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(0, true);
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            if (!infoWindow.Visible && sumbet > 0)
            {
                infoWindow.Visible = true;
                ShowInfo();
            }
            else
                infoWindow.Visible = false;
        }

        private void ShowInfo()
        {
            labelBets.Text = "поставлено " + sumbet.ToString();
            labelwins.Text = "получено     " + winbet.ToString();
            labelPlusovie.Text = "плюсовых " + roiList.Count(x => x > 0).ToString();
            if (roiList.Count > 0)
            {
                labelBestRoi.Text = "лучший roi " + roiList.Max().ToString("0.0");
                labelWorstRoi.Text = "худший roi " + roiList.Min().ToString("0.0");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)//open danilo settings
        {
            if (!tabControlDanilo.Visible)
                tabControlDanilo.Visible = true;
            else
                tabControlDanilo.Visible = false;
        }

        private List<int> ReadAllowedBets()
        {
            List<int> allowed = new List<int>();
            if (currentTestParametrs.p1p2x)
            {
                allowed.Add(0);
                allowed.Add(2);
            }
            if (currentTestParametrs.fora)
            {
                allowed.Add(3);
                allowed.Add(4);
            }
            if (currentTestParametrs.total)
            {
                allowed.Add(5);
                allowed.Add(6);
            }
            if (!currentTestParametrs.noDraw)
            {
                allowed.Add(1);
            }
            return allowed;
        }

        private void markAsWin(int row, int winnings)
        {
            dataGridView1.Rows[row].Cells[7].Value = 1;
            dataGridView1.Rows[row].Cells[7].Style.BackColor = Color.LimeGreen;
            dataGridView1.Rows[row].Cells[8].Value = winnings;
        }
        private void markAsReturn(int row)
        {
            dataGridView1.Rows[row].Cells[7].Value = "P";
            dataGridView1.Rows[row].Cells[7].Style.BackColor = Color.Yellow;
            dataGridView1.Rows[row].Cells[8].Value = 1000;
        }
        private void markAsLoose(int row)
        {
            dataGridView1.Rows[row].Cells[7].Style.BackColor = Color.OrangeRed;
            dataGridView1.Rows[row].Cells[7].Value = 0;
        }
        private void fora2575(int currentRow, int foraWins, int foraReturn)
        {
            if (foraWins == 0 && foraReturn == 0)
            {
                dataGridView1.Rows[currentRow].Cells[7].Value = 0;
                markAsLoose(currentRow);
            }
            if (foraWins == 1 && foraReturn == 1)
            {

                dataGridView1.Rows[currentRow].Cells[7].Value = "3/4";
                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LightYellow;
            }
            if (foraWins == 2)
            {

                dataGridView1.Rows[currentRow].Cells[7].Value = 1;
                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LimeGreen;
            }
            if (foraWins == 0 && foraReturn == 1)
            {
                dataGridView1.Rows[currentRow].Cells[7].Value = "1/2";
                dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Orange;
            }
        }
         private double RoiResults(int winbet, int sumbet)
        {
            double roi = (Convert.ToDouble(winbet) - Convert.ToDouble(sumbet)) / Convert.ToDouble(sumbet) * 100;
            labelroipers.Visible = true;
            labelroi.Visible = true;
            labelrake.Visible = true;
            labelrakeavg.Visible = true;
            labelroipers.Text = roi.ToString("0.000");
            return roi;
        }
        private int SkipCorners(Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet, int i)
        {
            string x = ObjWorkSheet.Cells[i, 2].Text;
            while (x.Contains("Corners") || x == string.Empty)
            {
                i++;
                x = ObjWorkSheet.Cells[i, 2].Text;
                if (i > (int)numericReadLines.Value)
                    return (int)numericReadLines.Value;
            }
            return i;
        }

        private void button3_Click(object sender, EventArgs e)// button read
        {
            ReadXml();
        }

        private void button4_Click(object sender, EventArgs e)// button full autotest
        {
            SelectXls();
            ReadXml();
            log.Info("###############################starting autotest###################################################");
            if (testParametrs.Count == 0)
                SaveTestParametrs();
            foreach (TestParametrs param in testParametrs)
            {
                currentTestParametrs = param;
                File.AppendAllText(@"file.txt", JsonConvert.SerializeObject(currentTestParametrs) + Environment.NewLine);
                PlaceBets(true);
                log.Info("###############################changing parametrs, continue autotest###################################################");
            }
        }

        private void button5_Click(object sender, EventArgs e)//button save marks
        {
            SaveTestParametrs();
        }

        private void SaveTestParametrs()
        {
            TestParametrs tmp = new TestParametrs
            {
                bets = (int)numericBets.Value,
                btimes = (int)numericBetTimes.Value,
                daniloCoeff = double.Parse(textBoxCoeffMore.Text, System.Globalization.CultureInfo.InvariantCulture),
                p1p2x = checkedListBox1.GetItemChecked(0),
                fora = checkedListBox1.GetItemChecked(1),
                total = checkedListBox1.GetItemChecked(2),
                moreBets = checkBoxAll.Checked,
                noDraw = checkBoxNoDraw.Checked,
                freshLine = checkBoxFreshLine.Checked,
                daniloStyle = radioButtonDanilich.Checked,
                Naverochku = radioButtonNaverochku.Checked,
                ordinaryBets = radioButtonOrdinary.Checked,
                hoursFrom = (int)numericHoursFrom.Value,
                hoursTo = (int)numericHoursTo.Value
            };
            currentTestParametrs = tmp;
            for (int i=0; i < Convert.ToInt32(textBoxMarksnumb.Text); i++)
            testParametrs.Add(tmp);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (testParametrs.Count == 0)
                SaveTestParametrs();
            foreach (TestParametrs param in testParametrs)
            {
                currentTestParametrs = param;
                File.AppendAllText(@"file.txt", JsonConvert.SerializeObject(currentTestParametrs) + Environment.NewLine);
                PlaceBets(true);
                log.Info("###############################changing parametrs, continue autotest###################################################");
            }
        }

        private void buttonclearMarks_Click(object sender, EventArgs e)
        {
            testParametrs.Clear();
        }
    }
}




