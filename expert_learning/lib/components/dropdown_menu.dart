import 'package:dropdown_button2/dropdown_button2.dart';
import 'package:expert_learning/theme/app_colors.dart';
import 'package:flutter/material.dart';

class AppDropdownMenu extends StatefulWidget {
  const AppDropdownMenu({super.key});

  @override
  State<AppDropdownMenu> createState() => _AppDropdownMenuState();
}

class _AppDropdownMenuState extends State<AppDropdownMenu> {
  final List<String> items = [
    "Portugues",
    "English",
    "Development",
    "Software Engineering",
  ];
  String? selectedValue;
  final TextEditingController controller = TextEditingController();
  bool _isMenuOpen = false;

  Border _dropdownOpenedBorder(BuildContext context) => Border(
    bottom: BorderSide(width: 2, color: Theme.of(context).colorScheme.primary),
    left: BorderSide(width: 2, color: Theme.of(context).colorScheme.primary),
    right: BorderSide(width: 2, color: Theme.of(context).colorScheme.primary),
  );

  ButtonStyleData _buttonStyleWhenOpened(BuildContext context) =>
      ButtonStyleData(
        height: 60,
        decoration: BoxDecoration(
          color: AppColors.secondaryBackground,
          borderRadius: BorderRadius.vertical(top: Radius.circular(12)),
          border: Border.all(
            width: 2,
            color: Theme.of(context).colorScheme.primary,
          ),
        ),
      );

  ButtonStyleData _buttonStyleWhenClosed(BuildContext context) =>
      ButtonStyleData(
        height: 60,
        decoration: BoxDecoration(
          color: AppColors.secondaryBackground,
          borderRadius: BorderRadius.circular(12),
          border: Border.all(color: Theme.of(context).colorScheme.outline),
        ),
      );

  DropdownStyleData _dropdownStyle(BuildContext context) => DropdownStyleData(
    maxHeight: 300,
    decoration: BoxDecoration(
      color: AppColors.secondaryBackground,
      borderRadius: BorderRadius.vertical(bottom: Radius.circular(12)),
      border: _dropdownOpenedBorder(context),
    ),
  );

  DropdownSearchData<String> _dropdownSearch(BuildContext context) =>
      DropdownSearchData(
        searchController: controller,
        searchInnerWidgetHeight: 0,
        searchInnerWidget: Container(
          height: 60,
          decoration: BoxDecoration(
            border: Border(
              bottom: BorderSide(color: Theme.of(context).colorScheme.outline),
            ),
          ),
          padding: EdgeInsets.all(8.0),
          child: TextFormField(
            controller: controller,
            textAlignVertical: TextAlignVertical.center,
            decoration: InputDecoration(
              prefixIcon: Icon(
                Icons.search,
                color: Theme.of(context).colorScheme.primary,
              ),
              hintText: 'Pesquisar...',
              hintStyle: Theme.of(context).textTheme.bodyMedium,
              contentPadding: EdgeInsets.only(bottom: 8),
              fillColor: AppColors.overlayDark,
              border: OutlineInputBorder(
                borderRadius: BorderRadius.circular(10),
                borderSide: BorderSide.none,
              ),
              filled: true,
            ),
          ),
        ),
        searchMatchFn: (item, searchValue) =>
            item.value?.toLowerCase().contains(searchValue.toLowerCase()) ??
            false,
      );

  _onMenuStateChange(bool isOpen) {
    if (!isOpen) controller.clear();

    setState(() => _isMenuOpen = isOpen);
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            Text('Assunto', style: Theme.of(context).textTheme.titleMedium),
          ],
        ),
        SizedBox(height: 10),
        DropdownButtonHideUnderline(
          child: DropdownButton2<String>(
            isExpanded: true,

            hint: Text(
              'Selecione um assunto',
              style: Theme.of(context).textTheme.titleSmall,
            ),

            items: items
                .map(
                  (item) =>
                      DropdownMenuItem<String>(value: item, child: Text(item)),
                )
                .toList(),

            value: selectedValue,
            onChanged: (value) => setState(() => selectedValue = value),

            buttonStyleData: _isMenuOpen
                ? _buttonStyleWhenOpened(context)
                : _buttonStyleWhenClosed(context),

            dropdownStyleData: _dropdownStyle(context),
            dropdownSearchData: _dropdownSearch(context),
            onMenuStateChange: _onMenuStateChange,
          ),
        ),
      ],
    );
  }
}
