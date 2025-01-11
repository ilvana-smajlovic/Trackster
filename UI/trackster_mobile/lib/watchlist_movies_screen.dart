import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:trackster_mobile/providers/watchlist_movie_provider.dart';

class WatchlistMoviesScreen extends StatefulWidget {
  @override
  _WatchlistMoviesScreenState createState() => _WatchlistMoviesScreenState();
}

class _WatchlistMoviesScreenState extends State<WatchlistMoviesScreen> {
  String selectedTab = "Planning";

  @override
  Widget build(BuildContext context) {
    final watchlistProvider = Provider.of<WatchlistMovieProvider>(context);
    final movies = watchlistProvider.getMoviesByWatchState(selectedTab);

    return Scaffold(
      appBar: AppBar(
        title: Text('Your watchlist', style: TextStyle(color: Colors.white)),
        backgroundColor: Colors.deepPurple,
      ),
      body: Column(
        children: [
          // Tab bar for movie status
          Container(
            color: Colors.deepPurple[50],
            padding: const EdgeInsets.symmetric(vertical: 10, horizontal: 16),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                _buildTabButton(context, "Planning"),
                _buildTabButton(context, "Watching"),
                _buildTabButton(context, "Finished"),
              ],
            ),
          ),

          // Movie list
          /*Expanded(
            child: movies.isEmpty
                ? Center(
              child: Text(
                'No movies in this category!',
                style: TextStyle(fontSize: 18, color: Colors.grey),
              ),
            )
                : ListView.builder(
              itemCount: movies.length,
              itemBuilder: (context, index) {
                final movie = movies[index];
                return Card(
                  margin: EdgeInsets.symmetric(vertical: 8, horizontal: 16),
                  color: Colors.deepPurple[50],
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(10),
                  ),
                  child: ListTile(
                    leading: ClipRRect(
                      borderRadius: BorderRadius.circular(8),
                      child: Image.network(
                        movie.imageUrl,
                        width: 50,
                        height: 50,
                        fit: BoxFit.cover,
                      ),
                    ),
                    title: Text(
                      movie.title,
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Colors.deepPurple,
                      ),
                    ),
                    subtitle: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text('${movie.year} • ${movie.runtime} min'),
                        Row(
                          children: [
                            Icon(Icons.star, color: Colors.amber, size: 16),
                            SizedBox(width: 4),
                            Text(
                              movie.rating.toString(),
                              style: TextStyle(color: Colors.grey[700]),
                            ),
                          ],
                        ),
                      ],
                    ),
                  ),
                );
              },
            ),
          ),*/
        ],
      ),
    );
  }

  Widget _buildTabButton(BuildContext context, String label) {
    return GestureDetector(
      onTap: () {
        setState(() {
          selectedTab = label;
        });
      },
      child: Container(
        decoration: BoxDecoration(
          color: selectedTab == label ? Colors.deepPurple : Colors.white,
          borderRadius: BorderRadius.circular(20),
          border: Border.all(color: Colors.deepPurple),
        ),
        padding: const EdgeInsets.symmetric(vertical: 8, horizontal: 16),
        child: Text(
          label,
          style: TextStyle(
            color: selectedTab == label ? Colors.white : Colors.deepPurple,
            fontWeight: FontWeight.bold,
          ),
        ),
      ),
    );
  }
}
