import 'package:expert_learning/components/dropdown_menu.dart';
import 'package:expert_learning/components/headline.dart';
import 'package:expert_learning/components/input_text.dart';
import 'package:expert_learning/components/label.dart';
import 'package:flutter/material.dart';

class NewFlashcard extends StatelessWidget {
  const NewFlashcard({super.key});

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: Column(
          children: [
            Padding(
              padding: const EdgeInsets.all(10),
              child: Headline(
                label: 'Novo Flashcard',
                leftButton: IconButton(
                  onPressed: () {},
                  icon: Icon(Icons.close),
                ),
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(18.0),
              child: Column(
                children: [
                  Label(labelText: 'Assunto'),
                  SizedBox(height: 10,),

                  AppDropdownMenu<String>(
                    label: 'Assunto',
                    innerLabel: 'Selecione o assunto',
                    searchLabel: 'Pesquisar',
                    items: [
                      DropdownMenuItem<String>(
                        value: 'Development',
                        child: Text('Development'),
                      ),
                      DropdownMenuItem<String>(
                        value: 'Software Engineerieng',
                        child: Text('Software Engineerieng'),
                      ),
                      DropdownMenuItem<String>(
                        value: 'English',
                        child: Text('English'),
                      ),
                    ],
                    searchMatchFn: (item, searchedValue) =>
                        item.value?.toLowerCase().contains(
                          searchedValue.toLowerCase(),
                        ) ??
                        false,
                  ),
                  SizedBox(height: 20),
                  
                  Label(labelText: 'Pergunta'),
                  SizedBox(height: 10,),
                  InputText(),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
