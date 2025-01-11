import 'package:flutter/material.dart';
import 'package:qr_flutter/qr_flutter.dart'; // Add qr_flutter package in pubspec.yaml

class QrCodeScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.deepPurple.withOpacity(0.9),
      body: Stack(
        children: [
          // Background content (can replace with actual content of the screen)
          Column(
            children: [
              Expanded(child: Container(color: Colors.deepPurple[100])),
              Expanded(child: Container(color: Colors.deepPurple[300])),
            ],
          ),

          // Floating QR box
          Center(
            child: Container(
              padding: EdgeInsets.all(16),
              width: 300,
              decoration: BoxDecoration(
                color: Colors.blueGrey[900],
                borderRadius: BorderRadius.circular(16),
              ),
              child: Column(
                mainAxisSize: MainAxisSize.min,
                children: [
                  // Profile picture
                  CircleAvatar(
                    radius: 40,
                    backgroundImage: NetworkImage(
                      'https://via.placeholder.com/150', // Replace with actual user image URL
                    ),
                  ),
                  SizedBox(height: 8),

                  // Username
                  Text(
                    'johanna_doe',
                    style: TextStyle(
                      color: Colors.white,
                      fontSize: 20,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  SizedBox(height: 16),

                  // QR Code
                  /*QrImage(
                    data: 'johanna_doe_profile', // Replace with your data string
                    version: QrVersions.auto,
                    size: 150,
                    backgroundColor: Colors.white,
                  ),*/
                ],
              ),
            ),
          ),

          // Close button
          Positioned(
            top: 40,
            left: 16,
            child: IconButton(
              icon: Icon(Icons.close, color: Colors.white),
              onPressed: () => Navigator.of(context).pop(),
            ),
          ),
        ],
      ),
    );
  }
}
