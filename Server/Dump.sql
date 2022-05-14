-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: gos
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `actual`
--
CREATE DATABASE IF NOT EXISTS `gos`;
USE `gos`;
DROP TABLE IF EXISTS `actual`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `actual` (
  `idactual` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `conf` longblob,
  `idlearninghistroy` int DEFAULT NULL,
  `type` int DEFAULT NULL,
  PRIMARY KEY (`idactual`),
  KEY `fk_lerning_actual_idx` (`idlearninghistroy`),
  CONSTRAINT `fk_lerning_actual` FOREIGN KEY (`idlearninghistroy`) REFERENCES `learninghistroy` (`idlearninghistroy`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `charlistobjects`
--

DROP TABLE IF EXISTS `charlistobjects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `charlistobjects` (
  `idCharList` int NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `Value` longtext,
  `invnumber` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idCharList`),
  KEY `fk_object_char_idx` (`invnumber`),
  CONSTRAINT `fk_object_char` FOREIGN KEY (`invnumber`) REFERENCES `objects` (`invnumber`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `charlistrequest`
--

DROP TABLE IF EXISTS `charlistrequest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `charlistrequest` (
  `idCharList` int NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `Value` longtext,
  `idrequestinner` int DEFAULT NULL,
  PRIMARY KEY (`idCharList`),
  KEY `fk_request_char_idx` (`idrequestinner`),
  CONSTRAINT `fk_request_char` FOREIGN KEY (`idrequestinner`) REFERENCES `requestinner` (`idrequestinner`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `context`
--

DROP TABLE IF EXISTS `context`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `context` (
  `idContext` int NOT NULL AUTO_INCREMENT,
  `domen` longtext,
  PRIMARY KEY (`idContext`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `contextable`
--

DROP TABLE IF EXISTS `contextable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contextable` (
  `idlearninghistroy` int NOT NULL,
  `idSearchContext` int DEFAULT NULL,
  PRIMARY KEY (`idlearninghistroy`),
  KEY `fk_search_idx` (`idSearchContext`),
  CONSTRAINT `fk_learning` FOREIGN KEY (`idlearninghistroy`) REFERENCES `learninghistroy` (`idlearninghistroy`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_search` FOREIGN KEY (`idSearchContext`) REFERENCES `searchcontext` (`idSearchContext`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `contexts`
--

DROP TABLE IF EXISTS `contexts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contexts` (
  `idContexts` int NOT NULL AUTO_INCREMENT,
  `idContext` int DEFAULT NULL,
  `idlearninghistroy` int DEFAULT NULL,
  PRIMARY KEY (`idContexts`),
  KEY `fk_context_s_idx` (`idContext`),
  KEY `fk_context_learning_idx` (`idlearninghistroy`),
  CONSTRAINT `fk_context_learning` FOREIGN KEY (`idlearninghistroy`) REFERENCES `contextable` (`idlearninghistroy`),
  CONSTRAINT `fk_context_s` FOREIGN KEY (`idContext`) REFERENCES `context` (`idContext`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `data`
--

DROP TABLE IF EXISTS `data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `data` (
  `idData` int NOT NULL AUTO_INCREMENT,
  `Feature` longtext,
  `Label` varchar(30) DEFAULT NULL,
  `idDataSet` int DEFAULT NULL,
  PRIMARY KEY (`idData`),
  KEY `fk_set_data_idx` (`idDataSet`),
  CONSTRAINT `fk_set_data` FOREIGN KEY (`idDataSet`) REFERENCES `dataset` (`iddataset`)
) ENGINE=InnoDB AUTO_INCREMENT=9410 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `dataset`
--

DROP TABLE IF EXISTS `dataset`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dataset` (
  `iddataset` int NOT NULL AUTO_INCREMENT,
  `setName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`iddataset`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `learninghistroy`
--

DROP TABLE IF EXISTS `learninghistroy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `learninghistroy` (
  `idlearninghistroy` int NOT NULL AUTO_INCREMENT,
  `date` datetime DEFAULT NULL,
  `iteration` int DEFAULT NULL,
  `iddataset` int DEFAULT NULL,
  `comment` longtext,
  `version` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`idlearninghistroy`),
  KEY `fk_set_learning_idx` (`iddataset`),
  CONSTRAINT `fk_set_learning` FOREIGN KEY (`iddataset`) REFERENCES `dataset` (`iddataset`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `objects`
--

DROP TABLE IF EXISTS `objects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `objects` (
  `invnumber` varchar(50) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `cost` float DEFAULT NULL,
  `idstatus` int DEFAULT NULL,
  `idlocation` int DEFAULT NULL,
  `idcat` int DEFAULT NULL,
  `idrequest` int DEFAULT NULL,
  PRIMARY KEY (`invnumber`),
  KEY `fk_status_objects_idx` (`idstatus`),
  KEY `fk_location_objects_idx` (`idlocation`),
  KEY `fk_cat_objects_idx` (`idcat`),
  KEY `fk_request_objects_idx` (`idrequest`),
  CONSTRAINT `fk_cat_objects` FOREIGN KEY (`idcat`) REFERENCES `scat` (`idcat`),
  CONSTRAINT `fk_location_objects` FOREIGN KEY (`idlocation`) REFERENCES `slocation` (`idlocation`),
  CONSTRAINT `fk_request_objects` FOREIGN KEY (`idrequest`) REFERENCES `request` (`idrequest`),
  CONSTRAINT `fk_status_objects` FOREIGN KEY (`idstatus`) REFERENCES `sstatus` (`idstatus`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `objectshistory`
--

DROP TABLE IF EXISTS `objectshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `objectshistory` (
  `idobjectshistory` int NOT NULL AUTO_INCREMENT,
  `invnumber` varchar(50) DEFAULT NULL,
  `idstatus` int DEFAULT NULL,
  `idlocation` int DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `comment` longtext,
  PRIMARY KEY (`idobjectshistory`),
  KEY `fk_status_history_idx` (`idstatus`),
  KEY `fk_objects_history_idx` (`invnumber`),
  KEY `fk_location_history_idx` (`idlocation`),
  CONSTRAINT `fk_location_history` FOREIGN KEY (`idlocation`) REFERENCES `slocation` (`idlocation`),
  CONSTRAINT `fk_objects_history` FOREIGN KEY (`invnumber`) REFERENCES `objects` (`invnumber`),
  CONSTRAINT `fk_status_history` FOREIGN KEY (`idstatus`) REFERENCES `sstatus` (`idstatus`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `options`
--

DROP TABLE IF EXISTS `options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `options` (
  `idOptions` int NOT NULL AUTO_INCREMENT,
  `type` int DEFAULT NULL,
  `value` longtext,
  `idContext` int DEFAULT NULL,
  PRIMARY KEY (`idOptions`),
  KEY `fk_options_context_idx` (`idContext`),
  CONSTRAINT `fk_options_context` FOREIGN KEY (`idContext`) REFERENCES `context` (`idContext`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `paths`
--

DROP TABLE IF EXISTS `paths`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paths` (
  `idPaths` int NOT NULL AUTO_INCREMENT,
  `Path` longtext,
  `Type` int DEFAULT NULL,
  `Class` int DEFAULT NULL,
  `idContext` int DEFAULT NULL,
  PRIMARY KEY (`idPaths`),
  KEY `fk_context_paths_idx` (`idContext`),
  CONSTRAINT `fk_context_paths` FOREIGN KEY (`idContext`) REFERENCES `context` (`idContext`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `request`
--

DROP TABLE IF EXISTS `request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `request` (
  `idrequest` int NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `File` longblob,
  `idlearninghistroy` int DEFAULT NULL,
  PRIMARY KEY (`idrequest`),
  KEY `fk_learning_request_idx` (`idlearninghistroy`),
  CONSTRAINT `fk_learning_request` FOREIGN KEY (`idlearninghistroy`) REFERENCES `learninghistroy` (`idlearninghistroy`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `requestinner`
--

DROP TABLE IF EXISTS `requestinner`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requestinner` (
  `idrequestinner` int NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `cost` float DEFAULT NULL,
  `idcat` int DEFAULT NULL,
  `idrequest` int DEFAULT NULL,
  `count` int DEFAULT NULL,
  PRIMARY KEY (`idrequestinner`),
  KEY `fk_cat_inner_idx` (`idcat`),
  KEY `fk_request_inner_idx` (`idrequest`),
  CONSTRAINT `fk_cat_inner` FOREIGN KEY (`idcat`) REFERENCES `scat` (`idcat`),
  CONSTRAINT `fk_request_inner` FOREIGN KEY (`idrequest`) REFERENCES `request` (`idrequest`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `scat`
--

DROP TABLE IF EXISTS `scat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scat` (
  `idcat` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idcat`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `searchcontext`
--

DROP TABLE IF EXISTS `searchcontext`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `searchcontext` (
  `idSearchContext` int NOT NULL AUTO_INCREMENT,
  `name` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idSearchContext`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `searchnames`
--

DROP TABLE IF EXISTS `searchnames`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `searchnames` (
  `idSearchNames` int NOT NULL AUTO_INCREMENT,
  `idSearchContext` int DEFAULT NULL,
  `name` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idSearchNames`),
  CONSTRAINT `fk_searchC_searchN` FOREIGN KEY (`idSearchNames`) REFERENCES `searchcontext` (`idSearchContext`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `slocation`
--

DROP TABLE IF EXISTS `slocation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `slocation` (
  `idlocation` int NOT NULL AUTO_INCREMENT,
  `location` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idlocation`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sstatus`
--

DROP TABLE IF EXISTS `sstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sstatus` (
  `idstatus` int NOT NULL AUTO_INCREMENT,
  `status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idstatus`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-12 22:22:19
