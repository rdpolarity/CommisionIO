   M S B A M L   `   `   `  ����O  KCommision.io WPF add, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:COMMISSION.io_WPF_addCOMMISSION.io_WPF_add  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   O KMaterialDesignColors, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:MaterialDesignColors;assembly=MaterialDesignColorsMaterialDesignColors 5
   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nulleHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5   	   *    $COMMISSION.io_WPF_add.COMMISSIONPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:COMMISSION.io_WPF_add     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   X TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   ]materialDesignColors@clr-namespace:MaterialDesignColors;assembly=MaterialDesignColors   5
   	   TwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf   5   	   H	 DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls 	 5   	      MaterialDesignBody#���   5	   	   $��Medium"�5   	   $��14(�5   	     N� 
FontFamily$X  Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	    N� Title$ COMMISSIONPage��5   	    � 	Resources 5       �� 
TargetType  themecircle 0 ,MaterialDesignFloatingActionMiniAccentButton �� BasedOn �� Property �� Value �� RelativeSource �� AncestorType&    COMMISSION.io_WPF_add.MainWindow	 �� Path
 �� Mode+  %MaterialDesignThemes.Wpf.ShadowAssist �� Color  StandardBorderBrush  StandardBackgroundBrush  HoverBorderBrush  SelectedBackgroundBrush  SelectedForegroundBrush  DisabledForegroundBrush 	 NormalBrush 
 NormalBorderBrush  HorizontalNormalBrush  HorizontalNormalBorderBrush  ListBoxBackgroundBrush �� 
StartPoint �� EndPoint � Color � Offset  StandardBrush  
GlyphBrush  PressedBrush  ScrollBarLineButton �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName  ScrollBarPageButton  ScrollBarThumb  VerticalScrollBar � RowDefinitions ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton  HorizontalScrollBar � ColumnDefinitions �� Triggers  FavsScrollViewer �� VerticalOffset � Value �� ScrollableHeight � Maximum  �� ViewportHeight! �� ViewportSize*" �� #ComputedVerticalScrollBarVisibility# �� Orientation$ �� HorizontalOffset% �� ScrollableWidth& �� ViewportWidth,' �� %ComputedHorizontalScrollBarVisibility��%�  &	       7  '�� �    &	 5    &	 S    &	 r    &	 �    &	 �    &	 �    &		 �    &	
 	    &	 '    &	 F    &	 d    &	 H    &	 �    &	     &	     7 	 7 
 7  7  7  &	 �    &	 V
    &	 �    7  7  7  7  7  7  7  &	     7  7  7  7 	 7 
 7  7  '�� !    7  7  &	 "    �� 5   
   " ��6   8   .�5      ��  � �� 6(   ��  �� *FindAncestor+"  $%	 DataContext.ApplyPrimaryCommand�$
 OneTime=��� 5       � �� 61   �� *managetheme+�� 5       � ��$ 25��6&   �� 5       � ��$ 25��6'   �� 5       �@ ShadowDepth$ Depth0=�6H   �� 5       � ��$ 10q�6'   �� 5       � �� 5      �� 5       6&   �� *ExemplarHue.Foreground+$
 OneTime=�5       5!      �� 5#   
   " ��6   .�5$      ��  � ��$ 
Nexa Light)�6+   5%      �� 5'   
   $
 #888��66   �� 5(   
   $ Black��6:   �� 5)   
   $
 #DDD��63   �� 5*   
   $
 Gray��6:   �� 5+   
   $ White��6:   �� 5,   
   $
 #888��6:   �� 5-   
   $
 #888��6.   �� 5.   
   $
 #888��64   �� 5/   
   $ Black��68   �� 50   
   $
 #888��6>   �� 51   
   $	 0,0&�53      $ 1,0.001&�6   ��55      � � 56      $ White��6#   $	 0.0Q�61   � 57      $ White��6#   $	 0.6Q�61   � 58      $ #DDDDDD��6#   $	 1.2Q�63   59      5;      �� 5<   
   $	 0,0&�5>      $	 0,1&�6   ��5@      � � 5A      $
 #FFF��6#   $	 0.0Q�60   � 5B      $
 #CCC��6#   $	 1.0Q�60   5C      5E      �� 5F   
   $
 #444��6-   �� 5G   
   $	 0,0&�5I      $	 0,1&�6   ��5K      � � 5L      $
 #BBB��6#   $	 0.0Q�60   � 5M      $
 #EEE��6#   $	 0.1Q�60   � 5N      $
 #EEE��6#   $	 0.9Q�60   � 5O      $
 #FFF��6#   $	 1.0Q�60   5P      5R      �� 5T   
   " ��6,   .�5U      ��  � y�$ Hidden=�6+   �� 5V       �@J�SnapsToDevicePixels . 64   �� 5W       �@�OverridesDefaultStyle . 66   �� 5X       � |� .  6*   �� 5Y       � �� 5Z      �� 5[      " ��6&   .R�5\      �� $��Border��5]      $��1q�5_      $ 2��5a      8��  8�� $��1q�5e      ._�5f      F� $��Center=�5g      $��Center=�5i      8�� ��5l      �� $	 Content� �� *TemplatedParent+5o       5p      P� 5q       � �� . . �5r   "   �� $ Border��6)   8   � ��5t   !   5u      P� 5v       � {� .  . �5w   "   �� 8   � ��5y   !   5z      5|      5~      5      �� 5�   
   " ��6,   .�5�      ��  � y�$ Hidden=�6+   �� 5�       �@J�SnapsToDevicePixels . 64   �� 5�       �@�OverridesDefaultStyle . 66   �� 5�       � �� .  6*   �� 5�       � |� .  6*   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� 
���   �6!   5�      5�      5�      �� 5�   
   " n�6'   .�5�      ��  �@J�SnapsToDevicePixels . 64   �� 5�       �@�OverridesDefaultStyle . 66   �� 5�       � �� .  6*   �� 5�       � |� .  6*   �� 5�       � �� 5�      �� 5�      " n�6&   .R�5�      �� $ 2��5�      #��z��5�      #��z��5�      $��0q�5�      $��8��5�      $��8,0,-2,0q�5�      5�      5�      5�      �� 5�   
   " ��5�      .R�5�      �  5�      �� 5�      $��0��6$   �� 5�      $��0.00001* �6$   �� 5�      $��0��6$   .+�5�      �� $��3��5�      $ 2��5�      
������ 5�      �� 5�      $��0��5�      8��  $��18��5�      $��ScrollBar.LineUpCommand��5�      $��M 0 4 L 8 4 L 4 0 Z��5�      ]� 5�      $��
PART_Track��5�      $��1��5�      ��.  5�      �� 5�      8�� $��ScrollBar.PageUpCommand��5�       5�      n� 5�      8�� $��1,0,1,0q�5�      8�� 8�� 5�       5�      �� 5�      8�� $��ScrollBar.PageDownCommand��5�      5�      �� 5�      $��3��5�      8�� $��18��5�      $��ScrollBar.LineDownCommand��5�      $��M 0 0 L 4 4 L 8 0 Z��5�      5�      5�      �� 5�   
   " ��5�      .R�5�      �  5�      �� 5�      $��18��6'   �� 5�      $��0.00001* �6'   �� 5�      $��18��6'   .+�5�      �� $��3��5�      $ 2��5�      ���#F0F0F05�      �� 5�      $��0��5�      8��  $��18��5�      $��ScrollBar.LineLeftCommand��5�      $��M 4 0 L 4 8 L 0 4 Z��5�      ]� 5�      $��
PART_Track��5�      $��1��5�      ��.   5�      �� 5�      8�� $��ScrollBar.PageLeftCommand��5       5     n� 5     8�� $��0,1,0,1q�5     8�� 8�� 5      5
     �� 5     8�� $ ��ScrollBar.PageRightCommand��5     5     �� 5     $��3��5     8�� $��18��5     $ ��ScrollBar.LineRightCommand��5     $��M 0 0 L 4 4 L 0 8 Z��5     5     5     �� 5  
   " ��6+   .�5     ��  �@J�SnapsToDevicePixels . 64   �� 5      �@�OverridesDefaultStyle . 66    5     P� 5      �@��Orientation$ 
Horizontal=�61   . �5      ��  � ��$
 Auto��6.   �� 5!      � ��$ 18��6/   �� 5"      � ��8   5$     5%     P� 5&      �@��Orientation$ Vertical=�61   . �5'     ��  � ��$ 18��6.   �� 5(      � ��$
 Auto��6/   �� 5)      � ��8  5+     5,     5.     �� 50  
   " ��6)   .�51     ��  �@�OverridesDefaultStyle . 66   �� 52      � �� 53     �� 54     " ��6&   .R�55     �  56     �� 57  "   $
��Auto �63   �� 58  "    5:     �� 5;  "   �� 5<  "   $
��Auto �60   .+�5?     �� $��1��65   �� 5A     $��PART_VerticalScrollBar��6(   # z 5C     # z 5D     #! z  5E     #y�z" 5F     �� 5G     $��PART_HorizontalScrollBar��6(   $# 
Horizontal=�5I     $��1��5K     $��1��5M     # z$ 5O     # z% 5P     #! z& 5Q     #y�z' 5R     5T     5U     5W     5X     5Y     .��5]     � .+�5a  
   )  #MaterialDesignThemes.Wpf.DialogHost  -   5        $��ReceiptDialog��5a  <   (   CloseOnClickAway( . )   DialogContent) 5b     � 5c     $��10q�6   $	��400��6#   $	��320��60   .+�5d     �� -   5        * ��Name$* get_receipt��5d  S   $��
Nexa Light)�6   $��5q�66   + �� 
IsReadOnly+ .  % !MaterialDesignTextFieldBoxTextBox#��[ 6h   )  #MaterialDesignThemes.Wpf.HintAssist,   Hint$, RECEIPT��6�   $��12(�6�   $	��350��6�   $	��Top=�6�   �� 5e       MaterialDesignFlatButton#��[ 5f     - �� IsCancel- . $��10q�5h     $2��,materialDesign:DialogHost.CloseDialogCommand��5i     $��Center=�6P   $��Bottom=�6m   $
��Auto��6�   ��5j     O
 Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem
 5k  -   ��6   3system&clr-namespace:System;assembly=mscorlib 	 6-   	False��5m     .��5o     '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]].   Kind$. Close=�62   5p     5q     5s     � 5w  
   $��5q�6   $	��Top=�6   $
��Left=�62   .+�5x     �� / �� Orientation$/ 
Horizontal=�6   .+�5y     �� -   5        0 ��Name$0 add_chip_panel��5y     $/ 
Horizontal=�65   5{     '  !MaterialDesignThemes.Wpf.PopupBox  5|     $��5q�5}       MaterialDesignPaper#���  5~     #���  5     #���   5�      - )MaterialDesignMultiFloatingActionPopupBox#��[ 5�     1   PlacementMode$1 BottomAndAlignCentres=�5�     2 ^� 	Placement$2 Right=�5�     $��Right=�5�     $��30��61   $��30��6<   3   PopupContent.3 5�     �� .+�5�     �� -   5        4 ��Name$4 sort_fav��5�  !   5 � ToolTip$5 Favorite��5�  !   .��5�       $. Heart=�5�  !   5�     �� 5�     -   5        $4 
sort_alpha��5�  !   $	5 A-Z��5�  !   .��5�       $. SortAlphabetical=�5�  !   5�     �� 5�     -   5        $4 	sort_date��5�  !   $5 
Date Added��5�  !   .��5�       $. Calendar=�5�  !   5�     5�     5�     5�     5�     �� 5�  
   -   5        $	��Top=�5�  6   $��0,45,0,0q�6N   .��5�     � .+�5�     � $��5,5,0,5q�6   $
��Left=�6(   $��50��6C   .+�5�     �� $	��Top=�6!   .+�5�     � $	��100��6   $	��Top=�6,   .+�5�     #  MaterialDesignThemes.Wpf.Card  $��Center=�62   $��40��6M   $��40��6X   ���	#FFFAED9E.��5�  "   �� $��Center=�6,   $��Center=�6I   16g   5�     5�     � 5�     $	��100��6   $	��Top=�6,   .+�5�       $��Center=�62   $��40��6M   $��40��6X   ���	#FFDBDDDF.��5�  "   �� $��Center=�6,   $��Center=�6I   26g   5�     5�     � 5�     $	��100��6   $	��Top=�6,   .+�5�       $��Center=�62   $��40��6M   $��40��6X   ���	#FFEECB87.��5�  "   �� $��Center=�6,   $��Center=�6I   36g   5�     5�     5�     5�     �� 5�     -   5        $��
lbTodoList��5�  M   #���   6   $��Stretch=�6_   $��50,0,0,0q�6�   ��5�     �� 5�     " ��6     5�     P� 5�  "    �@J�IsMouseOver . . �5�  &   ��  �@��
IsSelected . 6C   5�  #   5�     ��5�     �� 5�     .R�5�     ?	  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent	  C
  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase6 
  OpeningEffect6 6>   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *
ExpandIn+.��5�     � 
������ ��5�  "   �� 5�  &   " �6,    5�  *   P� 5�  .    �@J�IsMouseOver . . �5�  2   ��  � ��$	 130��6K   5�  /   5�  '   .+�5�  &   � $��Bottom=�6+   $��Stretch=�6F   .+�5�  *   �� $/ 
Horizontal=�65   $��Bottom=�6N   $
��Left=�6i   .+�5�  *   �� $4 proflie_open��6<   -	   5        $��5q�5�  1   #��[ 6R   $��Bottom=�6�   $
��Left=�6�   $
��Auto��6�   .��6�   VIEW PROFILE5�  +   �� 5�  *   $��1��64   $��10��6>   
�������6Y   �� 5�  *   $4 set_todo��61   -
   5        $��5q�5�  C   #��[ 6N   $��Bottom=�6�   $
��Left=�6�   $
��Auto��6�   
�������.��6�   TODO5�  +   �� 5�  *   $4 set_working��61   -   5        $��5q�5�  F   #��[ 6Q   $��Bottom=�6�   $
��Left=�6�   $
��Auto��6�   ���	#FFDBF36C.��6�   WORKING ON IT5�  +   �� 5�  *   $4 set_complete��61   -   5        $��5q�5�  G   #��[ 6R   $��Bottom=�6�   $
��Left=�6�   $
��Auto��6�   ���	#FF6DD471.��6�   
COMPLETE5�  +   5�  '   �� 5�  *   $/ 
Horizontal=�65   $��Right=�6N   .+�5�  *   �� 66   �� 5�  *   $4 moveup��6<   -   5        $��5q�5�  1   #��[ 6L   $��Bottom=�6~   $
��Left=�6�   $
��Auto��6�   .��5�  .     $. 	ChevronUp=�6F   5�  +   �� 5�  *   $4 movedown��6<   -   5        $��5q�5�  1   #��[ 6N   $��Bottom=�6�   $
��Left=�6�   $
��Auto��6�   .��5�  .     $. ChevronDown=�6F   5�  +   5�  '   5�  '   (  "MaterialDesignThemes.Wpf.ColorZone  5�  "   7  Name$7 
CLIENT_BOX��6;   8   Mode$8 Standard=�5�  %   9   CornerRadius$9 3��5�  %   :   ShadowDepth$: Depth2=�5�  %   $��5,5,0,5q�5�  %   $��88��66   ��5�  %   �� *	setcolour+$
 TwoWay=�.��5�  &   � .+�5�  *   �� $/ 
Horizontal=�5�  -   .+�5�  .   �� $��Center=�68   $��Center=�6U   6r   A� 5�  .   ; A�Name$; Profile_Picture��6Q   $��10q�6j   $��60��6v   $��60��6�   $��3��6�   ��66   �� *	outline+��5�  2   �� 5   6   < j� Stretch$< UniformToFill=�6A   = �� ImageSource= 6Y   �� *	imagepath+6}   5  /   � 5  .   .+�5  2   �� $/ 
Horizontal=�6=   .+�5  6   �� $��Center=�6A   .+�5  :   �� > ��Name$> COMMISSION_Title_Box��6\   $��
Nexa Light)�6D   $��Center=�5  5   $��5 0 0 0q�5  5   ��5
  5   �� *Title+5  ;   �� 5  :   $> COMMISSION_Client_Box��6\   $��
Nexa Light)�6D   $��Center=�5  5   $��5,0,0,0q�5  5   $��11(�6F   ��5  5   �� *Client+5  ;   5  7   5  3   �� 5  2   $* COMMISSION_Note_Box��6�   $��
Nexa Light)�6:   $��100,10,10,10q�6R   #��[ 6h   $, NOTES��6�   {�.  ? �� TextWrapping$
? Wrap=�6�   $��Center=�6$  $��Stretch=�6A  $��0��6]  $	��200��6j  $��0��6v  ��6  �� *Notes+6v  5  /   5  +   �� 5  *   $��Right=�65   $��Center=�6Q   $��10q�6l   $/ 
Horizontal=�6x   .+�5  .   �� $> COMMISSION_Date_Box��6P   $��
Nexa Light)�68   $��Center=�5   -   $��5q�5!  -   ��5"  -   �� *
Deadline+5$  /   �� 5%  .   $> COMMISSION_Cost��6[   $��
Nexa Light)�68   $��5q�6P   $��Center=�6t   ��5&  -   �� *Cost+5(  /   �� 5)  .   $4 
btn_reciet��65   -   5        $��5q�5)  I   @   OpenDialogCommand#��Z@ 6�   #��[ 6�   ��6T   �� A �� ElementName$A ReceiptDialog��.��5*  2     $. BookOpen=�6J   5+  /   d� 5,  .    ) %MaterialDesignFlatPrimaryToggleButton#��[ 5-  -   $+5 %MaterialDesignFlatPrimaryToggleButton��5.  -   B d� 	IsChecked$B FalseY�5/  -   ���	#FFFFB3B3
���  ��.��50  2     $. Heart=�51  1   $��21��52  1   $��21��53  1   54  /   55  +   56  '   57  #   58     5;     5<     5>     5?     5@     5A     5D     