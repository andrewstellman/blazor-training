var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/hello", () => "Hello world!");

app.MapGet("/random", () => RandomNumber.Value);

int TimesThree(int value)
{
    return value * 3;
}
app.MapGet("/times_three", TimesThree);

app.MapGet("/getobject", () => new { Value = 123, GhostSays = "Boo", Cow = "🐄" });

app.Run();

static class RandomNumber
{
    public static string Value
    {
        get
        {
            return Random.Shared.Next().ToString();
        }
    }
}