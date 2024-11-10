using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackster.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrewRoles",
                columns: table => new
                {
                    crew_role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crew_role_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewRoles", x => x.crew_role_id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.person_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "StreamingServices",
                columns: table => new
                {
                    streaming_service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamingServices", x => x.streaming_service_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profile_picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    media_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<float>(type: "real", nullable: false),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    backdrop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    language_id = table.Column<int>(type: "int", nullable: false),
                    streaming_service_id = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: true),
                    state_machine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.media_id);
                    table.ForeignKey(
                        name: "FK_Media_Languages_language_id",
                        column: x => x.language_id,
                        principalTable: "Languages",
                        principalColumn: "language_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Media_StreamingServices_streaming_service_id",
                        column: x => x.streaming_service_id,
                        principalTable: "StreamingServices",
                        principalColumn: "streaming_service_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notification_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isSent = table.Column<bool>(type: "bit", nullable: false),
                    scheduled_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sent_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    token_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.token_id);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserFolllow",
                columns: table => new
                {
                    follow_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    follower_id = table.Column<int>(type: "int", nullable: false),
                    followed_user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFolllow", x => x.follow_id);
                    table.ForeignKey(
                        name: "FK_UserFolllow_Users_followed_user_id",
                        column: x => x.followed_user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserFolllow_Users_follower_id",
                        column: x => x.follower_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    preference_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.preference_id);
                    table.ForeignKey(
                        name: "FK_UserPreferences_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    user_role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    changed_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.user_role_id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_role_id",
                        column: x => x.role_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    session_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    login_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    logout_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ip_address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.session_id);
                    table.ForeignKey(
                        name: "FK_UserSessions_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MediaPersonRole",
                columns: table => new
                {
                    mediapersonrole_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    media_id = table.Column<int>(type: "int", nullable: false),
                    person_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    crew_role_id = table.Column<int>(type: "int", nullable: false),
                    character_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaPersonRole", x => x.mediapersonrole_id);
                    table.ForeignKey(
                        name: "FK_MediaPersonRole_CrewRoles_role_id",
                        column: x => x.role_id,
                        principalTable: "CrewRoles",
                        principalColumn: "crew_role_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MediaPersonRole_Media_media_id",
                        column: x => x.media_id,
                        principalTable: "Media",
                        principalColumn: "media_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MediaPersonRole_People_person_id",
                        column: x => x.person_id,
                        principalTable: "People",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MediaStatistics",
                columns: table => new
                {
                    statistic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    media_id = table.Column<int>(type: "int", nullable: false),
                    total_watch_time = table.Column<int>(type: "int", nullable: false),
                    last_watched_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaStatistics", x => x.statistic_id);
                    table.ForeignKey(
                        name: "FK_MediaStatistics_Media_media_id",
                        column: x => x.media_id,
                        principalTable: "Media",
                        principalColumn: "media_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MediaStatistics_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    movie_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    media_id = table.Column<int>(type: "int", nullable: false),
                    runtime = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.movie_id);
                    table.ForeignKey(
                        name: "FK_Movies_Media_media_id",
                        column: x => x.media_id,
                        principalTable: "Media",
                        principalColumn: "media_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    media_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    review_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isApproved = table.Column<bool>(type: "bit", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_Reviews_Media_media_id",
                        column: x => x.media_id,
                        principalTable: "Media",
                        principalColumn: "media_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TVShows",
                columns: table => new
                {
                    tvshow_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    media_id = table.Column<int>(type: "int", nullable: false),
                    season_count = table.Column<int>(type: "int", nullable: true),
                    episode_count = table.Column<int>(type: "int", nullable: true),
                    episode_runtime = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShows", x => x.tvshow_id);
                    table.ForeignKey(
                        name: "FK_TVShows_Media_media_id",
                        column: x => x.media_id,
                        principalTable: "Media",
                        principalColumn: "media_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    favorite_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    media_id = table.Column<int>(type: "int", nullable: false),
                    added_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.favorite_id);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Media_media_id",
                        column: x => x.media_id,
                        principalTable: "Media",
                        principalColumn: "media_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPreferencespreference_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.genre_id);
                    table.ForeignKey(
                        name: "FK_Genres_UserPreferences_UserPreferencespreference_id",
                        column: x => x.UserPreferencespreference_id,
                        principalTable: "UserPreferences",
                        principalColumn: "preference_id");
                });

            migrationBuilder.CreateTable(
                name: "WatchlistMovie",
                columns: table => new
                {
                    watclist_movie_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    movie_id = table.Column<int>(type: "int", nullable: false),
                    watch_state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: true),
                    added_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchlistMovie", x => x.watclist_movie_id);
                    table.ForeignKey(
                        name: "FK_WatchlistMovie_Movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "Movies",
                        principalColumn: "movie_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WatchlistMovie_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WatchlistTVShow",
                columns: table => new
                {
                    watchlist_tvshow_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    tvshow_id = table.Column<int>(type: "int", nullable: false),
                    watch_state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: true),
                    added_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchlistTVShow", x => x.watchlist_tvshow_id);
                    table.ForeignKey(
                        name: "FK_WatchlistTVShow_TVShows_tvshow_id",
                        column: x => x.tvshow_id,
                        principalTable: "TVShows",
                        principalColumn: "tvshow_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WatchlistTVShow_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GenreMedia",
                columns: table => new
                {
                    genremedia_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    media_id = table.Column<int>(type: "int", nullable: false),
                    genre_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMedia", x => x.genremedia_id);
                    table.ForeignKey(
                        name: "FK_GenreMedia_Genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "Genres",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GenreMedia_Media_media_id",
                        column: x => x.media_id,
                        principalTable: "Media",
                        principalColumn: "media_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMedia_genre_id",
                table: "GenreMedia",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMedia_media_id",
                table: "GenreMedia",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_UserPreferencespreference_id",
                table: "Genres",
                column: "UserPreferencespreference_id");

            migrationBuilder.CreateIndex(
                name: "IX_Media_language_id",
                table: "Media",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "IX_Media_streaming_service_id",
                table: "Media",
                column: "streaming_service_id");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPersonRole_media_id",
                table: "MediaPersonRole",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPersonRole_person_id",
                table: "MediaPersonRole",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_MediaPersonRole_role_id",
                table: "MediaPersonRole",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_MediaStatistics_media_id",
                table: "MediaStatistics",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_MediaStatistics_user_id",
                table: "MediaStatistics",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_media_id",
                table: "Movies",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_user_id",
                table: "Notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_media_id",
                table: "Reviews",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_user_id",
                table: "Reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_user_id",
                table: "Tokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_TVShows_media_id",
                table: "TVShows",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_media_id",
                table: "UserFavorites",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_user_id",
                table: "UserFavorites",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFolllow_followed_user_id",
                table: "UserFolllow",
                column: "followed_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFolllow_follower_id",
                table: "UserFolllow",
                column: "follower_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_user_id",
                table: "UserPreferences",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_role_id",
                table: "UserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_user_id",
                table: "UserRoles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_user_id",
                table: "UserSessions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistMovie_movie_id",
                table: "WatchlistMovie",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistMovie_user_id",
                table: "WatchlistMovie",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistTVShow_tvshow_id",
                table: "WatchlistTVShow",
                column: "tvshow_id");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistTVShow_user_id",
                table: "WatchlistTVShow",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMedia");

            migrationBuilder.DropTable(
                name: "MediaPersonRole");

            migrationBuilder.DropTable(
                name: "MediaStatistics");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "UserFolllow");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "WatchlistMovie");

            migrationBuilder.DropTable(
                name: "WatchlistTVShow");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "CrewRoles");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "TVShows");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "StreamingServices");
        }
    }
}
