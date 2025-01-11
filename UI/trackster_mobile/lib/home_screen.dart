import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:trackster_mobile/providers/media_provider.dart';

import 'media_screen.dart';
import 'menu.dart';

class HomeScreen extends StatefulWidget {
  @override
  _HomeScreenState createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  final GlobalKey<ScaffoldState> _scaffoldKey = GlobalKey<ScaffoldState>();

  @override
  void initState() {
    super.initState();
    // Fetch the media items when the screen is initialized
    Future.delayed(Duration.zero, () {
      Provider.of<MediaProvider>(context, listen: false).getAllMedia();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      key: _scaffoldKey,
      appBar: AppBar(
        backgroundColor: Color(0xFF81689D),
        elevation: 0,
        leading: IconButton(
          icon: Icon(Icons.menu),
          onPressed: () {
            _scaffoldKey.currentState!.openDrawer();
          },
        ),
        actions: [
          Padding(
            padding: const EdgeInsets.only(right: 16.0),
            child: CircleAvatar(
              backgroundImage: NetworkImage('https://via.placeholder.com/150'),
            ),
          ),
        ],
      ),
      drawer: Menu(),
      body: Container(
        color: Color(0xFF81689D),
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16.0),
          child: Consumer<MediaProvider>(
            builder: (context, mediaProvider, child) {
              if (mediaProvider.isLoading) {
                return Center(child: CircularProgressIndicator());
              }

              if (mediaProvider.mediaItems.isEmpty) {
                return Center(child: Text('No media items available.'));
              }

              final mediaItems = mediaProvider.mediaItems
                  .map((media) => MediaItem(
                    id: media.media_id!.toInt(),
                    title: media.title ?? "Untitled",
                    imageUrl: media.picture ?? '',
              ))
                  .toList();

              return ListView(
                children: [
                  SizedBox(height: 10),
                  // Search Bar
                  Container(
                    padding: EdgeInsets.symmetric(horizontal: 12),
                    decoration: BoxDecoration(
                      color: Color(0xFF51376C),
                      borderRadius: BorderRadius.circular(10),
                    ),
                    child: TextField(
                      decoration: InputDecoration(
                        icon: Icon(Icons.search, color: Colors.white),
                        border: InputBorder.none,
                        hintText: 'Search',
                        hintStyle: TextStyle(color: Colors.white54),
                      ),
                    ),
                  ),
                  SizedBox(height: 20),
                  // Trending Now Section
                  Section(
                    title: 'Trending Now',
                    items: mediaItems,
                  ),
                ],
              );
            },
          ),
        ),
      ),
    );
  }
}

class Section extends StatelessWidget {
  final String title;
  final List<MediaItem> items;

  Section({required this.title, required this.items});

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          title,
          style: TextStyle(
              fontSize: 18, fontWeight: FontWeight.bold, color: Colors.white),
        ),
        SizedBox(height: 10),
        SingleChildScrollView(
          scrollDirection: Axis.horizontal,
          child: Row(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: items.map((item) => item.buildWidget(context)).toList(),
          ),
        ),
        Divider(color: Colors.white54),
      ],
    );
  }
}

class MediaItem {
  final int id;
  final String title;
  final String imageUrl;

  MediaItem({required this.id, required this.title, required this.imageUrl});

  Widget buildWidget(BuildContext context) {
    return GestureDetector(
        onTap: () {
      // Navigate to MediaScreen with only the mediaId
      Navigator.push(
        context,
        MaterialPageRoute(
          builder: (BuildContext context) => MediaScreen(mediaId: id),
        ),
      );
    },
    child: Padding(
      padding: const EdgeInsets.only(right: 12.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            width: 100,
            height: 150,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(10),
              image: DecorationImage(
                image: NetworkImage(imageUrl),
                fit: BoxFit.cover,
              ),
            ),
          ),
          SizedBox(height: 5),
          Container(
            width: 100,
            child: Text(
              title,
              style: TextStyle(color: Colors.white, fontSize: 12),
              textAlign: TextAlign.center,
              maxLines: 2,
              overflow: TextOverflow.ellipsis,
              softWrap: true,
            ),
          ),
        ],
      ),
     )
    );
  }
}
