using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbowConcept
{
    class  bettingData
    {
        public void setSportName(string newSport)
        {
            sportName = newSport;
        }
        public void setHomeTeam(string newHome)
        {
            homeTeamName = newHome;
        }
        public void setAwayTeam(string newAway)
        {
            awayTeamName = newAway;
        }
        public void setDate(DateTime newDate)
        {
            dateOfBet = newDate;
        }
        public void setMoneyBet(float newBet)
        {
            moneyBet = newBet;
        }
        public void setResult(string newResult)
        {
            result = newResult;
        }
        public void setBetType(string newBetType)
        {
            betType = newBetType;
        }
        public void setBetOdds(float newOdds)
        {
            betOdds = newOdds;
        }
        public void setMoneyWon(float newMoneyWon)
        {
            moneyWon = newMoneyWon;
        }

        public string getSportName()
        {
            return sportName;
        }
        public string getHomeTeam()
        {
            return homeTeamName;
        }
        public string getAwayTeam()
        {
            return awayTeamName;
        }
        public DateTime getDateOfBet()
        {
            return dateOfBet;
        }
        public float getMoneyBet()
        {
            return moneyBet;
        }
        public string getResult()
        {
            return result;
        }
        public string getBetType()
        {
            return betType;
        }
        public float getBetOdds()
        {
            return betOdds;
        }public float getMoneyWon()
        {
            return moneyWon;
        }

        string sportName;
        string homeTeamName;
        string awayTeamName;
        DateTime dateOfBet;
        float moneyBet;
        string result;
        string betType;
        float betOdds;
        float moneyWon;

    }
    
}
