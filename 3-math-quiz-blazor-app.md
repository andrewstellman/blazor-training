# Blazor Math Quiz Game (from Part 2)

Here's all of the code that you can copy and paste for the Blazor_Math_Quiz project in Part 2. Each slide in the training deck has a corresponding section in this page.

The full code for this project can be found here: 
* The version with one question is here: [Blazor_Math_Quiz_part_1](https://github.com/andrewstellman/blazor-training/tree/main/Code/Blazor_Math_Quiz_part_1)
* The updated version with six questions is here: [Blazor_Math_Quiz_part_2](https://github.com/andrewstellman/blazor-training/tree/main/Code/Blazor_Math_Quiz_part_2)

## Create a new Blazor app and update the navigation menu

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="mathquiz">
        <span class="oi oi-puzzle-piece" aria-hidden="true"></span> Math Quiz
    </NavLink>
</div>
```

## Add a Razor component for your math quiz page.

```razor
@page "/mathquiz"

<PageTitle>Math Quiz</PageTitle>

<div class="container">
    <div class="row">
        <h1>Math quiz!</h1>
    </div>
</div>


@code {

}
```
## Add the Question class to the project

```c#
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
```

## Create an instance of Question and use it on the page.

```razor
    <div class="row mt-2">
        <div class="col-2">
            @q.N1 @q.Operator @q.N2 =
        </div>
        <div class="col-2">
            <input type="text" class="form-control"/>
        </div>
        <div class="col-6">
            What's the answer?
        </div>
    </div>
```

```c#
    private Question q = new();
```

## Use data binding to get the answer from the input box

```razor
<input type="text" class="form-control"
       @bind="q.Answer"/>
```

## Use a Blazor conditional to display a message

```razor
    @if (q.Check())
    {
        <span>Correct!</span>
    }
```

## Here’s the C# code to add to the @code section

```c#
private List<Question> questions = new();
private const int QUESTION_COUNT = 6;

private void GenerateQuestions()
{
    questions.Clear();
    for (int i = 0; i < QUESTION_COUNT; i++)
        questions.Add(new());
}

protected override void OnInitialized()
{
    GenerateQuestions();
}
```

## Add a @foreach expression around the question rows

```razor
@foreach (Question q in questions) {
    <div class="row mt-2">
        <div class="col-2">
            @q.N1 @q.Operator @q.N2 =
        </div>
        <div class="col-2">
            <input type="text"
             class="form-control" @bind="q.Answer"/>
        </div>
        <div class="col-6">
            @if(q.Check())
            {
                <p>Correct!</p>
            }
        </div>
    </div>
}
```

## Use an @if directive with an else to display either text or a button.

```razor
@code {
    private int NumberCorrect() =>
            questions.Where(q => q.Check()).Count();
}

<div class="row mt-5">
    <div class="col-6">
        @if(NumberCorrect() < QUESTION_COUNT)
        {
            <h6>
                @NumberCorrect() out of @QUESTION_COUNT
            </h6>
        } else
        {
            <button class="btn btn-primary"
                    @onclick="GenerateQuestions">
                Generate New Quiz
            </button>
        }
    </div>
</div>
```

## Refactor the C# code to call the LINQ method once

```razor
<div class="row mt-5">
    <div class="col-6">
         @{
             var numberCorrect = NumberCorrect();
         }
         @if(numberCorrect < QUESTION_COUNT)
         {
             <h6>
                  @numberCorrect correct out of @QUESTION_COUNT
             </h6>
         }
         else
         {
            ...             
```
