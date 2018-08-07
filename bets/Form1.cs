using log4net;
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
        private List<line> lines;
        private List<result> results;
        private int sumbet = 0;
        private int winbet = 0;
        List<double> roiList = new List<double>();
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
            log.Info("Form INIT");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.Info("Reading xls");
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
                this.ShowInTaskbar = true;
                string pattern1 = "yyyy-MM-dd HH:mm";
                string pattern2 = "dd.MM.yyyy HH:mm";
                string pattern3 = "dd.MM.yyyy H:mm";
                for (int i = 1; i < read + 1; i++)
                {
                    line ln = new line();
                    result res = new result();
                    bool write = false;
                    bool newRes = false;
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
                                newRes = true;
                            }
                            else if (j == 2 && x != string.Empty && x != "Команда 1")
                            {
                                ln.team1 = x;
                                if (newRes)
                                    res.team1 = x;
                            }
                            else if (j == 3 && x != string.Empty && x != "Команда 2")
                            {
                                ln.team2 = x;
                                if (newRes)
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

                            else if (j == 13 && x.Contains(':'))//read scan
                            {
                                if (!DateTime.TryParseExact(x, pattern2, System.Globalization.CultureInfo.InvariantCulture,
                                                    System.Globalization.DateTimeStyles.None, out ln.data))
                                    DateTime.TryParseExact(x, pattern3, System.Globalization.CultureInfo.InvariantCulture,
                                                        System.Globalization.DateTimeStyles.None, out ln.data);
                                ln.rake = ((1 / ln.win1 + 1 / ln.win2 + 1 / ln.x) - 1) * 100;
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
            int guys = Convert.ToInt32(numericBetTimes.Value);
            log.Info("##################### NEW BETS ###########################");
            log.Info("BET pressed " + nbets + " bets " + guys + " times");
            List<double> rakeList = new List<double>();
            List<int> allowedBetsList = ReadAllowedBets();
            log.Info("allowed bet are: " + string.Join(", ", allowedBetsList.ToArray()));
            int hoursTo = (int)numericHoursTo.Value;
            int hoursFrom = (int)numericHoursFrom.Value;
            roiList.Clear();
            int currentGuy = 0;
            sumbet = 0;
            winbet = 0;
            labelroi.Visible = false;
            labelrakeavg.Visible = false;
            labelroipers.Visible = false;
            labelrake.Visible = false;
            Random rand = new Random();

            while (currentGuy < guys)
            {
                log.Info("guy # " + currentGuy + " starts bets");
                int guyWinBet = 0;
                int guySumBet = 0;
                if (results == null || nbets > results.Count())
                {
                    MessageBox.Show("Не найдено столько событий!");
                    log.Warn("bets>events");
                    return;
                }
                List<result> selectedResults = new List<result>();
                List<int> betEventIndexes = new List<int>();
                dataGridView1.RowCount = nbets;
                while (selectedResults.Count() < nbets)
                {
                    int rnd = rand.Next(0, results.Count());
                    if (!betEventIndexes.Contains(rnd))
                    {
                        betEventIndexes.Add(rnd);
                        selectedResults.Add(results.ElementAt(rnd));
                    }
                }
                log.Info("guy # " + currentGuy + " selects events: " + string.Join(", ", betEventIndexes.ToArray()));
                int currentRow = 0;
                for (int i = 0; i < selectedResults.Count(); i++)
                {
                    log.Info("handling selected resulr # " + i);
                    List<line> suitableLines = new List<line>();
                    foreach (line ln in lines)
                    {
                        int hrs = (selectedResults[i].data - ln.data).Hours + (selectedResults[i].data - ln.data).Days * 24;
                        if (selectedResults[i].team1 == ln.team1 && selectedResults[i].team2 == ln.team2 && hrs > hoursFrom && hrs < hoursTo)
                        {
                            suitableLines.Add(ln);
                        }
                    }

                    if (suitableLines.Count() == 0)
                    {
                        log.Warn("GUY # " + currentGuy + " CAN'T FIND A LINE FOR EVENT # " + i + " (" + selectedResults[i].team1 + " vs " + selectedResults[i].team2 + ")");
                    }
                    else
                    {
                        int betline;
                        if (checkBoxFreshLine.Checked)
                        {
                            betline = 0;
                        }
                        else
                        {
                            betline = rand.Next(suitableLines.Count());
                        }
                        dataGridView1.Rows[currentRow].Cells[0].Value = suitableLines[betline].team1;
                        dataGridView1.Rows[currentRow].Cells[1].Value = suitableLines[betline].team2;
                        dataGridView1.Rows[currentRow].Cells[2].Value = selectedResults[i].score1;
                        dataGridView1.Rows[currentRow].Cells[3].Value = selectedResults[i].score2;
                        guySumBet = guySumBet + 1000;
                        int bet = 404;
                        while (!allowedBetsList.Contains(bet))
                        {
                            bet = rand.Next(7);
                        }
                        if (radioButtonDanilich.Checked) // Danilich style
                        {
                            double coeffMore = Convert.ToDouble(numericBetCoeffMore.Value);
                            if (bet < 3)
                            {
                                if (suitableLines[betline].win2 > suitableLines[betline].win1 && suitableLines[betline].win2 > coeffMore)
                                    bet = 2;
                                else if (suitableLines[betline].win1 > suitableLines[betline].win2 && suitableLines[betline].win1 > coeffMore)
                                    bet = 0;
                            }
                            else if (bet == 3 || bet == 4)
                            {
                                if (suitableLines[betline].fora1k > suitableLines[betline].fora2k && suitableLines[betline].fora1k > coeffMore)
                                    bet = 3;
                                else if (suitableLines[betline].fora2k > suitableLines[betline].fora1k && suitableLines[betline].fora2k > coeffMore)
                                    bet = 4;
                            }
                            else if (bet == 5 || bet == 6)
                            {
                                if (suitableLines[betline].totalb > suitableLines[betline].totalm && suitableLines[betline].totalb > coeffMore)
                                    bet = 5;
                                else if (suitableLines[betline].totalm > suitableLines[betline].totalb && suitableLines[betline].totalm > coeffMore)
                                    bet = 6;
                            }
                            else
                                bet = 404;
                        }
                        if (radioButtonNaverochku.Checked)//Naverochku no fully implemented
                        {
                            if (bet == 0 && suitableLines[betline].win2 < suitableLines[betline].win1)
                                bet = 2;
                            else if (bet == 2 && suitableLines[betline].win1 < suitableLines[betline].win2)
                                bet = 0;
                        }
                        log.Info("guy # " + currentGuy + " wants to bet on " + bet + " in line # " + betline);

                        switch (bet) // handle bet
                        {
                            case 0:
                                if (suitableLines[betline].win1 == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (checkBoxAll.Checked)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                if (selectedResults[i].score1 > selectedResults[i].score2)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(suitableLines[betline].win1 * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].win1 * 1000));
                                }
                                else
                                {
                                    markAsLoose(currentRow);
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "П1";
                                dataGridView1.Rows[currentRow].Cells[6].Value = suitableLines[betline].win1;
                                rakeList.Add(suitableLines[betline].rake);
                                currentRow++;
                                break;
                            case 1:
                                if (suitableLines[betline].x == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (checkBoxAll.Checked)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                if (selectedResults[i].score1 == selectedResults[i].score2)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(suitableLines[betline].x * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].x * 1000));
                                }
                                else
                                {
                                    markAsLoose(currentRow);
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "X";
                                dataGridView1.Rows[currentRow].Cells[6].Value = suitableLines[betline].x;
                                rakeList.Add(suitableLines[betline].rake);
                                currentRow++;
                                break;
                            case 2:
                                if (suitableLines[betline].win2 == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (checkBoxAll.Checked)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }

                                if (selectedResults[i].score2 > selectedResults[i].score1 && suitableLines[betline].win2 != 0)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(suitableLines[betline].win2 * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].win2 * 1000));
                                }
                                else
                                { 
                                    markAsLoose(currentRow);
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "П2";
                                dataGridView1.Rows[currentRow].Cells[6].Value = suitableLines[betline].win2;
                                rakeList.Add(suitableLines[betline].rake);
                                currentRow++;
                                break;
                            case 3:
                                if (suitableLines[betline].fora1k == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (checkBoxAll.Checked)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "Фора1";
                                dataGridView1.Rows[currentRow].Cells[6].Value = suitableLines[betline].fora1k;
                                dataGridView1.Rows[currentRow].Cells[5].Value = suitableLines[betline].fora1;
                                if (suitableLines[betline].fora1.ToString().Contains("25") || suitableLines[betline].fora1.ToString().Contains("75") && checkBox1.Checked)
                                {
                                     int foraWins = 0;
                                     int foraReturn = 0;
                                     double tWin = 0;
                                     if (selectedResults[i].score1 - selectedResults[i].score2 + suitableLines[betline].fora1 + 0.25 > 0) // 1:2 vs 0.75 - win
                                     {
                                         foraWins++;
                                         guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].fora1k * 1000 / 2));
                                         tWin += Convert.ToInt32(suitableLines[betline].fora1k * 1000 / 2);
                                     }
                                     if (selectedResults[i].score1 - selectedResults[i].score2 + suitableLines[betline].fora1 - 0.25 > 0) // 1:2 vs 0.75 - win
                                     {
                                         foraWins++;
                                         guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].fora1k * 1000 / 2));
                                         tWin += Convert.ToInt32(suitableLines[betline].fora1k * 1000 / 2);
                                     }
                                     if (selectedResults[i].score1 - selectedResults[i].score2 + suitableLines[betline].fora1 + 0.25 == 0) // 1:2 vs 0.75 - win
                                     {
                                         foraReturn++;
                                         guyWinBet += 1000 / 2;
                                         tWin += 1000 / 2;
                                     }
                                     if (selectedResults[i].score1 - selectedResults[i].score2 + suitableLines[betline].fora1 - 0.25 == 0) // 1:2 vs 0.75 - win
                                     {
                                         foraReturn++;
                                         guyWinBet += 1000 / 2;
                                         tWin += 1000 / 2;
                                     }
                                     dataGridView1.Rows[currentRow].Cells[8].Value = tWin;
                                }
                                else if (selectedResults[i].score1 - selectedResults[i].score2 + suitableLines[betline].fora1 > 0)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(suitableLines[betline].fora1k * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].fora1k * 1000));
                                }
                                else if (selectedResults[i].score1 - selectedResults[i].score2 + suitableLines[betline].fora1 == 0)
                                {
                                    markAsReturn(currentRow);
                                    guyWinBet = (guyWinBet + 1000);
                                }
                                else
                                    markAsLoose(currentRow);
                                currentRow++;
                                break;
                            case 4:
                                if (suitableLines[betline].fora2k == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (checkBoxAll.Checked)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "Фора2";
                                dataGridView1.Rows[currentRow].Cells[6].Value = suitableLines[betline].fora2k;
                                dataGridView1.Rows[currentRow].Cells[5].Value = suitableLines[betline].fora1;

                                if (suitableLines[betline].fora1.ToString().Contains("25") || suitableLines[betline].fora1.ToString().Contains("75") && checkBox1.Checked)
                                {
                                    int foraWins = 0;
                                    int foraReturn = 0;
                                    double tWin = 0;
                                    if (selectedResults[i].score2 - selectedResults[i].score1 + suitableLines[betline].fora1 + 0.25 > 0) // 1:2 vs 0.75 - win
                                    {
                                        foraWins++;
                                        guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].fora2k * 1000 / 2));
                                        tWin += Convert.ToInt32(suitableLines[betline].fora2k * 1000 / 2);
                                    }
                                    if (selectedResults[i].score2 - selectedResults[i].score1 + suitableLines[betline].fora1 - 0.25 > 0) // 1:2 vs 0.75 - win
                                    {
                                        foraWins++;
                                        guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].fora2k * 1000 / 2));
                                        tWin += Convert.ToInt32(suitableLines[betline].fora2k * 1000 / 2);
                                    }
                                    if (selectedResults[i].score2 - selectedResults[i].score1 + suitableLines[betline].fora1 + 0.25 == 0) // 1:2 vs 0.75 - win
                                    {
                                        foraReturn++;
                                        guyWinBet += 1000 / 2;
                                        tWin += 1000 / 2;
                                    }
                                    if (selectedResults[i].score2 - selectedResults[i].score1 + suitableLines[betline].fora1 - 0.25 == 0) // 1:2 vs 0.75 - win
                                    {
                                        foraReturn++;
                                        guyWinBet += 1000 / 2;
                                        tWin += 1000 / 2;
                                    }
                                    fora2575(currentRow, foraWins, foraReturn);
                                    dataGridView1.Rows[currentRow].Cells[8].Value = tWin;
                                }

                                else if (selectedResults[i].score2 - selectedResults[i].score1 + suitableLines[betline].fora1 > 0)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(suitableLines[betline].fora2k * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].fora2k * 1000));
                                }
                                else if (selectedResults[i].score2 - selectedResults[i].score1 + suitableLines[betline].fora1 == 0)
                                {
                                    markAsReturn(currentRow);
                                    guyWinBet = (guyWinBet + 1000);
                                }
                                else
                                    markAsLoose(currentRow);
                                currentRow++;
                                break;
                            case 5: // ТБ
                                if (suitableLines[betline].totalb == 0)
                                {
                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (checkBoxAll.Checked)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                if (suitableLines[betline].total.ToString().Contains("25") || suitableLines[betline].total.ToString().Contains("75"))
                                {
                                    if (selectedResults[i].score1 + selectedResults[i].score2 > suitableLines[betline].total + 0.25) // 3 vs 2.25 - win
                                    {
                                        markAsWin(currentRow, Convert.ToInt32(suitableLines[betline].totalb * 1000));
                                        guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].totalb * 1000));
                                    }
                                    else if (selectedResults[i].score1 + selectedResults[i].score2 == suitableLines[betline].total - 0.25) // 2 vs 2.25 - расход 1/2 + проеб
                                    {
                                        dataGridView1.Rows[currentRow].Cells[7].Value = "1/2";
                                        dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Orange;
                                        guyWinBet = (guyWinBet + 1000 / 2);
                                        dataGridView1.Rows[currentRow].Cells[8].Value = 500;
                                    }
                                    else if (selectedResults[i].score1 + selectedResults[i].score2 == suitableLines[betline].total + 0.25) // 3 vs 2.75 - расход 1/2 + win 1/2 
                                    {
                                        dataGridView1.Rows[currentRow].Cells[7].Value = "3/4";
                                        dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LightYellow;
                                        guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].totalb * 1000 / 2) + 1000 / 2);
                                        dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(suitableLines[betline].totalb * 1000 / 2) + 1000 / 2;
                                    }
                                    else
                                        markAsLoose(currentRow);
                                }
                                else if (selectedResults[i].score1 + selectedResults[i].score2 > suitableLines[betline].total)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(suitableLines[betline].totalb * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].totalb * 1000));
                                }
                                else if (selectedResults[i].score1 + selectedResults[i].score2 == suitableLines[betline].total)
                                {
                                    markAsReturn(currentRow);
                                    guyWinBet = guyWinBet + 1000;
                                }
                                else
                                {
                                    markAsLoose(currentRow);
                                }
                                dataGridView1.Rows[currentRow].Cells[4].Value = "ТБ";
                                dataGridView1.Rows[currentRow].Cells[6].Value = suitableLines[betline].totalb;
                                dataGridView1.Rows[currentRow].Cells[5].Value = suitableLines[betline].total;
                                currentRow++;
                                break;
                            case 6:
                                dataGridView1.Rows[currentRow].Cells[4].Value = "ТМ";
                                dataGridView1.Rows[currentRow].Cells[6].Value = suitableLines[betline].totalm;
                                dataGridView1.Rows[currentRow].Cells[5].Value = suitableLines[betline].total;
                                if (suitableLines[betline].totalm == 0)
                                {

                                    log.Warn("NO COEFF HERE!");
                                    guySumBet = guySumBet - 1000;
                                    if (checkBoxAll.Checked)
                                    {
                                        log.Info("will try to find any coeffs here");
                                        i--;
                                    }
                                    break;
                                }
                                if (suitableLines[betline].total.ToString().Contains("25") || suitableLines[betline].total.ToString().Contains("75"))
                                {
                                    if (selectedResults[i].score1 + selectedResults[i].score2 < suitableLines[betline].total - 0.25) // 2 vs 2.75 win
                                    {
                                        markAsWin(currentRow, Convert.ToInt32(suitableLines[betline].totalm * 1000));
                                        guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].totalm * 1000));
                                    }
                                    else if (selectedResults[i].score1 + selectedResults[i].score2 == suitableLines[betline].total + 0.25) // 3 vs 2.75 - расход 1/2 + проеб
                                    {
                                        dataGridView1.Rows[currentRow].Cells[7].Value = "1/2";
                                        dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.Orange;
                                        guyWinBet = (guyWinBet + 1000 / 2);
                                        dataGridView1.Rows[currentRow].Cells[8].Value = 500;
                                    }
                                    else if (selectedResults[i].score1 + selectedResults[i].score2 == suitableLines[betline].total - 0.25) // 2 vs 2.25 - расход 1/2 + win 1/2 
                                    {
                                        dataGridView1.Rows[currentRow].Cells[7].Value = "3/4";
                                        dataGridView1.Rows[currentRow].Cells[7].Style.BackColor = Color.LightYellow;
                                        guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].totalm * 1000 / 2) + 1000 / 2);
                                        dataGridView1.Rows[currentRow].Cells[8].Value = Convert.ToInt32(suitableLines[betline].totalm * 1000 / 2) + 1000 / 2;
                                    }
                                    else
                                        markAsLoose(currentRow);
                                }
                                else if (selectedResults[i].score1 + selectedResults[i].score2 < suitableLines[betline].total)
                                {
                                    markAsWin(currentRow, Convert.ToInt32(suitableLines[betline].totalm * 1000));
                                    guyWinBet = (guyWinBet + Convert.ToInt32(suitableLines[betline].totalm * 1000));
                                }
                                else if (selectedResults[i].score1 + selectedResults[i].score2 == suitableLines[betline].total) // 2 vs 2
                                {
                                    markAsReturn(currentRow);
                                    guyWinBet = guyWinBet + 1000;
                                }
                                else
                                    markAsLoose(currentRow);
                                currentRow++;
                                break;
                            case 404:
                                log.Warn("Skiped coz tried to bet 404-bet");
                                break;
                        }
                    }
                }
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow dr = dataGridView1.Rows[i];
                    if (i > currentRow)
                    {
                        dataGridView1.Rows.Remove(dr);
                        log.Info("deleting rows (" + i + ")");
                    }
                }
                
                log.Info("guy # " + currentGuy + " placed " + guySumBet + " ,wins " + guyWinBet +  " and finished with roi = " + RoiResults(guyWinBet, guySumBet));
                roiList.Add(RoiResults(guyWinBet,guySumBet));
                sumbet += guySumBet;
                winbet += guyWinBet;
                currentGuy++;
            }
            if (infoWindow.Visible)//refresh info window
                ShowInfo();
            labelroipers.Text = roiList.Average().ToString("0.0");
            if (rakeList.Count != 0)
                labelrakeavg.Text = rakeList.Average().ToString("0.000");
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!tabControlDanilo.Visible)
                tabControlDanilo.Visible = true;
            else
                tabControlDanilo.Visible = false;
        }

        private List<int> ReadAllowedBets()
        {
            List<int> allowed = new List<int>();
            if (checkedListBox1.GetItemChecked(0))
            {
                allowed.Add(0);
                allowed.Add(2);
            }
            if (checkedListBox1.GetItemChecked(1))
            {
                allowed.Add(3);
                allowed.Add(4);
            }
            if (checkedListBox1.GetItemChecked(2))
            {
                allowed.Add(5);
                allowed.Add(6);
            }
            if (!checkBoxNoDraw.Checked)
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
    }
}




