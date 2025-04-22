using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID_1285126_C_Sharp_Final_Project.Manager
{
    public interface IProjectManager
    {
        double GetProfit();
        double ProjectBudget();
        double Expenditure();
        double GetProfitOrLossPercentage();
        string GetFeedback();

    }
}
