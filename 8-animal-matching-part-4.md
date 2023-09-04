# Animal Matching Game (part 4)

Here's all of the code that you can copy and paste for the AnimalMatchingGame_Server project in Part 4, going full stack. Each slide in the training deck has a corresponding section in this page.

The full code for this project can be found here: [AnimalMatchingGame_Server](https://github.com/andrewstellman/blazor-training/tree/main/Code/AnimalMatchingGame_Server)

## The difference between a Blazor Web App and a WebAssembly App in an nutshell

```razor
<h1>Does this value change? ➡️ @value</h1>
@code {
    int value = MyValue.Value;

    public static class MyValue
    {
        private static int i = 1;
        public static int Value => ++i;
    }
}
```

## Add Swagger to your ASP.NET Core Blazor Server app

```c#
app.MapGet("/hello",
     () => "Hello world!");
```

```c#
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

## Create an HTTP client and inject it into your Blazor app

```c#
builder.Services.AddHttpClient();

var baseUrls = builder.WebHost
       .GetSetting(WebHostDefaults.ServerUrlsKey);
var baseUrl = (baseUrls ?? "").Split(";").First();
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(baseUrl)
    });

var app = builder.Build();
```

## Add a class to track the best score

```c#
public static class ScoreTracker
{
    public static float LowestScore { get; set; } = 0;

    public static string SubmitScore(float score)
    {
        if ((LowestScore == 0) || (score < LowestScore))
        {
            LowestScore = score;
            return "You got the best time!";
        }
        else
            return string.Empty;
    }
}
```

```c#
app.MapGet("/scoretracker", ScoreTracker.SubmitScore);
```

## Update Index.razor to display the message and start updating the code

```razor
@if(!string.IsNullOrEmpty(bestTimeMessage))
{
    <h1>@bestTimeMessage</h1>
}
@if (ScoreTracker.LowestScore > 0)
{
    <h3>Best score: @ScoreTracker.LowestScore</h3>
}
```

```razor
@inject HttpClient Http

@code {

    string bestTimeMessage = string.Empty;
```

## Make your button’s @onclick event handler call the API

```c#
private async Task ButtonClick(string animal, string animalDescription)
```

```c#
// First selection of the pair. Remember it.
bestTimeMessage = string.Empty;
```

```c#
if (matchesFound == 8)
{
    bestTimeMessage = await Http.GetStringAsync($"/scoretracker?score={tenthsOfSecondsElapsed / 10F}");
```

## Make your button’s @onclick event call an asynchronous method

```razor
   @onclick="@(async () => await ButtonClick(animal, uniqueDescription))"
```


