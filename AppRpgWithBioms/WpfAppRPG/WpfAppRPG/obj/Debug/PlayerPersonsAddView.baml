   M S B A M L   `   `   `  ����D  @WpfAppRPG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfAppRPG	WpfAppRPG  5   	   $    WpfAppRPG.PlayerPersonsAddView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfAppRPG     5   	     � Title$  PlayerPersonsAddView��5   	   $	��450��6&   $	��800��63   .��5	      � .+�5
   
   �� -   5        $��textBoxNickname��5
      $
��Left=�6)   $��	40,24,0,0q�6D    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��120��6�   �� 5   
   -   5        $��textBoxLevel��5      $
��Left=�6&   $��	40,69,0,0q�6A   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��120��6�   �� 5   
   -   5        $��textBoxRace��5      $
��Left=�6%   $��
40,109,0,0q�6@   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��120��6�   �� 5   
   -   5        $��textBoxGender��5      $
��Left=�6'   $��
40,150,0,0q�6B   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��120��6�   �� 5   
   $��Nickname��6   $
��Left=�6#   $��
165,20,0,0q�6>   $	��Top=�6R   �� 5   
   $��Level��6   $
��Left=�6    $��
165,65,0,0q�6;   $	��Top=�6O   �� 5   
   $
��Race��6   $
��Left=�6   $��165,105,0,0q�6:   $	��Top=�6O   �� 5   
   $��Gender��6   $
��Left=�6!   $��165,146,0,0q�6<   $	��Top=�6Q   �� 5   
   -   5         ��Name$ idLabel��5      $�� ��6!   $
��Left=�6,   $��
40,173,0,0q�6G   $	��Top=�6[   �� 5   
   $��	ID_Player��6   $
��Left=�6$   $��165,172,0,0q�6?   $	��Top=�6T   �� 5   
   -   5         ��Name$ 	buttonAdd��5      $	��Add��6$   $
��Left=�62   $��235,176,0,0q�6M   $	��Top=�6b   $��70��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MainDataGrid��5      $��	0,217,0,0q�6T   $
��Left=�6g   $	��790��6�   $	��217��6�   $	��Top=�6�   �� 5   
   -   5        $ 
buttonEdit��5      $
��Edit��6%   $
��Left=�64   $��321,176,0,0q�6O   $	��Top=�6d   $��65��6�   �� 5   
   -	   5        $ buttonSortByLevel��5      $��
Sort Level��6,   $
��Left=�6A   $��400,176,0,0q�6\   $	��Top=�6q   6�   �� 5   
   -
   5        $ buttonSortByName��5      $��	Sort Name��6+   $
��Left=�6?   $��472,176,0,0q�6Z   $	��Top=�6o   6�   �� 5   
   -   5        $ ButtonLocation��5      $#��Выбрать локацию��6)   $
��Left=�6C   $��664,176,0,0q�6^   $	��Top=�6s   $	��113��6�   5      5      