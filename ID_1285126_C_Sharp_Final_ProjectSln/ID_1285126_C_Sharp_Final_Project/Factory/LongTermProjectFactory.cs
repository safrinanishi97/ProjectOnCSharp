using ID_1285126_C_Sharp_Final_Project.Entities;
using ID_1285126_C_Sharp_Final_Project.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID_1285126_C_Sharp_Final_Project.Factory
{
    public class LongTermProjectFactory:BaseProjectFactory
    {
        new Project _pjct;

        public LongTermProjectFactory(Project pjct) : base(pjct)
        {
            _pjct = pjct;
        }

        public override IProjectManager Create()
        {
            LongTermProjectManager manager = new LongTermProjectManager(_pjct.Budget,_pjct.TotalExpense);
            _pjct.TotalExpense = manager.Expenditure();
            _pjct.Monitoring = manager.MonitoringTeamMember();
            _pjct.Feedback = manager.GetFeedback();
            _pjct.Profit = manager.GetProfit();
            _pjct.GetProfitOrLossPercentage = manager.GetProfitOrLossPercentage();
            return manager;

        }
    }
}
