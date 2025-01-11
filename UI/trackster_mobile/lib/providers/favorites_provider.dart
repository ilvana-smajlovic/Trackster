import 'dart:convert';
import 'package:trackster_mobile/models/search_result.dart';
import 'package:trackster_mobile/models/user_favorites.dart';
import 'package:trackster_mobile/providers/base_provider.dart';
import 'package:trackster_mobile/providers/auth_provider.dart';
import 'package:http/http.dart' as http;

import '../models/media.dart';
import '../models/user.dart';


class FavoritesProvider extends BaseProvider<UserFavorite> {
  List<UserFavorite> favorites = [];
  bool _isLoading = false;

  bool get isLoading => _isLoading;

  UserFavorite? _selectedFavorites;

  UserFavorite? get selectedFavorites => _selectedFavorites;

  FavoritesProvider() : super("UserFavorite");

  @override
  UserFavorite fromJson(data) {
    return UserFavorite.fromJson(data);
  }

  // Fetch all media with the correct sub-route
  Future<List<UserFavorite>> getAllFavorites() async {
    _isLoading = true;
    notifyListeners(); // Notify listeners to trigger UI update (loading state)

    try {
      var result = await getAll(subRoute: "UserFavorites/GetList");
      favorites = result; // Store fetched media items
      _isLoading = false; // Set loading to false after data is fetched
      notifyListeners(); // Notify listeners again to update the UI
      return result;
    } catch (e) {
      _isLoading = false;
      notifyListeners();
      rethrow; // Re-throw error if fetching fails
    }
  }

  Future<void> addToFavorites(int? media_id) async {

    User user = AuthProvider.user!;

    final newFavorite = {
      'user_id': user.user_id,
      'media_id': media_id,
    };
    print("request before sent: $newFavorite");
    await insert("UserFavorites/Insert", newFavorite);
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
}