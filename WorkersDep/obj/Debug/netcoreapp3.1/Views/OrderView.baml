   M S B A M L   `   `   `  ����E  AWorkersDep, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WorkersDep.ViewsWorkersDep.Views  5   	        WorkersDep.Views.OrderView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WorkersDep.Views     5   	     � Title$  	OrderView��5   	   $	��200��6   $	��800��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��0.4* �6   �� 5      $��* �6   �� 5      $
��0.4* �6    � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   ��    tblStyle#��[  6   $��Название��66   �� 5   
   $��1��6S     tbStyle#��[ 6c   ��6   �� *
Order.Name+ �� UpdateSourceTrigger$ PropertyChanged=�6c   �� 5   
   $��2��6   #��[  6$   ��6F   �� *
Order.Id+ �� StringFormat$ Id: {0}���� 5   
     btStyle#��[ 60   $��2��6Q   $��1��6e   $��Сохранить��6r   ��6   �� *
Click_Save+6r   �� 5   
   #��[ 62   $��2��6S   $��1��6c   $��Удалить��6p   ��6   �� *Click_Delete+6p   5      5      