   M S B A M L   `   `   `  ????B  >WpfApp6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp6WpfApp6  5   	       WpfApp6.WindowAdminPanel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   'localclr-namespace:WpfApp6     5   	   -   5        $??TheMainOfTheMain??5   '     ? Title$/  )Панель администратора??6	   $	??380??6?   $	??550??6L   
??????? ? 
ResizeMode$ NoResize=?6?    ? WindowStyle$ ThreeDBorderWindow=?6?    ? Icon$ Resources\Logo.jpg??6?    ? WindowStartupLocation$ CenterOwner=?6?   .??5	      ? 
???   ?.+?5
   
   ?? 
????? ? ?? CornerRadius$ 50??6#   $y?Visible=?65   ._?5      ? .+?5      ?? $??10,8,10,291.4q?6   $X??RЗдесь вы можете редактировать пользователей??63    ?? TextAlignment$ Center=?6f   $??20(?6}   $??	ExtraBold"?6?   ?? 5      $??10,37,10,262.4q?6   $D??>И просматривать видео базы данных??64   $ Center=?6]   $??20(?6t   $??	ExtraBold"?6?   ?? 5      -   5        $??AdminPanelBackButton??5   ?   $??Bottom=?6   $??30q?67   $
??Left=?6C   $??
Назад??6^   $ Center=?6k   $??24(?6?   $??	ExtraBold"?6?   
???????6  &   System.Windows.Controls.DataGrid  5      -   5        $??AdminPanelGrid1??5   ?      AutoGenerateColumns . $??10,89,9.6,406.4q?66      VerticalGridLinesBrush ?#4b6584	   HorizontalGridLinesBrush	 ?#4b6584
   AlternatingRowBackground
 ?	#ff2c3e50
???????   RowBackground ?#34495e$??16(?6?   
??? ? ?   CanUserDeleteRows .     CanUserAddRows .     CanUserResizeColumns .  5        5      -   5        $??AdminPanelGrid2??5   ?    . $??10,462,9.6,64.4q?66    ?#4b6584	 ?#4b6584
 ?	#ff2c3e50
??????? ?#34495e$??16(?6?   
????? ? .   .   .  5      5      5      5      5      