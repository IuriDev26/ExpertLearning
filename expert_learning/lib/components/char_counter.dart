import 'package:flutter/material.dart';

class CharCounter extends StatefulWidget {
  final TextEditingController controller;
  final int maxLength;
  const CharCounter({super.key, required this.controller, required this.maxLength});

  @override
  State<CharCounter> createState() => _CharCounterState();
}

class _CharCounterState extends State<CharCounter> {

  int length = 0;

  @override
  void initState() {
    super.initState();

    widget.controller.addListener(
      () => setState( () => length = widget.controller.text.length )
    );

  }

  @override
  Widget build(BuildContext context) {
    return Text('$length/${widget.maxLength}', style: Theme.of(context).textTheme.titleMedium);
  }
}
