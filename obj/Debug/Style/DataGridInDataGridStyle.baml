   M S B A M L   `   `   `  ����E  APatientApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PatientApp.StylePatientApp.Style  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType=   7System.Windows.Controls.Primitives.DataGridColumnHeader   TemplateHeader'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value ��Name	 �� Padding
 �� 
StartPoint �� EndPoint � Offset � Color J� SnapsToDevicePixels �� 
TargetType  HeaderStyleInDataGrid �� Property �� Value)  #System.Windows.Controls.DataGridRow  DataGridRowStyleInDataGrid?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation;	  5System.Windows.Controls.SelectiveScrollingOrientation 	  Vertical �� ConverterParameter&
   System.Windows.Controls.DataGrid# 
  RowDetailsScrollingConverter �� 	Converter �� RelativeSource �� AncestorType:  4System.Windows.Controls.Primitives.DataGridRowHeader7  1System.Windows.Controls.DataGridHeadersVisibility
   Row! 
  HeadersVisibilityConverter*  $System.Windows.Controls.DataGridCell  DataGridCellStyleInDataGrid�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      (localclr-namespace:PatientApp.Style  5      %�  &	        &	 z    7   &	 f    &	 �    �� 5      "    6   .R�5   
   �  5        5      CommonStates��. 5	        
Normal��6"     5
      	MouseOver��. 5      �� .��5      �� $ columnHeaderBorder��6;   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�5   )   .g�5   "     $ 0��66   $ 	LightBlue��6B   5      5      5      5      .+�5      �� $ columnHeaderBorder��6   $��1q�5      $	 3,0,3,0q�5      ��5      �� 5      $
 0.5,0&�6*   $ 0.5,1&�6=   .��5      � $ 0Q�6'   $ #c682ed��62   � 5      $ 1Q�6'   $ #bfa1d1��62   5      ��5      �� 5      $
 0.5,0&�6*   $ 0.5,1&�6=   .��5      � $ 0Q�6'   $ #c687ed��62   � 5       $ 1Q�6'   $ #b058e2��62   5!      ._�5#      �� #��z��6#   #��z��5$   	   # z 5%      5&      5'      5(      �� 5*      "   6   .�5+   
   ��  � ��$ Center=�65   �� 5,   
    � ��$ 22��6#   �� 5-   
    �@  SeparatorBrush
 �  ��6+   �� 5.   
    � ��$ Black"�6'   �� 5/   
    � ��8   6%   50      �� 52      "  6   .�53   
   ��  � ��
 �����6'   �� 54   
    �@=�ErrorTemplate 65   Z� �� 55   
    � �� 56      �� 57      "   6"   .R�59      �� $ 
DGR_Border��6   #��z��5:      #��z��5;       .  5=        5>      CommonStates��. 5?   "     
Normal��6.     5@   "   Normal_AlternatingRow��. 5A   &   �� .��5B   *   �� $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�5C   )   .g�5D   .     $ 0��6B   $ #beb1f9��6N   5E   +   �� 5F   *   $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�5G   )   .g�5H   .     $ 0��6B   $ #b1e4f9��6N   5I   +   5J   '   5K   #     5L   "   Normal_Selected��. 5M   &   �� .��5N   *   �� $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�5O   )   .g�5P   .     $ 0��6B   $ #7556ad��6N   5Q   +   �� 5R   *   $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�5S   )   .g�5T   .     $ 0��6B   $ #7043c1��6N   5U   +   5V   '   5W   #     5X   "   	MouseOver��. 5Y   &   �� .��5Z   *   �� $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�5[   )   .g�5\   .     $ 0��6B   $ #d391e2��6N   5]   +   �� 5^   *   $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�5_   )   .g�5`   .     $ 0��6B   $ #ebcdf2��6N   5a   +   5b   '   5c   #   5d      ��5f      �� 5g      $
 0.5,0&�62   $ 0.5,1&�6E   .��5h   "   � $ 0Q�6/   $ #a67fd8��6:   � 5i   "   $ 1Q�6/   $ #a67fd8��6:   5j      ._�5l         5m      �� 5n   "   $
��Auto �63   �� 5o   "   $��* �63    5q      �� 5r   "   $��* �60   �� 5s   "   $
��Auto �60   .+�5u        $��1��65   #��z 5v      # z 5w        5x      $��1��67   $��1��5y      #y�z 5       5z      �� *AreRowDetailsFrozen+# Z # Z  �� " 
 5        5�      $��2��60   $ Vertical=�5�      y�5�      �� *HeadersVisibility+# Z # Z  �� " 
 5�      5�      5�      5�      5�      �� 5�      "  6   .�5�   
   ��  � �� 5�      �� 5�      "   6"   .R�5�      �� $ border��6   
������ 
������ $��1q�5�       . ._�5�      �� # z 6+   5�      5�      5�      5�      5�      