import 'package:flutter/material.dart';

class Headline extends StatelessWidget {

  final String label;
  final IconButton? leftButton;
  final IconButton? rightButton;

  const Headline({super.key, required this.label, this.leftButton, this.rightButton});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      child: Stack(
        alignment: Alignment.center,
        children: [
          Align(
            alignment: Alignment.centerLeft,
            child: leftButton,
          ),
          Text(
            label,
            style: Theme.of(context).textTheme.headlineMedium,
          ),
          Align(
            alignment: Alignment.centerRight,
            child: rightButton,
          )
        ],
      ),
    );
  }
}
