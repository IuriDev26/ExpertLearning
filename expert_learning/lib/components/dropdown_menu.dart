import 'package:dropdown_button2/dropdown_button2.dart';
import 'package:expert_learning/theme/app_colors.dart';
import 'package:expert_learning/theme/color_scheme_extension.dart';
import 'package:expert_learning/theme/text_theme_extension.dart';
import 'package:flutter/material.dart';

class AppDropdownMenu<T> extends StatefulWidget {
  final String label;
  final String innerLabel;
  final String searchLabel;
  final List<DropdownMenuItem<T>> items;
  final bool Function(DropdownMenuItem<T> item, String searchedValue)?
  searchMatchFn;
  const AppDropdownMenu({
    super.key,
    required this.label,
    required this.innerLabel,
    required this.searchLabel,
    required this.items,
    this.searchMatchFn,
  });

  @override
  State<AppDropdownMenu<T>> createState() => _AppDropdownMenuState<T>();
}

class _AppDropdownMenuState<T> extends State<AppDropdownMenu<T>> {

  T? selectedValue;
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
          color: Theme.of(context).colorScheme.secondarySurface,
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
          color: Theme.of(context).colorScheme.secondarySurface,
          borderRadius: BorderRadius.circular(12),
          border: Border.all(color: Theme.of(context).colorScheme.outline),
        ),
      );

  DropdownStyleData _dropdownStyle(BuildContext context) => DropdownStyleData(
    maxHeight: 300,
    decoration: BoxDecoration(
      color: Theme.of(context).colorScheme.secondarySurface,
      borderRadius: BorderRadius.vertical(bottom: Radius.circular(12)),
      border: _dropdownOpenedBorder(context),
    ),
  );

  DropdownSearchData<T> _dropdownSearch(BuildContext context) =>
      DropdownSearchData(
        searchController: controller,
        searchInnerWidgetHeight: 60,
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
              hintText: widget.searchLabel,
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
        searchMatchFn: widget.searchMatchFn,
      );

  _onMenuStateChange(bool isOpen) {
    if (!isOpen) controller.clear();

    setState(() => _isMenuOpen = isOpen);
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        DropdownButtonHideUnderline(
          child: DropdownButton2<T>(
            isExpanded: true,

            hint: Text(
              widget.innerLabel,
              style: Theme.of(context).textTheme.titleMediumOpaque,
            ),
            items: widget.items,
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
