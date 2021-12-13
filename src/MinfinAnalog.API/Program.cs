using MinfinAnalog.Data;
using Serilog;
using Serilog.Events;
using AutoMapper;
using MinfinAnalog.Domain.Mapping;
using MinfinAnalog.Domain.Interfaces;
using MinfinAnalog.Data.Repositories;
using MinfinAnalog.Domain.Services;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    // remove default logging providers
    builder.Logging.ClearProviders();
    // register Serilog
    builder.Logging.AddSerilog(Log.Logger);
    ConfigureServices(builder.Services, builder.Configuration.GetConnectionString("Default"));

    Log.Information("Starting web host");
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    Configure(app, app.Environment);

    app.MapControllers();

    app.Run();

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}

// This method gets called by the runtime. Use this method to add services to the container.
static void ConfigureServices(IServiceCollection services, string connectionString)
{
    services.AddControllers();

    services.AddDbContext(connectionString);
    // Add services to the container.
    var mappingConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new UserProfile());
    });

    IMapper mapper = mappingConfig.CreateMapper();
    services.AddSingleton(mapper);
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IUserService, UserService>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();

    app.UseAuthorization();



}