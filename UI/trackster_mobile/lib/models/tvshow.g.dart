// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'tvshow.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TVShow _$TVShowFromJson(Map<String, dynamic> json) => TVShow(
      tvshow_id: (json['id'] as num?)?.toInt(),
      media: json['media'] as Media?,
      season_count: (json['season_count'] as num?)?.toInt(),
      episode_count: (json['episode_count'] as num?)?.toInt(),
      episode_runtime: (json['episode_runtime'] as num?)?.toInt(),
    );

Map<String, dynamic> _$TVShowToJson(TVShow instance) => <String, dynamic>{
      'tvshow_id': instance.tvshow_id,
      'media': instance.media,
      'season_count': instance.season_count,
      'episode_count': instance.episode_count,
      'episode_runtime': instance.episode_runtime,
    };
