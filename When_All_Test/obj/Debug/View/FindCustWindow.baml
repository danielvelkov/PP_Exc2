   M S B A M L   `   `   `  ����H  DWhen_All_Test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:When_All_Test.ModelWhen_All_Test.Model  5   	   7 clr-namespace:When_All_Test.ViewWhen_All_Test.View  5   	   -clr-namespace:When_All_TestWhen_All_Test  5   	   '    !When_All_Test.View.FindCustWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3model!clr-namespace:When_All_Test.Model     5   	   2local clr-namespace:When_All_Test.View     5   	   ,projclr-namespace:When_All_Test     5   	     � Title$  FindCustWindow��5
   	   $	��450��6    $	��800��6-    � DataContext 5      !  When_All_Test.CustomersList  5   
   6   .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   �� $ 
Horizontal=�6   .+�5      �� $	��250��6/   $��20q�6;   $
��Left=�6G   ��6   �� *	TextIds+6d   �� 5      $��25��61   ��6   �� *	GetCust+.��6=   Find6C   5      �� 5   
   $	��300��6<   $
��Left=�6H   $��20q�6c   ��6   �� *SearchedCustomers+��5      �� 5       �� DataType"  When_All_Test.Model.Customer"  6   .R�5      �� $ Vertical=�6!   .+�5      �� $ 
Horizontal=�6%   .+�5      �� ID:6-   �� 5      ��6(   �� *Id+6>   5      �� 5      $ 
Horizontal=�6%   .+�5      �� Name:6/   �� 5      ��6(   �� *Name+6@   5      �� 5!      $ 
Horizontal=�6%   .+�5"      �� 
Address:63   �� 5#      ��6(   �� *	Address+6C   5$      �� 5&      $ 
Horizontal=�6%   .+�5'      �� 
#Orders:63   �� 5(      ��6(   �� *NumberOfOrders+6J   5)      5+      5,      5.      5/      50      