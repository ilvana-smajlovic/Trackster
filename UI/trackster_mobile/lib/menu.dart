import 'package:flutter/material.dart';
import 'package:trackster_mobile/home_screen.dart';

class Menu extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: Container(
        color: Color(0xFF2E2A4D),
        child: ListView(
          padding: EdgeInsets.zero,
          children: [
            DrawerHeader(
              decoration: BoxDecoration(
                color: Color(0xFF3C3A60),
              ),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  CircleAvatar(
                    backgroundImage:
                    NetworkImage('https://via.placeholder.com/150'),
                    radius: 30,
                  ),
                  SizedBox(height: 10),
                  Text(
                    'johanna_doe',
                    style: TextStyle(color: Colors.white, fontSize: 16),
                  ),
                  Text(
                    '3 followers · 3 following',
                    style: TextStyle(color: Colors.white54, fontSize: 12),
                  ),
                ],
              ),
            ),
            _buildMenuItem(Icons.home, 'Home', context),
            _buildMenuItem(Icons.favorite, 'Favorites', context),
            _buildMenuItem(Icons.bookmark, 'Watchlist', context),
            _buildMenuItem(Icons.bar_chart, 'Stats', context),
            _buildMenuItem(Icons.theaters, 'Theaters', context),
            _buildMenuItem(Icons.notifications, 'Notifications', context),
            Divider(color: Colors.white54),
            _buildMenuItem(Icons.settings, 'Settings', context),
          ],
        ),
      ),
    );
  }

  Widget _buildMenuItem(IconData icon, String title, BuildContext context) {
    return ListTile(
      leading: Icon(icon, color: Colors.white),
      title: Text(title, style: TextStyle(color: Colors.white)),
      onTap: () {
        Navigator.push(
          context,
          MaterialPageRoute(builder: (context) => HomeScreen()), // Replace with actual target screens
        );
        Navigator.pop(context); // Close the menu after an action
      },
    );
  }
}
