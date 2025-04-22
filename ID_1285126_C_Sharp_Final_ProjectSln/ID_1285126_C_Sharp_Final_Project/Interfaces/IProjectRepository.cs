using ID_1285126_C_Sharp_Final_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID_1285126_C_Sharp_Final_Project.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProject();
        Project GetProjectById(int Id);
        Project CreateNewProject(Project project);
        Project UpdateProject(Project upProject);
        Project DeleteProject(int Id);
    }
}
