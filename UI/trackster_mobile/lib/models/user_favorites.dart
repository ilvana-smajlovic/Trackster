import 'package:json_annotation/json_annotation.dart';
import 'package:trackster_mobile/models/media.dart';
import 'package:trackster_mobile/models/user.dart';

part 'user_favorites.g.dart';

@JsonSerializable()
class UserFavorite {
  int? favorite_id;
  User? user;
  Media? media;
  DateTime? added_at;

  UserFavorite({this.favorite_id, this.user, this.media, this.added_at});

  factory UserFavorite.fromJson(Map<String, dynamic> json) =>
      _$UserFavoriteFromJson(json);
  Map<String, dynamic> toJson() => _$UserFavoriteToJson(this);

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is UserFavorite &&
          runtimeType == other.runtimeType &&
          favorite_id == other.favorite_id;

  @override
  int get hashCode => favorite_id.hashCode;
}
