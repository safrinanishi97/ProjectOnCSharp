using ID_1285126_C_Sharp_Final_Project.Entities;
using ID_1285126_C_Sharp_Final_Project.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID_1285126_C_Sharp_Final_Project.Factory
{
    public class ShortTermProjectFactory : BaseProjectFactory
    {
        public ShortTermProjectFactory(Project pjct) : base(pjct)
        {
        }

        public override IProjectManager Create()
        {
            ShortTermProjectManager manager = new ShortTermProjectManager(_pjct.Budget,_pjct.TotalExpense);
            _pjct.TotalExpense = manager.Expenditure();
            _pjct.Monitoring = manager.MonitoringTeamMember();
            _pjct.Feedback = manager.GetFeedback();
            _pjct.Profit = manager.GetProfit();
            _pjct.GetProfitOrLossPercentage = manager.GetProfitOrLossPercentage();
            return manager;
        }
    }
}
