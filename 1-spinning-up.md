# Part 1 - Digging into Blazor code

Here's all of the code that you can copy and paste for the My_First_Blazor_App project in Part 1. Each slide in the training deck has a corresponding section in this page.

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
