import 'package:trackster_mobile/models/role.dart';
import 'package:json_annotation/json_annotation.dart';

part 'user.g.dart';

@JsonSerializable()
class User {
  int? user_id;
  String? username;
  String? email;
  String? password_hash;
  String? password_salt;
  String? bio;
  String? profile_picture;
  DateTime? created_at;
  int? role_id;
  Role? user_role;
  bool? status;

  User({
    this.user_id,
    this.username,
    this.email,
    this.bio,
    this.password_hash,
    this.password_salt,
    this.profile_picture,
    this.created_at,
    this.role_id,
    this.user_role,
    this.status,
  });

  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);
  Map<String, dynamic> toJson() => _$UserToJson(this);

  @override
  String toString() {
    return 'User(user_id: $user_id, username: $username, email: $email, '
        'bio: $bio, profile_picture: $profile_picture, created_at: $created_at, '
        'user_roles: $user_role, status: $status)';
  }

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is User &&
          runtimeType == other.runtimeType &&
          user_id == other.user_id;

  @override
  int get hashCode => user_id.hashCode;
}
