// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

User _$UserFromJson(Map<String, dynamic> json) => User(
      user_id: (json['user_id'] as num?)?.toInt(),
      username: json['username'] as String?,
      email: json['email'] as String?,
      bio: json['bio'] as String?,
      profile_picture: json['profile_picture'] as String?,
      created_at: json['created_at'] as DateTime?,
      user_roles: (json['user_roles'] as List<dynamic>?)
          ?.map((e) => Role.fromJson(e as Map<String, dynamic>))
          .toList(),
      status: json['status'] as bool?,
    );

Map<String, dynamic> _$UserToJson(User instance) => <String, dynamic>{
      'user_id': instance.user_id,
      'username': instance.username,
      'email': instance.email,
      'bio': instance.bio,
      'profile_picture': instance.profile_picture,
      'created_at': instance.created_at,
      'user_roles': instance.user_roles,
      'status': instance.status,
    };
