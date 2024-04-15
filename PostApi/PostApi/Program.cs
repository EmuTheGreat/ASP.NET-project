using Dal;
using Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.TryAddLogic();
builder.Services.TryAddDal();

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

///// <summary>
///// Post or comment
///// </summary>
//public class Post
//{
//    /// <summary>
//    /// The id is individually calculated for each user's wall
//    /// </summary>
//    public uint Id { get; set; }
//    /// <summary>
//    /// The author id with the post id form the primary key
//    /// </summary>
//    public uint AuthorId { get; set; }
//    /// <summary>
//    /// creation time
//    /// </summary>
//    public DateTime Time { get; set; } 
//    /// <summary>
//    /// Post content
//    /// </summary>
//    public string Text { get; set; }
//    /// <summary>
//    /// Number of reposts
//    /// </summary>
//    public uint RepostCount { get; set; }
//    /// <summary>
//    /// Number of likes
//    /// </summary>
//    public uint LikeCount { get; set; }
//    /// <summary>
//    /// Number of views
//    /// </summary>
//    public uint ViewCount {  get; set; }
//    /// <summary>
//    /// (id, authorId) link to the parent post, if id == 0, it means an independent post, otherwise a comment
//    /// </summary>
//    public (uint, uint) Source {  get; set; }
    
//}

///// <summary>
///// Counter of the post on the wall
///// </summary>
//class PostCounter
//{
//    /// <summary>
//    /// Wall owner id
//    /// </summary>
//    public uint AuthorId { get; set; }

//    /// <summary>
//    /// Number of posts and comments on the wall
//    /// </summary>
//    public uint PostCount {  get; set; }
//}
