   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command 5   	   E APatientApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PatientApp.ViewModelPatientApp.ViewModel 5	   	   "   PatientApp.View.AddOrderView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   ]cmdMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform     5   	   4local"clr-namespace:PatientApp.ViewModel     5	   	   $	��650��5      $
��1025��6     N� Title$  AddPatientView��5       � DataContext 5      �� *
AddOrder+   Locator �� Source# [  .��5      � 
����ح�.+�5   
   �� $��50��6   $��50��6   $	��Top=�6(   $��10 5 0 0q�6@   
������ $
��Left=�5   1   ��6   �� *	BackCmd+.��5      �� $��/Image/back.png��6   6/   5      �� 5   
   $��
Start Date��6     TextBlockStylePatient2#���  6&   $��0 220 200 0q�5       (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePicker1��5   S   $��25��6   $��Center=�6!   $��100 220 0 0q�6>   $	��Top=�5      $	��150��6      SelectedDate 6%   �� *	StartDate+6J   �� 5   
   $��End Date��6   #���  6$   $��0 270 200 0q�5         5   
   -   5        $��datePicker2��5   S   $��25��6   $��Center=�6!   $��100 275 0 0q�6>   $	��Top=�5      $	��150��6    6%   �� *	EndDate+   DisplayDateStart 6F   �� *	StartDate+6o   �� 5    
   $��Tests��6   #���  6!   $��0 320 200 0q�5!       �� 5"   
   $	��150��6   $��20��6   $��Center=�6+   $	��Top=�6H   $��100 325 0 0q�5#      |�.  ��6(   �� *SelectedTitles+ �� Mode$ TwoWay=�5$   '   �� 5%   
   $��80��6   $��20��6   $��Center=�6(   $	��Top=�6E   $��380 325 0 0q�5&      ��6&   �� *SelectTestCmd+.��5'      �� $��Add Test��6   6*   5(      �� 5+   
     ButtonStylePatient#���  6   ���	#FFE4EEC1$��Center=�6U   $��350 150 0 0q�5,      ��6&   �� *AddOrderCmd+{�6F   �� *CanAdd+.��5-      �� $	��Add��6   #���  6#   
���   � �� TextAlignment$ Center=�5.   +   6D   5/      50      .   (System.Windows.Interactivity.Interaction   Triggers 52      /   )System.Windows.Interactivity.EventTrigger  53   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase	   Actions.	 54      /  )GalaSoft.MvvmLight.Command.EventToCommand  
   Command
 6!   �� *OnLoad+55      57      