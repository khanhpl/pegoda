import 'package:firebase_messaging/firebase_messaging.dart';
import 'package:flutter/material.dart';
import 'package:convex_bottom_bar/convex_bottom_bar.dart';
import 'package:pegoda/screens/customer/cus_main/cus_home_screen.dart';
import 'package:pegoda/screens/customer/cus_account/cus_account_screen.dart';
import 'package:pegoda/screens/customer/notification/notification_screen.dart';
import 'package:pegoda/screens/customer/pet/pet_screen.dart';
import '../MyLib/constants.dart' as Constants;
import '../models/local_notification.dart';

class CusMain extends StatefulWidget {
  int selectedIndex = 0;

  bool isBottomNav = true;

  CusMain({required this.selectedIndex, required this.isBottomNav});

  @override
  State<CusMain> createState() => _CusMainSate(
      selectedIndex: this.selectedIndex, isBottomNav: this.isBottomNav);
}

class _CusMainSate extends State<CusMain> {
  int selectedIndex;
  bool isBottomNav;
  List<RemoteMessage> _messages = [];
  String? _token;
  _CusMainSate({required this.selectedIndex, required this.isBottomNav});

  var _primaryColor = Constants.primaryColor;

  Widget pageCaller(index) {
    switch (selectedIndex) {
      case 0:
        return CusHomeScreen();
      case 1:
        return PetScreen();
      case 2:
        isBottomNav = true;
        return NotificationScreen(messages: _messages,token: _token,);
      case 3:
        isBottomNav = true;
        return CusAccountScreen();

      default:
        return CusHomeScreen();
    }
  }
  void getTokenFCM() async {
    String? token = await FirebaseMessaging.instance.getToken();
    setState(() {
      _token = token;
    });
  }

  void _onItemTapped(int index) {
    setState(() {
      selectedIndex = index;
    });
  }
  Future<void> setupInteractedMessage() async {
    // Get any messages which caused the application to open from
    // a terminated state.
    RemoteMessage? initialMessage =
    await FirebaseMessaging.instance.getInitialMessage();

    // If the message also contains a data property with a "type" of "chat",
    // navigate to a chat screen
    if (initialMessage != null) {
      _handleMessage(initialMessage);
    }

    // Also handle any interaction when the app is in the background via a
    // Stream listener
    FirebaseMessaging.onMessageOpenedApp.listen(_handleMessage);
  }
  void _handleMessage(RemoteMessage message) {
    _messages = [..._messages, message];
    Navigator.of(context).push(MaterialPageRoute(builder: (context) => NotificationScreen(messages: _messages,token: _token,)));
  }

  @override
  void initState() {
    // TODO: implement initState
    super.initState();


    getTokenFCM();
    setupInteractedMessage();

    FirebaseMessaging.onMessage.listen((event) {
      LocalNotificationService.showNotificationsOnForeground(event);
      _messages = [..._messages, event];
    });

  }

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    return Scaffold(
      body: pageCaller(selectedIndex),
      bottomNavigationBar: isBottomNav == true
          ? ConvexAppBar(
        height: size.height * 0.1,
        style: TabStyle.react,
        backgroundColor: Colors.white,
        color: Colors.grey[700],
        activeColor: _primaryColor,
        onTap: _onItemTapped,
        initialActiveIndex: selectedIndex,
        top: -16,
        curveSize: 80,

        items: [

          TabItem(
            icon: Icons.home,
            title: 'Trang chủ\n',

          ),
          TabItem(
            icon: Icons.pets,
            title: 'Thú cưng\n',
          ),
          TabItem(
            icon: Icons.notifications,
            title: 'Thông báo\n',
          ),
          TabItem(
            icon: Icons.account_box_sharp,
            title: 'Tài khoản\n',
          ),
        ],
      )
          : Container(
        height: 0,
      ),
    );
  }
}
