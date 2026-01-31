import 'package:flutter/material.dart';

class Label extends StatelessWidget {
  final String labelText;
  final MainAxisAlignment mainAxisAlignment;
  final CrossAxisAlignment crossAxisAlignment;
  const Label({
    super.key, 
    required this.labelText, 
    this.mainAxisAlignment = MainAxisAlignment.start, 
    this.crossAxisAlignment = CrossAxisAlignment.center});

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: mainAxisAlignment,
      crossAxisAlignment: crossAxisAlignment,
      children: [
        Text(labelText, style: Theme.of(context).textTheme.titleMedium),
      ],
    );
  }
}
