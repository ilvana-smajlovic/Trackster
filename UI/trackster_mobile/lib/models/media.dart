import 'dart:ffi';

import 'package:trackster_mobile/models/genre.dart';
import 'package:trackster_mobile/models/language.dart';
import 'package:trackster_mobile/models/streaming_service.dart';
import 'package:json_annotation/json_annotation.dart';

part 'media.g.dart';

@JsonSerializable()
class Media {
  int? media_id;
  String? title;
  String? description;
  DateTime? release_date;
  String? status;
  double? rating;
  String? picture;
  String? backdrop;
  Language? language;
  StreamingService? streaming_service;
  bool? state;
  String? state_machine;

  Media({
    this.media_id,
    this.title,
    this.description,
    this.release_date,
    this.status,
    this.rating,
    this.picture,
    this.backdrop,
    this.language,
    this.streaming_service,
    this.state,
    this.state_machine,
  });

  factory Media.fromJson(Map<String, dynamic> json) => _$MediaFromJson(json);
  Map<String, dynamic> toJson() => _$MediaToJson(this);

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is Media &&
          runtimeType == other.runtimeType &&
          media_id == other.media_id;

  @override
  int get hashCode => media_id.hashCode;
}
