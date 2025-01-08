import 'package:json_annotation/json_annotation.dart';
import 'package:trackster_mobile/models/media.dart';
import 'package:trackster_mobile/models/user.dart';

part 'review.g.dart';

@JsonSerializable()
class Review {
  int? review_id;
  User? user;
  Media? media;
  int? rating;
  String? review_text;
  bool? isApproved;
  DateTime? created_at;

  Review(
      {this.review_id,
      this.user,
      this.media,
      this.rating,
      this.review_text,
      this.isApproved,
      this.created_at});

  factory Review.fromJson(Map<String, dynamic> json) => _$ReviewFromJson(json);
  Map<String, dynamic> toJson() => _$ReviewToJson(this);

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is Review &&
          runtimeType == other.runtimeType &&
          review_id == other.review_id;

  @override
  int get hashCode => review_id.hashCode;
}
