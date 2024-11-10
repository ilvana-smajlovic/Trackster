using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;
using Trackster.API;
using Trackster.Repository;
using Trackster.Services;
using Trackster.Services.MediaStateMachine;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ICrewRoleService, CrewRoleService>();
builder.Services.AddTransient<IGenreMediaService, GenreMediaService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<ILanguageService, LanguageService>();
builder.Services.AddTransient<IMediaPersonRoleService, MediaPersonRoleService>();
builder.Services.AddTransient<IMediaService, MediaService>();
builder.Services.AddTransient<IMediaStatisticsService, MediaStatisticsService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IStreamingServiceService, StreamingServiceService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<ITVShowService, TVShowService>();
builder.Services.AddTransient<IUserFavoritesService, UserFavoritesService>();
builder.Services.AddTransient<IUserFollowService, UserFollowService>();
builder.Services.AddTransient<IUserPreferenceService, UserPreferenceService>();
builder.Services.AddTransient<IUserRoleService, UserRoleService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserSessionService, UserSessionService>();
builder.Services.AddTransient<IWatchlistMovieService, WatchlistMovieService>();
builder.Services.AddTransient<IWatchlistTVShowService, WatchlistTVShowService>();

builder.Services.AddTransient<BaseMediaState>();
builder.Services.AddTransient<InitialMediaState>();
builder.Services.AddTransient<DraftMediaState>();
builder.Services.AddTransient<ActiveMediaState>();
builder.Services.AddTransient<HiddenMediaState>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme, Id = "basicAuth"}
            },
            new string[]{}
    } });
});

builder.Services.AddDbContext<TracksterContext>(
    dbContext => dbContext.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddMapster();
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

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
