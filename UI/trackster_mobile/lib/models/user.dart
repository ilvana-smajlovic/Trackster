import 'package:trackster_mobile/models/role.dart';
import 'package:json_annotation/json_annotation.dart';

part 'user.g.dart';

@JsonSerializable()
class User {
  int? user_id;
  String? username;
  String? email;
  String? bio;
  String? profile_picture;
  DateTime? created_at;
  List<Role>? user_roles;
  bool? status;

  User({
    this.user_id,
    this.username,
    this.email,
    this.bio,
    this.profile_picture,
    this.created_at,
    this.user_roles,
    this.status,
  });

  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);
  Map<String, dynamic> toJson() => _$UserToJson(this);

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is User &&
          runtimeType == other.runtimeType &&
          user_id == other.user_id;

  @override
  int get hashCode => user_id.hashCode;
}
