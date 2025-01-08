// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_favorites.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserFavorite _$UserFavoritesFromJson(Map<String, dynamic> json) => UserFavorite(
      favorite_id: (json['person_id'] as num?)?.toInt(),
      user: json['user'] as User?,
      media: json['media'] as Media?,
      added_at: json['created_at'] as DateTime?,
    );

Map<String, dynamic> _$UserFavoritesToJson(UserFavorite instance) =>
    <String, dynamic>{
      'favorite_id': instance.favorite_id,
      'user': instance.user,
      'media': instance.media,
      'added_at': instance.added_at,
    };
