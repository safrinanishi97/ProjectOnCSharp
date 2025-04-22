using ID_1285126_C_Sharp_Final_Project.Entities;
using ID_1285126_C_Sharp_Final_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID_1285126_C_Sharp_Final_Project.Repository
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly List<Project> _projectList;
        public ProjectRepository()
        {
            _projectList = new List<Project>()
            {
                  new Project()
                {
                   ProjectId=1,ProjectTitle="Pensions System",Budget=100000,ProjectStartingDate=new DateTime(2018,02,02),ProjectEndingDate=new DateTime(2019,05,05),Department=Department.PayRoll,ProjectType=ProjectType.ShortTermProject
                },

                new Project()
                {
                    ProjectId=2,ProjectTitle="HR System",Budget=400000,ProjectStartingDate=new DateTime(2018,02,02),Department=Department.HR,ProjectType=ProjectType.LongTermProject
                },

                new Project()
                {
                    ProjectId=3,ProjectTitle="Salaries System",Budget=120000,ProjectStartingDate=new DateTime(2018,02,02),ProjectEndingDate=new DateTime(2019,05,05),Department=Department.Accounts,ProjectType=ProjectType.ShortTermProject
                },
                 new Project()
                {
                   ProjectId=4,ProjectTitle="IT System",Budget=600000,ProjectStartingDate=new DateTime(2018,02,02),Department=Department.IT,ProjectType=ProjectType.LongTermProject
                }

            };

        }

        public Project CreateNewProject(Project project)
        {
            Project lastProject = (from p in _projectList orderby p.ProjectId descending select p).FirstOrDefault();
            project.ProjectId = lastProject.ProjectId + 1;
            _projectList.Add(project);
            return project;
        }

        public Project DeleteProject(int id)
        {

            Project delProject = GetProjectById(id);
            if (delProject != null)
            {
                _projectList.Remove(delProject);
            }
            return delProject;
        }

        public IEnumerable<Project> GetAllProject()
        {
            IEnumerable<Project> projects = from rows in _projectList select rows;
            return projects;
        }

        public Project GetProjectById(int id)
        {
            var project = (from p in _projectList where p.ProjectId == id select p).FirstOrDefault();
            return project;
        }

        public Project UpdateProject(Project upProject)
        {
            Project project = GetProjectById(upProject.ProjectId);
            if (project != null)
            {
                project.ProjectId = upProject.ProjectId;
                project.ProjectTitle = upProject.ProjectTitle;
                project.Budget = upProject.Budget;
                project.ProjectStartingDate = upProject.ProjectStartingDate;
                project.ProjectEndingDate = upProject.ProjectEndingDate;
                project.Department = upProject.Department;
                project.ProjectType = upProject.ProjectType;
                project.TotalExpense = upProject.TotalExpense;
                project.GetProfitOrLossPercentage= upProject.GetProfitOrLossPercentage;
                project.Feedback = upProject.Feedback;
                project.Monitoring = upProject.Monitoring;
  
            }
            return project;
        }





        //public Project CreateNewProject(Project project)
        //{
        //    Project lastProject = (from p in _projectList orderby p.ProjectId descending select p).FirstOrDefault();
        //    project.ProjectId = lastProject.ProjectId + 1;
        //    _projectList.Add(project);
        //    return project;
        //}
        //public Project GetProjectById(int Id)
        //{
        //    var project = (from p in _projectList where p.ProjectId == Id select p).FirstOrDefault();
        //    return project;
        //}
        //public Project DeleteProject(int Id)
        //{
        //    Project delProject = GetProjectById(Id);
        //    if (delProject != null)
        //    {
        //        _projectList.Remove(delProject);
        //    }
        //    return delProject;
        //}
        //public IEnumerable<Project> GetAllProject()
        //{
        //    IEnumerable<Project> projects = from rows in _projectList select rows;
        //    return projects;
        //}
        //public Project UpdateProject(Project upproject)
        //{
        //    Project project = GetProjectById(upproject.ProjectId);
        //    if (project != null)
        //    {
        //        project.ProjectId = upproject.ProjectId;
        //        project.ProjectTitle = upproject.ProjectTitle;
        //        project.Budget = upproject.Budget;
        //        project.ProjectStartingDate = upproject.ProjectStartingDate;
        //        project.ProjectEndingDate = upproject.ProjectEndingDate;
        //        project.ProjectType = upproject.ProjectType;
        //        project.Department = upproject.Department;
        //        project.Profit = upproject.Profit;
        //        project.TotalExpense = upproject.TotalExpense;
        //        project.Monitoring = upproject.Monitoring;
        //        project.Drawback = upproject.Drawback;
        //        project.Facilities=upproject.Facilities;
        //    }
        //    return project;
        //}
    }
}
