   M S B A M L   `   `   `  ����K  GAlgorithmTrainer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AlgorithmTrainer.ViewAlgorithmTrainer.View  5   	   I)clr-namespace:AlgorithmTrainer.ValidationAlgorithmTrainer.Validation  5   	   1    +AlgorithmTrainer.View.AlgorithmDetailWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AlgorithmTrainer.View     5   	   7v)clr-namespace:AlgorithmTrainer.Validation     5   	      
Background#��[  5	   	   $	��375��5   '   $	��650��67   $	��375��6F   $	��650��6V     � Icon$7  1/AlgorithmTrainer;component/images/RubiksIcon.png��6e    � WindowStartupLocation$ CenterScreen=�6�    � DataContext 5
   	   ��   mainViewModelLocator �� Source# [  �� Path$$ AlgorithmDetailWindowViewModel� � Title 5   	   �� *WindowTitle+.��5      � $��50q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   6-   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6-   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6-   �� 5      $��20 �6   6*   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $	��150 �6   6-   �� 5      $��* �6   6+   .+�5"   
   �� $��0��6   $��OLL Id:��6!   $y�	Collapsed=�60   �� 5#   
   $��1��6   $��Guide Number:��6!     TextBlockLarge#��[ 66   �� 5$   
   $��2��6   $��	Solution:��6!   #��[ 62   �� 5%   
   $��3��6   $��Active:��6!   #��[ 60   �� 5&   
   $��4��6   $��
Catergory:��6!   #��[ 63   �� 5'   
   $��5��6   $��Upload image:��6!   #��[ 66   y�6^   �� *ShowLoadImage+�� 5)   
   $��0��6   $��1��6!   $y�	Collapsed=�6W   ��61   �� *SelectedAlgorithm.Id+6W   �� 5*   
   -   5        $��Nummer��5*      $��1��6    $��1��6-     TextBoxSmall#��[ 6=   .��6d   ��5+      �� 5,      $ SelectedAlgorithm.Nummer�6    �� UpdateSourceTrigger$ PropertyChanged=�66   	 �� Mode$	 TwoWay=�6\   
 �� ValidationRules
 5-      .   (AlgorithmTrainer.Validation.MyValidation  5.      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ UpdatedValue=�6%   6E   50      .��51      52      �� 54   
   $��2��6   $��1��6   #��[ 6d   ��6/   �� *%#SelectedAlgorithm.AlgorithmSolution+6d   �� 55   
   $��3��6   $��1��6      ComboBox#��[ 60   .@�56      �� $
��True��6     ComboBoxItem#��[ 6P    �� 
IsSelected 6*   �� *IsSelectedTrue+6P   �� 57      $��False��6   #��[ 6S    6+   �� *IsSelectedFalse+6S   58      �� 59   
   $��4��6   $��1��6!     CategoriesComboboxTemplate#��[ 5;      #��[ 6L   #��[ 6   ��59   1   �� *
Categories+ �� SelectedItem 5:      �� *SelectedCategorie+5;      �� 5<   
   $��5��6   $��1��6   $��Browse��6.     ButtonSmall#��[ 6d   $��0,0,0,0q�6�   $
��Left=�6�   ��6?   �� *LoadImageCommand+y�6�   �� *ShowLoadImage+�� 5=   
    �� Orientation$ 
Horizontal=�6   $��7��6.   $��2��6;   .+�5>      �� $
��Save��6   #��[ 6G   ��6%   �� *UpdateCommand+6G   �� 5?      $��Delete��6   #��[ 6I   ��6'   �� *DeleteCommand+{�6n   �� *DeleteButtonEnabled+�� 5@      
���  ��$��
10,20,10,0q�6P   ��6   �� *ValidationMessage+6P   5A      5]      5^      