   M S B A M L   `   `   `  ����N  JDataPersistance One, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:DataPersistance_OneDataPersistance_One  5   	   $    DataPersistance_One.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:DataPersistance_One     5   	     � Title$  Contacts��5   	   $	��500��6   $	��460��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $	��25* �6   .+�5   
   �� $	��Top=�6   .+�5      o� $��20��6   .@�5      m� $
��File��6   .@�5      m� -   5        $��AppOpen��5      $
��Open��6.   6<   m� 5      -   5        $��AppSave��5      $
��Save��6.   6<   m� 5      -   5        $��	AppSaveAs��5      $��SaveAs��60   6@   5      5      5      � 5   
   $��1��6    � ColumnDefinitions 5   
   �� 5      $	��350 �6   �� 5      $	��100 �6   .+�5   
   �� .��5      �� -   5        $��tryIt��5      5      � 5   
   $��1��6   .+�5       �� -   5        $��btn_NewContact��5       $��New Contact��6+   $
��Left=�6A   $��48��6\   $��9,35,0,0q�6h   $	��Top=�6z   $��82��6�   6�   �� 5!      -   5        $��
btn_Remove��5!      $��Remove��6'   $
��Left=�68   $��47��6S   $��
10,106,0,0q�6_   $	��Top=�6s   $��81��6�   6�   5#      5$      5%      5&      