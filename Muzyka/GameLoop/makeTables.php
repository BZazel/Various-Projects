<?php 

	session_start();
	require_once "connect.php";

	$con = @new mysqli($host, $db_user, $db_password, $db_name);

	if ($con->connect_errno!=0) 
	{
		Echo "Coś nie tak";
	}
	else
	// {
	// 	for ($i=7; $i < 100 ; $i++) 
	// 	{ 
	// 			$z= $i-1;
	// 		$query = "ALTER TABLE gracze ADD res{$i} INT(11) NOT NULL AFTER res{$z} ";

	// 		if ($con->query($query)) 
	// 		{
				
	// 				echo "Chyba Ok";
	// 		}
				
	// 	}

	}	
	exit();
?>
	
<!DOCTYPE html>
<html lang="pl">
<head>
	<meta charset="UTF-8">
	<title>Index</title>
		
	<link rel="stylesheet" href="From_style.css">
</head>
<body>


</body>

</html>
