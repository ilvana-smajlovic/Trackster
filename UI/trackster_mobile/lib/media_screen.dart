import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:trackster_mobile/providers/favorites_provider.dart';
import 'package:trackster_mobile/providers/media_provider.dart';
import 'package:trackster_mobile/providers/watchlist_movie_provider.dart';

class MediaScreen extends StatefulWidget {
  final int mediaId;

  const MediaScreen({required this.mediaId});

  @override
  _MediaScreenState createState() => _MediaScreenState();
}

class _MediaScreenState extends State<MediaScreen> {
  @override
  void initState() {
    super.initState();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      Provider.of<MediaProvider>(context, listen: false)
          .getMediaById(widget.mediaId);
      }
    );
  }

  @override
  Widget build(BuildContext context) {
    final mediaProvider = Provider.of<MediaProvider>(context);
    final favoritesProvider = Provider.of<FavoritesProvider>(context);
    final watchlistMovieProvider = Provider.of<WatchlistMovieProvider>(context);
    final mediaDetails = mediaProvider.selectedMedia;

    return Scaffold(
      appBar: AppBar(
        backgroundColor: const Color(0xFF4E3A6A),
        elevation: 0,
        leading: IconButton(
          icon: const Icon(Icons.menu),
          onPressed: () {},
        ),
        title: TextField(
          decoration: InputDecoration(
            hintText: 'Search',
            filled: true,
            fillColor: Colors.white.withOpacity(0.2),
            prefixIcon: const Icon(Icons.search, color: Colors.white),
            border: OutlineInputBorder(
              borderRadius: BorderRadius.circular(30),
              borderSide: BorderSide.none,
            ),
          ),
        ),
      ),
      body: mediaProvider.isLoading
          ? const Center(child: CircularProgressIndicator())
          : mediaDetails == null
          ? const Center(child: Text('Media details not found.'))
          : SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Stack(
              children: [
                Image.network(
                  mediaDetails.backdrop!,
                  width: double.infinity,
                  height: 200,
                  fit: BoxFit.cover,
                ),
                Positioned(
                  left: 16,
                  top: 120,
                  child: Image.network(
                    mediaDetails.picture!,
                    height: 100,
                    width: 70,
                    fit: BoxFit.cover,
                  ),
                ),
              ],
            ),
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  /*Row(
                    children: mediaDetails.genres
                        .map((genre) => Container(
                      margin:
                      const EdgeInsets.only(right: 8),
                      padding: const EdgeInsets.symmetric(
                          horizontal: 12, vertical: 6),
                      decoration: BoxDecoration(
                        color: Colors.purple.shade800,
                        borderRadius:
                        BorderRadius.circular(20),
                      ),
                      child: Text(
                        genre,
                        style: const TextStyle(
                          color: Colors.white,
                          fontSize: 12,
                        ),
                      ),
                    ))
                        .toList(),
                  ),*/
                  const SizedBox(height: 8),
                  Row(
                    mainAxisAlignment:
                    MainAxisAlignment.spaceBetween,
                    children: [
                      Row(
                        children: [
                          const Icon(Icons.star,
                              color: Colors.yellow, size: 18),
                          const SizedBox(width: 4),
                          Text(
                            '${mediaDetails.rating}',
                            style: const TextStyle(
                                fontWeight: FontWeight.bold),
                          ),
                        ],
                      ),
                      Row(
                        children: [
                          IconButton(
                            icon: const Icon(Icons.favorite_border,
                                color: Colors.red),
                            onPressed: () {
                              // Call addToFavorites when the heart icon is pressed
                              favoritesProvider.addToFavorites(
                                mediaDetails.media_id
                              );
                            },
                          ),
                          IconButton(
                            icon: const Icon(Icons.bookmark_border,
                                color: Colors.white),
                            onPressed: () {
                              watchlistMovieProvider.addToWatchlist(context,
                                  mediaDetails.media_id);
                            },
                          ),
                        ],
                      ),
                    ],
                  ),
                  const SizedBox(height: 16),
                  Text(
                    '${mediaDetails.title} (${mediaDetails.release_date})',
                    style: const TextStyle(
                      fontSize: 22,
                      fontWeight: FontWeight.bold,
                      color: Colors.white,
                    ),
                  ),
                  const SizedBox(height: 8),
                  Text(
                    mediaDetails.description!,
                    style: const TextStyle(fontSize: 14),
                  ),
                  const Divider(color: Colors.white, height: 30),
                  Text(
                    'Creators',
                    style: const TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 16,
                      color: Colors.white,
                    ),
                  ),
                  const SizedBox(height: 8),
                  /*Row(
                    children: mediaDetails.creators
                        .map<Widget>((creator) => Expanded(
                      child: Column(
                        children: [
                          Text(
                            creator.name,
                            textAlign: TextAlign.center,
                            style: const TextStyle(
                                fontWeight: FontWeight.bold),
                          ),
                          Text(creator.role),
                        ],
                      ),
                    ))
                        .toList(),
                  ),
                  const Divider(color: Colors.white, height: 30),
                  Text(
                    'Cast and Crew',
                    style: const TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 16,
                      color: Colors.white,
                    ),
                  ),
                  const SizedBox(height: 8),
                  SizedBox(
                    height: 100,
                    child: ListView.builder(
                      scrollDirection: Axis.horizontal,
                      itemCount: mediaDetails.cast.length,
                      itemBuilder: (context, index) {
                        final cast = mediaDetails.cast[index];
                        return Container(
                          width: 80,
                          margin: const EdgeInsets.only(right: 8),
                          child: Column(
                            children: [
                              ClipRRect(
                                borderRadius:
                                BorderRadius.circular(8),
                                child: Image.network(
                                  cast.picture,
                                  height: 60,
                                  width: 60,
                                  fit: BoxFit.cover,
                                ),
                              ),
                              const SizedBox(height: 4),
                              Text(
                                cast.name,
                                textAlign: TextAlign.center,
                                style: const TextStyle(fontSize: 12),
                                maxLines: 1,
                                overflow: TextOverflow.ellipsis,
                              ),
                            ],
                          ),
                        );
                      },
                    ),
                  )*/
                  const Divider(color: Colors.white, height: 30),
                  Center(
                    child: ElevatedButton(
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.purple.shade800,
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(20),
                        ),
                      ),
                      onPressed: () {
                        // Open trailer link
                      },
                      child: const Text('Watch Trailer'),
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
