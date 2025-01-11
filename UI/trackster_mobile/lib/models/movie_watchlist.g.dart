// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'movie_watchlist.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

MovieWatchlist _$MovieWatchlistFromJson(Map<String, dynamic> json) =>
    MovieWatchlist(
      watclist_movie_id: (json['watclist_movie_id'] as num?)?.toInt(),
      user: json['user'] == null
          ? null
          : User.fromJson(json['user'] as Map<String, dynamic>),
      movie: json['movie'] == null
          ? null
          : Movie.fromJson(json['movie'] as Map<String, dynamic>),
      rating: (json['rating'] as num?)?.toInt(),
      watch_state: json['watch_state'] as String?,
      added_at: json['added_at'] == null
          ? null
          : DateTime.parse(json['added_at'] as String),
    );

Map<String, dynamic> _$MovieWatchlistToJson(MovieWatchlist instance) =>
    <String, dynamic>{
      'watclist_movie_id': instance.watclist_movie_id,
      'user': instance.user,
      'movie': instance.movie,
      'watch_state': instance.watch_state,
      'rating': instance.rating,
      'added_at': instance.added_at?.toIso8601String(),
    };
