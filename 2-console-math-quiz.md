# Console Math Quiz App (from Part 2)

Here's all of the code that you can copy and paste for the math quiz console app project in Part 2. Each slide in the training deck has a corresponding section in this page. 

## The Question class generates questions and checks answers

```c#
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
```

## This console app quiz game uses the Question class

```c#
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
```

## 
