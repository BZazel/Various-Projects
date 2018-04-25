-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 14 Sty 2018, 23:18
-- Wersja serwera: 10.1.28-MariaDB
-- Wersja PHP: 7.1.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `time-response`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `gracze`
--

CREATE TABLE `gracze` (
  `id` int(11) NOT NULL,
  `Nick` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `age` int(11) NOT NULL,
  `Typ_gry` int(11) NOT NULL,
  `Pyt1` text COLLATE utf32_polish_ci NOT NULL,
  `Pyt2` text COLLATE utf32_polish_ci NOT NULL,
  `Pyt3` text COLLATE utf32_polish_ci NOT NULL,
  `res1` int(11) DEFAULT NULL,
  `res2` int(11) NOT NULL,
  `res3` int(11) NOT NULL,
  `res4` int(11) NOT NULL,
  `res5` int(11) NOT NULL,
  `res6` int(11) NOT NULL,
  `res7` int(11) NOT NULL,
  `res8` int(11) NOT NULL,
  `res9` int(11) NOT NULL,
  `res10` int(11) NOT NULL,
  `res11` int(11) NOT NULL,
  `res12` int(11) NOT NULL,
  `res13` int(11) NOT NULL,
  `res14` int(11) NOT NULL,
  `res15` int(11) NOT NULL,
  `res16` int(11) NOT NULL,
  `res17` int(11) NOT NULL,
  `res18` int(11) NOT NULL,
  `res19` int(11) NOT NULL,
  `res20` int(11) NOT NULL,
  `res21` int(11) NOT NULL,
  `res22` int(11) NOT NULL,
  `res23` int(11) NOT NULL,
  `res24` int(11) NOT NULL,
  `res25` int(11) NOT NULL,
  `res26` int(11) NOT NULL,
  `res27` int(11) NOT NULL,
  `res28` int(11) NOT NULL,
  `res29` int(11) NOT NULL,
  `res30` int(11) NOT NULL,
  `res31` int(11) NOT NULL,
  `res32` int(11) NOT NULL,
  `res33` int(11) NOT NULL,
  `res34` int(11) NOT NULL,
  `res35` int(11) NOT NULL,
  `res36` int(11) NOT NULL,
  `res37` int(11) NOT NULL,
  `res38` int(11) NOT NULL,
  `res39` int(11) NOT NULL,
  `res40` int(11) NOT NULL,
  `res41` int(11) NOT NULL,
  `res42` int(11) NOT NULL,
  `res43` int(11) NOT NULL,
  `res44` int(11) NOT NULL,
  `res45` int(11) NOT NULL,
  `res46` int(11) NOT NULL,
  `res47` int(11) NOT NULL,
  `res48` int(11) NOT NULL,
  `res49` int(11) NOT NULL,
  `res50` int(11) NOT NULL,
  `res51` int(11) NOT NULL,
  `res52` int(11) NOT NULL,
  `res53` int(11) NOT NULL,
  `res54` int(11) NOT NULL,
  `res55` int(11) NOT NULL,
  `res56` int(11) NOT NULL,
  `res57` int(11) NOT NULL,
  `res58` int(11) NOT NULL,
  `res59` int(11) NOT NULL,
  `res60` int(11) NOT NULL,
  `res61` int(11) NOT NULL,
  `res62` int(11) NOT NULL,
  `res63` int(11) NOT NULL,
  `res64` int(11) NOT NULL,
  `res65` int(11) NOT NULL,
  `res66` int(11) NOT NULL,
  `res67` int(11) NOT NULL,
  `res68` int(11) NOT NULL,
  `res69` int(11) NOT NULL,
  `res70` int(11) NOT NULL,
  `res71` int(11) NOT NULL,
  `res72` int(11) NOT NULL,
  `res73` int(11) NOT NULL,
  `res74` int(11) NOT NULL,
  `res75` int(11) NOT NULL,
  `res76` int(11) NOT NULL,
  `res77` int(11) NOT NULL,
  `res78` int(11) NOT NULL,
  `res79` int(11) NOT NULL,
  `res80` int(11) NOT NULL,
  `res81` int(11) NOT NULL,
  `res82` int(11) NOT NULL,
  `res83` int(11) NOT NULL,
  `res84` int(11) NOT NULL,
  `res85` int(11) NOT NULL,
  `res86` int(11) NOT NULL,
  `res87` int(11) NOT NULL,
  `res88` int(11) NOT NULL,
  `res89` int(11) NOT NULL,
  `res90` int(11) NOT NULL,
  `res91` int(11) NOT NULL,
  `res92` int(11) NOT NULL,
  `res93` int(11) NOT NULL,
  `res94` int(11) NOT NULL,
  `res95` int(11) NOT NULL,
  `res96` int(11) NOT NULL,
  `res97` int(11) NOT NULL,
  `res98` int(11) NOT NULL,
  `res99` int(11) NOT NULL,
  `res100` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32 COLLATE=utf32_polish_ci;

--
-- Zrzut danych tabeli `gracze`
--

INSERT INTO `gracze` (`id`, `Nick`, `age`, `Typ_gry`, `Pyt1`, `Pyt2`, `Pyt3`, `res1`, `res2`, `res3`, `res4`, `res5`, `res6`, `res7`, `res8`, `res9`, `res10`, `res11`, `res12`, `res13`, `res14`, `res15`, `res16`, `res17`, `res18`, `res19`, `res20`, `res21`, `res22`, `res23`, `res24`, `res25`, `res26`, `res27`, `res28`, `res29`, `res30`, `res31`, `res32`, `res33`, `res34`, `res35`, `res36`, `res37`, `res38`, `res39`, `res40`, `res41`, `res42`, `res43`, `res44`, `res45`, `res46`, `res47`, `res48`, `res49`, `res50`, `res51`, `res52`, `res53`, `res54`, `res55`, `res56`, `res57`, `res58`, `res59`, `res60`, `res61`, `res62`, `res63`, `res64`, `res65`, `res66`, `res67`, `res68`, `res69`, `res70`, `res71`, `res72`, `res73`, `res74`, `res75`, `res76`, `res77`, `res78`, `res79`, `res80`, `res81`, `res82`, `res83`, `res84`, `res85`, `res86`, `res87`, `res88`, `res89`, `res90`, `res91`, `res92`, `res93`, `res94`, `res95`, `res96`, `res97`, `res98`, `res99`, `res100`) VALUES
(27, 'aljda', 23, 0, 'Glosniki laptopa', '', '', NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indexes for table `gracze`
--
ALTER TABLE `gracze`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `gracze`
--
ALTER TABLE `gracze`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
