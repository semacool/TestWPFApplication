   M S B A M L   `   `   `  ����E  AWorkersDep, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WorkersDep.ViewsWorkersDep.Views  5   	   %    WorkersDep.Views.DepartmentView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WorkersDep.Views     5   	     � Title$  DepartmentView��5   	   $	��346��6    $	��800��6-   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��156* �6   �� 5      $
��487* �6   �� 5      $
��157* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   ��    tblStyle#��[  6   $��Название��5      �� 5   
     tbStyle#��[ 6   $��1��5      ��5      �� *Department.Name+�� 5   
   #��[  6   $��2��5      ��5      �� *Department.Id+ �� StringFormat$ Id: {0}���� 5    
   #��[  6   $��1��5!      $��Начальник��5"      �� 5#   
     cbStyle#��[ 6   $��1��5$      $��1��6     �� SelectedItem 5%      �� *Department.Boss+��5&      �� *Department.Workers+�� 5(   
     btStyle#��[ 6   $��Center=�5)      $��2��5*      $��1��6!   $��Понизить��5+      ��5,      �� *Click_Demote+�� 5.   
   #��[ 6   $��1��5/      $��2��6!   $��Сохранить��50      ��51      �� *
Click_Save+�� 53   
   #��[ 6   $��2��54      $��2��6!   $��Удалить��55      ��56      �� *Click_Delete+57      58      