import 'package:json_annotation/json_annotation.dart';
import 'package:trackster_mobile/models/movie.dart';
import 'package:trackster_mobile/models/user.dart';

part 'movie_watchlist.g.dart';

@JsonSerializable()
class MovieWatchlist {
  int? watclist_movie_id;
  User? user;
  Movie? movie;
  String? watch_state;
  int? rating;
  DateTime? added_at;

  MovieWatchlist(
      {this.watclist_movie_id,
      this.user,
      this.movie,
      this.rating,
      this.watch_state,
      this.added_at});

  factory MovieWatchlist.fromJson(Map<String, dynamic> json) =>
      _$MovieWatchlistFromJson(json);
  Map<String, dynamic> toJson() => _$MovieWatchlistToJson(this);

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is MovieWatchlist &&
          runtimeType == other.runtimeType &&
          watclist_movie_id == other.watclist_movie_id;

  @override
  int get hashCode => watclist_movie_id.hashCode;
}
