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
      password_hash: json['password_hash'] as String?,
      password_salt: json['password_salt'] as String?,
      profile_picture: json['profile_picture'] as String?,
      created_at: json['created_at'] == null
          ? null
          : DateTime.parse(json['created_at'] as String),
      role_id: (json['role_id'] as num?)?.toInt(),
      user_role: json['user_role'] == null
          ? null
          : Role.fromJson(json['user_role'] as Map<String, dynamic>),
      status: json['status'] as bool?,
    );

Map<String, dynamic> _$UserToJson(User instance) => <String, dynamic>{
      'user_id': instance.user_id,
      'username': instance.username,
      'email': instance.email,
      'password_hash': instance.password_hash,
      'password_salt': instance.password_salt,
      'bio': instance.bio,
      'profile_picture': instance.profile_picture,
      'created_at': instance.created_at?.toIso8601String(),
      'role_id': instance.role_id,
      'user_role': instance.user_role,
      'status': instance.status,
    };
