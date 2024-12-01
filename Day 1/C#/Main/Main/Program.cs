namespace Main;

class Program
{
    static void Main(string[] args)
    {
        List<int> left = new();
        List<int> right = new();
        List<int> result = new();
        
        var lines = File.ReadAllLines("./input.txt");

        foreach (var line in lines)
        {
            var strings = line.Split("   ");
            
            left.Add(int.Parse(strings[0]));
            right.Add(int.Parse(strings[1]));
        }

        left = left.OrderBy(x => x).ToList();
        right = right.OrderBy(x => x).ToList();

        for (int i = 0; i < left.Count; i++)
        {
            Console.WriteLine(Math.Abs(left[i] - right[i]));
            result.Add(Math.Abs(left[i] - right[i]));
        }
        
        Console.WriteLine(result.Sum());
    }
}