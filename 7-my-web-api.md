# My_Web_API project

Here's all of the code that you can copy and paste for the My_Web_API project. Each slide in the training deck has a corresponding section in this page.

## Add a “Hello, world!” endpoint

```c#
app.MapGet("/hello",
     () => "Hello world!");
```

## Your APIs can take parameters

```c#
int TimesThree(int value)
{
    return value * 3;
}

app.MapGet("/times_three", TimesThree);
```

## .NET Minimal APIs make it easy to create API endpoints

```c#
app.MapGet("/getobject", () =>
    new { Value = 123, GhostSays = "Boo", Cow = "🐄" });
```
