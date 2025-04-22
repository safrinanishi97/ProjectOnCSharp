using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID_1285126_C_Sharp_Final_Project.Manager
{
    public class ShortTermProjectManager : IProjectManager
    {
        private double _bd;
        private double _expense;

        public ShortTermProjectManager(double bd, double expense)
        {
            _bd = bd;
            _expense = expense;
        }


        //ekhane constructor toiry kora mane dynamic vabe user data input korte parbe.
        public double GetProfit()
        {
            return _bd - _expense; 
        }
        public double GetProfitOrLossPercentage()
        {
            //double profit = GetProfit();

            //if (_bd == 0) return 0;

            //if (profit >= 0)
            //{
            //    double profitPercentage = (profit / _bd) * 100;
            //    return profitPercentage;
            //}
            //else
            //{
            //    double lossPercentage = ((_expense - _bd) / _bd) * 100;
            //    return lossPercentage;
            //}
            double profit = GetProfit();

            if (_bd == 0) return 0; // Zero budget হলে 0% return করবে।

            double percentage = (Math.Abs(profit) / _bd) * 100; // Absolute value use করা হচ্ছে

            return profit >= 0 ? percentage : -percentage; // Profit হলে positive, loss হলে negative return করবে।
        }

        public double ProjectBudget()
        {
            return _bd;
        }
        public double Expenditure()
        {
            //double othersExpensePcnt = 0.3;
            //double totalExpense = _bd + (ProjectBudget() * othersExpensePcnt);
            //return totalExpense;

            return _expense;
        }

        public double MonitoringTeamMember()
        {
            return 1;

        }


        public string GetFeedback()
        {
            double prfPercentage = GetProfitOrLossPercentage();

            if (prfPercentage > 20) return "Great Short-Term Gain";
            else if (prfPercentage >= 1 && prfPercentage <= 20) return "Break-Even Point";
            else if (prfPercentage < 0) return "Loss!Re-evaluate Short-Term Strategy"; 
            else return "Minimal Gain or No Profit"; 
        }
    }
}
