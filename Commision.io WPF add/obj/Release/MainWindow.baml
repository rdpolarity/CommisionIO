   M S B A M L   `   `   `  ���� O  KCommision.io WPF add, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:COMMISSION.io_WPF_addCOMMISSION.io_WPF_add  E'clr-namespace:MaterialDesignDemo.DomainMaterialDesignDemo.Domain  c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity O KMaterialDesignColors, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:MaterialDesignColors;assembly=MaterialDesignColorsMaterialDesignColors V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nulleHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf &     COMMISSION.io_WPF_add.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:COMMISSION.io_WPF_add     J FWpfAnimatedGif, Version=1.4.15.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5domain1'clr-namespace:MaterialDesignDemo.Domain  XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  X	 TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 ]materialDesignColors@clr-namespace:MaterialDesignColors;assembly=MaterialDesignColors  	 TwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf  	 H
 DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls 
 E ADragablz, Version=0.0.3.203, Culture=neutral, PublicKeyToken=null6dragablz'http://dragablz.net/winfx/xaml/dragablz  -     �Name$  	WindowSet��   MaterialDesignBody#���   ���	#33FFFFFF � AllowsTransparency . $��Medium"�$��14(�$X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)� � WindowStartupLocation$ CenterScreen=� � Title$ 
MainWindow��$��609.457��$	��784�� � 
ResizeMode$ NoResize=� � Topmost .  � WindowStyle$
 None=����	#DDFFFFFF � 	Resources  �� 
TargetType  themecircle 0 ,MaterialDesignFloatingActionMiniAccentButton	 �� BasedOn
 �� Property �� Value �� RelativeSource �� AncestorType&    COMMISSION.io_WPF_add.MainWindow �� Path �� Mode+  %MaterialDesignThemes.Wpf.ShadowAssist �� Color��%_  &	       7  �� " ��8	   .��� 
 � �� ��  �� *FindAncestor+"  $% DataContext.ApplyPrimaryCommand�$ OneTime=��� 
 � �� �� *managetheme+�� 
 � ��$ 25���� 
 � ��$ 25���� 
 �@ ShadowDepth$ Depth0=��� 
 � ��$ 10q��� 
 � �� ��  �� *ExemplarHue.Foreground+$ OneTime=�.��� .+��� -    ��Name$ help_box��$��	Quicksand)�$
��Wrap=�$��Center=�$��Center=����	#DDFFFFFF �� TextAlignment$ Center=�$��18(� J� Opacity$ 0Q�
PRESS THE '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ PlusCircleOutline=����	#DDFFFFFF=; IN THE BOTTOM RIGHT OF THE APPLICATION TO ADD A COMMISSION� -    �Name$ ADD_GRID��$��0,69,0,0q�.+�)  #MaterialDesignThemes.Wpf.DialogHost  -     Name$ edit_dialog��.�� � -     �Name$
 Body��  � NavigationUIVisibility$ Hidden=�$��0,40,0,0q�� .+�� $��0,69,0,0q�.+�  Dragablz.TabablzControl  -     Name$ 	tabheader��$��16q�$��0q�.@��� $
��HOME��$��	Quicksand)�.�� � -   $��hom_instance���� $��COMMISSIONS��$��	Quicksand)�.�� � -   $��com_instance���� $��CONTACTS��$��	Quicksand)�.�� � -	   $��con_instance���� $��	UPDATELOG��$��	Quicksand)�.�� � -
   $��log_instance���� -   $��setting��$
��Left=���  
�������$ Settings=�.�� � -   $��set_instance���� -    ��Name$ Add_Contact��$��25q�   OpenDialogCommand#��Z #��[  � ToolTip$ Add A COMMISSION��$��Bottom=�   ShadowDepth$ Depth3=�$��Right=�$��50��$��50������  �� ElementName$ addhost��.��  $
 Plus=�$��24��$��24������ $��16q�.+��� -    ��Name$ Client_Name��)  #MaterialDesignThemes.Wpf.HintAssist    Hint$  Client Name�� % !MaterialDesignFloatingHintTextBox#��[ $��10q�$��Stretch=��� -   $ Client_Email��$  Email��#��[ $��10q�$��Stretch=��� -   $ Client_Phone��$  Phone Number��#��[ $��10q�$��Stretch=��� $��Social��$��10q�.���� ! �� Orientation$! 
Horizontal=�$��5q�.+��� $��Center=�$��Center=�$��0,10,0,0q�https://www.deviantart.com/�� -   $ Client_DeviantArt��$  DeviantArt Profile��#��[ $��Center=�$��Center=�� .+��� -   $ ADD_CONTACT_ACCEPT_BUTTON��  MaterialDesignFlatButton#��[ " �� 	IsDefault" . $��0 8 8 0q�$
��Left=���O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem ��3system&clr-namespace:System;assembly=mscorlib  True��.��  $ Check=�$��16��$��16���� #��[ # �� IsCancel# . $��0 8 8 0q�$2��,materialDesign:DialogHost.CloseDialogCommand��$��Right=���1&clr-namespace:System;assembly=mscorlibSystem ��3system&clr-namespace:System;assembly=mscorlib  	False��.��  $ Close=��� -   $ Add_COMMISSION��$��25q�#��Z #��[ $ Add A COMMISSION��$��Bottom=�$ Depth3=�$��Right=�$��50��$��50������ $ addhost��.��  $
 Plus=�$��24��$��24������ $��16q�.+��� $��Center=�ADD COMMISSION� $��75��$��10q�$��75��.+�A� -   $ A�Name$$ Profile_Picture��  SecondaryAccentBrush#���  $��Center=�$��75��$��75��$��3��    MaterialDesignPaper#���  $
 Plus=�$��Center=�$��Center=�$��30��$��30���� -   $ COMMISSION_Title��% �� 	MaxLength$% 12��$  Title��#��[ $��10q�$��Stretch=�.������ $
 Name�& �� UpdateSourceTrigger$& PropertyChanged=�.���� -   $ COMMISSION_Cost��$% 4��$
  Cost��#��[ $��10q�$��Stretch=��� $! 
Horizontal=�.+��� -   $ cost_5��$��2q�$��8(�#��[ $
��Auto��$��Center=�$��Center=�.��$5�� -   $ cost_25��$��2q�$��8(�#��[ $
��Auto��$��Center=�$��Center=�.��$25�� -   $ cost_50��$��2q�$��8(�#��[ $
��Auto��$��Center=�$��Center=�.��$50�� -   $ cost_75��$��2q�$��8(�#��[ $
��Auto��$��Center=�$��Center=�.��$75�� -   $ cost_100��$��2q�$��8(�#��[ $
��Auto��$��Center=�$��Center=�.��$100�� -   ' ��Name$' COMMISSION_Client��$  Client��$��72��$��10,20,10,10q�$��Bottom=�( �� 
IsEditable( . ���� *#!LongListToTestComboVirtualization+) �� Text) �� $ SelectedTextTwo�$ TwoWay=�$& PropertyChanged=�* �� ValidationRules* ���� .R�$� (  "System.Windows.Controls.DatePicker  -   +  Name$+ COMMISSION_Deadline��$��Stretch=�$��10,25,10,10q�$  	Pick Date�� ( $MaterialDesignFloatingHintDatePicker#��[ �� -   $ COMMISSION_Notes�� % !MaterialDesignTextFieldBoxTextBox#��[ $	��Top=�, �� AcceptsReturn, . - �� TextWrapping$
- Wrap=�$	��300��$  Notes��� .+��� -   $" ADD_COMMISSION_ACCEPT_BUTTON��#��[ " . $��0 8 8 0q�$
��Left=���1&clr-namespace:System;assembly=mscorlibSystem ��3system&clr-namespace:System;assembly=mscorlib  True��.��  $ Check=�$��16��$��16���� -    $ txt_warning�����	#FFFF0B0B$��Center=�$��7(�$��Center=�PLEASE FILL IN EMPTY FIELDS�� #��[ # . $��0 8 8 0q�$2��,materialDesign:DialogHost.CloseDialogCommand��$��Right=���1&clr-namespace:System;assembly=mscorlibSystem ��3system&clr-namespace:System;assembly=mscorlib  	False��.��  $ Close=�(	  "MaterialDesignThemes.Wpf.ColorZone	  -!   . 	 Name$. 	WindowBar��/ 	  Mode$/ Accent=�$��16q�$ Depth0=�.��� $��Center=�.+��� $��	0,0,300,0q�$! 
Horizontal=�$��Center=�.+�  $ CalendarText=�$��Center=�$��Center=�$��25��$��25�����	#DDFFFFFF�� -"   $ toolbar_title��$��10,0,0,0q�$��Center=�
�������$��	Quicksand)�$��24(�$��Normal"�$��Center=�COMMISSION.�� .�IO��  	 PrimaryHueLightBrush#��� 	 $��Center=�$��5,0,0,0q�$��	Quicksand)��� .�ALPHA� $��Right=�.+��� $! 
Horizontal=�.+�?
  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent
  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase0   OpeningEffect0 D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *FadeIn+.���� -#   $ Minamize�� 
 MaterialDesignRaisedButton#��[
 $��37����Z� ��Z� .��  $ WindowMinimize=����	#DDFFFFFF
  0   *FadeIn+.���� -$   $ Maximize��#��[
 $��37����Z� ��Z� .��  $ WindowMaximize=����	#DDFFFFFF
  
���   �0   *FadeIn+��Z� .���� -%   $ CLOSEBUTTON��#��[
 $��37����Z� ��Z� .��  $ Close=����	#DDFFFFFF  -&   $��addhost���� -'   1 ��Name$1 sparkle��2 J� IsHitTestVisible2 .  $y�Hidden=�"  WpfAnimatedGif.ImageBehavior3   AnimatedSource$3 Resources/ALERT.gif��$
��Fill=�$	��100��$	��100��$��Right=�$��Bottom=�  -(   $��profilehost��4   DialogContent4 � $	��350��$	��600��.+��� .+�� .+��� -)   $1 background_image��$��UniformToFill=�$	��200��5 J� Effect5 -  'System.Windows.Media.Effects.BlurEffect  6   Radius$6 50Q��� #���  $	 0.3Q��� $��Center=�$��Center=�.+�A� -*   $$ Host_Profile_Picture��$��90��$��90��$��Center=�$��Center=��� -+   $ Profile_Title��$��5q�$��20(�$��Center=�$��Center=�$��	Quicksand)����	#DDFFFFFF$
��Bold"��� -,   $ Profile_Name��$��	Quicksand)�$��1q�$��16(�$��Center=�$��Center=����	#DDFFFFFF� ���	#FFC7C7C7$��30��.+��� --   $ Profile_Deadline��$��3q�$��Center=�$��Center=�� ���	#FFECECEC$��30��.+��� -.   $ Profile_Cost��$��3q�$��Center=�$��Center=��� -/   $ Profile_Notes��7 �� 
IsReadOnly7 . $��	Quicksand)�$��12q�#��[ $  NOTES��$��12(��� -0   $ Accept_Edit��#��[ " . $��10q�8   CloseDialogCommand#��Z8 $
��Left=�$��Bottom=���1&clr-namespace:System;assembly=mscorlibSystem ��3system&clr-namespace:System;assembly=mscorlib  True��.��  $ Check=�$��16��$��16���� -1   $ proflie_edit��#��Z $��10q�#��[ $��Bottom=�$��Center=�$
��Auto������ $ profiledithost��.��EDIT�� -2   $ Close_Unselect��#��[ # . $��10q�$2��,materialDesign:DialogHost.CloseDialogCommand��$��Right=�$��Bottom=�$
��Auto����1&clr-namespace:System;assembly=mscorlibSystem ��3system&clr-namespace:System;assembly=mscorlib  	False��.��  $ Close=�  -3   $��profiledithost��4 � .+��� .+�� .+�	  $/ Accent=�#��� 	 $��6q�.���� $! 
Horizontal=�$��Center=�.+��� #���  $��8 0 0 0q�$��Center=�$��Center=�EDIT COMMISSION�� $��16,50,16,16q�.+�� $��75��$��1q�$��75��.+�A� -4   $$ Edit_Picture��#���  $��Center=�$��75��$��75��$��3��  #���  $
 Plus=�$��Center=�$��Center=�$��30��$��30���� -5   $ 
edit_title��$% 12��$  Title��#��[ $��10q�$��Stretch=�.������ $
 Name�$& PropertyChanged=�.���� -6   $ 	edit_cost��$% 4��$
  Cost��#��[ $��10q�$��Stretch=��� $! 
Horizontal=�$��Center=�.+��� -7   $ 
editcost_5��$��2q�$��8(�#��[ $
��Auto��$��Center=�$��Center=�.��$5�� -8   $ editcost_25��$��2q�$��8(�#��[ $
��Auto��$��Center=�$��Center=�.��$25�� -9   $ editcost_50��$��2q�$��8(�#��[ $
��Auto��$��Center=�$��Center=�.��$50�� -:   $ editcost_75��$��2q�$��8(�#��[ $
��Auto��$��Center=�$��Center=�.��$75�� -;   $ editcost_100��$��2q�$��8(�#��[ $
��Auto��$��Center=�$��Center=�.��$100�� -<   $' edit_client��$  Client��$��72��$��10,20,10,10q�$��Bottom=�( . ���� *#!LongListToTestComboVirtualization+) �� $ SelectedTextTwo�$ TwoWay=�$& PropertyChanged=�* ���� .R�$�   -=   $+ edit_deadline��$��Stretch=�$��10,25,10,10q�$  	Pick Date��#��[ �� ->   $ 
edit_notes��#��[ $	��Top=�, . $
- Wrap=�$	��300��$  Notes��� $��5q�.+��� -?   $ Profile_Delete��#��Z8 #��[ $��Bottom=�$��Right=����	#FFF75530.��DELETE�� -@   $ edit_confirm��#��Z8 #��[ $��Bottom=�$
��Left=�.��	CONFIRM�� -A   $ 
txt_tester��$y�Hidden=�$
��Left=�$	��Top=�ALPHA TESTER BUILD v2.32