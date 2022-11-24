// From: https://haacked.com/archive/2022/11/22/csharp-list-pattern/

var partsResult = new ListDemoCSharp11.Parts("a","b","c");

Console.WriteLine(partsResult);

var parsedResult = ListDemoCSharp11.Parts.Parse(partsResult.ToString());

Console.WriteLine(parsedResult);

var invalidResult = ListDemoCSharp11.Parts.Parse(parsedResult.ToString() + "|d");

Console.WriteLine(invalidResult);

namespace ListDemoCSharp11
{
    public record Parts(string Part1, string Part2, string? Part3 = null)
    {
        public static Parts Parse(string formatted)
        {
            return formatted.Split('|') switch
            {
                [var part1, var part2] => new Parts(part1, part2),

                [var part1, var part2, var part3] => new Parts(part1, part2, part3),

                var parts => throw new InvalidOperationException($"Expected 3 parts, but got {parts.Length} parts for formatted string: {formatted}."),
            };
        }

        public override string ToString() => Part3 is null ? $"{Part1}|{Part2}" : $"{Part1}|{Part2}|{Part3}";
    }
}