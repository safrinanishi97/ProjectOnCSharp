using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID_1285126_C_Sharp_Final_Project.Entities
{
    public class Project
    {
        int projectId;
        string projectTitle;
        double projectBudget;
        DateTime projectStartingDate;
        DateTime projectEndingDate;
        Department department;
        ProjectType projectType;

        public Project()
        {
            
        }

        public Project(int projectId, string projectTitle, double projectBudget, DateTime projectStartingDate, DateTime projectEndingDate, Department department, ProjectType projectType)
        {
            this.ProjectId = projectId;
            this.ProjectTitle = projectTitle;
            this.Budget = projectBudget;
            this.ProjectStartingDate = projectStartingDate;
            this.ProjectEndingDate = projectEndingDate;
            this.Department = department;
            this.ProjectType = projectType;
        }
        public double GetProfitOrLossPercentage { get; set; }
        public double Profit { get; set; }
        public double TotalExpense { get; set; }
        public double Monitoring { get; set; }
        public string Feedback { get; set; }
        public int ProjectId { get => projectId; set => projectId = value; }
        public string ProjectTitle { get => projectTitle; set => projectTitle = value; }
        public double Budget { get => projectBudget; set => projectBudget = value; }
        public DateTime ProjectStartingDate { get => projectStartingDate; set => projectStartingDate = value; }
        public DateTime ProjectEndingDate { get => projectEndingDate; set => projectEndingDate = value; }
        public Department Department { get => department; set => department = value; }
        public ProjectType ProjectType { get => projectType; set => projectType = value; }
    }
}
