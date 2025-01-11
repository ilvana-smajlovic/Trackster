import 'dart:convert';
import 'package:trackster_mobile/models/media.dart';
import 'package:trackster_mobile/models/search_result.dart';
import 'package:trackster_mobile/providers/base_provider.dart';
import 'package:trackster_mobile/providers/auth_provider.dart';
import 'package:http/http.dart' as http;

import '../models/language.dart';
import '../models/streaming_service.dart';

class MediaProvider extends BaseProvider<Media> {
  List<Media> mediaItems = [];
  bool _isLoading = false;
  bool get isLoading => _isLoading;

  Media? _selectedMedia;
  Media? get selectedMedia => _selectedMedia;

  int _currentPage = 0;
  final int _pageSize = 10;
  bool _hasMore = true;

  MediaProvider() : super("Media");

  @override
  Media fromJson(data) {
    return Media.fromJson(data);
  }

  // Fetch all media with the correct sub-route
  Future<List<Media>> getAllMedia() async {
    _isLoading = true;
    notifyListeners(); // Notify listeners to trigger UI update (loading state)

    try {
      var result = await getAll(subRoute: "Media/GetList");
      mediaItems = result; // Store fetched media items
      _isLoading = false; // Set loading to false after data is fetched
      notifyListeners(); // Notify listeners again to update the UI
      return result;
    } catch (e) {
      _isLoading = false;
      notifyListeners();
      rethrow; // Re-throw error if fetching fails
    }
  }

  // Delete a movie by ID
  Future<void> deleteMovie(int id) async {
    await delete(id);
  }

  // Add a new movie
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

    await insert("Media/AddMedia", newMedia);
  }

  // Update existing media
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

  // Get media by ID
  Future<Media> getMediaById(int id) async {
    subRoute: "Media/GetById";
    _isLoading = true;
    notifyListeners();

    try {
      Media media = await super.getById("GetById", id);
      _selectedMedia = media;
      print("MEDIA: -> $media");
      return media;  // Ensure the return type is consistent
    } catch (e) {
      _selectedMedia = null;
      return Future.value(null); // Return null wrapped in a Future
    } finally {
      _isLoading = false;
      notifyListeners();
    }
  }

  // Fetch media recommendations
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

  // Helper function to get headers (authentication)
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
}
