using ID_1285126_C_Sharp_Final_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID_1285126_C_Sharp_Final_Project.Factory
{
    public class ProjectManagerFactory
    {
        public BaseProjectFactory CreateFactory(Project pjct)
        {
            BaseProjectFactory value = null;
            if (pjct.ProjectType == ProjectType.LongTermProject)
            {
                value = new LongTermProjectFactory(pjct);
            }
            else if (pjct.ProjectType == ProjectType.ShortTermProject)
            {
                value = new ShortTermProjectFactory(pjct);
            }
            return value;
        }
    }
}
