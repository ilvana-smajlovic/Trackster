// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'review.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Review _$ReviewFromJson(Map<String, dynamic> json) => Review(
      review_id: (json['review_id'] as num?)?.toInt(),
      user: json['user'] == null
          ? null
          : User.fromJson(json['user'] as Map<String, dynamic>),
      media: json['media'] == null
          ? null
          : Media.fromJson(json['media'] as Map<String, dynamic>),
      rating: (json['rating'] as num?)?.toInt(),
      review_text: json['review_text'] as String?,
      isApproved: json['isApproved'] as bool?,
      created_at: json['created_at'] == null
          ? null
          : DateTime.parse(json['created_at'] as String),
    );

Map<String, dynamic> _$ReviewToJson(Review instance) => <String, dynamic>{
      'review_id': instance.review_id,
      'user': instance.user,
      'media': instance.media,
      'rating': instance.rating,
      'review_text': instance.review_text,
      'isApproved': instance.isApproved,
      'created_at': instance.created_at?.toIso8601String(),
    };
