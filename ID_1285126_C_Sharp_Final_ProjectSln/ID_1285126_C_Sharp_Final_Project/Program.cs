using ID_1285126_C_Sharp_Final_Project.Entities;
using ID_1285126_C_Sharp_Final_Project.Factory;
using ID_1285126_C_Sharp_Final_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ID_1285126_C_Sharp_Final_Project
{
    internal class Program
    {
        public static ProjectRepository repo = new ProjectRepository();
        static void Main(string[] args)
        {

            try
            {
                DoTask();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.ReadLine(); }
        }

        private static void DoTask()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t\t\t\t\t    **Trainee Information**\r");
            Console.WriteLine("\t\t\t\t\t\t\t\t    =======================\n");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t\t*Trainee ID\t: 1285126\r");
            Console.WriteLine("\t\t\t\t\t\t\t\t*Name\t\t: Safrina Akter\r");
            Console.WriteLine("\t\t\t\t\t\t\t\t*Batch ID\t: CS/SCSL-M/61/01\r");
            Console.WriteLine("\t\t\t\t\t\t\t\t---------------------------------\n");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t  -----***Project on Project Management***-----\r");
            Console.WriteLine("\t\t\t\t\t\t\t  =============================================\n");
            Console.WriteLine();
            Console.WriteLine("*How many operation would you like to perform?\r");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t\t\t\t**********Operation**********");
                Console.WriteLine("\t\t\t\t\t\t\t\t=============================");
                Console.WriteLine();
                Console.WriteLine("*Select Operation\nSelect- -1\nCreate- -2\nUpdate- -3\nDelete- -4");
                int operationNumber = Convert.ToInt16(Console.ReadLine());
                switch (operationNumber)
                {
                    case 1: ShowAllProject(null); break;
                    case 2: CreateProject(); break;
                    case 3: UpdateProject(); break;
                    case 4: DeleteProject(); break;
                    default: ShowAllProject(null); break;

                }

            }
        }

        private static void DeleteProject()
        {
        EnterId:
            Console.WriteLine("*Enter project id that you want to delete");
            Console.WriteLine();
            int id = Convert.ToInt32(Console.ReadLine());
            if (id > 0)
            {
                Project deleteProject = new Project();
                deleteProject.ProjectId = id;
                deleteProject = repo.GetProjectById(deleteProject.ProjectId);
                repo.DeleteProject(deleteProject.ProjectId);
                Console.WriteLine();
                Console.WriteLine("*Project Deleted Successfully");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t\t\t\t**********Deleted Project**********");
                ShowAllProject(deleteProject);
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t\t\t\t***********All Project************");
                ShowAllProject(null);
            }
            else 
            {
                Console.WriteLine();
                Console.WriteLine("**Invalid input!! Please enter a valid Id");
                goto EnterId;
            }


        }

        private static void UpdateProject()
        {

            Console.WriteLine();
            Console.WriteLine("*Enter Project Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("*Enter Project Title");
            string pName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("*Enter Project Budget");
            double budget = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("*Enter Project Total Expense");
            double totalExpense = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("*Enter Project Starting Date\n**Hint:yyyy/mm/dd");
            DateTime sDateTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("*Enter Project Ending Date\n**Hint:yyyy/mm/dd");
            DateTime eDateTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();


        EnterDepartment:
            Console.WriteLine("*Enter the Department:\n**Hints:IT=1,\nHR=2,\nPayRoll=3,\nSales=4,\nNetworking=5,\nAccounts=6,\nOthers=0");
            string deptRead = Console.ReadLine();
            Department dept;
            try
            {
                dept = (Department)Enum.Parse(typeof(Department), deptRead);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("*Invalid type!!! Please Try Again...");
                goto EnterDepartment;
            }
            Console.WriteLine();
        EnterProjectType:
            Console.WriteLine("*Enter Project Type:\n**Hints:\nLongTermProject=1,\nShorttermProject=2");
            string typeRead = Console.ReadLine();
            ProjectType projectType;
            try
            {
                projectType = (ProjectType)Enum.Parse(typeof(ProjectType), typeRead);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("*Invalid type!!! Please Try Again...");
                goto EnterProjectType;
            }

            Project upPjt = new Project();
            upPjt.ProjectId = id;
            upPjt.ProjectTitle = pName;
            upPjt.Budget = budget;
            upPjt.ProjectStartingDate = sDateTime;
            upPjt.ProjectEndingDate = eDateTime;
            upPjt.Department = dept;
            upPjt.ProjectType = projectType;
            upPjt.TotalExpense=totalExpense;

            if (upPjt.ProjectType == ProjectType.LongTermProject)
            {
                upPjt.ProjectType = ProjectType.LongTermProject;
                BaseProjectFactory pjtFactory = new LongTermProjectFactory(upPjt);
                pjtFactory.ProjectWiseProfit();

            }
            else if (upPjt.ProjectType == ProjectType.ShortTermProject)
            {
                upPjt.ProjectType = ProjectType.ShortTermProject;
                BaseProjectFactory pjtFactory = new ShortTermProjectFactory(upPjt);
                pjtFactory.ProjectWiseProfit();
            }
            repo.UpdateProject(upPjt);
            Console.WriteLine();
            Console.WriteLine("*Project Updated Successfully");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t\t*********Updated Project**********");
            ShowAllProject(upPjt);
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t\t***********All Projects*********");
            ShowAllProject(null);

        }

        private static void CreateProject()
        {

            Console.WriteLine();
            Console.WriteLine("*Enter Project Title");
            string pName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("*Enter Project Budget");
            double budget = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("*Enter Project Total Expense");
            double totalExpense = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("*Enter Project Starting Date\n**Hint:yyyy/mm/dd");
            DateTime sDateTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("*Enter Project Ending Date\n**Hint:yyyy/mm/dd");
            DateTime eDateTime = Convert.ToDateTime(Console.ReadLine());
           

            Console.WriteLine();
        EnterDepartment:
            Console.WriteLine("*Enter the Department:\n**Hints:IT=1,\nHR=2,\nPayRoll=3,\nSales=4,\nNetworking=5,\nAccounts=6,\nOthers=0");
            string deptRead = Console.ReadLine();
            Department dept;
            try
            {
                dept = (Department)Enum.Parse(typeof(Department), deptRead);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("*Invalid type!!! Please Try Again...");
                goto EnterDepartment;
            }
            Console.WriteLine();
        EnterProjectType:
            Console.WriteLine("Enter Project Type:\n**Hints:LongTermProject=1,\nShortTermProject=2");
            string typeRead = Console.ReadLine();
            ProjectType projectType;
            try
            {
                projectType = (ProjectType)Enum.Parse(typeof(ProjectType), typeRead);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("*Invalid type!!! Please Try Again...");
                goto EnterProjectType;
            }
            Console.WriteLine();
            Project pjt = new Project(0, pName, budget, sDateTime, eDateTime, dept, projectType);
            pjt.TotalExpense = totalExpense;
            if (pjt.ProjectType == ProjectType.LongTermProject)
            {
                pjt.ProjectType = ProjectType.LongTermProject;
                BaseProjectFactory pjtFactory = new LongTermProjectFactory(pjt);
                pjtFactory.ProjectWiseProfit();

            }
            else if (pjt.ProjectType == ProjectType.ShortTermProject)
            {
                pjt.ProjectType = ProjectType.ShortTermProject;
                BaseProjectFactory pjtFactory = new ShortTermProjectFactory(pjt);
                pjtFactory.ProjectWiseProfit();
            }
            repo.CreateNewProject(pjt);
            Console.WriteLine();
            Console.WriteLine("*Project Added Successfully");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t\t*********New Project**********");
            ShowAllProject(pjt);
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t\t*********All Projects*********");
            ShowAllProject(null);

        }

        //private static void ShowAllProject(Project pjt)
        //{

        //    List<Project> list = new List<Project>();
        //    Console.WriteLine("=========================================================================================================================================================");

        //    Console.WriteLine(string.Format("|{0,-5}|{1,-20}|{2,-15}|{3,-18}|{4,-18}|{5,-8}|{6,-12}|{7,-10}|{8,-15}", "ID", "Project Name", "Department", "Project Type", "MonitoringMember", "Budget", "Total Cost", "Profit", "Facilities and Drawback"));
        //    Console.WriteLine("=========================================================================================================================================================");

        //    if (pjt == null)
        //    {
        //        list = repo.GetAllProject().ToList();
        //        foreach (var item in list)
        //        {
        //            Console.WriteLine(string.Format("|{0,-5}|{1,-20}|{2,-15}|{3,-18}|{4,-18}|{5,-8}|{6,-12}|{7,-10}|{8,-15}", item.ProjectId, item.ProjectTitle, item.Department, item.ProjectType, item.Monitoring, item.Budget, item.TotalExpense, item.Profit, item.Facilities));
        //            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------");
        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine(string.Format("|{0,-5}|{1,-20}|{2,-15}|{3,-18}|{4,-18}|{5,-8}|{6,-12}|{7,-10}|{8,-15}", pjt.ProjectId, pjt.ProjectTitle, pjt.Department, pjt.ProjectType, pjt.Monitoring, pjt.Budget, pjt.TotalExpense, pjt.Profit, pjt.Facilities));
        //        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
        //    }

        //}


        //private static void ShowAllProject(Project pjt)
        //{
        //    List<Project> list = new List<Project>();

        //    if (pjt == null)
        //    {
        //        list = repo.GetAllProject().ToList();
        //    }
        //    else
        //    {
        //        list.Add(pjt);
        //    }

        //    Console.ForegroundColor = ConsoleColor.Cyan; // Set text color

        //    Console.WriteLine("======================================================================================================================");
        //    Console.WriteLine("| {0,-5} | {1,-20} | {2,-15} | {3,-18} | {4,-18} | {5,-10} |",
        //        "ID", "Project Name", "Department", "Project Type", "Budget", "Profit");
        //    Console.WriteLine("======================================================================================================================");

        //    foreach (var item in list)
        //    {
        //        Console.WriteLine("| {0,-5} | {1,-20} | {2,-15} | {3,-18} | {4,-18} | {5,-10} |",
        //            item.ProjectId, item.ProjectTitle, item.Department, item.ProjectType, item.Budget, item.Profit);
        //        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
        //    }

        //    Console.ResetColor(); // Reset text color to default
        //}

        private static void ShowAllProject(Project pjt)
        {
            List<Project> list = new List<Project>();

            if (pjt == null)
            {
                list = repo.GetAllProject().ToList();
            }
            else
            {
                list.Add(pjt);
            }

            Console.ForegroundColor = ConsoleColor.Yellow; // Set color for header
            Console.WriteLine("╔═══════╦═════════════════╦══════════════╦════════════════════╦════════════╦════════════╦═══════════╦═══════════╦════════════════════════════════════════╗");
            Console.WriteLine("║  ID   ║   Project Name  ║  Department  ║   Project Type     ║ Monitoring ║   Budget   ║Total Cost ║   Profit  ║            Project Feedback            ║");         
            Console.WriteLine("╠═══════╬═════════════════╬══════════════╬════════════════════╬════════════╬════════════╬═══════════╬═══════════╬════════════════════════════════════════╣");

            Console.ResetColor(); // Reset color after header

            Console.ForegroundColor = ConsoleColor.Cyan; // Set color for data
            foreach (var item in list)
            {
                Console.WriteLine($"║ {item.ProjectId,-5} ║ {item.ProjectTitle,-15} ║ {item.Department,-12} ║ {item.ProjectType,-18} ║ {item.Monitoring,-10} ║ {item.Budget,-10} ║ {item.TotalExpense,-9} ║ {item.GetProfitOrLossPercentage,-9} ║ {item.Feedback,-38} ║");
                Console.WriteLine("╠═══════╬═════════════════╬══════════════╬════════════════════╬════════════╬════════════╬═══════════╬═══════════╬════════════════════════════════════════╣");
            }

            Console.WriteLine("╚═══════╩═════════════════╩══════════════╩════════════════════╩════════════╩════════════╩═══════════╩═══════════╩════════════════════════════════════════╝");
            Console.ResetColor(); // Reset to default color
        }


    }
}
