// Common Interface
public interface IProjectManager
{
    double GetProfit();
    double ProjectBudget();
    double Expenditure();
    string GetFeedback();
    string ProjectDuration();
    string RiskLevel();
    string ProjectComplexity();
    int RequiredManpower();
    string MarketImpact();
}

// Long-Term Project Manager
public class LongTermProjectManager : IProjectManager
{
    private double _bd;
    private double _expense;

    public LongTermProjectManager(double bd, double expense)
    {
        _bd = bd;
        _expense = expense;
    }

    public double GetProfit()
    {
        return _bd - _expense;
    }

    public double ProjectBudget()
    {
        return _bd;
    }

    public double Expenditure()
    {
        return _expense;
    }

    public string GetFeedback()
    {
        double profitPercentage = (GetProfit() / _bd) * 100;

        if (profitPercentage > 20)
            return "Excellent Long-Term Investment ✅";
        else if (profitPercentage >= 10 && profitPercentage <= 20)
            return "Stable but Review Expenses ⚠️";
        else
            return "Financial Risk! Need Budget Review ❌";
    }

    public string ProjectDuration()
    {
        return "Long-Term (More than 1 year)";
    }

    public string RiskLevel()
    {
        return "High Risk (Market Fluctuation, Economic Downturn)";
    }

    public string ProjectComplexity()
    {
        return "Highly Complex (Multiple Phases, Large Team)";
    }

    public int RequiredManpower()
    {
        return 20; // More employees needed
    }

    public string MarketImpact()
    {
        return "Long-term impact on company growth & stability";
    }
}

// Short-Term Project Manager
public class ShortTermProjectManager : IProjectManager
{
    private double _bd;
    private double _expense;

    public ShortTermProjectManager(double bd, double expense)
    {
        _bd = bd;
        _expense = expense;
    }

    public double GetProfit()
    {
        return _bd - _expense;
    }

    public double ProjectBudget()
    {
        return _bd;
    }

    public double Expenditure()
    {
        return _expense;
    }

    public string GetFeedback()
    {
        double profitPercentage = (GetProfit() / _bd) * 100;

        if (profitPercentage > 15)
            return "Great Short-Term Gain ✅";
        else if (profitPercentage >= 5 && profitPercentage <= 15)
            return "Break-Even Point ⚠️";
        else
            return "Loss! Re-evaluate Short-Term Strategy ❌";
    }

    public string ProjectDuration()
    {
        return "Short-Term (Less than 1 year)";
    }

    public string RiskLevel()
    {
        return "Low Risk (Less duration, controlled expenses)";
    }

    public string ProjectComplexity()
    {
        return "Simple (Limited scope, small team)";
    }

    public int RequiredManpower()
    {
        return 5; // Fewer employees needed
    }

    public string MarketImpact()
    {
        return "Immediate financial gains but no long-term stability";
    }
}






IProjectManager longTermProject = new LongTermProjectManager(500000, 400000);
IProjectManager shortTermProject = new ShortTermProjectManager(100000, 95000);

Console.WriteLine("Long-Term Project:");
Console.WriteLine("Budget: " + longTermProject.ProjectBudget());
Console.WriteLine("Expense: " + longTermProject.Expenditure());
Console.WriteLine("Profit: " + longTermProject.GetProfit());
Console.WriteLine("Feedback: " + longTermProject.GetFeedback());
Console.WriteLine("Duration: " + longTermProject.ProjectDuration());
Console.WriteLine("Risk Level: " + longTermProject.RiskLevel());
Console.WriteLine("Project Complexity: " + longTermProject.ProjectComplexity());
Console.WriteLine("Required Manpower: " + longTermProject.RequiredManpower());
Console.WriteLine("Market Impact: " + longTermProject.MarketImpact());

Console.WriteLine("\nShort-Term Project:");
Console.WriteLine("Budget: " + shortTermProject.ProjectBudget());
Console.WriteLine("Expense: " + shortTermProject.Expenditure());
Console.WriteLine("Profit: " + shortTermProject.GetProfit());
Console.WriteLine("Feedback: " + shortTermProject.GetFeedback());
Console.WriteLine("Duration: " + shortTermProject.ProjectDuration());
Console.WriteLine("Risk Level: " + shortTermProject.RiskLevel());
Console.WriteLine("Project Complexity: " + shortTermProject.ProjectComplexity());
Console.WriteLine("Required Manpower: " + shortTermProject.RequiredManpower());
Console.WriteLine("Market Impact: " + shortTermProject.MarketImpact());




Long-Term Project:
Budget: 500000
Expense: 400000
Profit: 100000
Feedback: Stable but Review Expenses ⚠️
Duration: Long-Term (More than 1 year)
Risk Level: High Risk (Market Fluctuation, Economic Downturn)
Project Complexity: Highly Complex (Multiple Phases, Large Team)
Required Manpower: 20
Market Impact: Long-term impact on company growth & stability

Short-Term Project:
Budget: 100000
Expense: 95000
Profit: 5000
Feedback: Break-Even Point ⚠️
Duration: Short-Term (Less than 1 year)
Risk Level: Low Risk (Less duration, controlled expenses)
Project Complexity: Simple (Limited scope, small team)
Required Manpower: 5
Market Impact: Immediate financial gains but no long-term stability
