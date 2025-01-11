import 'dart:convert';
import 'package:http/http.dart' as http;

import 'package:trackster_mobile/models/user.dart';
import 'package:trackster_mobile/providers/base_provider.dart';

class AuthProvider extends BaseProvider<User> {
  AuthProvider() : super("User");

  static String? username;
  static String? password;
  static int? userId;

  static User? user;


  static void setUser(User user) {
    userId = user.user_id;
  }

  Future<User?> login(String username, String password) async {
    try {
      final url = Uri.parse(
          "${baseUrl}User/Login?username=$username&password=$password");
      final response = await http.post(
        url,
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({'username': username, 'password': password}),
      );

      if (response.statusCode == 200) {
        final userJson = jsonDecode(response.body);
        print("user: $userJson");
        user = User.fromJson(userJson);
        print("user: $user");

        AuthProvider.username = username;
        AuthProvider.password = password;

        return user;
      } else {
        return null;
      }
    } catch (e) {
      return null;
    }
  }

}
