namespace DnaParser
{
    internal class Parser
    {
        private static Dictionary<char, char[]> nonTerminalSymbols = new Dictionary<char, char[]>
        {
            {'R', new char[] {'A', 'G'}},
            {'Y', new char[] {'C', 'T'}},
            {'M', new char[] {'A', 'C'}},
            {'K', new char[] {'G', 'T'}},
            {'S', new char[] {'C', 'G'}},
            {'W', new char[] {'A', 'T'}},
            {'H', new char[] {'A', 'C', 'T'}},
            {'B', new char[] {'C', 'G', 'T'}},
            {'V', new char[] {'A', 'C', 'G'}},
            {'D', new char[] {'A', 'G', 'T'}},
            {'N', new char[] {'A', 'C', 'G', 'T'}}
        };

        private static List<string> GenerateVariants(string input)
        {
            List<string> variants = [input];

            for (int i = 0; i < variants.Count; i++)
            {
                string currentVariant = variants[i];
                int index = currentVariant.IndexOfAny(nonTerminalSymbols.Keys.ToArray());

                if (index == -1)
                {
                    continue;
                }

                char[] possibleReplacements = nonTerminalSymbols[currentVariant[index]];

                foreach (char replacement in possibleReplacements)
                {
                    string newVariant = currentVariant.Substring(0, index) + replacement + currentVariant.Substring(index + 1);
                    variants.Add(newVariant);
                }

                variants.RemoveAt(i);
                i--;
            }

            return variants;
        }

        public static void Parse(string input)
        {
            DateTime startTime = DateTime.Now;
            List<string> variants = GenerateVariants(input);

            Console.WriteLine($"\nAll {variants.Count} possible variants:\n");
            foreach (string variant in variants)
            {
                Console.WriteLine(variant);
            }
            Console.WriteLine($"\nElapsed time: {DateTime.Now - startTime}\n");
        }

        public static void PrintDictionary()
        {
            Console.WriteLine("\nSymbols and bases represented:");
            foreach (var symbol in nonTerminalSymbols)
            {
                Console.WriteLine($"{symbol.Key} -> {string.Join(", ", symbol.Value)}");
            }
        }
    }
}