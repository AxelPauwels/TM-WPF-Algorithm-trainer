   M S B A M L   `   `   `  ����K  GAlgorithmTrainer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AlgorithmTrainer.ViewAlgorithmTrainer.View  5   	   &     AlgorithmTrainer.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AlgorithmTrainer.View     5   	     � Title$  Algorithm OLL Trainer��5
   	    � Icon$7 1/AlgorithmTrainer;component/images/RubiksIcon.png��6)    � WindowStartupLocation$ CenterScreen=�6b    � WindowState$ 	Maximized=�6�   $	��775��5   	   $	��365��6    +� FocusedElement 5   	   ��  �� ElementName$ startStopButton�� � DataContext 5	   	   ��    mainViewModelLocator �� Source# [   �� Path$ MainWindowViewModel���5      �� 5   
   	 j� Stretch$	 UniformToFill=�68   
 �� ImageSource
 6   �� *
Background+68    � 	Resources 5        TemplateWrapPanelImages �� Orientation �� StringFormat  ButtonAsImage  WrapPanelTextBlock��%�  &	       7   7  7   7  7  7  �� 5   
   .R�5      �� $ 
Horizontal=�6   $��	8,10,8,10q�62   
������ $	��125��6_   .+�5      �� $��ollId��6   $��0��6<   $y�	Collapsed=�6G   ��6%   �� *Id+6`   �� 5      $��afbeeldingPath��6/   $y�	Collapsed=�6    6E   �� 8   $ MainWindowViewModel���5      �� *AfbeeldingPath+�� 5      $��
afbeelding��6/   $y�	Collapsed=�6   ��6A   �� *
Afbeelding+�� 5      $��imageSource��63   $y�	Collapsed=�6   ��5      `� 5      $ {0}{1}��6'   .1�5      �� $ afbeeldingPath��6&   $ Content�6C   �� 5      $ 
afbeelding��6&   $ Content�6?   5       5"      �� 5$      
������ 
������ 8��  6   �� 8  $ MainWindowViewModel���6x   �� *AlgorithmActiefCommand+��6�   �� *	Content+$ ollId��.��5%      �� $��65��6N   $��65��6]   ��6   �� *Text+$ imageSource��6]   5&      �� 5'      $ Vertical=�6   .+�5(      �� 
���   �$��1q�61   $��50��6E   $��10��6P   $��0,10,0,0q�6\   ._�5)      �� $
��Left=�6$   $��50��6b   $��10��6�   ��6?   �� *ActiefColor+��6p   �� *ResultaatProgress+6�   5*      �� 5+      8�� ��6    �� *ResultaatAverage+$ Avg {0}��6Z   �� 5,      8�� ��6    �� *ResultaatBest+$ Best {0}��6X   �� 5-      8�� ��6    �� *ResultaatWorst+$ 	Worst {0}��6Z   5.      5/      50      51      .��53      � .+�54   
   ]� ��. .+�56      �� $ 
Horizontal=�6   $	��Top=�62   $��	-1,-1,0,0q�6G   .+�57      c�   Toolbar#��[ 6   
���   �{�6N   �� *	IsEnabled+.@�58      o�   Menu#��[ 6   .@�59      m� $
��Edit��6#     HoofdMenuItem#��[ 61   .@�5:      m� $��
Algorithms��6'     MenuItem#��[ 6e    m� Command 6;   �� *EditAlgorithmsCommand+6e   m� 5;      $��
Categories��6'   #��[ 6e    6;   �� *EditCategoriesCommand+6e   m� 5<      $��Results��6'   #��[ 6c    69   �� *EditResultatenCommand+6c   5=      5>      o� 5?      $��Stretch=�6=   
������   MenuBackgrounds#��[ 6s   ��6   �� *	MenuItems+6s   o� 5@      #��[ 6   .@�5A      m� $��About��6#   #��[ 6S    62   �� *AboutCommand+6S   5B      5C      5D      � 5G       � RowDefinitions 5H      �� 5I      $��2* �6$   �� 5J      $��2* �6$   �� 5K      $
��auto �6$   �� 5L      $��* �6$   �� 5M      $
��auto �6$   �� 5N      $
��auto �6$    � ColumnDefinitions 5P      �� 5Q      $	��175 �6'   �� 5R      $	��175 �6'   �� 5S      $��* �6'   .+�5W      �� -   5        $��randomImage��5W      $y�	Collapsed=�6U   ��6/   �� *RandomAlgorithmImage+6U   �� 5X      $��0��6I   $��2��6V    	 RandomImage#��[	 6j   $��0,50,0,0q�6�   ��6   �� *Text+$ randomImage��6�   �� 5[      -   5        $��	textTimer��5[      $��1��6-   $��2��6:   $	��150(�6l   $��Center=�6{   ��6N   �� *TimerDisplay+6{   �� 5^      $,��&Use spacebar to start / stop the timer��6   $��2��6J   $��2��6W   $��10(�6l   $��Center=�6z   $��Verdana)�6�   �� 5a      $��3��6   $��2��6+   $ 
Horizontal=�6?   $��Center=�6X   $��10,10,10,10q�6u   .+�5b      �� -   5        $��redirectFocus��5b      $y�	Collapsed=�62   6K   �� 5c      -   5        $��startStopButton��5c   ^    
 ButtonLarge#��[
 6u   ��6   �� *TimerStatus+��6=   �� *TimerCommand+{�6�   �� *	IsEnabled+�� 5d      $��Delete Last��6   #��[
 6]   $��	10,0,10,0q�6�   ��63   �� *DeleteLastTimeCommand+{�6�   �� *	IsEnabled+�� 5e      $��Reset Active��6   #��[
 6\   ��64   �� *ResetActiveCommand+{�6�   �� *	IsEnabled+5f      �� 5i      $��Settings��6   $��4��6-   $��2��6:   $��10,10,10,75q�6N   $
��Bold"�6c   .��5j      � .+�5k      �� $ Vertical=�6%   $��10q�6<   .+�5l      �� $ 
Horizontal=�6*   .+�5m   "   �� -   5        $��textboxInspectionTime��5m   *     SettingsTextBox#��[ 6g   $��0,0,2,5q�6�   ��6G   �� *InspectionTime+6�   �� 5n   "   -   5        $��labelInspectionTime��5n   (     	FontSmall#��[ 6C   .��6f   Sec. inspection time6|   5o      �� 5p      $ 
Horizontal=�6)   .+�5q   "   �� -   5        $��checkboxEnableSound��5q   +     SettingsCheckBox#��[ 6f    d� 	IsChecked 6F   �� *	PlaySound+6f   �� 5r   "   -   5        $��labelEnableSound��5r   (   #��[ 6@   .��6c   
Play sound6o   5s      �� 5t      $ 
Horizontal=�6)   .+�5u   "   �� -	   5        $��checkboxShowResults��5u   +   #��[ 6r    6G   �� *ShowResultsBySession+6r   �� 5v   "   -
   5        $��labelShowResults��5v   (   #��[ 6@   .��6c   %#Show only results from this session6�   5w      5x      5y      5z      � 5}      $��2��6   $��5��6,   $��10,10,10,10q�6=   .+�5~      �� #��[ 6B     ListBoxWrapPanel#��[ 6�   
������ 
������ $��Disabled=�6  ��6   �� *
Algorithms+ �� SelectedItem 6z   �� *RandomAlgorithm+��5      �� 5�      .R�5�   "   �  � Orientation$ Vertical=�6,   5�      5�      5�      �� 5�      $��5��6   $��0��6)   $��3��69   $��UPDATING��6M    �� TextAlignment$ Center=�6�    �� Padding$ 0,5,0,0q�6�     TextBlockLarge#��[ 6�   y�6^   �� *ProgressVisibility+6�   � 5�      $��5��6   $��0��6+   $��3��6;     ProgressBar#��[ 6y   y�6O   �� *ProgressVisibility+6y   5�      5�      5�      5�      