# Animal Matching Game (part 3)

Here's all of the code that you can copy and paste for the third part of the AnimalMatchingGame project in Part 3, adding a timer. Each slide in the training deck has a corresponding section in this page.

## Add fields to use a Timer and keep track of the time

```razor
<div class="row">
    <h2>Time: @timeDisplay</h2>
</div>
```

```razor
@using System.Linq
@using System.Timers

@code {

    Timer timer = new Timer(100);
    int tenthsOfSecondsElapsed = 0;
    string timeDisplay = "";
```

## Reset the timer when the game starts

```razor
private void SetUpGame()
{
    shuffledAnimals = animalEmoji
        .OrderBy(item => Random.Shared.Next())
        .ToList();
    matchesFound = 0;
    timer = new Timer(100);
    timer.Elapsed += Timer_Elapsed;
    tenthsOfSecondsElapsed = 0;
}
```

## Make the timer run when the player is finding matches

```c#
        timer.Start();
```

```c#
            timer.Stop();
            timeDisplay += " - Play Again?";
```

## Update the time display when the timer ticks

```c#
private void Timer_Elapsed(object? source, 
                        ElapsedEventArgs e)
{
    InvokeAsync(
        () =>
        {
            tenthsOfSecondsElapsed++;
            timeDisplay = 
                   (tenthsOfSecondsElapsed / 10F)
                       .ToString("0.0s");
            StateHasChanged();
        }
    );
}
```

