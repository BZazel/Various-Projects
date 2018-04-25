<?php
	// Status Check
	session_start();
		// Jesli ankieta została już wypełniona ... 
	if ((isset($_SESSION['Ankieta_wypelniona'])) && ($_SESSION['Ankieta_wypelniona']==true))
	{
		// Jesli gracz przeszedł juz trening ...
		if ((isset($_SESSION['Trening_done'])) && ($_SESSION['Trening_done'] == true))
		{
			header('Location: gra.php ');
		}
		else
		{
			header('Location: trening.php');
		}
		exit();
	}
?>
<!DOCTYPE html>
<html lang="pl">
<head>
	<meta charset="UTF-8">
	<title>Index</title>		
	<link rel="stylesheet" href="Form-style.css">
</head>
<body>
	<h3>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Laboriosam, autem aspernatur, obcaecati, pariatur voluptate eaque distinctio dignissimos dolor quos enim quo minima blanditiis id! Porro.</h3>
	<form action="Ankieta_check.php" id="FirstForm" method="post">
		<div>
			<label class="TxtLabel">Podaj pseudonim ( dowolny )<input class="TxtInput" type="text" name="nick"></label>
			<label class="TxtLabel">Podaj swój wiek<input class="TxtInput" type="text" name="age"></label>
		</div>
		<div class="QBox">
			<label>Jakie sprzętu audio teraz używasz?</label>
			<input type="checkbox" name="checkList[]" value="Sluchawki">
			<p>Słuchawki</p>
			<br>
			<input type="checkbox" name="checkList[]" value="Glosniki laptopa" ><p>Głośniki laptopa</p>
			<br>
			<input type="checkbox" name="checkList[]" value="Duze Glosniki"><p>Duze Głośniki</p>
			<br>
			
		</div>
		<button id="SubmitBtn" type="submit" value="sumbmit">Zatwierdź</button>
	</form>
</body>
</html>