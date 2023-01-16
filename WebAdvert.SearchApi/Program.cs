using WebAdvert.SearchApi.Extensions;
using WebAdvert.SearchApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Extension ElasticSearch
builder.Services.AddElasticSearch(builder.Configuration);
builder.Services.AddTransient<ISearchService, SearchService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddAWSProvider(builder.Configuration.GetAWSLoggingConfigSection(),
    formatter:(logelvel, message, exception)=>$"[{DateTime.Now} {logelvel} {message} {exception?.Message}]");

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
