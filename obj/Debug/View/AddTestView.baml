   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command 5   	   E APatientApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PatientApp.ViewModelPatientApp.ViewModel 5	   	   !   PatientApp.View.AddTestView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   ]cmdMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform     5   	   4local"clr-namespace:PatientApp.ViewModel     5	   	   $	��650��5      $
��1025��6     N� Title$  AddTestView��5       � DataContext 5      �� *	AddTest+   Locator �� Source# [  .��5      � 
����ح�.+�5   
   �� $��50��6   $��50��6   $	��Top=�6(   $��10 5 0 0q�6@   
������ $
��Left=�5   1   ��6   �� *	BackCmd+.��5      �� $��/Image/back.png��6   6/   5      �� 5   
   $
��Type��6     TextBlockStylePatient2#���  6    $��0 160 200 0q�5      �� 5   
     TextBoxPatient#���  6   $��100 165 0 0q�6;   ��5      �� *
TestType+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 6|   �� 5   
   $��Title��6   #���  6!   $��0 210 200 0q�5      �� 5   
     ComboBoxStyle#���  6   $	��150��6;   $��25��6G   $	��Top=�6S   $��100 215 0 0q�6k   ��5      �� *	TestTitle+ �� SelectedItem 65   �� *SelectedTitle+$ TwoWay=�$ PropertyChanged=� . 6�   �� 5    
   $��SpecimenCode��6   #���  6(   $��0 260 200 0q�5!       �� 5"   
   #���  6   $��100 265 0 0q�6;   ��5#      �� *TestSpecimenCode+$ TwoWay=�$ PropertyChanged=� . 6�   �� 5%   
   $��Priority��6   #���  6$   $��0 310 200 0q�5&       �� 5'   
   #���  6   $��100 315 0 0q�6;   $	��150��6P   $��25��6\   $	��Top=�6h   ��5(      �� *	Numbers+ 6>   �� *SelectedPriority+$ TwoWay=�$ PropertyChanged=� . 6�   �� 5*   
   $��OrderNumber��6   #���  6'   $��0 360 200 0q�5+       �� 5,   
   #���  6   $��100 365 0 0q�6;    �� 
IsReadOnly . ��5-      �� *TestOrderNumber+$ TwoWay=�$ PropertyChanged=� . 5.   &   �� 50   
     ButtonStylePatient#���  6   ���	#FFE4EEC1$��Center=�6U   $��350 250 0 0q�51      ��6&   �� *
AddTestCmd+{�6E   �� *
IsValidAdd+.��52      �� $	��Add��6   #���  6#   
���   � �� TextAlignment$ Center=�53   +   6D   54      55      .   (System.Windows.Interactivity.Interaction	   Triggers	 57      /   )System.Windows.Interactivity.EventTrigger  58   
   
   	EventName$
 Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 59      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 6!   �� *OnLoad+5:      5<      