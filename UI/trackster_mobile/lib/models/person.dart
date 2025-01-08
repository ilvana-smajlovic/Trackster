import 'package:json_annotation/json_annotation.dart';

part 'person.g.dart';

@JsonSerializable()
class Person {
  int? person_id;
  String? name;
  String? last_name;
  DateTime? birthday;
  String? biography;
  String? picture;
  String? gender;

  Person(
      {this.person_id,
      this.name,
      this.last_name,
      this.biography,
      this.birthday,
      this.picture,
      this.gender});

  factory Person.fromJson(Map<String, dynamic> json) => _$PersonFromJson(json);
  Map<String, dynamic> toJson() => _$PersonToJson(this);

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is Person &&
          runtimeType == other.runtimeType &&
          person_id == other.person_id;

  @override
  int get hashCode => person_id.hashCode;
}
