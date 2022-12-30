-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.28 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.0.0.6468
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for student_database
CREATE DATABASE IF NOT EXISTS `student_database` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `student_database`;

-- Dumping structure for table student_database.academicprogram
CREATE TABLE IF NOT EXISTS `academicprogram` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Unique` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

-- Dumping structure for table student_database.student
CREATE TABLE IF NOT EXISTS `student` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(60) NOT NULL,
  `FatherName` varchar(60) NOT NULL,
  `MotherName` varchar(60) NOT NULL,
  `Gender` char(1) NOT NULL,
  `PermanentAddress` varchar(60) NOT NULL,
  `TemporaryAddress` varchar(60) NOT NULL,
  `MobileNumber` varchar(13) NOT NULL,
  `EmailAddress` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `AcademicProgramId` int NOT NULL,
  `AcademicYear` varchar(4) NOT NULL,
  `RegistrationNumber` varchar(20) NOT NULL,
  `Photo` longtext NOT NULL,
  `Signature` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `AcademicProgramId` (`AcademicProgramId`),
  CONSTRAINT `student_ibfk_1` FOREIGN KEY (`AcademicProgramId`) REFERENCES `academicprogram` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
