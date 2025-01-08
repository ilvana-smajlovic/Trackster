import 'package:json_annotation/json_annotation.dart';
import 'package:trackster_mobile/models/media.dart';

part 'tvshow.g.dart';

@JsonSerializable()
class TVShow {
  int? tvshow_id;
  Media? media;
  int? season_count;
  int? episode_count;
  int? episode_runtime;

  TVShow(
      {this.tvshow_id,
      this.media,
      this.season_count,
      this.episode_count,
      this.episode_runtime});

  factory TVShow.fromJson(Map<String, dynamic> json) => _$TVShowFromJson(json);
  Map<String, dynamic> toJson() => _$TVShowToJson(this);

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is TVShow &&
          runtimeType == other.runtimeType &&
          tvshow_id == other.tvshow_id;

  @override
  int get hashCode => tvshow_id.hashCode;
}
