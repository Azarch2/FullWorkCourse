   M S B A M L   `   `   `  ????B  >WpfApp6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp6WpfApp6  5   	        WpfApp6.WindowChoosedVideo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   'localclr-namespace:WpfApp6     5   	   -   5          ? Title$)  #Окно работы с видео??5   	   $	??460??6%   $	??550??62   
??????? ? 
ResizeMode$ NoResize=?6?    ? WindowStyle$ ThreeDBorderWindow=?6?    ? Icon$ Resources\Logo.jpg??6?    ? WindowStartupLocation$ CenterScreen=?6?   .??5	      ? 
???   ?.+?5
      ?? 
????? ? ?? CornerRadius$ 50??6(   $y?Visible=?6:   ._?5      ? .+?5      ?? $??10,8,10,291.4q?6   $#??Выбранное видео??63    ?? TextAlignment$ Center=?6J   $??28(?6a   $??	ExtraBold"?6o   ?? 5      -   5        $??ChoosedVideoBackButton??5   ?   $??Center=?6   $??Center=?69   $??0,350,-350,0q?6U   $??На главную??6k   $ Center=?6}   $??24(?6?   $??	ExtraBold"?6?   
???????6  ?? 5      -   5        $??ChoosedVideoInfoButton??5   ?   $??Center=?6   $??Center=?69   $??0,350,-20,0q?6T   $??Информация??6i   $ Center=?6{   $??24(?6?   $??	ExtraBold"?6?   
???????6  ?? 5      -   5        $??ChoosedVideoImage??5   9   $y?Hidden=?6   $	??250??6,   6T   ?? 5      -   5        $??ChoosedVideoFullButton??5   ?   $??Center=?6   $??Center=?69   $??0,350,250,0q?6T   $??
Плеер??6i   $ Center=?6v   $??24(?6?   $??	ExtraBold"?6?   
???????6  r? 5      -   5        $??ChoosedVideo??5   ?    r? UnloadedBehavior$ Manual=?6   $??0,40,0,0q?69   $y?Visible=?6K   $	??250??6`    r? LoadedBehavior$ Manual=?6m   6?   ?? 5      $y?Hidden=?6   $??10,10,-10,60.4q?6,   ?? 5      -   5        $??ChoosedVideoDeleteButton??5   ?   $??Resources/DeleteIcon.jpg??6   $??60??6:   $??
25,360,0,0q?6F   $
??Left=?6Z   $y?Visible=?6u   6?   o? 5      -   5        $
??Menu??5   /   
???????$??50??6;   $	??Top=?6G   $??
10,45,10,0q?6_   	 ? 	Resources	 5      
 ?? 
TargetType ?? Property ?? Value??%d   '??       ?? 5      "
 ??6    .?5      ??  ?@??CornerRadius$ 25??6=   6J   5      5      .@?5      m? $%??Управление видео??6   .@?5      m? -	   5        $??Запуск??5   #   6I   m? 5      -
   5        $??Остановить??5   #   6L   m? 5      -   5        $??Продолжить??5   #   6O   5      m? 5      $ ??Работа с видео??6   .@?5       m? -   5        $%??Назначить автора??5    #   6V   m? 5!      -   5        $8??2Назначить место совершения??5!   #   6_   5"      5#      5$      5%      5&      5'      