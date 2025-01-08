import 'dart:convert';
import 'package:trackster_mobile/models/language.dart';
import 'package:trackster_mobile/models/streaming_service.dart';
import 'package:trackster_mobile/providers/auth_provider.dart';
import 'package:http/http.dart' as http;

import 'package:trackster_mobile/models/genre.dart';
import 'package:trackster_mobile/models/media.dart';
import 'package:trackster_mobile/models/search_result.dart';
import 'package:trackster_mobile/providers/base_provider.dart';

class MediaProvider extends BaseProvider<Media> {
  MediaProvider() : super("Media");

  @override
  Media fromJson(data) {
    return Media.fromJson(data);
  }

  Future<SearchResult<Media>> getMedia({String? fts}) async {
    var filter = {
      'IsGenreIncluded': 'true',
    };
    if (fts != null && fts.isNotEmpty) {
      filter['fts'] = fts;
    }
    return await get(filter: filter);
  }

  Future<List<Media>> getAllMedia() async {
    return await getAll();
  }

  Future<void> deleteMovie(int id) async {
    await delete(id);
  }

  Future<void> addMovie(
    String? title,
    String? description,
    DateTime? release_date,
    String? status,
    double? rating,
    String? picture,
    String? backdrop,
    Language? language,
    StreamingService? streaming_service,
    bool? state,
    String? state_machine,
  ) async {
    final newMedia = {
      'title': title,
      'description': description,
      'release_date': release_date,
      'status': status,
      'rating': rating,
      'picture': picture,
      'backdrop': backdrop,
      'language': language,
      'streaming_service': streaming_service,
      'state': state,
      'state_machine': state_machine,
    };

    await insert(newMedia);
  }

  Future<void> updateMedia(
    int media_id,
    String? title,
    String? description,
    DateTime? release_date,
    String? status,
    double? rating,
    String? picture,
    String? backdrop,
    Language? language,
    StreamingService? streaming_service,
    bool? state,
    String? state_machine,
  ) async {
    final updatedMedia = {
      'media_id': media_id,
      'title': title,
      'description': description,
      'release_date': release_date,
      'status': status,
      'rating': rating,
      'picture': picture,
      'backdrop': backdrop,
      'language': language,
      'streaming_service': streaming_service,
      'state': state,
      'state_machine': state_machine,
    };

    await update(media_id, updatedMedia);
  }

  @override
  Future<Media> getById(int id) async {
    Media media = await super.getById(id);
    return media;
  }

  Future<Map<String, String>> getHeaders() async {
    final headers = {
      'Content-Type': 'application/json',
    };

    if (AuthProvider.username != null && AuthProvider.password != null) {
      final credentials = base64Encode(
        utf8.encode('${AuthProvider.username}:${AuthProvider.password}'),
      );
      headers['Authorization'] = 'Basic $credentials';
    }

    return headers;
  }

  Future<List<Media>> getRecommendations(int mediaId) async {
    try {
      final url = Uri.parse('$baseUrl$endpoint/$mediaId/recommendations');
      final headers = await getHeaders();
      final response = await http.get(url, headers: headers);

      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);

        return data.map((item) => Media.fromJson(item)).toList();
      } else {
        throw Exception(
            'Failed to fetch recommendations: ${response.statusCode} - ${response.body}');
      }
    } catch (e) {
      rethrow;
    }
  }
}
