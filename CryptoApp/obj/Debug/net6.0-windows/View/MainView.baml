   M S B A M L   `   `   `  ????D  @CryptoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CryptoApp.ViewModelCryptoApp.ViewModel  5   	   %clr-namespace:CryptoApp	CryptoApp  5   	       CryptoApp.MainView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0vm!clr-namespace:CryptoApp.ViewModel     5   	   )localclr-namespace:CryptoApp     5   	     ? Title$  MainView??5	   	   $	??450??6   $	??800??6'   $	??350??5
   	   $	??620??5   	    ? WindowStyle$
 none=?5   	    ? AllowsTransparency$
 True??5   	   
??????  ? DataContext 5      '  !CryptoApp.ViewModel.MainViewModel  5   
   6   .??5      ?  ? RowDefinitions 5   
   ?? 5      $	??10* ?6   6+   ?? 5      $	??92* ?6   6+   .+?5   
   ? -   5        $??0??5         	MainPanel#???   5       ? ColumnDefinitions 5      ?? 5      $
??143* ?6#   62   ?? 5      $	??57* ?6#   61   .+?5      ]? 
?????? .+?5       ??   MainPageBtn#???  6   $??Center=?5!      $
??Left=?5#      $??	10 0 10 0q?5$      ??5"      ?? *LoadMainPage+.??5$   ,   
Crypto App68   ?? 5%      $??Right=?6   $??Center=?5&      
???????$??10q?5(      
?????? ??5*      ?? *
ChangeMode+.??5+      ?? ??6   ?? *
ModeIcon+6:   5,      5-      ?? 5/      $??1??6   $
??Left=?50      $??Center=?51       ?? Orientation$ 
Horizontal=?52      $??18??62   $	??172??6>   .+?53      ?? $
??Bold"?6    ?? TextAlignment$ Center=?54      $??0 0 15 0q?55      $??Center=?56      Search6?   ?? 57      -   5        $??TextBox??58      $	??120??57      .??58   )    J? InputBindings 59      ?? 5:      
	 ?? Key$	 Enter??6%   
 ?? Command
 5;   %   ?? *SearchCommand+ ?? CommandParameter 5<   %   ??  ?? ElementName$ TextBox?? ?? Path$
 Text?6c   .??5=   -   5>      5@      ?? 5A      $??0,0,15,0q?6   $??1??5B        
DefaultBtn#???  5C      $??Center=?5D      $??Right=?5E      ??5F      ?? *CloseCommand+??5G      ??  ?? RelativeSource ?? *FindAncestor+ ?? AncestorType" ???5I      ?? 5J       ?? CornerRadius$ 15??6   $??25??5K   !   $??2q?5L   !    ?? Padding$ 1q?5M   !   ._?5N      ?? $??X??6$   $??Center=?5O   (   $??Center=?5P   (   5Q      5S      5T      >? 5U   
   $??1??5V      ??5U      ?? *	Control+5V   %   5W      5X      