   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command 5   	   E APatientApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PatientApp.ViewModelPatientApp.ViewModel 5	   	   '   !PatientApp.View.ChangePatientView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   ]cmdMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform     5   	   4local"clr-namespace:PatientApp.ViewModel     5	   	   $	��650��5      $
��1025��6     N� Title$  AddPatientView��5       � DataContext 5      �� *ChangePatient+   Locator �� Source# [  .��5      � 
����ح�.+�5   
   �� $��50��6   $��50��6   $	��Top=�6(   $��10 5 0 0q�6@   
������ $
��Left=�5   1   ��6   �� *	BackCmd+.��5      �� $��/Image/back.png��6   6/   5      �� 5   
   $��	FirstName��6     TextBlockStylePatient2#���  6%   $��0 120 200 0q�5      �� 5   
     TextBoxPatient#���  6   $��100 125 0 0q�6;   ��5      �� *PatientFirstName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 5      �� 5   
   $��
SecondName��6   #���  6&   $��0 170 200 0q�5      �� 5   
   #���  6   $��100 175 0 0q�6;   ��5      �� *PatientSecondName+$ TwoWay=�$ PropertyChanged=� . 6�   �� 5!   
   $	��MRN��6   #���  6   $��0 220 200 0q�5"       �� 5#   
   #���  6   $��100 225 0 0q�6;    �� 
IsReadOnly . ��5$   /   �� *
PatientMRN+$ TwoWay=�$ PropertyChanged=� . 6�   �� 5&   
   $	��DOB��6   #���  6   $��0 270 200 0q�5'       (  "System.Windows.Controls.DatePicker  5(   
   -   5        $��datePicker1��5(   S   $��25��6   $��Center=�6!   $��100 275 0 0q�6>   $	��Top=�5)      $	��150��6      SelectedDate 6%   �� *
PatientDOB+   DisplayDateEnd 6I   �� *
ActualDate+6q   �� 5+   
   $	��Sex��6   #���  6   $��0 320 200 0q�5,       �� 5-   
     ComboBoxStyle#���  6   $��100 325 0 0q�6<   ��5.      �� *
PatientSex+	 �� SelectedItem	 5/      �� *SelectedPatientSex+$ TwoWay=�$ PropertyChanged=� . 6�   �� 51   
   $��Email��6   #���  6!   $��0 370 200 0q�52       �� 53   
   #���  6   $��100 375 0 0q�6;   ��54      �� *PatientEmail+$ TwoWay=�$ PropertyChanged=� . 6�   �� 56   
     ButtonStylePatient#���  6   ���	#FFE4EEC1$��Center=�6U   $��350 250 0 0q�57      ��6&   �� *ChangePatientDataCmd+{�6O   �� *IsValidChange+.��58      �� $��Change��6   #���  6&   
���   �
 �� TextAlignment$
 Center=�59   +   6D   5:      5;      .   (System.Windows.Interactivity.Interaction   Triggers 5<      /   )System.Windows.Interactivity.EventTrigger  5=   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5>      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 6!   �� *OnLoad+5?      5B      