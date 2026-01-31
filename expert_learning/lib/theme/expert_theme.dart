import 'package:expert_learning/theme/app_colors.dart';
import 'package:expert_learning/theme/expert_text_theme.dart';
import 'package:flutter/material.dart';

class ExpertTheme {
  static ThemeData getTheme() => ThemeData(
    useMaterial3: true,
    fontFamily: 'Lexend',
    colorScheme: ColorScheme(
      brightness: Brightness.light,
      primary: AppColors.primaryDark,
      onPrimary: AppColors.onPrimary,
      secondary: AppColors.secondary,
      onSecondary: AppColors.onSecondary,
      error: AppColors.error,
      onError: AppColors.onError,
      surface: AppColors.backgroundDark,
      onSurface: AppColors.onSurface,
      outline: Colors.white10
    ),
    textTheme: ExpertTextTheme.dark()
  );
}
