   M S B A M L   `   `   `  ����M  IGestionChampionnat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GestionChampionnatGestionChampionnat  5   	   $    GestionChampionnat.ModifEquipe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:GestionChampionnat     5   	     � Title$  Modification de l'équipe��5   	   $	��450��6*   $
��1000��67   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   .+�5      �� $��Nom de l'équipe : ��6   $��
10,10,10,0q�62   $
��Bold"�6F   6Z   �� 5      $��
10,5,10,10q�6   ��6*   �� *CurrentClub.CurrentEquipe.Nom+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��Niveau du championnat��6   $��
10,10,10,0q�65   6K   �� 5      -   5         ��Name$ cbNiveau��5      $��20��6Y   $	��top=�6e   $��10,10,10,10q�6}   .@�5      �� .��6   Pré-poussins6-   �� 5      .��6   
Poussins6)   �� 5      .��6   	Benjamins6*   �� 5      .��6   Cadets6'   �� 5      .��6   	Juniors6(   �� 5      .��6   P46#   �� 5      .��6   P36#   �� 5       .��6   P26#   �� 5!      .��6   P16#   �� 5"      .��6   D36#   �� 5#      .��6   D26#   �� 5$      .��6   D16#   5%      �� 5'      -   5         ��Name$ tbCat��5'      $��Catégorie du championnat��6'   $��
10,10,10,0q�6G   6]   �� 5(      -   5        $ cbCat��5(      $��20��6&   $	��top=�62   $��
10,10,10,5q�6J   .@�5)      �� .��6   
Provincial6+   �� 5*      .��6   Élite6&   �� 5+      .��6   	Régional6)   5,      �� 5-      $��Modifier coach��6   $��10,10,10,10q�60   .��5.      �� .+�5/      �� -   5        $ txtNomCoach��5/       $��Nom :��65   $��
10,10,10,0q�6B   6X   �� 50      -   5         ��Name$ 
tbNomCoach��50      $��	10,5,10,0q�62   ��6E   �� **(CurrentClub.CurrentEquipe.Entraineur.Nom+$ PropertyChanged=�6�   �� 52      -   5        $ txtPrenomCoach��52       $��	Prénom :��68   $��
10,10,10,0q�6H   6^   �� 53      -   5        $ tbPrenomCoach��53      $��	10,5,10,0q�65   ��6H   �� *-+CurrentClub.CurrentEquipe.Entraineur.Prenom+$ PropertyChanged=�6�   �� 55      -   5        $ txtNumCoach��55       $��Numéro de coach : ��65   $��
10,10,10,0q�6O   6e   �� 56      -	   5        $ 
tbNumCoach��56      $��
10,5,10,10q�62   ��6F   �� */-CurrentClub.CurrentEquipe.Entraineur.NumCoach+$ PropertyChanged=�6�   57      58      59      �� 5<   
   $��1��6   .+�5=      �� $��Ajouter une personne��6   $��10,10,10,10q�66   .��5>      �� .+�5?      �� -
   5        $	 txt��5?       $��Nom : ��6-   $��
10,10,10,0q�6;   6Q   �� 5@      -   5        $ tbNom��5@      $��	10,5,10,0q�6-   6B   �� 5B      -   5        $ 	txtPrenom��5B       $��
Prénom : ��63   $��
10,10,10,0q�6D   6Z   �� 5C      -   5        $ tbPrenom��5C      $��	10,5,10,0q�60   6E   �� 5E      -   5        $ txtNum��5E       $��
Numéro : ��60   $��
10,10,10,0q�6A   6W   �� 5F      -   5        $ tbNum��5F      $��
10,5,10,10q�6-   6C   � 5G       5H      �� 5I      �� 5J      .+�5M      	� -   5         	�Name$ rBtnJ��5M   &   $��0��65   $��10,10,10,10q�6E   .��6Z   Joueur6b   	� 5N      -   5        $ rBtnD��5N   &   $��1��65   $��10,10,10,10q�6E   .��6Z   
Délégué6c   5O      5P      5Q      �� 5R      -   5         ��Name$ btnAddPeople��5R      $��10,10,10,10q�6+   .��6]   Ajouter la personne6r   5S      �� 5V   
   $��2��6   .+�5W      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgDelegue��5W   '   $��2��6   $��10,10,10,10q�6u   	   AutoGenerateColumns	 .  
   SelectionMode$
 Single=�6�   ��6:   �� *$"CurrentClub.CurrentEquipe.Delegues+   Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6N      MinWidth$ 70Q�6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Nom+6X     5Z      $ Prénom��6)   $ * 6T   $ 70Q�6^    69   �� *Prenom+6^     5[      $ Num. de délégue��6)   $ * 6a   $ 70Q�6k    6B   �� *
NumDelegue+6k   5]      �� 5^      -   5        $ btnSuprDelegue��5^      $��10,10,10,10q�6-   .��6a   Suprrimer le délégué6w   5_      �� 5b   
   $��3��6   .+�5c        -   5        $ dgJoueur��5c   '   $��3��6   $��10,10,10,10q�6s   	 .  $
 Single=�6�   ��69   �� *#!CurrentClub.CurrentEquipe.Joueurs+ 5d        5e      $	 Nom��6)   $ * 6N   $ 70Q�6X    66   �� *Nom+6X     5f      $ Prénom��6)   $ * 6T   $ 70Q�6^    69   �� *Prenom+6^     5g      $ Num. de délégue��6)   $ * 6`   $ 70Q�6j    6B   �� *	NumJoueur+6j   5i      �� 5j      -   5        $ btnSuprJoueur��5j      $��10,10,10,10q�6,   .��6_   Supprimmer le joueur6u   5k      5l      5m      