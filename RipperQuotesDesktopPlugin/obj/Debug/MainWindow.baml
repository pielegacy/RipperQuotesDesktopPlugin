   M S B A M L   `   `   `  ����T  PRipperQuotesDesktopPlugin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:RipperQuotesDesktopPluginRipperQuotesDesktopPlugin  5   	   *    $RipperQuotesDesktopPlugin.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:RipperQuotesDesktopPlugin     5   	   -   5          � Title$  Ripper Quotes Beta��5   	   $	��360��6$   $	��525��61    � 
ResizeMode$ CanMinimize=�6=    � WindowStyle$ 
ToolWindow=�6m   .��5	      �  � RowDefinitions 5
   
   �� 5      $��2* �6   6*   �� 5      $��6* �6   6*   �� 5      $��3* �6   6*   �� 5      $��3* �6   6*   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF00FFEF��6   � 5      $ 	#FFFF00D1��6    � Offset$ 1Q�61   5      .+�5   
   �� -   5         ��Name$ 
text_title��5      $��Times New Roman)�6(   $��26.667(�6E   
�������Ripper Quotes6y   �� 5   
   -   5        	 ��Name$	 quote_content��5      $��1��6)   $
��20px(�66   $
��auto��6F   $��Times New Roman)�6T   $	��500��6r   $��Your quote...��6�   
 �� SelectionBrush
 �	#FFFF00D1$��10,0,9,0q�6�   6�   �� 5   
   -   5        $	 quote_author��5      $��2��6(   $
��20px(�65   $
��30px��6E   $��Times New Roman)�6S   $	��500��6p   $��The author...��6|    �� TextAlignment$
 Left=�6�   
 �	#FFFF00D1$��
10,21,9,20q�6�   6�   �� 5   
   -   5         ��Name$ quote_topic��5      $��3��6(   $
��28px��65   $��300px��6C   $
��Left=�6Q   $��
10,10,0,31q�6l   6�   �� 5   
   -   5         ��Name$ quote_submit��5      $��3��6'   $
��28px��64   $��150px��6B   $��Right=�6P   $��
0,10,10,29q�6l   $��Submit Quote��6�   $y�	Collapsed=�6�   6�   5      5      