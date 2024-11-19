class Program
{
    static Dictionary<char, int> kamus = new Dictionary<char, int>
    {
        {'A', 0}, {'B', 1}, {'C', 1}, {'D', 1}, {'E', 2}, {'F', 3}, {'G', 3}, {'H', 3},
        {'I', 4}, {'J', 5}, {'K', 5}, {'L', 5}, {'M', 5}, {'N', 5}, {'O', 6}, {'P', 7},
        {'Q', 7}, {'R', 7}, {'S', 7}, {'T', 7}, {'U', 8}, {'V', 9}, {'W', 9}, {'X', 9},
        {'Y', 9}, {'Z', 9}, {'a', 9}, {'b', 8}, {'c', 8}, {'d', 8}, {'e', 7}, {'f', 6},
        {'g', 6}, {'h', 6}, {'i', 5}, {'j', 4}, {'k', 4}, {'l', 4}, {'m', 4}, {'n', 4},
        {'o', 3}, {'p', 2}, {'q', 2}, {'r', 2}, {'s', 2}, {'t', 2}, {'u', 1}, {'v', 0},
        {'w', 0}, {'x', 0}, {'y', 0}, {'z', 0}, {' ', 0}
    };

    static string Task1(string sentence)
    {
        return sentence.Aggregate("", (result, charItem) =>
            kamus.ContainsKey(charItem) ? result + kamus[charItem] : result);
    }

    static int Task2(string sentence)
    {
        List<int> values = sentence.Select(charItem => kamus.ContainsKey(charItem) ? kamus[charItem] : 0).ToList();

        int result = values.FirstOrDefault();
        for (int i = 1; i < values.Count; i++)
        {
            result = i % 2 == 0 ? result - values[i] : result + values[i];
        }
        return result;
    }

    static List<int> Task3(int target)
    {
        List<int> numbers = new List<int>();
        int currentSum = 0;
        int nextNumber = 0;

        while (currentSum < target)
        {
            if (currentSum + nextNumber > target)
            {
                nextNumber = 0;
            }
            numbers.Add(nextNumber);
            currentSum += nextNumber;
            nextNumber++;
        }
        return numbers;
    }

    static List<int> Task4(List<int> values)
    {
        List<int> transformedValues = new List<int>(values);
        if (transformedValues.Count >= 2)
        {
            transformedValues[transformedValues.Count - 2] += 1;
            transformedValues[transformedValues.Count - 1] += 1;
        }
        return transformedValues;
    }

    static List<int> Task5(List<string> letters)
    {
        List<int> values = letters.Select(letter =>
            kamus.ContainsKey(letter[0]) ? kamus[letter[0]] : -1).ToList();

        return values.Select(value => value % 2 == 0 ? value + 1 : value).ToList();
    }

    static string ConvertNumbersToLetters(List<int> numbers)
    {
        Dictionary<int, char> reverseKamus = kamus.GroupBy(kvp => kvp.Value)
            .ToDictionary(g => g.Key, g => g.First().Key);

        return string.Join(" ", numbers.Select(num => reverseKamus.ContainsKey(num) ? reverseKamus[num] : ' '));
    }

    static void Main(string[] args)
    {
        Console.Write("Masukkan kalimat: ");
        string input = Console.ReadLine();

        string resultTask1 = Task1(input);
        int resultTask2 = Task2(input);
        List<int> resultTask3 = Task3(Math.Abs(resultTask2));
        string resultLettersTask3 = ConvertNumbersToLetters(resultTask3);
        List<int> resultTask4 = Task4(resultTask3);
        string resultLettersTask4 = ConvertNumbersToLetters(resultTask4);
        List<int> resultTask5 = Task5(resultLettersTask4.Split(' ').ToList());

        Console.WriteLine($"Task 1: {resultTask1}");
        Console.WriteLine($"Task 2: {resultTask2}");
        Console.WriteLine($"Task 3: {resultLettersTask3}");
        Console.WriteLine($"Task 4: {resultLettersTask4}");
        Console.WriteLine($"Task 5: {string.Join(" ", resultTask5)}");
    }
}