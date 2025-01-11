// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'person.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Person _$PersonFromJson(Map<String, dynamic> json) => Person(
      person_id: (json['person_id'] as num?)?.toInt(),
      name: json['name'] as String?,
      last_name: json['last_name'] as String?,
      biography: json['biography'] as String?,
      birthday: json['birthday'] == null
          ? null
          : DateTime.parse(json['birthday'] as String),
      picture: json['picture'] as String?,
      gender: json['gender'] as String?,
    );

Map<String, dynamic> _$PersonToJson(Person instance) => <String, dynamic>{
      'person_id': instance.person_id,
      'name': instance.name,
      'last_name': instance.last_name,
      'birthday': instance.birthday?.toIso8601String(),
      'biography': instance.biography,
      'picture': instance.picture,
      'gender': instance.gender,
    };
