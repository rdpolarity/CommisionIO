   M S B A M L   `   `   `  ���� O  KCommision.io WPF add, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:COMMISSION.io_WPF_addCOMMISSION.io_WPF_add  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity O KMaterialDesignColors, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:MaterialDesignColors;assembly=MaterialDesignColorsMaterialDesignColors V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nulleHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf *    $COMMISSION.io_WPF_add.COMMISSIONPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:COMMISSION.io_WPF_add     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     X TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   ]materialDesignColors@clr-namespace:MaterialDesignColors;assembly=MaterialDesignColors   TwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf   H	 DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls 	    MaterialDesignBody#���   $��Medium"�$��14(�  N� 
FontFamily$X  Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)� N� Title$ COMMISSIONPage�� � 	Resources  �� 
TargetType  themecircle 0 ,MaterialDesignFloatingActionMiniAccentButton �� BasedOn �� Property �� Value �� RelativeSource �� AncestorType&    COMMISSION.io_WPF_add.MainWindow	 �� Path
 �� Mode+  %MaterialDesignThemes.Wpf.ShadowAssist �� Color  StandardBorderBrush  StandardBackgroundBrush  HoverBorderBrush  SelectedBackgroundBrush  SelectedForegroundBrush  DisabledForegroundBrush 	 NormalBrush 
 NormalBorderBrush  HorizontalNormalBrush  HorizontalNormalBorderBrush  ListBoxBackgroundBrush �� 
StartPoint �� EndPoint � Color � Offset  StandardBrush  
GlyphBrush  PressedBrush  ScrollBarLineButton �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName  ScrollBarPageButton  ScrollBarThumb  VerticalScrollBar � RowDefinitions ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton  HorizontalScrollBar � ColumnDefinitions �� Triggers  FavsScrollViewer �� VerticalOffset � Value �� ScrollableHeight � Maximum  �� ViewportHeight! �� ViewportSize*" �� #ComputedVerticalScrollBarVisibility# �� Orientation$ �� HorizontalOffset% �� ScrollableWidth& �� ViewportWidth,' �� %ComputedHorizontalScrollBarVisibility��%�  &	       7  '�� Q    &	 |    &	 �    &	 �    &	 �    &	 �    &	 �    &		 �    &	
 �    &	 �    &	     &	     &	 �    &	 �    &	 �    &	 �    7 	 7 
 7  7  7  &	 %    &	 �    &	 �    7  7  7  7  7  7  7  &	 �    7  7  7  7 	 7 
 7  7  '�� G
    7  7  &	 �    �� " ��8   .���  � �� ��  �� *FindAncestor+"  $%	 DataContext.ApplyPrimaryCommand�$
 OneTime=���  � �� �� *managetheme+��  � ��$ 25����  � ��$ 25����  �@ ShadowDepth$ Depth0=���  � ��$ 10q���  � �� ��  �� *ExemplarHue.Foreground+$
 OneTime=��� " ��.���  � ��$ 
Nexa Light)��� $
 #888���� $ Black���� $
 #DDD���� $
 Gray���� $ White���� $
 #888���� $
 #888���� $
 #888���� $ Black���� $
 #888���� $	 0,0&�$ 1,0.001&���� � $ White��$	 0.0Q�� $ White��$	 0.6Q�� $ #DDDDDD��$	 1.2Q��� $	 0,0&�$	 0,1&���� � $
 #FFF��$	 0.0Q�� $
 #CCC��$	 1.0Q��� $
 #444���� $	 0,0&�$	 0,1&���� � $
 #BBB��$	 0.0Q�� $
 #EEE��$	 0.1Q�� $
 #EEE��$	 0.9Q�� $
 #FFF��$	 1.0Q��� " ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � |� .  ��  � �� �� " ��.R��� $��Border��$��1q�$ 2��8��  8�� $��1q�._�F� $��Center=�$��Center=�8�� ���� $	 Content� �� *TemplatedParent+ P�  � �� . . ��� $ Border��8   � ��P�  � {� .  . ��� 8   � ���� " ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 
���   ��� " n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " n�.R��� $ 2��#��z��#��z��$��0q�$��8��$��8,0,-2,0q��� " ��.R��  �� $��0���� $��0.00001* ��� $��0��.+��� $��3��$ 2��
������ �� $��0��8��  $��18��$��ScrollBar.LineUpCommand��$��M 0 4 L 8 4 L 4 0 Z��]� $��
PART_Track��$��1����.  �� 8�� $��ScrollBar.PageUpCommand�� n� 8�� $��1,0,1,0q�8�� 8��  �� 8�� $��ScrollBar.PageDownCommand���� $��3��8�� $��18��$��ScrollBar.LineDownCommand��$��M 0 0 L 4 4 L 8 0 Z���� " ��.R��  �� $��18���� $��0.00001* ��� $��18��.+��� $��3��$ 2�����#F0F0F0�� $��0��8��  $��18��$��ScrollBar.LineLeftCommand��$��M 4 0 L 4 8 L 0 4 Z��]� $��
PART_Track��$��1����.   �� 8�� $��ScrollBar.PageLeftCommand�� n� 8�� $��0,1,0,1q�8�� 8��  �� 8�� $ ��ScrollBar.PageRightCommand���� $��3��8�� $��18��$ ��ScrollBar.LineRightCommand��$��M 0 0 L 4 4 L 0 8 Z���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle .  P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 18����  � ��8   P�  �@��Orientation$ Vertical=�. ���  � ��$ 18����  � ��$
 Auto����  � ��8  �� " ��.���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��  �� $
��Auto ���  �� �� $
��Auto �.+��� $��1���� $��PART_VerticalScrollBar��# z # z #! z  #y�z" �� $��PART_HorizontalScrollBar��$# 
Horizontal=�$��1��$��1��# z$ # z% #! z& #y�z' .��� .+�)  #MaterialDesignThemes.Wpf.DialogHost  -   $��ReceiptDialog��(   CloseOnClickAway( . )   DialogContent) � $��10q�$	��400��$	��320��.+��� -   * ��Name$* get_receipt��+ �� TextWrapping$
+ Wrap=�$��
Nexa Light)�$��5q�, �� 
IsReadOnly, .  % !MaterialDesignTextFieldBoxTextBox#��[ )  #MaterialDesignThemes.Wpf.HintAssist-   Hint$- RECEIPT��$��20(�$	��350��$	��Top=���   MaterialDesignFlatButton#��[ . �� IsCancel. . $��10q�$2��,materialDesign:DialogHost.CloseDialogCommand��$��Center=�$��Bottom=�$
��Auto����O
 Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem
 ��3system&clr-namespace:System;assembly=mscorlib 	 	False��.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]/   Kind$/ Close=�� $��5q�$	��Top=�$
��Left=�.+��� 0 �� Orientation$0 
Horizontal=�.+��� -   1 ��Name$1 add_chip_panel��$0 
Horizontal=�'  !MaterialDesignThemes.Wpf.PopupBox  $��5q�  MaterialDesignPaper#���  #���  #���    - )MaterialDesignMultiFloatingActionPopupBox#��[ 2   PlacementMode$2 BottomAndAlignCentres=�3 ^� 	Placement$3 Right=�$��Right=�$��30��$��30��4   PopupContent.4 �� .+��� -   5 ��Name$5 sort_fav��6 � ToolTip$6 Favorite��.��  $/ Heart=��� -   $5 
sort_alpha��$	6 A-Z��.��  $/ SortAlphabetical=��� -   $5 	sort_date��$6 
Date Added��.��  $/ Calendar=��� -   $	��Top=�$��0,45,0,0q�.��� .+��� -   $��lstbox_commission��#���   $��Stretch=����� " ��# [B�� P�  �@J�IsKeyboardFocusWithin . . ���  �@��
IsSelected . .�-	   ���� .R�?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C	  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase7 	  OpeningEffect7 D
  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension
  *
ExpandIn+.��� 
������ ���� " � P�  �@J�IsMouseOver . . ���  � ��$	 130��.+�� $��Bottom=�$��Stretch=�.+��� $0 
Horizontal=�$��Bottom=�$
��Left=�.+��� $5 proflie_open��-
   $��5q�#��[ $��Bottom=�$
��Left=�$
��Auto��.��VIEW PROFILE�� $��1��$��10��
��������� $5 set_todo��-   $��5q�#��[ $��Bottom=�$
��Left=�$
��Auto��
�������.��TODO�� $5 set_working��-   $��5q�#��[ $��Bottom=�$
��Left=�$
��Auto�����	#FFDBF36C.��WORKING ON IT�� $5 set_complete��-   $��5q�#��[ $��Bottom=�$
��Left=�$
��Auto�����	#FF6DD471.��
COMPLETE�� $0 
Horizontal=�$��Right=�.+��� �� $5 moveup��-   $��5q�#��[ $��Bottom=�$
��Left=�$
��Auto��.��  $/ 	ChevronUp=��� $5 movedown��-   $��5q�#��[ $��Bottom=�$
��Left=�$
��Auto��.��  $/ ChevronDown=�(  "MaterialDesignThemes.Wpf.ColorZone  8  Name$8 
CLIENT_BOX��9   Mode$9 Standard=�:   CornerRadius$: 3��;   ShadowDepth$; Depth2=�$��5,5,0,5q�$��88������ *	setcolour+.��� .+��� $0 
Horizontal=�.+��� $��Center=�$��Center=�A� < A�Name$< Profile_Picture��$��10q�$��60��$��60��$��3������ *	outline+���� = j� Stretch$= UniformToFill=�> �� ImageSource> �� *	imagepath+� .+��� $0 
Horizontal=�.+��� $��Center=�.+��� ? ��Name$? COMMISSION_Title_Box��$��
Nexa Light)�$��Center=�$��5 0 0 0q����� *Title+�� $? COMMISSION_Client_Box��$��
Nexa Light)�$��Center=�$��5,0,0,0q�$��11(����� *Client+�� $* COMMISSION_Note_Box��$��
Nexa Light)�$��100,10,10,10q�#��[ $- NOTES��{�.  $
+ Wrap=�$��Center=�$��Stretch=�$��0��$	��200��$��0������ *Notes+�� $��Right=�$��Center=�$��10q�$0 
Horizontal=�.+��� $? COMMISSION_Date_Box��$��
Nexa Light)�$��Center=�$��5q����� *
Deadline+�� $? COMMISSION_Cost��$��
Nexa Light)�$��5q�$��Center=����� *Cost+�� $5 
btn_reciet��-   $��5q�@   OpenDialogCommand#��Z@ #��[ ���� A �� ElementName$A ReceiptDialog��.��  $/ BookOpen=�d�  ) %MaterialDesignFlatPrimaryToggleButton#��[ $+6 %MaterialDesignFlatPrimaryToggleButton��B d� 	IsChecked$B FalseY����	#FFFFB3B3
���  ��.��  $/ Heart=�$��21��$��21��