import 'dart:convert';
import 'dart:js';
import 'package:http/http.dart' as http;
import 'package:flutter/material.dart';
import 'package:trackster_mobile/models/media.dart';
import 'package:trackster_mobile/providers/auth_provider.dart';
import 'package:trackster_mobile/providers/media_provider.dart';

class HomeScreen extends StatefulWidget {
  @override
  _HomeScreenState createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  List<MediaItem> _mediaItems = [];

  @override
  void initState() {
    super.initState();
    fetchMedia();
  }

  fetchMedia() async {
    String? _baseUrl;

    const apiHost =
        String.fromEnvironment("API_HOST", defaultValue: "10.0.2.2");
    const apiPort = String.fromEnvironment("API_PORT", defaultValue: "7023");
    _baseUrl = "http://$apiHost:$apiPort/Media/GetList";

    try {
      var uri = Uri.parse(_baseUrl);
      var response = await http.get(uri);

      var data = jsonDecode(response.body);

      setState(() {
        _mediaItems = List<MediaItem>.from(
            data.map((item) => MediaItem(item['title'], item['imageUrl'])));
      });
    } catch (e) {
      throw Exception('Failed to load media: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Color(0xFF81689D),
        elevation: 0,
        leading: IconButton(
          icon: Icon(Icons.menu),
          onPressed: () {},
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
      body: Container(
        color: Color(0xFF81689D),
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 16.0),
          child: ListView(
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
              if (_mediaItems.isNotEmpty)
                Section(
                  title: 'Trending Now',
                  items: _mediaItems,
                ),
            ],
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
            children: items.map((item) => item.buildWidget()).toList(),
          ),
        ),
        Divider(color: Colors.white54),
      ],
    );
  }
}

class MediaItem {
  final String title;
  final String imageUrl;

  MediaItem(this.title, this.imageUrl);

  Widget buildWidget() {
    return Padding(
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
    );
  }
}
