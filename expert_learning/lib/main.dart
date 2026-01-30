import 'package:expert_learning/pages/newFlashcardPage/new_flashcard_page.dart';
import 'package:expert_learning/theme/expert_theme.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(const ExpertLearningApp());
}

class ExpertLearningApp extends StatelessWidget {
  const ExpertLearningApp({super.key});
  
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Expert Learning',
      theme: ExpertTheme.getTheme(),
      home: const NewFlashcard(),
    );
  }
}
