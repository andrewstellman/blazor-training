# Animal Matching Game (part 2)

Here's all of the code that you can copy and paste for the **second** part of the AnimalMatchingGame project in Part 3, adding mouse clicks. Each slide in the training deck has a corresponding section in this page.

The full code for this project can be found here: [AnimalMatchingGame_part_2](https://github.com/andrewstellman/blazor-training/tree/main/Code/AnimalMatchingGame_part_2)

## Add code to shuffle the animals

```razor
@using System.Linq

@code {

    List<string> shuffledAnimals = new();

    private void SetUpGame()
    {
        shuffledAnimals = animalEmoji
            .OrderBy(item => Random.Shared.Next())
            .ToList();
    }
    protected override void OnInitialized()
    {
        SetUpGame();
    }
```

## Modify the @foreach loop to use the shuffled emoji

```razor
@foreach (var animal in shuffledAnimals)
```

## Add a click event handler method

```c#
string lastAnimalFound = string.Empty;
string lastDescription = string.Empty;
private void ButtonClick(string animal, string animalDescription)
{
    if (lastAnimalFound == string.Empty)
    {
        // First selection of the pair. Remember it.
        lastAnimalFound = animal;
        lastDescription = animalDescription;
    }
    else if ((lastAnimalFound == animal)
                && (animalDescription != lastDescription))
    {
        // Match found! Reset for next pair.
        lastAnimalFound = string.Empty;

        // Replace found animals with empty string to hide them.
        shuffledAnimals = shuffledAnimals
            .Select(a => a.Replace(animal, string.Empty))
            .ToList();
    }
    else
    {
        // User selected a pair that don't match, reset selection.
        lastAnimalFound = string.Empty;
    }
}
```

## Update the loop to add an @onclick event to each button

```razor
<div class="container">
    <div class="row">
        @for (var animalNumber = 0; 
              animalNumber < shuffledAnimals.Count; 
              animalNumber++)
        {
            var animal = shuffledAnimals[animalNumber];
            var uniqueDescription = 
                   $"Button #{animalNumber}";
            <div class="col-3">
                <button type="button" 
                @onclick="@(() => 
                    ButtonClick(animal, uniqueDescription))"
                class="btn btn-outline-dark">
                    <h1>@animal</h1>
                </button>
            </div>
        }
    </div>
</div>
```

## Add a field to keep track of the number of matches found

```c#
List<string> shuffledAnimals = new();
int matchesFound = 0;

private void SetUpGame()
{
    shuffledAnimals = animalEmoji
        .OrderBy(item => Random.Shared.Next())
        .ToList();
    matchesFound = 0;
}
```

## Modify ButtonClick to update the matchesFound field

```c#
        matchesFound++;
        if (matchesFound == 8)
        {
            SetUpGame();
        }
```

## Display the number of matches found

```razor
    <div class="row">
        <h2>Matches found: @matchesFound</h2>
    </div>
```

