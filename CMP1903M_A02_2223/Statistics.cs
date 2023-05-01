namespace CMP1903M_A02_2223;

class Statistics
{
    private string path = AppDomain.CurrentDomain.BaseDirectory.Replace(Path.Combine("bin", "Debug", "net6.0"), "Stats");
    private string[] fpath;
    
    public Statistics()
    {
        fpath = new [] {path, "Statistics.txt"};

        // Create file if it doesn't exist
        if (!File.Exists(Path.Combine(fpath)))
        {
           File.Create(Path.Combine(fpath));
        }
    }

    public void CalculateStats(List<Equation> equations)
    {
        CalculateEquationStats(equations);
    }
    
    public string ReadStats()
    {
        return File.ReadAllText(Path.Combine(fpath));
    }
    
    private void CalculateEquationStats(List<Equation> equations)
    {
        string text = "";

        text += "Equation completed: " + equations.Count;
        text += " Average time: " + (equations.Average(equation => equation.Speed) / 1000).ToString("F2") + "s";
        text += " Average score: " + equations.Average(equation => Convert.ToInt32(equation.Score)) * 100 + "%";
        text += "\n";
        
        WriteToFile(text);
    }

    private void WriteToFile(string text)
    {
        File.AppendAllText(Path.Combine(fpath), text);
    }
    
}