   M S B A M L   `   `   `  ����K  GAlgorithmTrainer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AlgorithmTrainer.ViewAlgorithmTrainer.View  5   	   +    %AlgorithmTrainer.View.AlgorithmWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AlgorithmTrainer.View     5   	      
Background#��[  5   	     � Title$  
Algorithms��5
   	   $	��585��6   $	��850��6,   $	��585��6;   $	��850��6H    � Icon$7 1/AlgorithmTrainer;component/images/RubiksIcon.png��6T    � WindowStartupLocation$ CenterScreen=�6�    � DataContext 5	   	   ��   mainViewModelLocator �� Source# [  �� Path$ AlgorithmWindowViewModel�.��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��0��6     ListBoxSmall#��[ 6q     ListboxItemSmall#��[ 6�   ��6#   �� *
Algorithms+ �� SelectedItem 6F   �� *SelectedAlgorithm+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��ollId��6$   	 �� TextAlignment$	 Right=�6F   $��Center=�6\   $��Center=�6w   $��55,0,5,0q�6�   $��20��6�   ��61   �� *Id+6�   �� 5      $��afbeeldingPath��67   $y�	Collapsed=�6     6M   �� # [ $ MainWindowViewModel���5      �� *AfbeeldingPath+�� 5      $��
afbeelding��67   $y�	Collapsed=�6    ��6I   �� *
Afbeelding+�� 5      $��imageSource��6;   $y�	Collapsed=�6$   ��5      `� 5   "   
 �� StringFormat$
 {0}{1}��6/   .1�5   &   ��  �� ElementName$ afbeeldingPath��6.   $ Content�6K   �� 5   &   $ 
afbeelding��6.   $ Content�6G   5   #   5!      �� 5#      $��50��6R   $��50��6a   ��6    �� *Text+$ imageSource��6a   5$      5%      5'      � 5)   
   $��1��6   $��50,100,50,100q�6    � RowDefinitions 5*      �� 5+      $
��auto �6    61   �� 5,      $
��auto �6    60   �� 5-      $
��auto �6    61   �� 5.      $
��auto �6    60   �� 5/      $
��auto �6    60   �� 50      $
��auto �6    60   �� 51      $
��auto �6    60   �� 52      $��1 �6    6-    54      �� 55      $	��150 �6#   61   �� 56      $��* �6#   6/   .+�58      �� $��0��6   $
��OLL:��6%     TextBlockLarge#��[ 61   �� 59      $��1��6   $��Guide Number:��6%   #��[ 6:   �� 5:      $��2��6   $��	Solution:��6%   #��[ 66   �� 5;      $��3��6   $��Active:��6%   #��[ 64   �� 5<      $��4��6   $��
Catergory:��6%   #��[ 67   �� 5=      $��5��6   $��
ImageName:��6%   #��[ 67   �� 5?      $��0��6   $��1��6%     TextBlockSmall#��[ 6[   ��65   �� *SelectedAlgorithm.Id+6[   �� 5@      $��1��6   $��1��6%   #��[ 6_   ��65   �� *SelectedAlgorithm.Nummer+6_   �� 5A      $��2��6   $��1��6%   #��[ 6j   ��65   �� *%#SelectedAlgorithm.AlgorithmSolution+6j   �� 5B      $��3��6   $��1��6%   #��[ 6_   ��65   �� *SelectedAlgorithm.Actief+6_   �� 5C      $��4��6   $��1��6%   #��[ 6f   ��65   �� *!SelectedAlgorithm.CategorieNaam+6f   �� 5D      $��5��6   $��1��6%   #��[ 6c   ��65   �� *SelectedAlgorithm.Afbeelding+6c   �� 5F      $ 
Horizontal=�6   $��6��62   $��2��6?   .+�5G      �� $��Change��6     ButtonSmall#��[ 6U   ��6*   �� *WijzigAlgorithmCommand+6U   �� 5H      $��Add new��6   #��[ 6W   ��6+   �� *VoegAlgorithmToeCommand+6W   �� 5I      $
��Back��6     ButtonSmallBack#��[ 6H   ��6(   �� *ExitCommand+6H   5J      5K      5M      5N      