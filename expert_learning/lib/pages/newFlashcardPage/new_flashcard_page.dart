import 'package:expert_learning/components/char_counter.dart';
import 'package:expert_learning/components/dropdown_menu.dart';
import 'package:expert_learning/components/headline.dart';
import 'package:expert_learning/components/input_text.dart';
import 'package:expert_learning/components/label.dart';
import 'package:flutter/material.dart';

class NewFlashcard extends StatefulWidget {
  const NewFlashcard({super.key});

  @override
  State<NewFlashcard> createState() => _NewFlashcardState();
}

class _NewFlashcardState extends State<NewFlashcard> {
  final TextEditingController questionController = TextEditingController();
  final TextEditingController answerController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: SingleChildScrollView(
          child: Column(
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
                    SizedBox(height: 10),

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
                    SizedBox(height: 10),
                    InputText(
                      placeholder: 'Quem inventou o avião?',
                      controller: questionController,
                      actions: Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Expanded(
                            child: Align(
                              alignment: Alignment.centerLeft,
                              child: Icon(Icons.label, color: Colors.grey[600]),
                            ),
                          ),
                          Text(
                            '|',
                            style: TextStyle(
                              color: Colors.grey[600],
                              fontWeight: FontWeight.w100,
                              fontSize: 20,
                            ),
                          ),
                          Expanded(
                            child: Align(
                              alignment: Alignment.centerRight,
                              child: CharCounter(
                                controller: questionController,
                                maxLength: 500,
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),

                    SizedBox(height: 20),

                    Label(labelText: 'Resposta'),
                    SizedBox(height: 10),
                    InputText(
                      placeholder: 'Os Irmãos Wright',
                      controller: answerController,
                      actions: Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Spacer(),
                          Text(
                            '|',
                            style: TextStyle(
                              color: Colors.grey[600],
                              fontWeight: FontWeight.w100,
                              fontSize: 20,
                            ),
                          ),
                          Expanded(
                            child: Align(
                              alignment: Alignment.centerRight,
                              child: CharCounter(
                                controller: answerController,
                                maxLength: 500,
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
