import 'package:expert_learning/theme/app_colors.dart';
import 'package:flutter/material.dart';

class ExpertTextTheme extends TextTheme{
  
  ExpertTextTheme.dark() : super(
      displayLarge: TextStyle(fontWeight: FontWeight.w900), // Black
      displayMedium: TextStyle(fontWeight: FontWeight.w800), // ExtraBold
      displaySmall: TextStyle(fontWeight: FontWeight.w700), // Bold
      headlineLarge: TextStyle(fontWeight: FontWeight.w800), // ExtraBold
      headlineMedium: TextStyle(fontWeight: FontWeight.w700, fontSize: 18, color: AppColors.primaryTextColor), // Bold
      headlineSmall: TextStyle(fontWeight: FontWeight.w600), // SemiBold
      titleLarge: TextStyle(fontWeight: FontWeight.w700), // Bold
      titleMedium: TextStyle(fontWeight: FontWeight.w600, color: AppColors.secondaryTextColor), // SemiBold
      titleSmall: TextStyle(fontWeight: FontWeight.w500), // Medium
      bodyLarge: TextStyle(
        fontWeight: FontWeight.w500,
      ),
      bodyMedium: TextStyle(fontWeight: FontWeight.w400), // Regular
      bodySmall: TextStyle(fontWeight: FontWeight.w300), // Light
      labelLarge: TextStyle(
        fontWeight: FontWeight.w600,
      ),
      labelMedium: TextStyle(fontWeight: FontWeight.w500), // Medium
      labelSmall: TextStyle(fontWeight: FontWeight.w400), // Regular
    );

}