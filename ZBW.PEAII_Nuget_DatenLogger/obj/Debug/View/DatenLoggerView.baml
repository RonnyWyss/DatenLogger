   M S B A M L   `   `   `  ����V  RZBW.PEAII_Nuget_DatenLogger, Version=3.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:ZBW.PEAII_Nuget_DatenLogger.View ZBW.PEAII_Nuget_DatenLogger.View  5      ]3clr-namespace:ZBW.PEAII_Nuget_DatenLogger.ModelView%ZBW.PEAII_Nuget_DatenLogger.ModelView  5      6    0ZBW.PEAII_Nuget_DatenLogger.View.DatenLoggerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:ZBW.PEAII_Nuget_DatenLogger.View     5      I	viewModel3clr-namespace:ZBW.PEAII_Nuget_DatenLogger.ModelView     5      .��5      �   � ColumnDefinitions  5   
   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $��50 �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5       $��30 �6   �� 5!      $��30 �6   �� 5"      $��30 �6   �� 5#      $��30 �6   �� 5$      $��30 �6   �� 5%      $��30 �6   �� 5&      $��30 �6   �� 5'      $��30 �6   �� 5(      $��* �6   .+�5,   
   �� $��1��6   $��1��6    $��Bottom=�6-   .��6H   Servername:6U   �� 5-   
   $��1��6   $��2��6"   $��2q�6/   $��Center=�6C    � ToolTip$2 ,Datenbankserver eingeben /Default: localhost��6^   $	��0,5q�6�   ��6�   �� *
Servername+6�   �� 5.   
   $��3��6   $��1��6    .��6-   
Datenbase:69   �� 5/   
   $��3��6   $��2��6"   $��2q�6/   $��Center=�6C   $? 9Datenbankname eingeben /Default: inventarisierungsloesung��6^   $	��0,5q�6�   ��6�   �� *
Database+6�   �� 50   
   $��5��6   $��1��6    .��6-   
User Id:67   �� 51   
   $��5��6   $��2��6"   $��2q�6/   $��Center=�6C   $* $Benutzername eingeben /Default: root��6^   $	��0,5q�6�   ��6�   �� *
Username+6�   �� 52   
   $��7��6   $��1��6    $��2��6-   .��6A   	Password:6L   �� 53   
   $��7��6   $��2��6"   $��2q�6/   $��Center=�6C   $&  Passwort eingeben /Default: root��6^   $��1��6�   $	��0,5q�6�   ��6�   �� *
Passwort+6�   �� 54   
   $��10��6   $��2��6"   $ Datenbank laden��6/   ��6I   �� *	CmdLoad+.��6e   Load6k   �� 55   
   $��10��6   $��4��6"   $ Datensatz bestätigen��6/   ��6N   �� *
CmdConfirm+.��6m   	Confirm6v   �� 57   
   $��10��6   $��6��6"   $ Datensätze laden��6/   ��6J   �� *	CmdAddLog+.��6h   	Add Log6q   �� 58   
   $��10��6   $��8��6"   $ Dublikate check��6/   ��6I   �� *CmdDublicateCheck+.��6o   Find Duplicates6�   �� 5:   
   $��10��6   $��10��6"   $ 
Hierarchie��60   ��6E   �� *CmdHierarchie+.��6g   
Hierarchie6s   �� 5<   
   -   5        $��LogEntriesGrid��5=      $��4��5>      $��1��5?      $��8��5@      $��5��5A      $��Stretch=�5B      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5C       �� SelectedIndex$ 0��5E      ��5D      �� *
LogEntries+ �� SelectedItem 5F      �� *SelectedEntity+ �� Mode$ TwoWay=� �� View 5G      �� 5H      -   5        logEntryGrids��.P�5I      ��  �� Width$ 50��5J      $��Id��5L      	 �� DisplayMemberBinding	 5K      �� *Id+5L      �� 5M      $	 100��5N      $
��Time��5P      	 5O      �� *	Timestamp+5P      �� 5Q      $	 100��5R      $��Hostname��5T      	 5S      �� *
Hostname+5T      �� 5U      $	 100��5V      $	��Pod��5X      	 5W      �� *Pod+5X      �� 5Y      $	 100��5Z      $��Location��5\      	 5[      �� *
Location+5\      �� 5]      $	 100��5^      $��Severity��5`      	 5_      �� *
Severity+5`      �� 5a      $	 200��5b      $��Message��5d      	 5c      �� *	Message+5d      5e      5g      5i      5j      