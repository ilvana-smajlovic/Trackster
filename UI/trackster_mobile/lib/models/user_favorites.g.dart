// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_favorites.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserFavorite _$UserFavoriteFromJson(Map<String, dynamic> json) => UserFavorite(
      favorite_id: (json['favorite_id'] as num?)?.toInt(),
      user: json['user'] == null
          ? null
          : User.fromJson(json['user'] as Map<String, dynamic>),
      media: json['media'] == null
          ? null
          : Media.fromJson(json['media'] as Map<String, dynamic>),
      added_at: json['added_at'] == null
          ? null
          : DateTime.parse(json['added_at'] as String),
    );

Map<String, dynamic> _$UserFavoriteToJson(UserFavorite instance) =>
    <String, dynamic>{
      'favorite_id': instance.favorite_id,
      'user': instance.user,
      'media': instance.media,
      'added_at': instance.added_at?.toIso8601String(),
    };
