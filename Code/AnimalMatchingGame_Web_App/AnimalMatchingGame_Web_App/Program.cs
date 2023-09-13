using AnimalMatchingGame_Web_App;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddServerComponents();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorComponents<App>();

app.MapGet("/hello",
     () => "Hello world!");

app.MapGet("/scoretracker", ScoreTracker.SubmitScore);

app.Run();
