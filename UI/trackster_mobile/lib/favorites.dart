import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:trackster_mobile/providers/favorites_provider.dart';

class FavoritesScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final favoritesProvider = Provider.of<FavoritesProvider>(context);

    return Scaffold(
      appBar: AppBar(
        title: Text('Favorites', style: TextStyle(color: Colors.white)),
        backgroundColor: Colors.deepPurple,
      ),
      body: Padding(
        padding: const EdgeInsets.all(8.0),
        child: favoritesProvider.favorites.isEmpty
            ? Center(
          child: Text(
            'No favorites added yet!',
            style: TextStyle(fontSize: 18, color: Colors.grey),
          ),
        )
            : ListView.builder(
          itemCount: favoritesProvider.favorites.length,
          itemBuilder: (context, index) {
            final favorite = favoritesProvider.favorites[index];

            return Card(
              margin: EdgeInsets.symmetric(vertical: 8),
              color: Colors.deepPurple[50],
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(10),
              ),
              child: ListTile(
                leading: ClipRRect(
                  borderRadius: BorderRadius.circular(8),
                  child: Image.network(
                    favorite.media!.picture!,
                    width: 50,
                    height: 50,
                    fit: BoxFit.cover,
                  ),
                ),
                title: Text(
                  favorite.media!.title!,
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    color: Colors.deepPurple,
                  ),
                ),
                subtitle: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(favorite.media!.release_date!.toString()),
                    /*if (favorite.alsoLikedBy.isNotEmpty)
                      Text(
                        'also by ${favorite.alsoLikedBy.join(", ")}',
                        style: TextStyle(fontSize: 12, color: Colors.grey[600]),
                      ),*/
                  ],
                ),
                /*trailing: IconButton(
                  icon: Icon(Icons.favorite, color: Colors.red),
                  onPressed: () {
                    favoritesProvider.removeFavorite(favorite);
                  },
                ),*/
              ),
            );
          },
        ),
      ),
    );
  }
}

