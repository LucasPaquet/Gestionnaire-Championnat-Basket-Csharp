   M S B A M L   `   `   `  ����M  IGestionChampionnat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GestionChampionnatGestionChampionnat  5   	   "    GestionChampionnat.ModifClub   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:GestionChampionnat     5   	     � Title$  Modification d'un club��5   	   $	��630��6(   $
��1200��65   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   .+�5      �� $��Nom : ��6   $��10,10,10,10q�6&   6=   �� 5      -   5         ��Name$ tbNom��5      $
��Left=�6%   $��10,10,10,10q�6@    �� TextWrapping$
 Wrap=�6U   $	��Top=�6�   $	��300��6�   ��6i   �� *CurrentClub.Nom+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��
Adresse : ��6   $��10,10,10,10q�6*   6A   �� 5      -   5        $ 	tbAdresse��5      $��
10,0,10,10q�6)   ��6=   �� *CurrentClub.Adresse+$ PropertyChanged=�6�   �� 5      $��Ajouter un arbitre��6   $��SemiBold"�63   .��5      �� .+�5      �� -   5         ��Name$ txtNomArbitre��5       $��Nom : ��67   $��
10,10,10,0q�6E   6[   �� 5      -   5        $ tbNomArbitre��5      $��	10,5,10,0q�64   6I   �� 5      -   5        $ 	txtPrenom��5       $��
Prénom : ��63   $��
10,10,10,0q�6D   6Z   �� 5      -   5        $ tbPrenom��5      $��	10,5,10,0q�60   6E   �� 5       -   5        $ txtNumArbitre��5        $��
Numéro : ��67   $��
10,10,10,0q�6H   6^   �� 5!      -   5        $ tbNum��5!      $��	10,5,10,0q�6-   6B   �� 5#      -	   5         ��Name$ btnAddArbitre��5#      $��10,10,10,10q�64   .��6g   Ajouter l'arbitre6z   5$      5%      �� 5'      $��Logo du club��6   .��5(      �� .+�5)      �� $	��150��6?   $	��150��6K   $��10q�6X   ��6   �� *CurrentClub.Img+6f   �� 5*      -
   5        $ btnSearchImg��5*      $��10q�63   .��6\   Chercher une image6p   5+      5,      5-      �� 5/   
   $��1��6   .+�50      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgArbitre��50   '   $��1��6   $��10,10,10,10q�6g      AutoGenerateColumns .  ��6:   �� *CurrentClub.Arbitres+	   Columns	 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn
   Header$	
 Nom��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6r      MinWidth$ 70Q�6|   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Nom+$ PropertyChanged=�6|     53      $
 Prénom��6)   $ * 6x   $ 70Q�6�    69   �� *Prenom+$ PropertyChanged=�6�     54      $
 Num. d'arbitre��6)   $ * 6�   $ 70Q�6�    6A   �� *
NumArbitre+$ PropertyChanged=�6�   56      �� 57      -   5        $ btnSuprArbitre��57      $��Supprimer l'arbitre��6-   $��10q�6K   6x   58      �� 59   
   $��2��6   .+�5:      �� $��Équipes : ��6   $��
10,10,10,0q�6*   6@     5;      -   5        $ dgEquipe��5;      $��10,10,10,10q�6�    .     
IsReadOnly . ��6)   �� *CurrentClub.Equipes+ �� SelectedItem 6U   �� *CurrentClub.CurrentEquipe+	 5<        5=      $	
 Nom��6)   $ * 6r   $ 70Q�6|    66   �� *Nom+$ PropertyChanged=�6|     5>      $
 Niveau��6)   $ * 6x   $ 70Q�6�    69   �� *Niveau+$ PropertyChanged=�6�   5@      � 5B       5C      �� 5D      �� 5E      .+�5H      �� -   5        $ btnSuprEquipe��5H      $��0��60   $��Supprimer l'équipe��6@   $��10,10,10,10q�6]   6�   �� 5I      -   5        $ btnCreateEquipe��5I      $��1��62   $��Créer une équipe��6B   $��10,10,10,10q�6]   6�   5J      5K      5M      5N      