   M S B A M L   `   `   `  ����G  CMatrixEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MatrixEditor.EditorsMatrixEditor.Editors  5      ?$clr-namespace:MatrixEditor.UtilitiesMatrixEditor.Utilities  5      *    $MatrixEditor.Editors.WorldEditorView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:MatrixEditor.Editors     5      4utl$clr-namespace:MatrixEditor.Utilities     5        J� InputBindings  5
      �� 5   
   
 �� Key$ Z��65    �� 	Modifiers$
 Ctrlf�6=    �� Command 6   �� *UndoCommand+6=   �� 5   
   $ Y��65   $
 Ctrlf�6=    6   �� *RedoCommand+6=   �� 5   
   $ S��65   $
 Ctrlf�6=    6   �� *SaveCommand+6=   .��5      �  � RowDefinitions 5   
   �� 5      $��32 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Undo��6   ��6$   �� *UndoCommand+�� 5      $
��Redo��6   $��32,0,0,0q�6D   ��6$   �� *RedoCommand+6D   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      � $��0��6    5      �� 5      �� 5       .+�5"      �� $��1��6   $��5��6,   $��Stretch=�67   $	��Top=�5#      �� 5$      $��1��6   .@�5%      �� $��History��6   .��5&      )   #MatrixEditor.Utilities.UndoRedoView   � DataContext 6+   �� *
UndoRedo+5'      �� 5(      $	��Log��6   .��5)      '   !MatrixEditor.Utilities.LoggerView  5*      5+      5,      �� 5-      $��1��6   $��5��6+   $
��Left=�65   $��Stretch=�5.      � 5/      $��1��6   $��5,0,0,0q�6#    50      �� 51      �� 52      .+�54      �� $��1��6   $��5��6,   $��Stretch=�67   $	��Top=�55      ,   &MatrixEditor.Editors.ProjectLayoutView  56      )   #MatrixEditor.Editors.GameEntityView  57      $��1��6'   58      59      5:      5;      