   M S B A M L   `   `   `  ����O  KCommision.io WPF add, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:COMMISSION.io_WPF_addCOMMISSION.io_WPF_add  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   O KMaterialDesignColors, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:MaterialDesignColors;assembly=MaterialDesignColorsMaterialDesignColors 5
   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nulleHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5   	   '    !COMMISSION.io_WPF_add.ContactPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:COMMISSION.io_WPF_add     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   X TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   ]materialDesignColors@clr-namespace:MaterialDesignColors;assembly=MaterialDesignColors   5
   	   TwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf   5   	   H	 DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls 	 5   	      MaterialDesignBody#���   5	   	   $��Medium"�5   	   $��14(�5   	     N� 
FontFamily$X  Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	    N� Title$ ContactPage��5   	    � 	Resources 5        StandardBorderBrush �� Color  StandardBackgroundBrush  HoverBorderBrush  SelectedBackgroundBrush  SelectedForegroundBrush  DisabledForegroundBrush  NormalBrush  NormalBorderBrush 	 HorizontalNormalBrush 
 HorizontalNormalBorderBrush  ListBoxBackgroundBrush �� 
StartPoint �� EndPoint � Color � Offset  StandardBrush  
GlyphBrush  PressedBrush  ScrollBarLineButton �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� CornerRadius �� Path �� RelativeSource �� Triggers P� Property P� Value �� 
TargetName  ScrollBarPageButton  ScrollBarThumb  VerticalScrollBar � RowDefinitions ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton  HorizontalScrollBar � ColumnDefinitions �� Triggers  FavsScrollViewer �� VerticalOffset � Value �� ScrollableHeight � Maximum �� ViewportHeight �� ViewportSize* �� #ComputedVerticalScrollBarVisibility  �� Orientation! �� HorizontalOffset" �� ScrollableWidth# �� ViewportWidth,$ �� %ComputedHorizontalScrollBarVisibility��%�  &	       &	      &	 =     &	 [     &	 y     &	 �     &	 �     &	 �     &		 �     &	
     &	 /    &	     &	 �    &	 �    &	 �    7  7  7  7  7  &	 �    &	 !    &	 �	    7  7  7  7 	 7 
 7  7  &	 �    7  7  7  7  7  7  7  '�� �    7  7  &	 �    �� 5   
   $
 #888��66   �� 5   
   $ Black��6:   �� 5   
   $
 #DDD��63   �� 5   
   $
 Gray��6:   �� 5   
   $ White��6:   �� 5   
   $
 #888��6:   �� 5   
   $
 #888��6.   �� 5   
   $
 #888��64   �� 5   
   $ Black��68   �� 5   
   $
 #888��6>   �� 5   
   $	 0,0&�5      $ 1,0.001&�6   ��5!      � � 5"      $ White��6#   $	 0.0Q�61   � 5#      $ White��6#   $	 0.6Q�61   � 5$      $ #DDDDDD��6#   $	 1.2Q�63   5%      5'      �� 5(   
   $	 0,0&�5*      $	 0,1&�6   ��5,      � � 5-      $
 #FFF��6#   $	 0.0Q�60   � 5.      $
 #CCC��6#   $	 1.0Q�60   5/      51      �� 52   
   $
 #444��6-   �� 53   
   $	 0,0&�55      $	 0,1&�6   ��57      � � 58      $
 #BBB��6#   $	 0.0Q�60   � 59      $
 #EEE��6#   $	 0.1Q�60   � 5:      $
 #EEE��6#   $	 0.9Q�60   � 5;      $
 #FFF��6#   $	 1.0Q�60   5<      5>      �� 5@   
   " ��6,   .�5A      �� 	 � y�$
 Hidden=�6+   �� 5B      	 �@J�SnapsToDevicePixels
 . 64   �� 5C      	 �@�OverridesDefaultStyle
 . 66   �� 5D      	 � |�
 .  6*   �� 5E      	 � ��
 5F      �� 5G      " ��6&   .R�5H      �� $��Border��5I      $��1q�5K      $ 2��5M      8��  8�� $��1q�5Q      ._�5R      F� $��Center=�5S      $��Center=�5U      8�� ��5X      �� $ Content� �� *TemplatedParent+5[       5\      P� 5]       � �� . . �5^   "   �� $ Border��6)   8
  	 � ��5`   !   5a      P� 5b       � {� .  . �5c   "   �� 8
  	 � ��5e   !   5f      5h      5j      5k      �� 5l   
   " ��6,   .�5m      �� 	 � y�$
 Hidden=�6+   �� 5n      	 �@J�SnapsToDevicePixels
 . 64   �� 5o      	 �@�OverridesDefaultStyle
 . 66   �� 5p      	 � ��
 .  6*   �� 5q      	 � |�
 .  6*   �� 5r      	 � ��
 5s      �� 5t      " ��6&   .R�5u      �� 
���   �6!   5v      5x      5y      �� 5z   
   " n�6'   .�5{      �� 	 �@J�SnapsToDevicePixels
 . 64   �� 5|      	 �@�OverridesDefaultStyle
 . 66   �� 5}      	 � ��
 .  6*   �� 5~      	 � |�
 .  6*   �� 5      	 � ��
 5�      �� 5�      " n�6&   .R�5�      �� $ 2��5�      #��z��5�      #��z��5�      $��0q�5�      $��8��5�      $��8,0,-2,0q�5�      5�      5�      5�      �� 5�   
   " ��5�      .R�5�      �  5�      �� 5�      $��0��6$   �� 5�      $��0.00001* �6$   �� 5�      $��0��6$   .+�5�      �� $��3��5�      $ 2��5�      
