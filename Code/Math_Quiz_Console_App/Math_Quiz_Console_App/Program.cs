Question quiz = new();
while (true)
{
    Console.Write($"{quiz.N1} {quiz.Operator} {quiz.N2} = ");
    quiz.Answer = Console.ReadLine();
    if (quiz.Answer == "")
    {
        Console.WriteLine("Thanks for playing!");
        return;
    }
    if (quiz.Check())
    {
        Console.WriteLine("Right!");
        quiz = new Question();
    }
    else Console.WriteLine("Wrong! Try again.");
}
