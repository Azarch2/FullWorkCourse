   M S B A M L   `   `   `  ????B  >WpfApp6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp6WpfApp6  5   	       WpfApp6.WindowVideoPlayer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   'localclr-namespace:WpfApp6     5   	   -   5          ? WindowState$  	Maximized=?5   D    ? Title$+ %Проигрыватель видео??6l   $
??1440??6?   
????? ? ? WindowStyle$
 None=?6?    ? Icon$ Resources\Logo.jpg??6?    ? WindowStartupLocation$ CenterScreen=?6?   .??5	      ? .+?5
   
   r? -   5        $??
PleerMedia??5
   I    r? LoadedBehavior$ Manual=?6    r? UnloadedBehavior$ Manual=?6/   6]   ?? 5   
   -   5        $??StackPanelWithElements??5   )   $y?Hidden=?6   $	??100??6G   $??Bottom=?6T    ?? Orientation$ 
Horizontal=?6o   .+?5      ?? -   5        $??90??5   1   
?????? 
?????? $
??Left=?6p   $??10,5,5,5q?6?   .??5      ?? $#??Resources/backButtonImage.png??6   6A   5      ?? 5      -   5        $??90??5   +   
?????? 
?????? $
??Left=?6j   $??10,5,5,5q?6?   .??5      ?? $#??Resources/stopButtonImage.png??6   6A   5      ?? 5      -   5        $??VideoSlider??5   :   
??????$	??840??6e   $??Center=?6q   6?   ?? 5      -   5        $??80??5   1   
?????? 
?????? $??Right=?6p   $??10,5,5,5q?6?   .??5      ?? $'??!Resources/continueButtonImage.png??6   6E   5      5      5      5      