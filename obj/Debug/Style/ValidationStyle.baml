   M S B A M L   `   `   `  ����E  APatientApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PatientApp.StylePatientApp.Style  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   TextBoxPatient �� Property �� Value  ErrorToolTipTemplate_1 �� Triggers P� Property P� Value �� RelativeSource �� Path � 	Resources  Key	 �� CornerRadius  textblockErrorTooltip
 �� ElementName  ComboBoxStyle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      (localclr-namespace:PatientApp.Style  5      %�  &	        &	 .    7  &	 �    �� 5      "  ��6   .�5   
   ��  � ��$	 150��6"   �� 5   
    � ��$ 25��6#   �� 5   
    � ��
 �����6'   �� 5	   
    � ��$ Center=�60   �� 5
   
    � ��$	 Top=�6.   �� 5   
    � ��$ 13(�6%   �� 5   
    � ��$
 Bold"�6'   �� 5   
    �@��
IsReadOnly .  6'   �� 5   
    �@=�ErrorTemplate# �  65    5   
   P� 5       �@=�HasError . . �5      ��  �@�ToolTip 6,   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�5      5      �� 5       5   
   ���� 5      textblockErrorTooltip "  ��62   .�5      ��  � ��$ Center=�68   �� 5       � ��$ Center=�66   �� 5       � ��$
 Bold"�6/   �� 5       � ��
 �����6/   �� 5       � ��$ 	10 0 10 0q�6+   5      5      .R�5    
   ]� ��. .+�5!      �� $
��Auto��6   $��5,0,0,0q�5"      ���#DC000C$	 3��5$      $��right=�5%      ._�5&      �� 8��  ��6K   �� $
 customAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5'      �� 5(      $��customAdorner��6(   .v�5)      �� ���#DC000C$	��1.3q�6/   5*      5+      5,      �� 5/      "  ��6   .�50   
   ��  � ��$	 150��6"   �� 51   
    � ��$ 25��6#   �� 52   
    � ��$ Center=�60   �� 53   
    � ��$	 Top=�6.   �� 54   
    � ��$ 13(�6%   �� 55   
    � ��$
 Bold"�6'   �� 56   
    �@��
IsReadOnly .  6'   �� 57   
    �@=�ErrorTemplate# �  65    58   
   P� 59       �@=�HasError . . �5:      ��  �@�ToolTip 6,   ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�5;      5=      5>      