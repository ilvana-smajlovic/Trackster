// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'movie.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Movie _$MovieFromJson(Map<String, dynamic> json) => Movie(
      movie_id: (json['id'] as num?)?.toInt(),
      media: json['title'] as Media?,
      runtime: (json['duration'] as num?)?.toInt(),
    );

Map<String, dynamic> _$MovieToJson(Movie instance) => <String, dynamic>{
      'movie_id': instance.movie_id,
      'media': instance.media,
      'runtime': instance.runtime,
    };
