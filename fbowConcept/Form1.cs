using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fbowConcept
{
    public partial class Form1 : Form
    {
        List<bettingData> resultsData = new List<bettingData>();
        
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Sport:";
            label2.Text = "Home Team:";
            label3.Text = "Away team:";
            label4.Text = "Date:";
            label5.Text = "Money Bet:";
            label6.Text = "Result:";
            label7.Text = "Bet Type:";
            label8.Text = "Odds:";
            label9.Text = "Money Won:";
            resultCmb.Items.Add("Win");
            resultCmb.Items.Add("Lose");
            resultCmb.Items.Add("Draw");
            betTypeCmb.Items.Add("Money Line");
            betTypeCmb.Items.Add("Spread");
            betTypeCmb.Items.Add("Total");
            betTypeCmb.SelectedIndex = 0;
            resultCmb.SelectedIndex = 0;
            sportTxt.Select();
            resultsList.View = View.Details;

            resultsList.FullRowSelect = true;
            resultsList.Columns.Add("Sport", 50);
            resultsList.Columns.Add("Home Team", 75);
            resultsList.Columns.Add("Away Team", 75);
            resultsList.Columns.Add("Date", 100);
            resultsList.Columns.Add("Money Bet", 75);
            resultsList.Columns.Add("Result", 75);
            resultsList.Columns.Add("Bet Type", 75);
            resultsList.Columns.Add("Odds", 50);
            resultsList.Columns.Add("Money Won", 75);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //handles functionality to the add result button
        private void addBetBtn_Click(object sender, EventArgs e)
        {
            getBetData();
            updateResultsGraphics();

            //test to see if items are being added to resultsData correctly and to see if net winnings is right
            addBetDataToListview(resultsData[resultsData.Count - 1]);
           

        }

        private bool addBetDataToListview(bettingData currentBets)
        {
            
            string[] dataStrings = new string[9];
            ListViewItem listedData;
            dataStrings[0] = currentBets.getSportName();
            dataStrings[1] = currentBets.getHomeTeam();
            dataStrings[2] = currentBets.getAwayTeam();
            dataStrings[3] = currentBets.getDateOfBet().ToString("MMMM dd, yyyy");
            dataStrings[4] = currentBets.getMoneyBet().ToString();
            dataStrings[5] = currentBets.getResult();
            dataStrings[6] = currentBets.getBetType();
            dataStrings[7] = currentBets.getBetOdds().ToString();
            dataStrings[8] = currentBets.getMoneyWon().ToString();
            
            listedData = new ListViewItem(dataStrings);
            resultsList.Items.Add(listedData);

            return true;
        }
        //handles the functionality of calculating net winnings of a betting data list given as a parameter
        private double  calculateWinnings(List<bettingData> bets)
        {
            double winnings = 0.0;
            for(int i = 0; i < bets.Count; i++)
            {
                winnings += bets[i].getMoneyWon();
            }
            return winnings;
        }

        //clears the items in the text boxes so new values can be added.
        private void clearTextBoxes()
        {
            sportTxt.Clear();
            homeTeamTxt.Clear();
            awayTeamTxt.Clear();
            moneyBetTxt.Clear();
            oddsTxt.Clear();
            moneyWonTxt.Clear();
        }

        //handles the updating the results graphics
        private void updateResultsGraphics()
        {
            moneyWonLBL.Text = calculateWinnings(resultsData).ToString();
            if (calculateWinnings(resultsData) > 0.0)
            {
                moneyWonLBL.ForeColor = System.Drawing.Color.Green;
            }
            else
                moneyWonLBL.ForeColor = System.Drawing.Color.Red;
        }

        //gets the betting data from the forms filled out by the user and error controls the inputs
        private void getBetData()
        {
             bettingData currentData = new bettingData();
            if (!anyTextBoxesEmpty())
            {
                currentData.setSportName(sportTxt.Text);
                currentData.setHomeTeam(homeTeamTxt.Text);
                currentData.setAwayTeam(awayTeamTxt.Text);
                currentData.setDate(dateTimePicker1.Value);

                currentData.setResult(resultCmb.SelectedItem.ToString());
                currentData.setBetType(betTypeCmb.SelectedItem.ToString());
                float holder1, holder2, holder3;
                if (float.TryParse(oddsTxt.Text, out holder1) &&
                    float.TryParse(moneyWonTxt.Text, out holder2) &&
                    float.TryParse(moneyBetTxt.Text, out holder3))
                {
                    currentData.setBetOdds(holder1);
                    currentData.setMoneyWon(holder2);
                    currentData.setMoneyBet(holder3);
                    clearTextBoxes();
                }
                else
                    MessageBox.Show("Odds/Money Won/Money Bet need to be Numbers", "error", MessageBoxButtons.OK);
                resultsData.Add(currentData);

            }
            else
                MessageBox.Show("Labels can't be empty", "error", MessageBoxButtons.OK);
            
        }


    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
               
        }

        //handles the action performed when the Clear Data button is pressed
        private void button1_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        //returns a boolean whether any of the necessary  text boxes are empty on the form
        private bool anyTextBoxesEmpty()
        {
            if (sportTxt.Text == "" || homeTeamTxt.Text == "" ||
                awayTeamTxt.Text == "" || moneyBetTxt.Text == ""  ||
                oddsTxt.Text == "" || moneyWonTxt.Text == "")
                return true;
            else
                return false;
        }
    }
}
