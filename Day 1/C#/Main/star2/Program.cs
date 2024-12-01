using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace star2;

class Program
{
    const int iterationCount = 10_000;
    
    public static void Main(string[] args)
    {
        Execute();
        Execute();
    }

    private static void Execute()
    {
        double sum = 0;
                
        var content = File.ReadAllText("./input.txt");

        List<int> left = new(1000);
        Dictionary<int, int> right = new();

        var start = Stopwatch.GetTimestamp();
        
        for (int j = 0; j < iterationCount; j++)
        {
            left.Clear();
            right.Clear();
            int result = 0;

            Span<Range> ranges = stackalloc Range[2];

            var lineEnumerator = content.AsSpan().Split('\n');

            foreach (var lineRange in lineEnumerator)
            {
                var line = content.AsSpan()[lineRange];
                line.Split(ranges, "   ");

                var leftI = line[ranges[0]];
                var rightI = line[ranges[1]];

                var leftNum = int.Parse(leftI);
                var rightNum = int.Parse(rightI);

                left.Add(leftNum);

                ref int value = ref CollectionsMarshal.GetValueRefOrNullRef(right, rightNum);

                if (Unsafe.IsNullRef(ref value))
                {
                    right.Add(rightNum, rightNum);
                }
                else
                {
                    value += rightNum;
                }
            }

            for (int i = 0; i < left.Count; i++)
            {
                if (right.TryGetValue(left[i], out int value))
                {
                    result += value;
                }
            }
        }

        Console.WriteLine(Stopwatch.GetElapsedTime(start).TotalMilliseconds / iterationCount);        
    }
}