   M S B A M L   `   `   `  ����N  JDuAn_QuanLiKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:DuAn_QuanLiKhachSan.UserControls DuAn_QuanLiKhachSan.UserControls  5      /    )DuAn_QuanLiKhachSan.UserControls.InfoCard   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:DuAn_QuanLiKhachSan.UserControls     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      -   5        $��infoCard��5      $	��342��6.   $	��203��6:   .��5	      �� $��0 0 25 0q�6     J� Effect  5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      	Direction$	 330Q�6/      Color$ #0a2342��6?      ShadowDepth$ 4Q�6O      Opacity$	 0.3Q�6_   6o   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,2&�63   .��5      �  � Offset$ 0Q�6X   	 � Color	 6   �� 
 �� Path$
 Background1� �� ElementName$ infoCard��6X   � 5      $ 1Q�6X   	 6   �� $
 Background2�$ infoCard��6X   5       J� Clip 5   
   �� 5       �� RadiusX$ 15Q�6     �� RadiusY$ 15Q�6-    �� Rect$ 0,0,317,180�6:   ._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      A� $	��250��6   $��0,-76,-107,33q�6"   $��Right=�69   $��1��6U   ��5      �� 5       .��5!      � $ 0Q�6g   	 6'   �� $
 EllipseBackground1�$ infoCard��6g   � 5"      $ 1Q�6g   	 6'   �� $
 EllipseBackground2�$ infoCard��6g   5#      5%      !  FontAwesome.Sharp.IconImage  5'      $��	0,33,23,0q�6L   $��80��6_   $��80��6j   �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   
Foreground �#ffff$��Right=�6�   $	��Top=�6�   $��1��6�      Icon 6   �� $

 Icon�$ infoCard��6�   �� 5(      $��
15 0 10 40q�6   $��Bottom=�6-   $��2��6H   .+�5)      �� ���#f3f8ff$��18(�6^   $
��Wrap=�6l   $��25��6�   $��Arial Rounded MT Bold)�6�   ��6   �� *Title+$ infoCard��6�   �� 5*      ���#ecfcff$��32(�6_   $��SemiBold"�6m   $��Britannic Bold)�6�   $��Italic$�6�   ��6   �� *Number+$ infoCard��6�   5-      5.      5/      50      