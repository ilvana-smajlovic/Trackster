import 'package:json_annotation/json_annotation.dart';
import 'package:trackster_mobile/models/media.dart';

part 'movie.g.dart';

@JsonSerializable()
class Movie {
  int? movie_id;
  Media? media;
  int? runtime;

  Movie({this.movie_id, this.media, this.runtime});

  factory Movie.fromJson(Map<String, dynamic> json) => _$MovieFromJson(json);
  Map<String, dynamic> toJson() => _$MovieToJson(this);

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is Movie &&
          runtimeType == other.runtimeType &&
          movie_id == other.movie_id;

  @override
  int get hashCode => movie_id.hashCode;
}
