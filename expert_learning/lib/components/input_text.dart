import 'package:expert_learning/theme/app_colors.dart';
import 'package:expert_learning/theme/color_scheme_extension.dart';
import 'package:expert_learning/theme/text_theme_extension.dart';
import 'package:flutter/material.dart';

class InputText extends StatelessWidget {
  final double height = 150;
  const InputText({super.key});

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
                decoration: InputDecoration(
                  border: InputBorder.none,
                  contentPadding: EdgeInsets.all(10),
                  hint: Text(
                    'Quem inventou o avião?',
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
          child: Row(
            children: [
              Icon(Icons.label_outline, color: AppColors.secondaryTextColor,)
            ],
          ),
        ),
      ],
    );
  }
}
