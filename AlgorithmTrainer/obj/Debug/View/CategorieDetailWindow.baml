   M S B A M L   `   `   `  ����K  GAlgorithmTrainer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AlgorithmTrainer.ViewAlgorithmTrainer.View  5   	   I)clr-namespace:AlgorithmTrainer.ValidationAlgorithmTrainer.Validation  5   	   1    +AlgorithmTrainer.View.CategorieDetailWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:AlgorithmTrainer.View     5   	   7v)clr-namespace:AlgorithmTrainer.Validation     5   	      
Background#��[  5	   	   $	��375��5   '   $	��650��67   $	��375��6F   $	��650��6V     � Icon$7  1/AlgorithmTrainer;component/images/RubiksIcon.png��6e    � WindowStartupLocation$ CenterScreen=�6�    � DataContext 5
   	   ��   mainViewModelLocator �� Source# [  �� Path$$ CategorieDetailWindowViewModel� � Title 5   	   �� *WindowTitle+.��5      � $��1��6   $��50q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   6-   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��10 �6   6*    � ColumnDefinitions 5   
   �� 5      $	��150 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��0��6   $��OLL Number:��6!   $
��Bold"�64   $y�	Collapsed=�6F   �� 5   
   $��1��6   $��Name:��6!     TextBlockLarge#��[ 6.   �� 5   
   $��0��6   $��1��6!   $y�	Collapsed=�6W   ��61   �� *SelectedCategorie.Id+6W   �� 5   
   -   5        $
��Naam��5      $��1��6   $��1��6,     TextBoxSmall#��[ 6=   .��6d   ��5   
   �� 5      $ SelectedCategorie.Naam�6    �� UpdateSourceTrigger$ PropertyChanged=�64   	 �� Mode$	 TwoWay=�6Z   
 �� ValidationRules
 5       .   (AlgorithmTrainer.Validation.MyValidation  5!      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ UpdatedValue=�6%   6E   5#      .��5$      5%      �� 5&   
   $��2��6   $��1��6!   
���  ����61   �� *ValidationMessage+6T   �� 5)   
    �� Orientation$ 
Horizontal=�6   $��3��6.   $��2��6;   .+�5*      �� $
��Save��6     ButtonSmall#��[ 6G   ��6%   �� *UpdateCommand+6G   �� 5+      $��Delete��6   #��[ 6I   ��6'   �� *DeleteCommand+{�6n   �� *DeleteButtonEnabled+5,      5.      5/      