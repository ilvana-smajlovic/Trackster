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
      birthday: json['birthday'] as DateTime?,
      picture: json['picture'] as String?,
      gender: json['gender'] as String?,
    );

Map<String, dynamic> _$PersonToJson(Person instance) => <String, dynamic>{
      'person_id': instance.person_id,
      'name': instance.name,
      'last_name': instance.last_name,
      'biography': instance.biography,
      'birthday': instance.birthday,
      'picture': instance.picture,
      'gender': instance.gender,
    };
