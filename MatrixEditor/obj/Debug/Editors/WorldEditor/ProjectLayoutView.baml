   M S B A M L   `   `   `  ����G  CMatrixEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MatrixEditor.EditorsMatrixEditor.Editors  5      C&clr-namespace:MatrixEditor.GameProjectMatrixEditor.GameProject  5      ,    &MatrixEditor.Editors.ProjectLayoutView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:MatrixEditor.Editors     5      7proj&clr-namespace:MatrixEditor.GameProject     5      .��5      �   � RowDefinitions  5   
   �� 5      $��32 �6   �� 5      .+�5   
   �� $��	Add Scene��6   $��96��6%   $��Center=�60   |�.  $��0��5      $
��Left=�6   $��20,0,0,0q�65   ��5      �� *AddSceneCommand+�� 5   
   $��1��6   $
��Auto=�6$   $
��Auto=�6I   .��5      �� ��6   �� *Scenes+��5      �� 5      .R�5      �� 5      ��5      �� 5      .R�5      9�  9� 
IsExpanded 6#   �� *
IsActive+ �� Mode$ OneWay=���5      � 5   "   .+�5   &   ��  �� Orientation$ 
Horizontal=�61   .+�5    *   �� ��64   �� *Name+�� 5!   *   $��Remove��61   $
��20,0q�5#   J   |�.  ��5"   -   �� * DataContext.RemoveSceneCommand+ �� RelativeSource ��  �� AncestorType$ UserControlL���5#   -   �� 6X   �� 5$   *   -   5        $��+��5$   1   {�6=   �� *
IsActive+5%   -   5&   '   5'   #   .��5)      �� -   5         �� SelectionMode$ Extended=�5)   j   ��6&   �� *GameEntities+{�6K   �� *
IsActive+��5+   "   �� 5,   &   .R�5-   *   �� $ 
Horizontal=�65   .+�5.   .   �� ��68   �� *Name+�� 5/   .   $��Remove��65   ��6F   �� *%#ParentScene.RemoveGameEntityCommand+��50   1   �� 51   +   52   '   54      55      56      58      59      5:      5;      