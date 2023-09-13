namespace Blazor_Math_Quiz
{
    class Question
    {
        public Question()
        {
            Operator = (Random.Shared.Next(2) == 1) ? "+" : "*";
            N1 = Random.Shared.Next(1, 10);
            N2 = Random.Shared.Next(1, 10);
        }

        public int N1 { get; private set; }

        public string Operator { get; private set; }

        public int N2 { get; private set; }

        public string? Answer { get; set; }

        public bool Check()
        {
            if (int.TryParse(Answer, out int i))
            {
                if (Operator == "+") return (i == N1 + N2);
                else return (i == N1 * N2);
            }
            else return false;
        }
    }
}