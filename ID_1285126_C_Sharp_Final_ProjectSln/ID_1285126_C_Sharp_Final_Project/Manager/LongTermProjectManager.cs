using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID_1285126_C_Sharp_Final_Project.Manager
{
    public class LongTermProjectManager : IProjectManager
    {
        private double _bd;
        private double _expense;

        public LongTermProjectManager(double bd, double expense)
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
            double profit = GetProfit();

            if (_bd == 0) return 0; 

            double percentage = (Math.Abs(profit) / _bd) * 100; 

            return profit >= 0 ? percentage : -percentage; 
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
            return 4;

        }


        //public string FacilitiesAndDrawBack()
        //{
        //    return ("Inflexible but longlasting");
        //}
        public string GetFeedback()
        {
            double percentage = GetProfitOrLossPercentage();
            
            if (percentage > 20) return "Excellent Profit Margin!";
            else if (percentage >= 1 && percentage <= 20) return "Moderate Profit.Consider Cost Cutting";
            else if (percentage < 0) return "Low Profit!Need Immediate Action!";
            else return "Minimal Gain or No Profit";
        }

    }
}
