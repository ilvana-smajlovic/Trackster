// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'movie_watchlist.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

MovieWatchlist _$MovieWatchlistFromJson(Map<String, dynamic> json) =>
    MovieWatchlist(
      watclist_movie_id: (json['watclist_movie_id'] as num?)?.toInt(),
      user: json['user'] as User?,
      movie: json['movie'] as Movie?,
      rating: (json['rating'] as num?)?.toInt(),
      watch_state: json['watch_state'] as String?,
      added_at: json['added_at'] as DateTime?,
    );

Map<String, dynamic> _$MovieWatchlistToJson(MovieWatchlist instance) =>
    <String, dynamic>{
      'watclist_movie_id': instance.watclist_movie_id,
      'user': instance.user,
      'movie': instance.movie,
      'rating': instance.rating,
      'watch_state': instance.watch_state,
      'added_at': instance.added_at,
    };
