   M S B A M L   `   `   `  ����C  ?CardGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CardGame.ControllersCardGame.Controllers  5   	       CardGame.Views.Game   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:CardGame.Controllers     5   	     � Title$  
MainWindow��5   	   $	��800��6   $	��800��6)    � DataContext 5	      )  #CardGame.Controllers.GameController  5
   
   .��5      � .+�5   
   o� .@�5      m� $
��Game��6   .@�5      m� -   5        $��New Game��5      6-   m� 5      -   5        $��	Save Game��5      6.   m� 5      -   5        $��	Load Game��5      6.   �� 5      m� 5      -   5        $��Back to Main Menu��5      66   5      m� 5      $��
Board Size��6   .@�5      m� -   5        $��Standard(4x4)��5      62   m� 5      -   5        $��Custom��5      6+   5      m� 5      -   5        $��
Statistics��5      6+   m� 5      -   5        $��About��5      5      5      �� 5   
   -	   5         ��Name$ gameGrid��5   ;   $��Center=�6M   $��Center=�6j   ��6   �� *ButtonItems+��5      �� 5      .R�5       �� ��6#   �� ��5!      �� 5"      .R�5#   "   � 5$      ��5&      �� 5'      .R�5(   "   �� -
   5        $��60��5(   )   $��85��5)   !   $��5q�5*   !   .��5,   &   �� .+�5-   *   �� $��60��5/   0   $��85��50   0   ��5-   0   �� *ImageSource+y�5.   0   �� *
Visibility+50   0   51   '   52   #   53      55      56      58      �� 59   
   -   5         ��Name$ 	playerPic��59      $
��Left=�6$   $��78��6?   $��	10,27,0,0q�6K   $	��Top=�6^   $��76��6v   �� 5:   
   -   5         ��Name$ 
playerName��5:      $��Name:
��6$   $��10,110,661,293q�6>   �� 5;   
   -   5        $ 	playerLvl��5;      $��Level:��6#   $��10,141,661,267q�64   �� 5<   
   -   5        $ playerTimer��5<      $��
Time left:��6%   $��10,173,661,235q�6:   5=      5>      