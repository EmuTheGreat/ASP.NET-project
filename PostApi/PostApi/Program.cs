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
    /// Уникальный индентификатор для каждого поста.
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// Идентификатор автора поста.
    /// </summary>
    public uint AuthorId { get; set; }

    /// <summary>
    /// Текст поста.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Время создания.
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// Кол-во лайков.
    /// </summary>
    public uint LikeNumber { get; set; }
}
