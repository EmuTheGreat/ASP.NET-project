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

app.Run();

public class Post
{
    /// <summary>
    /// A unique identifier for each post.
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// Post author ID.
    /// </summary>
    public uint AuthorId { get; set; }

    /// <summary>
    /// Post text.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Time of creation.
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// Number of likes.
    /// </summary>
    public uint LikeNumber { get; set; }
}
