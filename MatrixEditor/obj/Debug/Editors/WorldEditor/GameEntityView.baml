   M S B A M L   `   `   `  ����G  CMatrixEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MatrixEditor.EditorsMatrixEditor.Editors  5      )    #MatrixEditor.Editors.GameEntityView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:MatrixEditor.Editors     5      .��5	      �� $
��Auto=�6   $��Disabled=�66   ��5
   
   �� 5        �� 
TargetType"  ��6    �� Triggers 5      P� 5       P� Property �@�DataContext P� Value 65   Z� . �5      ��  �� Property � y� �� Value$ 	Collapsed=�67   5      5      .��5   
   �� .+�5      �� $��32��6   ._�5      d� -   5         d�Name$ addComponent��5      $��Center=�65   $
��Left=�5      $��5,0,0,0q�62   ��5      ]� 5      .+�5      �� $��Add Component��6(   $	��5,0q�6=   F� 5      $��3,0,2,0q�6#   =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	$��Center=�5      
���   �$��Center=�5      5      5       5!      � 5"       � ColumnDefinitions 5#      �� 5$      $��78 �6'   �� 5%      �� 5&      $
��Auto �6'   .+�5(      �� $
��Name��6   $��0��6(   $��5,0,0,0q�68   �� 5)      $��1��60   ��6   �� *Name+
 � Tag 6@   �� *RenameCommand+�� 5*      	 �� Orientation$	 
Horizontal=�6   $��2��66   .+�5+      �� $��Enabled��6    $��5,0,0,0q�6/   �� 5,      $	��5,0q�5/      $��Center=�6(   
 d� 	IsChecked
 5,      �� *	IsEnabled+ �� Mode$ OneWay=���5-      �� *IsEnabledCommand+��5.      �� *	IsChecked+ �� RelativeSource �� *Self+5/   (   50      51      �� 52      ��6   �� *
Components+��53      �� 54      .R�55      �� 56      59      5:      5;      5<      