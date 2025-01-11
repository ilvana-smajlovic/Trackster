import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:trackster_mobile/providers/favorites_provider.dart';
import 'package:trackster_mobile/providers/media_provider.dart';
import 'package:trackster_mobile/providers/watchlist_movie_provider.dart';

import 'home_screen.dart';
import 'login.dart';

void main() {
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => MediaProvider()),
      ChangeNotifierProvider(create: (_) => FavoritesProvider()),
      ChangeNotifierProvider(create: (_) => WatchlistMovieProvider()),
    ],
    child: MyApp(),
    ),
  );
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ChangeNotifierProvider(
      create: (context) => MediaProvider(),
      child: MaterialApp(
        initialRoute: '/login',
        routes: {
          '/login': (context) => LoginScreen(),
          '/home': (context) => HomeScreen(),  // HomeScreen needs to be defined
        },
      ),
    );
  }
}