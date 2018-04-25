
<?php 
	
require_once "connect.php";	

 $connection = @new mysqli($host, $db_user, $db_password, $db_name);

		
 if ($connection -> connect_errno!=0) 
 {
 	////echo "Error: ".$connection -> connect_errno;
 }
 else
 { //Jeśli wszystko ok
 		// Pobierz pseudonim
 	$list = array();
 	for ($i=0; $i < 100; $i++) { 
 		$list[$i]=$i;
 	}
 	
 	$checked_count = count($_POST['checkList']);

 		$nick = $_POST['nick'];
 		//echo $nick;
 		//echo "Wybranych ".$checked_count;
 		$age = $_POST['age'];
 		//echo "Wiek: ". $age;
		$firstItem = $_POST['checkList'][0];
		$sql = "INSERT INTO gracze SET Nick='$nick', age='$age', Pyt1='$firstItem'";


	 		if ($connection->query($sql)) 
	 		{	
	 			//=============== Popoulacja tabeli ==================================== !!
		 		// $num = 0;

					// foreach ($list as $item) 
					// {	
					// 	$name = "res".$num;
					// 	$ListSql = "UPDATE gracze SET $name='$item' WHERE Nick='$nick'";	

					// 	$connection->query($ListSql);

					// 	$num++;
					// 	//echo "<script>console.log('$item')</script>";

					// }

				 $_SESSION['Ankieta_wypelniona'] = true;
				 	//echo "Czy zmienna ustawiona?: ".isset($_SESSION['Ankieta_wypelniona']);
	 			////echo "Item send";

	 			header('Location: game-loop.html');
	 		}
	 }
 ?>