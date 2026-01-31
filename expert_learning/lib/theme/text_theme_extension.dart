import 'package:flutter/material.dart';

extension ExpertTextThemeExtension on TextTheme{

  TextStyle get titleMediumOpaque => titleMedium!.copyWith(
    color: titleMedium!.color!.withAlpha(50)
  );

}