   M S B A M L   `   `   `  ????D  @CryptoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CryptoApp.ViewModelCryptoApp.ViewModel  5      /clr-namespace:CryptoApp.ViewCryptoApp.View  5           CryptoApp.View.MainControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0vm!clr-namespace:CryptoApp.ViewModel     5      .localclr-namespace:CryptoApp.View     5        ? DataContext  5
      .  (CryptoApp.ViewModel.MainControlViewModel  5   
   6$   .??5      ? .+?5   
   ?    SideGrid#???   6    ? ColumnDefinitions 5      ?? 5      $	??20* ?6#   61   ?? 5      $	??60* ?6#   61   ?? 5      $	??20* ?6#   61   .+?5      ]? $??1??6     DefaultDock#???  5      .+?5      ?? $??
10 10 10 0q?6   
?????? ??5      ?? *
Currencies+??5      Z?  ?? SelectedItem 5      ?? *SelectedCurrency+??5      ?? 5      .R?5      ?? 6+   5      ??5       ?? 5!      .R?5"      ??  ?? Orientation$ 
Horizontal=?6)   $??Stretch=?5#   -   .+?5$   "   ?? .+?5%   &   ?? $??64??5&   ,   $??64??5'   ,   ??5%   ,   ?? *
ImageUrl+5'   :   5(   #   ?? 5)   "   $??Center=?6-   .+?5*   &   ?? $
??Bold"?60   ???#289037 ?? TextAlignment$ Center=?5,   1   $??18??5-   G   ??61   ?? *Name+6G   ?? 5.   &   ???#75c270$ Center=?5/   0   $??0 10 0 0q?50   0   ??51   0   ?? *Symbol+6J   52   #   53      54      56      57      ?? 58      $??2??6   .+?59      ? .+?5:      ?? .+?5;      ?? $??64??6!   $??64??5<   !   
?????? 
?????? ??5=   !   ?? *CalculateFrom+.??5@      ?? ??6$   ?? *
LogoFrom+6B   5A      5B      ?? 5C        ConvertText#???  6    $??Center=?5D       ->6?   ?? 5E      .+?5F      ?? $??64??6!   $??64??5G   !   
?????? 
?????? ??5H   !   ?? *CalculateTo+.??5K      ?? ??6$   ?? *LogoTo+6@   5L      5M      5N      ? 5O      .+?5P      ?? $??	15 20 0 8q?6      DescriptionText#???  5Q       
Count of6T   ?? 5R      $??3 20 0 0q?5S       #???  5T       ??5R       ?? *CurrencyFromName+5T   L   ?? 5U      -   5        $??	CountText??5W      $	??100??5U      $??30 0 0 0q?5V      $??14(?5X      
 ? Tag 5Y      ??  ?? ElementName$ 
PercentBox?? ?? Path$
 Text?6R   5Z      ?? 5[      $??	15 20 0 8q?6   #???  5\      
Commission6S   ?? 5]      -   5        $??
PercentBox??5`      $	??100??5]      $??3 0 0 0q?5^      $??14(?5_      5`   .   ?? 5a      $??	40 5 40 0q?6   
?????? 
?????? 
???????$??14(?5e      ??5f      ?? *CalculateCommand+??5g      ?? $ 	CountText??.??6L   	Calculate6W   ?? 5h      $??
15 20 20 8q?6   #???  5i      Result6N   ?? 5j      $??33 0 0 0q?6   ??5k      ?? *CalculateResult+6?   5l      5m      5n      5o      