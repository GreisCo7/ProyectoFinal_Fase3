CREATE DATABASE  IF NOT EXISTS `petlife` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `petlife`;
-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: localhost    Database: petlife
-- ------------------------------------------------------
-- Server version	8.0.46

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
-- Table structure for table `cita`
--

DROP TABLE IF EXISTS `cita`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cita` (
  `id_cita` int unsigned NOT NULL AUTO_INCREMENT,
  `id_mascota` int unsigned NOT NULL,
  `id_veterinario` int unsigned NOT NULL,
  `fecha_hora` datetime NOT NULL,
  `motivo` varchar(200) COLLATE utf8mb4_spanish_ci NOT NULL,
  `estado` enum('Programada','Reprogramada','Cancelada','Atendida') COLLATE utf8mb4_spanish_ci NOT NULL DEFAULT 'Programada',
  `registrada_por` int unsigned NOT NULL,
  `fecha_registro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ocupa_espacio` tinyint GENERATED ALWAYS AS ((case when (`estado` in (_utf8mb4'Programada',_utf8mb4'Reprogramada')) then 1 else NULL end)) STORED,
  PRIMARY KEY (`id_cita`),
  UNIQUE KEY `uq_cita_vet_espacio` (`id_veterinario`,`fecha_hora`,`ocupa_espacio`),
  UNIQUE KEY `uq_cita_mascota_espacio` (`id_mascota`,`fecha_hora`,`ocupa_espacio`),
  KEY `fk_cita_registrador` (`registrada_por`),
  KEY `ix_cita_vet_fecha` (`id_veterinario`,`fecha_hora`),
  KEY `ix_cita_estado` (`estado`),
  CONSTRAINT `fk_cita_mascota` FOREIGN KEY (`id_mascota`) REFERENCES `mascota` (`id_mascota`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_cita_registrador` FOREIGN KEY (`registrada_por`) REFERENCES `usuario` (`id_usuario`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_cita_veterinario` FOREIGN KEY (`id_veterinario`) REFERENCES `veterinario` (`id_veterinario`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `ck_cita_30min` CHECK (((minute(`fecha_hora`) in (0,30)) and (second(`fecha_hora`) = 0))),
  CONSTRAINT `ck_cita_motivo` CHECK ((char_length(trim(`motivo`)) > 0))
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cita`
--

LOCK TABLES `cita` WRITE;
/*!40000 ALTER TABLE `cita` DISABLE KEYS */;
INSERT INTO `cita` (`id_cita`, `id_mascota`, `id_veterinario`, `fecha_hora`, `motivo`, `estado`, `registrada_por`, `fecha_registro`) VALUES (1,1,1,'2026-11-16 09:00:00','Vacuna anual y revisión general','Programada',5,'2026-11-15 17:45:34'),(2,3,1,'2026-11-16 10:00:00','Control de peso','Programada',1,'2026-11-15 17:45:34'),(3,4,1,'2026-11-16 09:30:00','Revisión de oídos','Cancelada',7,'2026-11-15 17:45:34'),(4,2,1,'2026-11-17 08:30:00','Desparasitación','Reprogramada',5,'2026-11-15 17:45:34'),(5,5,2,'2026-11-16 14:00:00','Corte de uñas y pico','Programada',7,'2026-11-15 17:45:34'),(6,3,1,'2026-11-08 09:00:00','Consulta por tos','Atendida',1,'2026-11-15 17:45:34'),(10,1,1,'2026-11-16 11:00:00','Prueba de registro desde C#','Programada',5,'2026-11-15 18:52:07');
/*!40000 ALTER TABLE `cita` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dueno`
--

DROP TABLE IF EXISTS `dueno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dueno` (
  `id_dueno` int unsigned NOT NULL AUTO_INCREMENT,
  `id_usuario` int unsigned NOT NULL,
  PRIMARY KEY (`id_dueno`),
  UNIQUE KEY `uq_dueno_usuario` (`id_usuario`),
  CONSTRAINT `fk_dueno_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dueno`
--

LOCK TABLES `dueno` WRITE;
/*!40000 ALTER TABLE `dueno` DISABLE KEYS */;
INSERT INTO `dueno` VALUES (1,5),(2,6),(3,7);
/*!40000 ALTER TABLE `dueno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `horario_atencion`
--

DROP TABLE IF EXISTS `horario_atencion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `horario_atencion` (
  `id_horario` int unsigned NOT NULL AUTO_INCREMENT,
  `id_veterinario` int unsigned NOT NULL,
  `dia_semana` tinyint unsigned NOT NULL,
  `hora_inicio` time NOT NULL,
  `hora_fin` time NOT NULL,
  PRIMARY KEY (`id_horario`),
  UNIQUE KEY `uq_horario_bloque` (`id_veterinario`,`dia_semana`,`hora_inicio`),
  KEY `ix_horario_vet_dia` (`id_veterinario`,`dia_semana`),
  CONSTRAINT `fk_horario_veterinario` FOREIGN KEY (`id_veterinario`) REFERENCES `veterinario` (`id_veterinario`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `ck_horario_30min` CHECK (((minute(`hora_inicio`) in (0,30)) and (second(`hora_inicio`) = 0) and (minute(`hora_fin`) in (0,30)) and (second(`hora_fin`) = 0))),
  CONSTRAINT `ck_horario_dia` CHECK ((`dia_semana` between 1 and 7)),
  CONSTRAINT `ck_horario_rango` CHECK ((`hora_fin` > `hora_inicio`))
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `horario_atencion`
--

LOCK TABLES `horario_atencion` WRITE;
/*!40000 ALTER TABLE `horario_atencion` DISABLE KEYS */;
INSERT INTO `horario_atencion` VALUES (1,1,1,'08:00:00','12:00:00'),(2,1,2,'08:00:00','12:00:00'),(3,1,3,'08:00:00','12:00:00'),(4,1,4,'08:00:00','12:00:00'),(5,1,5,'08:00:00','12:00:00'),(6,1,6,'08:00:00','12:00:00'),(7,1,1,'14:00:00','17:00:00'),(8,1,2,'14:00:00','17:00:00'),(9,1,3,'14:00:00','17:00:00'),(10,1,4,'14:00:00','17:00:00'),(11,1,5,'14:00:00','17:00:00'),(12,2,1,'13:00:00','18:00:00'),(13,2,2,'13:00:00','18:00:00'),(14,2,3,'13:00:00','18:00:00'),(15,2,4,'13:00:00','18:00:00'),(16,2,5,'13:00:00','18:00:00'),(17,3,1,'08:00:00','11:00:00'),(18,3,2,'08:00:00','11:00:00'),(19,3,3,'08:00:00','11:00:00'),(20,3,4,'08:00:00','11:00:00'),(21,3,5,'08:00:00','11:00:00'),(22,3,6,'08:00:00','11:00:00');
/*!40000 ALTER TABLE `horario_atencion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mascota`
--

DROP TABLE IF EXISTS `mascota`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mascota` (
  `id_mascota` int unsigned NOT NULL AUTO_INCREMENT,
  `id_dueno` int unsigned NOT NULL,
  `nombre` varchar(60) COLLATE utf8mb4_spanish_ci NOT NULL,
  `especie` varchar(40) COLLATE utf8mb4_spanish_ci NOT NULL,
  `raza` varchar(60) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `fecha_nacimiento` date DEFAULT NULL,
  PRIMARY KEY (`id_mascota`),
  KEY `fk_mascota_dueno` (`id_dueno`),
  CONSTRAINT `fk_mascota_dueno` FOREIGN KEY (`id_dueno`) REFERENCES `dueno` (`id_dueno`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mascota`
--

LOCK TABLES `mascota` WRITE;
/*!40000 ALTER TABLE `mascota` DISABLE KEYS */;
INSERT INTO `mascota` VALUES (1,1,'Luna','Perro','Labrador','2021-03-14'),(2,1,'Michi','Gato','Siamés','2022-07-02'),(3,2,'Rocky','Perro','Bulldog francés','2020-11-20'),(4,3,'Nala','Gato','Mestizo','2023-01-09'),(5,3,'Kiwi','Ave','Periquito','2024-05-30');
/*!40000 ALTER TABLE `mascota` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notificacion`
--

DROP TABLE IF EXISTS `notificacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notificacion` (
  `id_notificacion` int unsigned NOT NULL AUTO_INCREMENT,
  `id_veterinario` int unsigned NOT NULL,
  `id_cita` int unsigned NOT NULL,
  `tipo` enum('Agendada','Reprogramada','Cancelada') COLLATE utf8mb4_spanish_ci NOT NULL,
  `mensaje` varchar(255) COLLATE utf8mb4_spanish_ci NOT NULL,
  `leida` tinyint(1) NOT NULL DEFAULT '0',
  `fecha_creacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_notificacion`),
  KEY `fk_notificacion_cita` (`id_cita`),
  KEY `ix_notificacion_vet_leida` (`id_veterinario`,`leida`),
  CONSTRAINT `fk_notificacion_cita` FOREIGN KEY (`id_cita`) REFERENCES `cita` (`id_cita`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_notificacion_veterinario` FOREIGN KEY (`id_veterinario`) REFERENCES `veterinario` (`id_veterinario`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notificacion`
--

LOCK TABLES `notificacion` WRITE;
/*!40000 ALTER TABLE `notificacion` DISABLE KEYS */;
INSERT INTO `notificacion` VALUES (1,1,1,'Agendada','Nueva cita: Luna el 16/11/2026 09:00',0,'2026-11-15 17:45:34'),(2,1,2,'Agendada','Nueva cita: Rocky el 16/11/2026 10:00',0,'2026-11-15 17:45:34'),(3,1,3,'Cancelada','Cita cancelada: Nala el 16/11/2026 09:30',1,'2026-11-15 17:45:34'),(4,1,4,'Reprogramada','Cita reprogramada: Michi al 17/11/2026 08:30',0,'2026-11-15 17:45:34'),(5,2,5,'Agendada','Nueva cita: Kiwi el 16/11/2026 14:00',0,'2026-11-15 17:45:34');
/*!40000 ALTER TABLE `notificacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recepcionista`
--

DROP TABLE IF EXISTS `recepcionista`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recepcionista` (
  `id_recepcionista` int unsigned NOT NULL AUTO_INCREMENT,
  `id_usuario` int unsigned NOT NULL,
  PRIMARY KEY (`id_recepcionista`),
  UNIQUE KEY `uq_recepcionista_usuario` (`id_usuario`),
  CONSTRAINT `fk_recepcionista_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recepcionista`
--

LOCK TABLES `recepcionista` WRITE;
/*!40000 ALTER TABLE `recepcionista` DISABLE KEYS */;
INSERT INTO `recepcionista` VALUES (1,1);
/*!40000 ALTER TABLE `recepcionista` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `id_usuario` int unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) COLLATE utf8mb4_spanish_ci NOT NULL,
  `cedula` varchar(20) COLLATE utf8mb4_spanish_ci NOT NULL,
  `telefono` varchar(20) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `correo` varchar(120) COLLATE utf8mb4_spanish_ci NOT NULL,
  `contrasena_hash` char(60) COLLATE utf8mb4_spanish_ci NOT NULL,
  `rol` enum('Dueno','Recepcionista','Veterinario') COLLATE utf8mb4_spanish_ci NOT NULL,
  `activo` tinyint(1) NOT NULL DEFAULT '1',
  `fecha_creacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_usuario`),
  UNIQUE KEY `uq_usuario_cedula` (`cedula`),
  UNIQUE KEY `uq_usuario_correo` (`correo`),
  CONSTRAINT `ck_usuario_hash` CHECK ((`contrasena_hash` like _utf8mb4'$2%'))
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Sofía Morales','8-900-1001','6000-1001','recepcion@petlife.test','$2a$10$kbDiMhSo1odlxPOVe4GykOL7i/yd0V/xmLFZNB3UjX7rWKuLt37pu','Recepcionista',1,'2026-11-15 17:45:34'),(2,'Laura Rivera','8-900-2001','6000-2001','lrivera@petlife.test','$2a$10$GzaJvsDOkI1H0FUyQbU28uvvLmMpuAYOgPrWOniK.4jWVj7jjWBdC','Veterinario',1,'2026-11-15 17:45:34'),(3,'Carlos Gómez','8-900-2002','6000-2002','cgomez@petlife.test','$2a$10$lpf.nB4Cmnz75UJcdP8o9OedH.n59v1GsPpxfILOo680nlry/OCDG','Veterinario',1,'2026-11-15 17:45:34'),(4,'Ana Herrera','8-900-2003','6000-2003','aherrera@petlife.test','$2a$10$ci4Qrb6TNmHXqSTSD.MMfOB0rollUbFvpaxf482u11ncj34Bu8LAK','Veterinario',1,'2026-11-15 17:45:34'),(5,'Ana Pérez','8-900-3001','6000-3001','ana.perez@petlife.test','$2a$10$7HZNNGyDU3YDRU1f5ALktedb3xQymD4i5BB95V68GPOQQb/Ichlqq','Dueno',1,'2026-11-15 17:45:34'),(6,'Pedro Castillo','8-900-3002','6000-3002','pcastillo@petlife.test','$2a$10$sUbYo1m8QaMVNXbfM8Jh3efqy0AOcuRZsgxs1v2L4yTdPY1obqNnq','Dueno',1,'2026-11-15 17:45:34'),(7,'María Sánchez','8-900-3003','6000-3003','msanchez@petlife.test','$2a$10$5cREy7y5UCXRVNh6K0lqO.K/FKD8jjP8YmvMBNw3SxxzzK4.LQv8S','Dueno',1,'2026-11-15 17:45:34');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `veterinario`
--

DROP TABLE IF EXISTS `veterinario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `veterinario` (
  `id_veterinario` int unsigned NOT NULL AUTO_INCREMENT,
  `id_usuario` int unsigned NOT NULL,
  `especialidad` varchar(80) COLLATE utf8mb4_spanish_ci NOT NULL,
  PRIMARY KEY (`id_veterinario`),
  UNIQUE KEY `uq_veterinario_usuario` (`id_usuario`),
  CONSTRAINT `fk_veterinario_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veterinario`
--

LOCK TABLES `veterinario` WRITE;
/*!40000 ALTER TABLE `veterinario` DISABLE KEYS */;
INSERT INTO `veterinario` VALUES (1,2,'Medicina general'),(2,3,'Cirugía'),(3,4,'Dermatología');
/*!40000 ALTER TABLE `veterinario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `vw_cita_detalle`
--

DROP TABLE IF EXISTS `vw_cita_detalle`;
/*!50001 DROP VIEW IF EXISTS `vw_cita_detalle`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vw_cita_detalle` AS SELECT 
 1 AS `id_cita`,
 1 AS `fecha_hora`,
 1 AS `motivo`,
 1 AS `estado`,
 1 AS `fecha_registro`,
 1 AS `id_mascota`,
 1 AS `mascota`,
 1 AS `especie`,
 1 AS `id_dueno`,
 1 AS `dueno`,
 1 AS `correo_dueno`,
 1 AS `id_veterinario`,
 1 AS `veterinario`,
 1 AS `especialidad`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vw_veterinario`
--

DROP TABLE IF EXISTS `vw_veterinario`;
/*!50001 DROP VIEW IF EXISTS `vw_veterinario`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vw_veterinario` AS SELECT 
 1 AS `id_veterinario`,
 1 AS `id_usuario`,
 1 AS `nombre`,
 1 AS `cedula`,
 1 AS `correo`,
 1 AS `especialidad`,
 1 AS `activo`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping routines for database 'petlife'
--

--
-- Final view structure for view `vw_cita_detalle`
--

/*!50001 DROP VIEW IF EXISTS `vw_cita_detalle`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vw_cita_detalle` AS select `c`.`id_cita` AS `id_cita`,`c`.`fecha_hora` AS `fecha_hora`,`c`.`motivo` AS `motivo`,`c`.`estado` AS `estado`,`c`.`fecha_registro` AS `fecha_registro`,`m`.`id_mascota` AS `id_mascota`,`m`.`nombre` AS `mascota`,`m`.`especie` AS `especie`,`d`.`id_dueno` AS `id_dueno`,`ud`.`nombre` AS `dueno`,`ud`.`correo` AS `correo_dueno`,`v`.`id_veterinario` AS `id_veterinario`,`uv`.`nombre` AS `veterinario`,`v`.`especialidad` AS `especialidad` from (((((`cita` `c` join `mascota` `m` on((`m`.`id_mascota` = `c`.`id_mascota`))) join `dueno` `d` on((`d`.`id_dueno` = `m`.`id_dueno`))) join `usuario` `ud` on((`ud`.`id_usuario` = `d`.`id_usuario`))) join `veterinario` `v` on((`v`.`id_veterinario` = `c`.`id_veterinario`))) join `usuario` `uv` on((`uv`.`id_usuario` = `v`.`id_usuario`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vw_veterinario`
--

/*!50001 DROP VIEW IF EXISTS `vw_veterinario`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vw_veterinario` AS select `v`.`id_veterinario` AS `id_veterinario`,`v`.`id_usuario` AS `id_usuario`,`u`.`nombre` AS `nombre`,`u`.`cedula` AS `cedula`,`u`.`correo` AS `correo`,`v`.`especialidad` AS `especialidad`,`u`.`activo` AS `activo` from (`veterinario` `v` join `usuario` `u` on((`u`.`id_usuario` = `v`.`id_usuario`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-15 19:13:40
