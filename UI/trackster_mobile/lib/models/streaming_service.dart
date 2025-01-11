import 'package:json_annotation/json_annotation.dart';

part 'streaming_service.g.dart';

@JsonSerializable()
class StreamingService {
  int? streaming_service_id;
  String? service_name;
  String? url;

  StreamingService({this.streaming_service_id, this.service_name, this.url});

  factory StreamingService.fromJson(Map<String, dynamic> json) =>
      _$StreamingServiceFromJson(json);
  Map<String, dynamic> toJson() => _$StreamingServiceToJson(this);

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is StreamingService &&
          runtimeType == other.runtimeType &&
          streaming_service_id == other.streaming_service_id;

  @override
  int get hashCode => streaming_service_id.hashCode;
}
