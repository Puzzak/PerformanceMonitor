<?
    $mysql_host = "";
    $mysql_user="";
    $mysql_password=""; 
    $mysql_database = "";
    mysql_connect($mysql_host, $mysql_user, $mysql_password); 
    mysql_select_db($mysql_database); 
    mysql_set_charset('utf8');
    $cpu=$_REQUEST[cpu];
    $freeram=$_REQUEST[freeram];
    $mac=$_REQUEST[mac];
    $totalram=$_REQUEST[totalram];
    $sec=date(s);
    $min=date(i);
    $hour=date(H);
    $day=date(d);
    $month=date(m);
    $year=date(Y);
    $d=mysql_query("SELECT * FROM `pm` WHERE `mac`='$mac'");
    $a=mysql_num_rows($d);
    if($a!==0){
        mysql_query("UPDATE `pm` SET `cpu`='$cpu',`totalram`='$totalram',`freeram`='$freeram',`sec`='$sec',`min`='$min',`hour`='$hour',`day`='$day',`month`='$month',`year`='$year' WHERE `mac`='$mac'");
    }else{
        mysql_query("INSERT INTO `pm` (`mac`, `cpu`, `totalram`, `freeram`, `sec`, `min`, `hour`, `day`, `month`, `year`) VALUES ('$mac','$cpu','$totalram','$freeram','$sec','$min','$hour','$day','$month','$year')");
    }
?>
