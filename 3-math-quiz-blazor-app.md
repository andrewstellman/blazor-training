# Blazor Math Quiz Game (from Part 2)

Here's all of the code that you can copy and paste for the Blazor_Math_Quiz project in Part 2. Each slide in the training deck has a corresponding section in this page.

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

        public bool Check(int answer)
        {
            if (Operator == "+") return (answer == N1 + N2);
            else return (answer == N1 * N2);
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
            <input type="text" class="form-control"
            @bind="q.Answer"/>
        </div>
        <div class="col-6">
            @if (q.Check())
            {
                <span>Correct!</span>
            }
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

## Add a method that needs a using statement

```razor
@using System.Linq

@code {
    private int NumberCorrect() =>
            questions.Where(q => q.Check()).Count();

    private List<Question> questions = new();
    private const int QUESTION_COUNT = 6;
```

## Use an @if directive with an else to display either text or a button.

```razor
<div class="row mt-5">
    <div class="col-6">
        @if(numberCorrect < QUESTION_COUNT)
        {
            <h6>
                @numberCorrect out of @QUESTION_COUNT
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
