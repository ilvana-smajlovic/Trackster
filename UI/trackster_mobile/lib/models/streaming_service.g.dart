// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'streaming_service.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

StreamingService _$StreamingServiceFromJson(Map<String, dynamic> json) =>
    StreamingService(
      streaming_service_id: (json['streaming_service_id'] as num?)?.toInt(),
      service_name: json['service_name'] as String?,
      url: json['url'] as String?,
    );

Map<String, dynamic> _$StreamingToJson(StreamingService instance) =>
    <String, dynamic>{
      'streaming_service_id': instance.streaming_service_id,
      'service_name': instance.service_name,
      'url': instance.url,
    };