������ 5�      �� 5�      $��0��5�      8��  $��18��5�      $��ScrollBar.LineUpCommand��5�      $��M 0 4 L 8 4 L 4 0 Z��5�      ]� 5�      $��
PART_Track��5�      $��1��5�      ��.  5�      �� 5�      8�� $��ScrollBar.PageUpCommand��5�       5�      n� 5�      8�� $��1,0,1,0q�5�      8�� 8�� 5�       5�      �� 5�      8�� $��ScrollBar.PageDownCommand��5�      5�      �� 5�      $��3��5�      8�� $��18��5�      $��ScrollBar.LineDownCommand��5�      $��M 0 0 L 4 4 L 8 0 Z��5�      5�      5�      �� 5�   
   " ��5�      .R�5�      �  5�      �� 5�      $��18��6'   �� 5�      $��0.00001* �6'   �� 5�      $��18��6'   .+�5�      �� $��3��5�      $ 2��5�      ���#F0F0F05�      �� 5�      $��0��5�      8��  $��18��5�      $��ScrollBar.LineLeftCommand��5�      $��M 4 0 L 4 8 L 0 4 Z��5�      ]� 5�      $��
PART_Track��5�      $��1��5�      ��.   5�      �� 5�      8�� $��ScrollBar.PageLeftCommand��5�       5�      n� 5�      8�� $��0,1,0,1q�5�      8�� 8�� 5�       5�      �� 5�      8�� $ ��ScrollBar.PageRightCommand��5�      5�      �� 5�      $��3��5�      8�� $��18��5      $ ��ScrollBar.LineRightCommand��5     $��M 0 0 L 4 4 L 0 8 Z��5     5     5     �� 5  
   " ��6+   .�5     �� 	 �@J�SnapsToDevicePixels
 . 64   �� 5	     	 �@�OverridesDefaultStyle
 . 66    5
     P� 5      �@��Orientation$ 
Horizontal=�61   . �5     �� 	 � ��$

 Auto��6.   �� 5     	 � ��$
 18��6/   �� 5     	 � ��8
   5     5     P� 5      �@��Orientation$ Vertical=�61   . �5     �� 	 � ��$
 18��6.   �� 5     	 � ��$

 Auto��6/   �� 5     	 � ��8
  5     5     5     �� 5  
   " ��6)   .�5     �� 	 �@�OverridesDefaultStyle
 . 66   �� 5     	 � ��
 5     �� 5      " ��6&   .R�5!     �  5"     �� 5#  "   $
��Auto �63   �� 5$  "    5&     �� 5'  "   �� 5(  "   $
��Auto �60   .+�5+     �� $��1��65   �� 5-     $��PART_VerticalScrollBar��6(   # z 5/     # z 50     # z 51     #y�z 52     �� 53     $��PART_HorizontalScrollBar��6(   $  
Horizontal=�55     $��1��57     $��1��59     # z! 5;     # z" 5<     # z# 5=     #y�z$ 5>     5@     5A     5C     5D     5E     .��5G     � .+�5H  
   �� -   5        .��5I     �� -   5        $��lbTodoList2��5I  b   #���   60   $��Stretch=�6u   ��5J     �� 5K     .R�5L     ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  .��5M     (  "MaterialDesignThemes.Wpf.ColorZone  %  Name$% Contact_box��67   .��5O  "   � .+�5P  &   �� & �� Orientation$& 
Horizontal=�61   .+�5Q  *   d� $��10q�5R  %   $��25��5S  %   $��25��5T  %   $��C��5U  %    * &MaterialDesignActionAccentToggleButton#��[ 5V  %   ' d� 	IsChecked$
' TrueY�5W  %   ( � ToolTip$,( &MaterialDesignActionAccentToggleButton��5X  %   �� 5Y  *   $��10q�64   $��Center=�6^   $��Stretch=�6y   ��6@   �� *ContactTitle+6y   �� 5\  *   ) ��Name$) DeviantArtLink��61   -   5          MaterialDesignFlatButton#��[ 5\  I   ���	#FFB3C7AF$��Center=�6�   $��Center=�6�   .��5]  .   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]*   Kind$* 
Deviantart=�6F   5^  +   �� 5`  *   $) FacebookLink��61   #��[ 6G   ���#4267B2$��Center=�6�   $��Center=�6�   .��5a  .     $* 
Deviantart=�6F   5b  +   5c  '   �� 5e  &   $��Right=�61   .+�5f  *   �� $��10q�64   ��6@   �� *ContactEmail+�� 5g  *   $��10q�64   ��6@   �� *ContactPhone+5h  '   5i  #   5k     5l     5m     5o     5p     5q     5r     