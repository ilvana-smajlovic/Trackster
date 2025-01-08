// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'media.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Media _$MediaFromJson(Map<String, dynamic> json) => Media(
      media_id: (json['media_id'] as num?)?.toInt(),
      title: json['title'] as String?,
      description: json['description'] as String?,
      release_date: json['release_date'] as DateTime?,
      status: json['status'] as String?,
      rating: (json['rating'] as num?)?.toDouble(),
      picture: json['picture'] as String?,
      backdrop: json['backdrop'] as String?,
      language: (json['language'] as Language),
      streaming_service: (json['streaming_service'] as StreamingService),
      state: json['state'] as Bool?,
      state_machine: json['state_machine'] as String?,
    );

Map<String, dynamic> _$MediaToJson(Media instance) => <String, dynamic>{
      'media_id': instance.media_id,
      'title': instance.title,
      'description': instance.description,
      'release_date': instance.release_date,
      'status': instance.status,
      'rating': instance.rating,
      'picture': instance.picture,
      'backdrop': instance.backdrop,
      'language': instance.language,
      'streaming_service': instance.streaming_service,
      'state': instance.state,
      'state_machine': instance.state_machine,
    };
