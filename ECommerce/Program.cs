using System.Reflection;
using ECommerce.Api.Middlewares;
using ECommerce.Application.Orders.GetOrder;
using ECommerce.Core.MessagingAdapter;
using ECommerce.Core.Validation;
using ECommerce.Domain.Context;
using MediatR;
using MediatR.Pipeline;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Compile Time - Service Registration
ConfigureServices(builder.Services);

var app = builder.Build();

// RunTime - Feature registration to services
Configure(app, app.Configuration);

await app.RunAsync();

static void ConfigureServices(IServiceCollection services)
{
    // Default
    services.AddOptions();
    services.AddMvc();
    services.AddRouting(options => options.LowercaseUrls = true);

    // DB Context
    services.AddDbContext<ApplicationDbContext>();

    // Swagger
    ConfigureSwagger(services);

    // MediatR
    services.AddMediatR(typeof(GetOrderQuery).Assembly);
    services.AddTransient(typeof(IRequestPreProcessor<>), typeof(CQRSValidationProcessor<>));
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));

    services.Scan(x => x.FromAssemblies(typeof(GetOrderQuery).Assembly)
        .AddClasses(x => x.AssignableTo(typeof(IBaseValidator<>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

    services.Scan(x => x.FromAssemblies(typeof(GetOrderQuery).Assembly)
        .AddClasses(y => y.AssignableTo(typeof(IBaseQueryHandler<,>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

    // Services
    services.AddScoped<ICQRSProcessor, CQRSProcessor>();
}

static void Configure(IApplicationBuilder app, IConfiguration configuration)
{
    // Default
    app.UseMiddleware<ExceptionMiddleware>();
    app.UseRouting();
    app.UseEndpoints(x =>
    {
        x.MapControllers();
    });

    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("./v1/swagger.json", "ECommerce API");
    });
}

static void ConfigureSwagger(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        options.CustomSchemaIds(i => i.FullName);
        options.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "ECommerce API",
                Version = "v1",
                Contact = new OpenApiContact(),
                Description = "",
            });

        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var commentsFileName = Assembly.GetEntryAssembly().GetName().Name + ".xml";
        var commentsFile = Path.Combine(baseDirectory, commentsFileName);

        if (File.Exists(commentsFile))
        {
            options.IncludeXmlComments(commentsFile);
        }
    });
}
