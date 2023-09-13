# Animal Matching Game (part 1)

Here's all of the code that you can copy and paste for the **first** part of the AnimalMatchingGame project in Part 2. Each slide in the training deck has a corresponding section in this page.

The full code for this project can be found here: [AnimalMatchingGame_part_1](https://github.com/andrewstellman/blazor-training/tree/main/Code/AnimalMatchingGame_part_1)

## Add a List of animal emoji to the page’s @code

```c#
@code {
    List<string> animalEmoji = new()
    {
        "🐶","🐶",
        "🐺","🐺",
        "🐮","🐮",
        "🦊","🦊",
        "🐱","🐱",
        "🦁","🦁",
        "🐯","🐯",
        "🐹","🐹",
    };
}
```

## Use a @foreach loop to add a button for each emoji

```razor
@page "/"

<PageTitle>Animal Matching Game</PageTitle>

<div class="container">
    <div class="row">
        @foreach (var animal in animalEmoji)
        {
            <div class="col-3">
                <button type="button"
                  class="btn btn-outline-dark">
                    <h1>@animal</h1>
                </button>
            </div>
        }
    </div>
</div>
```

## Use a <style> tag to include CSS styles in your page

```razor
<style> 
     .container {
        width: 400px;
    }
    button {
        width: 100px;
        height: 100px;
        font-size: 50px;
    }
</style>
```

