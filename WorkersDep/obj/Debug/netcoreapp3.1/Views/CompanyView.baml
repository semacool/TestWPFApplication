   M S B A M L   `   `   `  ����E  AWorkersDep, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WorkersDep
WorkersDep  5   	       WorkersDep.CompanyView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WorkersDep     5   	     � Title$  Company��5   	   $	��450��6   $	��800��6&    � 	Resources 5	         MainInfo �� 
TargetType �� Property �� Value  	SplitInfo  AddInfo  lbDepartments �� Orientation  	lbWorkers �� StringFormat  lbOrders��%6  &	        &	 H     &	 �     &	     7   7  &	 �    7  7  7  7  7  &	 %    7  7   �� 5   
   " ��6!   .�5      ��  � ��$ 25(�6)   5      �� 5   
   " ��6"   .�5      ��  � ��$ 20(�6)   �� 5       � ��$ 0,0,5,0q�6'   5      �� 5   
   " ��6    .�5      ��  � ��$ 15(�6)   5      �� 5   
   .R�5      �� $ Vertical=�6   .+�5      �� 8��  ��6   �� *Name+6V   �� 5      8�� ��6   �� *Boss+6U   5      5      �� 5   
   .R�5      �� $ Vertical=�6   .+�5       �� $ 
Horizontal=�6   .+�5!      �� 8��  ��6    �� *Name+6[   �� 5"      8�� ��6    �� *	Surname+6^   �� 5#      8�� ��6    �� *
Middlename+6a   5$      �� 5%      8�� ��6   �� *
Birthday+$ {0:D}��6o   �� 5&      8�� ��6   �� *Gender+6W   5'      5)      �� 5*   
   .R�5+      �� $ Vertical=�6   .+�5,      �� 8��  ��6   �� *Id+$ Id:{0}��6g   �� 5-      8�� ��6   �� *Name+6V   5.      50      53      .��54      �  � ColumnDefinitions 55   
   �� 56      6!   �� 57      $
��auto �6   6.   �� 58      6!   �� 59      $
��auto �6   6.   �� 5:      6!   .+�5<   
   �� $ ��Подразделения��6   $��4��6*   .��5=      �� #��[ 5?      ��5>      �� *Departments+ �� SelectedItem 5@      �� *SelectedDepartment+	 � ContextMenu	 5A      �� 5B      .@�5C      m� $��Добавить��6#   
 m� CommandParameter$
 
Department��5E   #    m� Command 5D   #   �� *Click_AddDepartment+5E   #   m� 5F      $��Подробнее��6#    5G   #   �� *Click_Department+
 5H   #   �� *SelectedDepartment+5I      5K      5M      �� 5P   
   $��3��6   $��Center=�6'   $��Stretch=�6D   $��3��6`   �� 5R   
   $��Рабочие��6   $��2��6$   .��5S      �� #��[ 5U      ��5T      �� *SelectedDepartment.Workers+ 5V      �� *SelectedWorker+	 5W      �� 5X      .@�5Y      m� $��Добавить��6#    5Z      �� *Click_AddWorker+
 5[      �� *SelectedDepartment+m� 5\      $��Подробнее��6#    5]      �� *Click_Worker+
 5^      �� *SelectedWorker+5_      5a      5b      �� 5d   
   $��1��6   $��Center=�6'   $��Stretch=�6D   $��3��6`   �� 5f   
   $��Заказы��6   $��0��6#   .��5g      �� $��0��6   #��[ 5i      ��5h      �� *SelectedWorker.Orders+ 5j      �� *SelectedOrder+	 5k      �� 5l      .@�5m      m� $��Добавить��6#    5n      �� *Click_AddOrder+
 5o      �� *SelectedWorker+m� 5p      $��Подробнее��6#    5q      �� *Click_Order+
 5r      �� *SelectedOrder+5s      5u      5v      5w      5x      