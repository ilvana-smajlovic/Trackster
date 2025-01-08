import 'package:flutter/material.dart';

class MediaScreen extends StatelessWidget {
  final Map<String, dynamic> mediaDetails;

  const MediaScreen({required this.mediaDetails});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(mediaDetails['title']),
        backgroundColor: const Color(0xFF81689D),
      ),
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            // Banner with poster overlay
            Stack(
              children: [
                Image.network(mediaDetails['bannerUrl'],
                    fit: BoxFit.cover, width: double.infinity),
                Positioned(
                  left: 16,
                  top: 16,
                  child: Image.network(mediaDetails['posterUrl'], height: 150),
                ),
              ],
            ),
            const SizedBox(height: 8),
            // Genres, rating, buttons
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    children: mediaDetails['genres']
                        .map<Widget>((genre) => Container(
                              margin: const EdgeInsets.only(right: 8),
                              padding: const EdgeInsets.symmetric(
                                  horizontal: 8, vertical: 4),
                              decoration: BoxDecoration(
                                color: Colors.purple[700],
                                borderRadius: BorderRadius.circular(8),
                              ),
                              child: Text(
                                genre,
                                style: const TextStyle(color: Colors.white),
                              ),
                            ))
                        .toList(),
                  ),
                  const SizedBox(height: 8),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(
                        '${mediaDetails['rating']} ⭐',
                        style: const TextStyle(
                            fontSize: 18, fontWeight: FontWeight.bold),
                      ),
                      Row(
                        children: [
                          IconButton(
                            onPressed: () {},
                            icon: const Icon(Icons.favorite_border,
                                color: Colors.red),
                          ),
                          IconButton(
                            onPressed: () {},
                            icon: const Icon(Icons.bookmark_border,
                                color: Colors.white),
                          ),
                        ],
                      ),
                    ],
                  ),
                  const SizedBox(height: 8),
                  // Title, year, description
                  Text(
                    '${mediaDetails['title']} (${mediaDetails['releaseYear']})',
                    style: const TextStyle(
                        fontSize: 20, fontWeight: FontWeight.bold),
                  ),
                  const SizedBox(height: 8),
                  Text(mediaDetails['description']),
                ],
              ),
            ),
            const Divider(color: Colors.white),
            // Creators section
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Text('Creators:',
                      style:
                          TextStyle(fontSize: 18, fontWeight: FontWeight.bold)),
                  const SizedBox(height: 8),
                  Row(
                    children: mediaDetails['creators']
                        .map<Widget>((creator) => Container(
                              margin: const EdgeInsets.only(right: 16),
                              child: Column(
                                children: [
                                  Text(creator['name'],
                                      style:
                                          const TextStyle(color: Colors.white)),
                                  Text(
                                    creator['role'],
                                    style: const TextStyle(
                                        color: Colors.white54, fontSize: 12),
                                  ),
                                ],
                              ),
                            ))
                        .toList(),
                  ),
                ],
              ),
            ),
            const Divider(color: Colors.white),
            // Cast section
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Text('Cast:',
                      style:
                          TextStyle(fontSize: 18, fontWeight: FontWeight.bold)),
                  const SizedBox(height: 8),
                  Row(
                    children: mediaDetails['cast']
                        .map<Widget>((actor) => Container(
                              margin: const EdgeInsets.only(right: 16),
                              child: Column(
                                children: [
                                  Image.network(actor['photoUrl'], height: 80),
                                  const SizedBox(height: 4),
                                  Text(actor['name'],
                                      style:
                                          const TextStyle(color: Colors.white)),
                                  Text(actor['role'],
                                      style: const TextStyle(
                                          color: Colors.white54, fontSize: 12)),
                                ],
                              ),
                            ))
                        .toList(),
                  ),
                ],
              ),
            ),
            const Divider(color: Colors.white),
            // Streaming services
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Text('Watch on:',
                      style:
                          TextStyle(fontSize: 18, fontWeight: FontWeight.bold)),
                  const SizedBox(height: 8),
                  Row(
                    children: mediaDetails['streamingServices']
                        .map<Widget>(
                            (service) => Image.network(service, height: 50))
                        .toList(),
                  ),
                ],
              ),
            ),
            const Divider(color: Colors.white),
            // Similar media
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Text('More Like This:',
                      style:
                          TextStyle(fontSize: 18, fontWeight: FontWeight.bold)),
                  const SizedBox(height: 8),
                  Row(
                    children: mediaDetails['similarMedia']
                        .map<Widget>((media) => Column(
                              children: [
                                Image.network(media['imageUrl'], height: 80),
                                const SizedBox(height: 4),
                                Text(media['title'],
                                    style:
                                        const TextStyle(color: Colors.white)),
                              ],
                            ))
                        .toList(),
                  ),
                ],
              ),
            ),
            const Divider(color: Colors.white),
            // Reviews
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const Text('Reviews:',
                      style:
                          TextStyle(fontSize: 18, fontWeight: FontWeight.bold)),
                  const SizedBox(height: 8),
                  Column(
                    children: mediaDetails['reviews']
                        .map<Widget>((review) => Padding(
                              padding: const EdgeInsets.only(bottom: 8.0),
                              child: Column(
                                crossAxisAlignment: CrossAxisAlignment.start,
                                children: [
                                  Text(review['title'],
                                      style: const TextStyle(
                                          color: Colors.white,
                                          fontWeight: FontWeight.bold)),
                                  Text(review['content'],
                                      style: const TextStyle(
                                          color: Colors.white70)),
                                ],
                              ),
                            ))
                        .toList(),
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
