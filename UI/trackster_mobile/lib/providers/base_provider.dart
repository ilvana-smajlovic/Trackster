import 'dart:convert';

import 'package:trackster_mobile/models/search_result.dart';
import 'package:trackster_mobile/providers/auth_provider.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

abstract class BaseProvider<T> with ChangeNotifier {
  static String? _baseUrl;
  String _endpoint = "";

  BaseProvider(String endpoint) {
    _endpoint = endpoint;

    const apiHost =
        String.fromEnvironment("API_HOST", defaultValue: "10.0.2.2");
    const apiPort = String.fromEnvironment("API_PORT", defaultValue: "7023");

    _baseUrl = "http://$apiHost:$apiPort/";
  }

  String get baseUrl => _baseUrl ?? "";
  String get endpoint => _endpoint;

  Future<SearchResult<T>> get({dynamic filter}) async {
    var url = "$_baseUrl$_endpoint";

    if (filter != null) {
      var queryString = getQueryString(filter);
      url = "$url?$queryString";
    }

    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      var result = SearchResult<T>();

      result.count = data['count'];

      for (var item in data['resultList']) {
        result.result.add(fromJson(item));
      }

      return result;
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<List<T>> getAll({String? subRoute}) async {
    var uri = Uri.parse("$_baseUrl$subRoute");
    print('URI: $uri');

    var headers = createHeaders();
    print("HEADER IN GET ALL: $headers");

    var response = await http.get(uri, headers: headers);

    if (response.statusCode == 200) {
      // Decode the response body
      var decodedBody = jsonDecode(response.body);

      // Check for the 'resultList' key in the response
      if (decodedBody is Map<String, dynamic> && decodedBody['resultList'] is List) {
        final List<dynamic> resultList = decodedBody['resultList'];
        return resultList.map((item) => fromJson(item)).toList();
      } else {
        throw Exception("Unexpected response format: ${response.body}");
      }
    } else {
      throw Exception("Failed to load data: ${response.statusCode}");
    }
  }




  Future<T> insert(String? subRoute, dynamic request) async {
    var url = "$_baseUrl$subRoute";
    var uri = Uri.parse(url);

    var headers = createHeaders();
    print("URL: $url");

    var jsonRequest = jsonEncode(request);

    try {
      var response = await http.post(uri, headers: headers, body: jsonRequest);

      if (isValidResponse(response)) {
        var data = jsonDecode(response.body);
        print("RESPONSE DATA: $data");
        return fromJson(data);
      } else {
        throw Exception("Server returned status code: ${response.statusCode}");
      }
    } catch (e) {
      throw Exception("Failed to insert: $e");
    }
  }

  Future<T> update(int id, [dynamic request]) async {
    var url = "$_baseUrl$_endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var jsonRequest = jsonEncode(request);
    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Unknown error");
    }
  }

  T fromJson(data) {
    throw Exception("Method not implemented");
  }

  bool isValidResponse(Response response) {
    if (response.statusCode >= 200 && response.statusCode < 300) {
      return true;
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else {
      throw Exception("Error ${response.statusCode}: ${response.reasonPhrase}");
    }
  }

  Map<String, String> createHeaders() {
    String username = AuthProvider.username ?? "";
    String password = AuthProvider.password ?? "";

    print("Username: $username");
    print("Password: $password");

    String basicAuth =
        "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    var headers = {
      "Content-Type": "application/json",
      "Authorization": basicAuth
    };
    print("HEADER: $headers");
    return headers;
  }

  String getQueryString(Map params,
      {String prefix = '&', bool inRecursion = false}) {
    String query = '';
    params.forEach((key, value) {
      if (inRecursion) {
        if (key is int) {
          key = '[$key]';
        } else if (value is List || value is Map) {
          key = '.$key';
        } else {
          key = '.$key';
        }
      }
      if (value is String || value is int || value is double || value is bool) {
        var encoded = value;
        if (value is String) {
          encoded = Uri.encodeComponent(value);
        }
        query += '$prefix$key=$encoded';
      } else if (value is DateTime) {
        query += '$prefix$key=${(value).toIso8601String()}';
      } else if (value is List || value is Map) {
        if (value is List) value = value.asMap();
        value.forEach((k, v) {
          query +=
              getQueryString({k: v}, prefix: '$prefix$key', inRecursion: true);
        });
      }
    });
    return query;
  }

  Future<void> delete(int id) async {
    var url = "$_baseUrl$_endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.delete(uri, headers: headers);

    if (isValidResponse(response)) {
      notifyListeners();
    } else {
      throw Exception("Failed to delete item");
    }
  }

  Future<T> getById(String subRoute, int id) async {
    var url = "$_baseUrl$_endpoint/$subRoute/$id";
    var uri = Uri.parse(url);
    var headers = createHeaders();

    var response = await http.get(uri, headers: headers);
    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Unknown error");
    }
  }
}
