   M S B A M L   `   `   `  ����K  GAlgorithmTrainer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AlgorithmTrainer.ViewAlgorithmTrainer.View  5   	   +    %AlgorithmTrainer.View.ResultaatWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AlgorithmTrainer.View     5   	      
Background#��[  5   	     � Title$  Results��5
   	   $	��585��6   $	��900��6)   $	��585��68   $	��900��6H    � Icon$7 1/AlgorithmTrainer;component/images/RubiksIcon.png��6W    � WindowStartupLocation$ CenterScreen=�6�    � DataContext 5	   	   ��   mainViewModelLocator �� Source# [  �� Path$ ResultaatWindowViewModel� � 	Resources 5       " AlgorithmsComboboxItemTemplate �� Orientation �� StringFormat	 �� ElementName
 �� TextAlignment��%  &	       7  �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��afbeeldingPath��6/   $y�	Collapsed=�6    6E   �� 8   $ MainWindowViewModel���5      �� *AfbeeldingPath+�� 5      $��
afbeelding��6/   $y�	Collapsed=�6   ��6A   �� *
Afbeelding+�� 5      $��imageSource��63   $y�	Collapsed=�6   ��5      `� 5      $ {0}{1}��6'   .1�5      �� $	 afbeeldingPath��6&   $ Content�6C   �� 5      $	 
afbeelding��6&   $ Content�6?   5      5      �� 5      $��ollId��6   $
 Center=�6>   $��Center=�6V   $��Center=�6s   $��	90,0,10,0q�6�   $��20��6�   ��6)   �� *Id+6�   �� 5      $��40��6J   $	�� 40��6Y   ��6   �� *Text+$	 imageSource��6Y   5      5      5       .��5"      �  � ColumnDefinitions 5#   
   �� 5$      $	��175 �6   6-   �� 5%      $	��175 �6   6-   �� 5&      $��* �6   6+   .+�5)   
   �� $��0��6     ListBoxSmall#��[ 6i     ListboxItemSmall#��[ 6�   $	��160��6�   ��6#   �� *Datums+ �� SelectedItem 6B   �� *SelectedDatum+��5*      �� 5+      .R�5,      �  5-      �� 5.      $	��158 �6/   6=   �� 5/      $��68 �6/   6<   .+�51      �� $��0��6$     TextBlockSmall#��[ 6r   ��64   �� *Datum+$ d�� �� ConverterCulture$ nl-BE��6r   52      53      55      �� 57   
   $��1��6   #��[ 6x   #��[ 6�   $	��160��6�   ��6#   �� *ResultatenOpDatum+ 6M   �� *SelectedResultaat+��58      �� 59      .R�5:      �  5;      �� 5<      $��88 �6/   6<   �� 5=      $��68 �6/   6<   .+�5?      �� $��0��6$   #��[ 6�   ��64   �� *Datum+$ {0:HH:mm:ssu}��$ nl-BE��6�   �� 5@      $��1��6$   #��[ 6e   ��64   �� *Tijd+$ 	 {0} sec.��6e   5A      5B      5D      � 5F   
   $��2��6   $��50q�6    � RowDefinitions 5G      �� 5H      $
��auto �6    61   �� 5I      $
��auto �6    60   �� 5J      $
��auto �6    61   �� 5K      $
��auto �6    60   �� 5L      $��20 �6    6.   �� 5M      $
��auto �6    60    5O      �� 5P      $	��150 �6#   61   �� 5Q      $��* �6#   6/   .+�5T      �� $��0��6   $��Result:��6%     TextBlockLarge#��[ 64   $��0,-5,0,0q�6\   �� 5U      $��1��6   $��Date:��6%   #��[ 62   �� 5V      $��2��6   $��Time:��6%   #��[ 62   �� 5W      $��3��6   $
��OLL:��6%   #��[ 61   $��40��6Y   $��0,20,0,0q�6e   �� 5Y      $��0��6   $��1��6%   #��[ 6[   $��2,0,0,0q�6�   ��65   �� *SelectedResultaat.Id+6�   �� 5Z      $��1��6   $��1��6#     TextBoxSmall#��[ 6s   ��63   �� *SelectedResultaat.Datum+$ nl-BE��6s   �� 5[      $��2��6   $��1��6#   #��[ 6[   ��63   �� *SelectedResultaat.Tijd+6[   �� 5]      $��3��6   $��1��6%   #��[ 5_        ComboBoxItem#��[ 6P    	 ComboBox#��[	 6�   ��5]   5   �� *
Algorithms+ 5^      �� *SelectedAlgorithm+5_   �   �� 5a      $ 
Horizontal=�6   $��5��62   $��2��6?   .+�5b      �� $
��Save��6    
 ButtonSmall#��[
 6T   ��6)   �� *WijzigResultaatCommand+6T   �� 5c      $��Add new��6   #��[
 6X   ��6,   �� *VoegResultaatToeCommand+6X   �� 5d      $��Delete��6   #��[
 6V   ��6+   �� *DeleteResultaatCommand+{�6{   �� *DeleteButtonEnabled+�� 5e      $
��Back��6     ButtonSmallBack#��[ 6H   ��6(   �� *ExitCommand+6H   5f      5g      5i      5j      