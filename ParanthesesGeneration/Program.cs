using System.Text;

namespace ParanthesesGeneration
{
    internal class Program
    {

        static char[] arr = new[] { '(', ')' };
        static void Main(string[] args)
        {
            

            do 
            {
                for (int i = 1; i <= 20; i++)
                {
                    var generated = GenerateValidParantheses(8);
                    Console.WriteLine($"{i:00} -> {generated}");
                }


            } while (Console.ReadKey().Key==ConsoleKey.Enter);

            static string GenerateValidParantheses(int length = 4)
            {
                if (length < 2)
                    return string.Empty;

                if (length % 2 != 0)
                    throw new Exception("Length is not valid");

                return GenerateParentheses(length, 0, 0);
            }

            static string GenerateParentheses(int lentgh, int openCount, int closeCount)
            {
                int max = lentgh / 2;
                int arrIndex;
                var sb = new StringBuilder(capacity: lentgh);

                if (openCount <= closeCount)
                    arrIndex = 0;  // Open
                else
                if (openCount == max && closeCount < max)
                    arrIndex = 1;
                else
                    arrIndex = Random.Shared.Next(maxValue: 2);

                var p = arr[arrIndex];

                sb.Append(p);

                // Aşağıda verilen if-else için kullanılabilir.
                //openCount += arrIndex == 0 ? 1 : 0;
                //closeCount += arrIndex == 1 ? 1 : 0;

                if (arrIndex == 0)
                    openCount++;
                else
                    closeCount++;

                if (openCount + closeCount >= lentgh)
                    return sb.ToString();

                var val = GenerateParentheses(lentgh, openCount, closeCount);

                sb.Append(val);

                return sb.ToString();


            }
        }

        



    }
}
