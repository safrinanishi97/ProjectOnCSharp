using ID_1285126_C_Sharp_Final_Project.Entities;
using ID_1285126_C_Sharp_Final_Project.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID_1285126_C_Sharp_Final_Project.Factory
{
    public abstract class BaseProjectFactory
    {
        protected Project _pjct;

        protected BaseProjectFactory(Project pjct)
        {
            _pjct = pjct;
        }
        public abstract IProjectManager Create();
        public Project ProjectWiseProfit()
        {
            IProjectManager manager = this.Create();
            _pjct.Profit = manager.GetProfit();
            _pjct.Budget = manager.ProjectBudget();
            _pjct.TotalExpense=manager.Expenditure();
            _pjct.Feedback = manager.GetFeedback();
          
            _pjct.GetProfitOrLossPercentage = manager.GetProfitOrLossPercentage();
            return _pjct;
        }
    }
}
