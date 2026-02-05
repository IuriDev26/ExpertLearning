import 'package:expert_learning/theme/color_scheme_extension.dart';
import 'package:expert_learning/theme/text_theme_extension.dart';
import 'package:flutter/material.dart';

class InputText extends StatelessWidget {
  final String placeholder;
  final double height = 150;
  final Row? actions;
  final TextEditingController controller;
  const InputText({super.key, required this.placeholder, required this.controller, this.actions});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          width: double.infinity,
          height: height,
          decoration: BoxDecoration(
            border: Border(
              top: BorderSide(color: Theme.of(context).colorScheme.outline),
              left: BorderSide(color: Theme.of(context).colorScheme.outline),
              right: BorderSide(color: Theme.of(context).colorScheme.outline),
            ),
            color: Theme.of(context).colorScheme.secondarySurface,
            borderRadius: BorderRadius.vertical(top: Radius.circular(12)),
          ),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.end,
            children: [
              TextFormField(
                maxLines: null,
                minLines: 5,
                keyboardType: TextInputType.multiline,
                controller: controller,
                decoration: InputDecoration(
                  border: InputBorder.none,
                  contentPadding: EdgeInsets.all(10),
                  hint: Text(
                    placeholder,
                    style: Theme.of(context).textTheme.titleMediumOpaque,
                  ),
                ),
              ),
            ],
          ),
        ),
        Container(
          width: double.infinity,
          height: 50,
          decoration: BoxDecoration(
            color: Theme.of(context).colorScheme.terciarySurface,
            border: Border.all(
              color: Theme.of(context).colorScheme.terciarySurface,
            ),
            borderRadius: BorderRadius.vertical(bottom: Radius.circular(12)),
          ),
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: actions
          ),
        ),
      ],
    );
  }
}
