   M S B A M L   `   `   `  ����L  HMiniGames.UIGames, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MiniGames.UIGamesMiniGames.UIGames  5      K*clr-namespace:MiniGames.UIGames.PropertiesMiniGames.UIGames.Properties  5      I)clr-namespace:MiniGames.UIGames.ViewModelMiniGames.UIGames.ViewModel  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
      +    %MiniGames.UIGames.ConfigPlayerControl   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:MiniGames.UIGames     5      8p*clr-namespace:MiniGames.UIGames.Properties     5      @
viewModels)clr-namespace:MiniGames.UIGames.ViewModel     5      9system&clr-namespace:System;assembly=mscorlib     5
      -   5        $	��255��5	      $	��100��6     � DataContext  5      8   2MiniGames.UIGames.ViewModel.ConfigPlayersViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ]� $��0��6   $��0��6!   $��2��61   ��5      �� 5       �� ElementName$ avatarComboBox��6    �� Path$" SelectedItem.SolidBrushColor�67   .+�5      �� ,   &MiniGames.UIGames.Properties.Resources   AVATAR#��Z 6   $��Center=�6=   $��Stretch=�6Z   5      �� 5   
   -   5         ��Name$ avatarComboBox��5      $��1��6+   $��0��68   $��5q�5   h   ��6   �� *	Avatars+ �� Mode$ TwoWay=� �� SelectedItem 6@   �� *AvatarSelected+��5       �� 5!      	 �� 
TargetType"	 ��6   .�5"      �� 
 �� Property
 � {� �� Value 62   �� *	Enabled+�� 5#      
 � ��$ Stretch=�6C   �� 5$      
 � ��$ Stretch=�6A   �� 5%      
 � �� 63   �� *SolidBrushColor+5&      ��5(      �� 5)      .R�5*      ��  �� Orientation$ 
Horizontal=�6!   $��5q�6:   .+�5+      �� $��5q�69   $��50��6D   $��50��6P   ��6    �� *Image+6P   �� 5,      $��Center=�6=   $��Center=�6Z   ��6    �� *
NickName+6Z   5-      5.      50      ]� 51   
   $��5q�6   $��1��6   $��1��6,   $��Center=�6<   $��Center=�6Y   .+�52      �� $��AI��6   53      55      57      