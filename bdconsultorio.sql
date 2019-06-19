-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         5.7.14 - MySQL Community Server (GPL)
-- SO del servidor:              Win64
-- HeidiSQL Versión:             9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Volcando estructura de base de datos para consultorio
CREATE DATABASE IF NOT EXISTS `consultorio` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `consultorio`;


-- Volcando estructura para tabla consultorio.consultas
CREATE TABLE IF NOT EXISTS `consultas` (
  `id_consulta` bigint(20) NOT NULL,
  `usuario_id` varchar(50) DEFAULT NULL,
  `s` longtext,
  `o` longtext,
  `a` longtext,
  `p` longtext,
  `plan_manejo` longtext,
  `subsecuente` longtext,
  `fecha` date NOT NULL,
  PRIMARY KEY (`id_consulta`),
  KEY `FK_consulta_usuarios` (`usuario_id`),
  CONSTRAINT `FK_consulta_usuarios` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='tabla consulta';

-- Volcando datos para la tabla consultorio.consultas: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `consultas` DISABLE KEYS */;
INSERT INTO `consultas` (`id_consulta`, `usuario_id`, `s`, `o`, `a`, `p`, `plan_manejo`, `subsecuente`, `fecha`) VALUES
	(1, 'fede', 'test', 'test', 'test', 'test', 'test', 'test', '2019-06-19'),
	(2, 'fede', '', '', '', '', '', '', '2019-06-19');
/*!40000 ALTER TABLE `consultas` ENABLE KEYS */;


-- Volcando estructura para tabla consultorio.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `usuario` varchar(50) NOT NULL,
  `nombres` varchar(300) NOT NULL,
  `apellidos` varchar(300) NOT NULL,
  `clave` varchar(128) NOT NULL,
  `tipo` varchar(50) NOT NULL,
  PRIMARY KEY (`usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla consultorio.usuarios: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` (`usuario`, `nombres`, `apellidos`, `clave`, `tipo`) VALUES
	('fede', 'federico', 'castillo Valenzuela', '202cb962ac59075b964b07152d234b70', 'Administrador'),
	('fede4', 'federicoco', 'castillo Valenzuelaco', '202cb962ac59075b964b07152d234b70', 'Administrador');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
