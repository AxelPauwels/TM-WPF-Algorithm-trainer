   M S B A M L   `   `   `  ����K  GAlgorithmTrainer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AlgorithmTrainer.ViewAlgorithmTrainer.View  5   	   +    %AlgorithmTrainer.View.CategorieWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AlgorithmTrainer.View     5   	      
Background#��[  5   	     � Title$  
Categories��5
   	   $	��585��6   $	��850��6,   $	��585��6;   $	��850��6H    � Icon$7 1/AlgorithmTrainer;component/images/RubiksIcon.png��6T    � WindowStartupLocation$ CenterScreen=�6�    � DataContext 5	   	   ��   mainViewModelLocator �� Source# [  �� Path$ CategorieWindowViewModel�.��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��0��6     ListBoxSmall#��[ 6q     ListboxItemSmall#��[ 6�   ��6#   �� *
Categories+ �� SelectedItem 6F   �� *SelectedCategorie+��5      �� 5      .R�5      �� $��ollId��6      TextBlockSmall#��[ 6C   ��6-   �� *Naam+6C   5      5      � 5   
   $��1��6   $��50,100,50,100q�6    � RowDefinitions 5      �� 5      $
��auto �6    61   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $��50 �6    6/   �� 5      $
��auto �6    61   �� 5       $
��auto �6    61    5"      �� 5#      $	��150 �6#   61   �� 5$      $��* �6#   6/   .+�5&      �� $��0��6   $��OLL Number:��6%   $y�	Collapsed=�68     TextBlockLarge#��[ 6O   �� 5'      $��1��6   $��Name:��6%   #��[ 62   �� 5(      $��4��6   $��2��6%   $��OLL's in this Category:��6:   $
��Bold"�6Y   $��	0,20,0,10q�6l   #��[ 6   �� 5*      $��0��6   $��1��6%   $y�	Collapsed=�6[   #��[ 6r   ��65   �� *SelectedCategorie.Id+6r   �� 5+      $��1��6   $��1��6%   #��[ 6]   ��65   �� *SelectedCategorie.Naam+6]   �� 5-      $��2��6   $��2��6&   	 �� Orientation$	 
Horizontal=�6:   .+�5.      �� $��Change��6     ButtonSmall#��[ 6U   ��6*   �� *WijzigCategorieCommand+6U   �� 5/      $��Add new��6   #��[ 6W   ��6+   �� *VoegCategorieToeCommand+6W   �� 50      $
��Back��6     ButtonSmallBack#��[ 6H   ��6(   �� *ExitCommand+6H   51      �� 52      $��5��6   $��2��6$   #��[ 6e   $��Center=�6�   
������ 
������ ��69   �� *CategorieAlgorithms+��53      �� 54      .R�55      �� $	 
Horizontal=�6%   6@   56      ��58      �� 59      .R�5:      �� $	 Vertical=�6%   $��0,0,10,0q�6<   .+�5<      �� $��afbeeldingPath��6;   $y�	Collapsed=�6$    6Q   �� # [ $ MainWindowViewModel���5=      �� *AfbeeldingPath+�� 5>      $��
afbeelding��6;   $y�	Collapsed=�6$   ��6M   �� *
Afbeelding+�� 5?      $��imageSource��6?   $y�	Collapsed=�6(   ��5@   "   `� 5A   &   
 �� StringFormat$
 {0}{1}��63   .1�5B   *   ��  �� ElementName$ afbeeldingPath��62   $ Content�6O   �� 5C   *   $ 
afbeelding��62   $ Content�6K   5D   '   5F      �� 5H      $��50��6V   $��50��6e   ��6$   �� *Text+$ imageSource��6e   �� 5I      $��ollId��6(    �� TextAlignment$ Center=�6J   $��Center=�6b   $��	10,0,10,0q�6   $��20��6�   ��65   �� *Id+6�   5J      5K      5M      5N      5P      5Q      