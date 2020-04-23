<?
    $mysql_host = "";
    $mysql_user="";
    $mysql_password=""; 
    $mysql_database = "";
    mysql_connect($mysql_host, $mysql_user, $mysql_password); 
    mysql_select_db($mysql_database); 
    mysql_set_charset('utf8');
    
    $d=mysql_query("SELECT * FROM `pm`");
    $a=mysql_num_rows($d);
    $n=mysql_query("SELECT * FROM `pm` WHERE `entry`='$a'");
    $z = mysql_fetch_array($n);
    $ramtrue=($z[totalram]/1024)/1024;
    $time="$z[day]-$z[month]-$z[year], $z[hour]:$z[min]:$z[sec]";
    echo"{\"freeram\":\""."$z[freeram]"."\",\"cpuusage\":\""."$z[cpu]"."\",\"totalram\":\"$ramtrue\",\"time\":\"$time\"}";
    ?>
