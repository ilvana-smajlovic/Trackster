import 'dart:convert';
import 'package:flutter/cupertino.dart';
import 'package:provider/provider.dart';
import 'package:trackster_mobile/models/movie_watchlist.dart';
import 'package:trackster_mobile/providers/base_provider.dart';
import 'package:trackster_mobile/providers/auth_provider.dart';
import 'package:http/http.dart' as http;
import 'package:trackster_mobile/providers/movie_provider.dart';

import '../models/movie.dart';
import '../models/user.dart';


class WatchlistMovieProvider extends BaseProvider<MovieWatchlist> {
  List<MovieWatchlist> favorites = [];
  bool _isLoading = false;

  bool get isLoading => _isLoading;

  MovieWatchlist? _selectedMovies;

  MovieWatchlist? get selectedMovies => _selectedMovies;

  WatchlistMovieProvider() : super("MovieWatchlist");

  @override
  MovieWatchlist fromJson(data) {
    return MovieWatchlist.fromJson(data);
  }

  // Fetch all media with the correct sub-route
  Future<List<MovieWatchlist>> getAllWatchlistMovies() async {
    _isLoading = true;
    notifyListeners(); // Notify listeners to trigger UI update (loading state)

    try {
      var result = await getAll(subRoute: "WatchlistMovie/GetList");
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

  Future<List<MovieWatchlist>> getMoviesByWatchState(String state) async {
    _isLoading = true;
    notifyListeners(); // Notify listeners to trigger UI update (loading state)

    try {
      var result = await getAll(subRoute: "WatchlistMovie/GetList");
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

  Future<void> addToWatchlist(BuildContext context, int? media_id) async {
    final movieProvider = Provider.of<MovieProvider>(context, listen: false);
    List<Movie> movies = await movieProvider.getAllMovies();

    Movie? selectedMovie = movies.firstWhere(
            (movie) => movie.movie_id == media_id);
    print("movie in prov: $selectedMovie");
    User user = AuthProvider.user!;

    final newMovie = {
      "user_id": user.user_id,
      "movie_id": selectedMovie.movie_id,
      "watch_state": "Planning",
      "rating": 0
    };
    print("request before sent: $newMovie");
    await insert("WatchlistMovie/Insert", newMovie);
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