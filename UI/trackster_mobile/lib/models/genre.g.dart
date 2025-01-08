// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'genre.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Genre _$GenreFromJson(Map<String, dynamic> json) => Genre(
      genre_id: (json['genre_id'] as num?)?.toInt(),
      genre_name: json['genre_name'] as String?,
    );

Map<String, dynamic> _$GenreToJson(Genre instance) => <String, dynamic>{
      'genre_id': instance.genre_id,
      'genre_name': instance.genre_name,
    };
