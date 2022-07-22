# Part 1 - Digging into Blazor code

Here's all of the code that you can copy and paste for the My_First_Blazor_App project in Part 1. Each slide in the training deck has a corresponding section in this page.

The full code for this project can be found here: [My_First_Blazor_App](https://github.com/andrewstellman/blazor-training/tree/main/Code/My_First_Blazor_App)

## Spin up your first Blazor app

### Modify the code for the Counter page

Lines of code to add to Counter.razor:

```razor
<h4>Updated at @timestamp</h4>
```

```c#
private string timestamp = DateTime.Now.ToLongTimeString();
```

```c#
timestamp = DateTime.Now.ToLongTimeString();
```

Change the HTML markup to style the timestamp differently – try each of these:

```razor
<h4>Updated at @timestamp</h4>
<h2>Updated at @timestamp</h2>
<button class="btn btn-primary">
   Updated at @timestamp
</button>
<p>Updated at @timestamp</p>
```

### Add a component

```razor
@page "/controls"

### Add the component to the navigation menu

<PageTitle>Experiment with Controls</PageTitle>
```

```razor
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="controls">
                <span class="oi oi-list-rich" aria-hidden="true"></span> Controls
            </NavLink>
        </div>
```

### Add a field and an event handler method

```razor
@code {

    private string displayValue = "";

    private void UpdateValue(ChangeEventArgs e)
    {
        displayValue = e.Value.ToString();
    }

}
```

### Here’s the rest of the HTML code for the page

```razor
<div class="container">
    <div class="row">
      <h1>Experiment with controls</h1>
    </div>
    <div class="row mt-2">
       <div class="col">
          Enter text: 
       </div>
       <div class="col">
          <input type="text" class="form-control"
                 @onchange="UpdateValue"/>
       </div>
    </div>
    <div class="row mt-5">
       <h2>
          Here's the value: <strong>@displayValue</strong>
       </h2> 
    </div>
</div>
```


### Add a slider (or “range”) control to enter numbers

```razor
<div class="row mt-2">
    <div class="col">
        Pick a number: 
    </div>
    <div class="col">
        <input type="range" class="form-control"
         @onchange="UpdateNumericValue"/>
    </div>
</div>
```

### Add the event handler for the slider control

```razor
private void UpdateNumericValue(ChangeEventArgs e)
{
    if (int.TryParse(e.Value.ToString(), out int result))
    {
        displayValue = result.ToString();
    }
}
```
