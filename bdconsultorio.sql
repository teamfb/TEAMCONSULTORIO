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


-- Volcando estructura para tabla consultorio.ant_aparatos
CREATE TABLE IF NOT EXISTS `ant_aparatos` (
  `id_antecedente` bigint(20) NOT NULL,
  `paciente_id` bigint(20) NOT NULL,
  `pade_actual` varchar(100) DEFAULT NULL,
  `endocrino` varchar(100) DEFAULT NULL,
  `sintomas` varchar(100) DEFAULT NULL,
  `urinario` varchar(100) DEFAULT NULL,
  `circulatorio` varchar(100) DEFAULT NULL,
  `psiquico` varchar(100) DEFAULT NULL,
  `linf_sangui` varchar(100) DEFAULT NULL,
  `piel_mucosas` varchar(100) DEFAULT NULL,
  `nervioso` varchar(100) DEFAULT NULL,
  `musc_esque` varchar(100) DEFAULT NULL,
  `genital` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_antecedente`),
  KEY `FK_ant_aparatos_pacientes` (`paciente_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla consultorio.ant_aparatos: ~11 rows (aproximadamente)
/*!40000 ALTER TABLE `ant_aparatos` DISABLE KEYS */;
INSERT INTO `ant_aparatos` (`id_antecedente`, `paciente_id`, `pade_actual`, `endocrino`, `sintomas`, `urinario`, `circulatorio`, `psiquico`, `linf_sangui`, `piel_mucosas`, `nervioso`, `musc_esque`, `genital`) VALUES
	(1, 25, '1', '23', '3', '4', '5', '6', '7', '8', '9', '10', NULL),
	(2, 32, '', '', '', '', '', '', '', '', '', '', ''),
	(3, 33, '', '', '', '', '', '', '', '', '', '', ''),
	(4, 34, '', '', '', '', '', '', '', '', '', '', ''),
	(5, 35, '', '', '', '', '', '', '', '', '', '', ''),
	(6, 36, '', '', '', '', '', '', '', '', '', '', ''),
	(7, 37, '', '', '', '', '', '', '', '', '', '', ''),
	(8, 38, '', '', '', '', '', '', '', '', '', '', ''),
	(9, 39, '', '', '', '', '', '', '', '', '', '', ''),
	(10, 40, '', '', '', '', '', '', '', '', '', '', ''),
	(11, 41, '', '', '', '', '', '', '', '', '', '', '');
/*!40000 ALTER TABLE `ant_aparatos` ENABLE KEYS */;


-- Volcando estructura para tabla consultorio.ant_familiares
CREATE TABLE IF NOT EXISTS `ant_familiares` (
  `id_antecedente` bigint(20) NOT NULL,
  `paciente_id` bigint(20) NOT NULL,
  `tipo_fami` varchar(50) DEFAULT NULL,
  `vive` varchar(2) DEFAULT NULL,
  `diabetes` varchar(100) DEFAULT NULL,
  `cardiobascular` varchar(100) DEFAULT NULL,
  `cancer` varchar(100) DEFAULT NULL,
  `obesidad` varchar(100) DEFAULT NULL,
  `tuberculosis` varchar(100) DEFAULT NULL,
  `alergicos` varchar(100) DEFAULT NULL,
  `veneros` varchar(100) DEFAULT NULL,
  KEY `FK_ant_familares_pacientes` (`paciente_id`),
  CONSTRAINT `FK_ant_familares_pacientes` FOREIGN KEY (`paciente_id`) REFERENCES `pacientes` (`folio`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla consultorio.ant_familiares: ~168 rows (aproximadamente)
/*!40000 ALTER TABLE `ant_familiares` DISABLE KEYS */;
INSERT INTO `ant_familiares` (`id_antecedente`, `paciente_id`, `tipo_fami`, `vive`, `diabetes`, `cardiobascular`, `cancer`, `obesidad`, `tuberculosis`, `alergicos`, `veneros`) VALUES
	(1, 20, 'Padre', 'NO', '1', '', '', '', '', '', '1'),
	(2, 20, 'Madre', 'SI', '2', '', '', '', '', '', '2'),
	(3, 20, 'Conyuge', 'NO', '3', '', '', '', '', '', '3'),
	(4, 20, 'Hijos', 'SI', '4', '', '', '', '', '', '4'),
	(5, 20, 'Hermanos', 'NO', '5', '', '', '', '', '', '56'),
	(6, 20, 'Abuelos', 'NO', '6', '', '', '', '', '', '7'),
	(7, 20, 'Tios', 'NO', '7', '', '', '', '', '', '8'),
	(8, 21, 'Padre', '', '', '', '', '', '', '', ''),
	(9, 21, 'Madre', '', '', '', '', '', '', '', ''),
	(10, 21, 'Conyuge', '', '', '', '', '', '', '', ''),
	(11, 21, 'Hijos', '', '', '', '', '', '', '', ''),
	(12, 21, 'Hermanos', '', '', '', '', '', '', '', ''),
	(13, 21, 'Abuelos', '', '', '', '', '', '', '', ''),
	(14, 21, 'Tios', '', '', '', '', '', '', '', ''),
	(15, 22, 'Padre', 'SI', '', '', '', '', '', '', ''),
	(16, 22, 'Madre', 'NO', '', '', '', '', '', '', ''),
	(17, 22, 'Conyuge', '', '', '', '', '', '', '', ''),
	(18, 22, 'Hijos', '', '', '', '', '', '', '', ''),
	(19, 22, 'Hermanos', '', '', '', '', '', '', '', ''),
	(20, 22, 'Abuelos', '', '', '', '', '', '', '', ''),
	(21, 22, 'Tios', '', '', '', '', '', '', '', ''),
	(22, 23, 'Padre', '', '', '', '', '', '', '', ''),
	(23, 23, 'Madre', '', '', '', '', '', '', '', ''),
	(24, 23, 'Conyuge', '', '', '', '', '', '', '', ''),
	(25, 23, 'Hijos', '', '', '', '', '', '', '', ''),
	(26, 23, 'Hermanos', '', '', '', '', '', '', '', ''),
	(27, 23, 'Abuelos', '', '', '', '', '', '', '', ''),
	(28, 23, 'Tios', '', '', '', '', '', '', '', ''),
	(29, 24, 'Padre', '', '', '', '', '', '', '', ''),
	(30, 24, 'Madre', '', '', '', '', '', '', '', ''),
	(31, 24, 'Conyuge', '', '', '', '', '', '', '', ''),
	(32, 24, 'Hijos', '', '', '', '', '', '', '', ''),
	(33, 24, 'Hermanos', '', '', '', '', '', '', '', ''),
	(34, 24, 'Abuelos', '', '', '', '', '', '', '', ''),
	(35, 24, 'Tios', '', '', '', '', '', '', '', ''),
	(36, 25, 'Padre', '', '', '', '', '', '', '', ''),
	(37, 25, 'Madre', '', '', '', '', '', '', '', ''),
	(38, 25, 'Conyuge', '', '', '', '', '', '', '', ''),
	(39, 25, 'Hijos', '', '', '', '', '', '', '', ''),
	(40, 25, 'Hermanos', '', '', '', '', '', '', '', ''),
	(41, 25, 'Abuelos', '', '', '', '', '', '', '', ''),
	(42, 25, 'Tios', '', '', '', '', '', '', '', ''),
	(43, 26, 'Padre', '', '', '', '', '', '', '', ''),
	(44, 26, 'Madre', '', '', '', '', '', '', '', ''),
	(45, 26, 'Conyuge', '', '', '', '', '', '', '', ''),
	(46, 26, 'Hijos', '', '', '', '', '', '', '', ''),
	(47, 26, 'Hermanos', '', '', '', '', '', '', '', ''),
	(48, 26, 'Abuelos', '', '', '', '', '', '', '', ''),
	(49, 26, 'Tios', '', '', '', '', '', '', '', ''),
	(50, 27, 'Padre', '', '', '', '', '', '', '', ''),
	(51, 27, 'Madre', '', '', '', '', '', '', '', ''),
	(52, 27, 'Conyuge', '', '', '', '', '', '', '', ''),
	(53, 27, 'Hijos', '', '', '', '', '', '', '', ''),
	(54, 27, 'Hermanos', '', '', '', '', '', '', '', ''),
	(55, 27, 'Abuelos', '', '', '', '', '', '', '', ''),
	(56, 27, 'Tios', '', '', '', '', '', '', '', ''),
	(57, 27, 'Padre', '', '', '', '', '', '', '', ''),
	(58, 27, 'Madre', '', '', '', '', '', '', '', ''),
	(59, 27, 'Conyuge', '', '', '', '', '', '', '', ''),
	(60, 27, 'Hijos', '', '', '', '', '', '', '', ''),
	(61, 27, 'Hermanos', '', '', '', '', '', '', '', ''),
	(62, 27, 'Abuelos', '', '', '', '', '', '', '', ''),
	(63, 27, 'Tios', '', '', '', '', '', '', '', ''),
	(64, 28, 'Padre', '', '', '', '', '', '', '', ''),
	(65, 28, 'Madre', '', '', '', '', '', '', '', ''),
	(66, 28, 'Conyuge', '', '', '', '', '', '', '', ''),
	(67, 28, 'Hijos', '', '', '', '', '', '', '', ''),
	(68, 28, 'Hermanos', '', '', '', '', '', '', '', ''),
	(69, 28, 'Abuelos', '', '', '', '', '', '', '', ''),
	(70, 28, 'Tios', '', '', '', '', '', '', '', ''),
	(71, 29, 'Padre', '', '', '', '', '', '', '', ''),
	(72, 29, 'Madre', '', '', '', '', '', '', '', ''),
	(73, 29, 'Conyuge', '', '', '', '', '', '', '', ''),
	(74, 29, 'Hijos', '', '', '', '', '', '', '', ''),
	(75, 29, 'Hermanos', '', '', '', '', '', '', '', ''),
	(76, 29, 'Abuelos', '', '', '', '', '', '', '', ''),
	(77, 29, 'Tios', '', '', '', '', '', '', '', ''),
	(78, 30, 'Padre', '', '', '', '', '', '', '', ''),
	(79, 30, 'Madre', '', '', '', '', '', '', '', ''),
	(80, 30, 'Conyuge', '', '', '', '', '', '', '', ''),
	(81, 30, 'Hijos', '', '', '', '', '', '', '', ''),
	(82, 30, 'Hermanos', '', '', '', '', '', '', '', ''),
	(83, 30, 'Abuelos', '', '', '', '', '', '', '', ''),
	(84, 30, 'Tios', '', '', '', '', '', '', '', ''),
	(85, 31, 'Padre', '', '', '', '', '', '', '', ''),
	(86, 31, 'Madre', '', '', '', '', '', '', '', ''),
	(87, 31, 'Conyuge', '', '', '', '', '', '', '', ''),
	(88, 31, 'Hijos', '', '', '', '', '', '', '', ''),
	(89, 31, 'Hermanos', '', '', '', '', '', '', '', ''),
	(90, 31, 'Abuelos', '', '', '', '', '', '', '', ''),
	(91, 31, 'Tios', '', '', '', '', '', '', '', ''),
	(92, 32, 'Padre', '', '', '', '', '', '', '', ''),
	(93, 32, 'Madre', '', '', '', '', '', '', '', ''),
	(94, 32, 'Conyuge', '', '', '', '', '', '', '', ''),
	(95, 32, 'Hijos', '', '', '', '', '', '', '', ''),
	(96, 32, 'Hermanos', '', '', '', '', '', '', '', ''),
	(97, 32, 'Abuelos', '', '', '', '', '', '', '', ''),
	(98, 32, 'Tios', '', '', '', '', '', '', '', ''),
	(99, 32, 'Padre', '', '', '', '', '', '', '', ''),
	(100, 32, 'Madre', '', '', '', '', '', '', '', ''),
	(101, 32, 'Conyuge', '', '', '', '', '', '', '', ''),
	(102, 32, 'Hijos', '', '', '', '', '', '', '', ''),
	(103, 32, 'Hermanos', '', '', '', '', '', '', '', ''),
	(104, 32, 'Abuelos', '', '', '', '', '', '', '', ''),
	(105, 32, 'Tios', '', '', '', '', '', '', '', ''),
	(106, 33, 'Padre', '', '', '', '', '', '', '', ''),
	(107, 33, 'Madre', '', '', '', '', '', '', '', ''),
	(108, 33, 'Conyuge', '', '', '', '', '', '', '', ''),
	(109, 33, 'Hijos', '', '', '', '', '', '', '', ''),
	(110, 33, 'Hermanos', '', '', '', '', '', '', '', ''),
	(111, 33, 'Abuelos', '', '', '', '', '', '', '', ''),
	(112, 33, 'Tios', '', '', '', '', '', '', '', ''),
	(113, 34, 'Padre', '', '', '', '', '', '', '', ''),
	(114, 34, 'Madre', '', '', '', '', '', '', '', ''),
	(115, 34, 'Conyuge', '', '', '', '', '', '', '', ''),
	(116, 34, 'Hijos', '', '', '', '', '', '', '', ''),
	(117, 34, 'Hermanos', '', '', '', '', '', '', '', ''),
	(118, 34, 'Abuelos', '', '', '', '', '', '', '', ''),
	(119, 34, 'Tios', '', '', '', '', '', '', '', ''),
	(120, 35, 'Padre', '', '', '', '', '', '', '', ''),
	(121, 35, 'Madre', '', '', '', '', '', '', '', ''),
	(122, 35, 'Conyuge', '', '', '', '', '', '', '', ''),
	(123, 35, 'Hijos', '', '', '', '', '', '', '', ''),
	(124, 35, 'Hermanos', '', '', '', '', '', '', '', ''),
	(125, 35, 'Abuelos', '', '', '', '', '', '', '', ''),
	(126, 35, 'Tios', '', '', '', '', '', '', '', ''),
	(127, 36, 'Padre', '', '', '', '', '', '', '', ''),
	(128, 36, 'Madre', '', '', '', '', '', '', '', ''),
	(129, 36, 'Conyuge', '', '', '', '', '', '', '', ''),
	(130, 36, 'Hijos', '', '', '', '', '', '', '', ''),
	(131, 36, 'Hermanos', '', '', '', '', '', '', '', ''),
	(132, 36, 'Abuelos', '', '', '', '', '', '', '', ''),
	(133, 36, 'Tios', '', '', '', '', '', '', '', ''),
	(134, 37, 'Padre', '', '', '', '', '', '', '', ''),
	(135, 37, 'Madre', '', '', '', '', '', '', '', ''),
	(136, 37, 'Conyuge', '', '', '', '', '', '', '', ''),
	(137, 37, 'Hijos', '', '', '', '', '', '', '', ''),
	(138, 37, 'Hermanos', '', '', '', '', '', '', '', ''),
	(139, 37, 'Abuelos', '', '', '', '', '', '', '', ''),
	(140, 37, 'Tios', '', '', '', '', '', '', '', ''),
	(141, 38, 'Padre', '', '', '', '', '', '', '', ''),
	(142, 38, 'Madre', '', '', '', '', '', '', '', ''),
	(143, 38, 'Conyuge', '', '', '', '', '', '', '', ''),
	(144, 38, 'Hijos', '', '', '', '', '', '', '', ''),
	(145, 38, 'Hermanos', '', '', '', '', '', '', '', ''),
	(146, 38, 'Abuelos', '', '', '', '', '', '', '', ''),
	(147, 38, 'Tios', '', '', '', '', '', '', '', ''),
	(148, 39, 'Padre', '', '', '', '', '', '', '', ''),
	(149, 39, 'Madre', '', '', '', '', '', '', '', ''),
	(150, 39, 'Conyuge', '', '', '', '', '', '', '', ''),
	(151, 39, 'Hijos', '', '', '', '', '', '', '', ''),
	(152, 39, 'Hermanos', '', '', '', '', '', '', '', ''),
	(153, 39, 'Abuelos', '', '', '', '', '', '', '', ''),
	(154, 39, 'Tios', '', '', '', '', '', '', '', ''),
	(155, 40, 'Padre', '', '', '', '', '', '', '', ''),
	(156, 40, 'Madre', '', '', '', '', '', '', '', ''),
	(157, 40, 'Conyuge', '', '', '', '', '', '', '', ''),
	(158, 40, 'Hijos', '', '', '', '', '', '', '', ''),
	(159, 40, 'Hermanos', '', '', '', '', '', '', '', ''),
	(160, 40, 'Abuelos', '', '', '', '', '', '', '', ''),
	(161, 40, 'Tios', '', '', '', '', '', '', '', ''),
	(162, 41, 'Padre', '', '', '', '', '', '', '', ''),
	(163, 41, 'Madre', '', '', '', '', '', '', '', ''),
	(164, 41, 'Conyuge', '', '', '', '', '', '', '', ''),
	(165, 41, 'Hijos', '', '', '', '', '', '', '', ''),
	(166, 41, 'Hermanos', '', '', '', '', '', '', '', ''),
	(167, 41, 'Abuelos', '', '', '', '', '', '', '', ''),
	(168, 41, 'Tios', '', '', '', '', '', '', '', '');
/*!40000 ALTER TABLE `ant_familiares` ENABLE KEYS */;


-- Volcando estructura para tabla consultorio.ant_ginecolo
CREATE TABLE IF NOT EXISTS `ant_ginecolo` (
  `id_antecedente` bigint(20) NOT NULL,
  `paciente_id` bigint(20) NOT NULL,
  `menarca` varchar(50) NOT NULL,
  `ritmo` varchar(50) NOT NULL,
  `fur` date NOT NULL,
  `vsa` varchar(50) NOT NULL,
  `menopausia` varchar(50) NOT NULL,
  `gesta` varchar(50) NOT NULL,
  `partos` varchar(50) NOT NULL,
  `cesareas` varchar(50) NOT NULL,
  `abortos` varchar(50) NOT NULL,
  `orbitos` varchar(50) NOT NULL,
  `fecha_ulti_exp` varchar(50) NOT NULL,
  `resulta_ulti_exp` varchar(500) NOT NULL,
  `fecha_cito_vagi` date NOT NULL,
  `resulta_cito_vagi` varchar(500) NOT NULL,
  `plani_famili` varchar(200) NOT NULL,
  `obcervaciones` varchar(500) NOT NULL,
  `edad_pri_emb` int(11) NOT NULL,
  `num_pare_sex` int(11) NOT NULL,
  `fecha_ulti_parto` date NOT NULL,
  `propor_lact` varchar(2) NOT NULL,
  `cancer_matriz` varchar(2) NOT NULL,
  `cancer_mama` varchar(2) NOT NULL,
  `familiares` varchar(50) NOT NULL,
  PRIMARY KEY (`id_antecedente`),
  KEY `FK__pacientes` (`paciente_id`),
  CONSTRAINT `FK__pacientes` FOREIGN KEY (`paciente_id`) REFERENCES `pacientes` (`folio`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla consultorio.ant_ginecolo: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `ant_ginecolo` DISABLE KEYS */;
INSERT INTO `ant_ginecolo` (`id_antecedente`, `paciente_id`, `menarca`, `ritmo`, `fur`, `vsa`, `menopausia`, `gesta`, `partos`, `cesareas`, `abortos`, `orbitos`, `fecha_ulti_exp`, `resulta_ulti_exp`, `fecha_cito_vagi`, `resulta_cito_vagi`, `plani_famili`, `obcervaciones`, `edad_pri_emb`, `num_pare_sex`, `fecha_ulti_parto`, `propor_lact`, `cancer_matriz`, `cancer_mama`, `familiares`) VALUES
	(1, 40, '1', '2', '2019-07-25', '3', '4', '5', '6', '7', '8', '9', '2019-07-25', '10', '2019-07-25', '11', '', '12', 13, 14, '2019-07-25', 'Si', 'Si', 'Si', 'Cancer de mamtriz y cancer de mama'),
	(2, 41, '1', '2', '2019-07-25', '3', '4', '5', '6', '7', '8', '9', '2019-07-25', '10', '2019-07-25', '11', 'Hormonal, inyectable, quirurgico, baja, oral, diu y local', '12', 13, 14, '2019-07-25', 'Si', 'Si', 'Si', 'Cancer de mamtriz y cancer de mama');
/*!40000 ALTER TABLE `ant_ginecolo` ENABLE KEYS */;


-- Volcando estructura para tabla consultorio.ant_no_pato
CREATE TABLE IF NOT EXISTS `ant_no_pato` (
  `id_antecedente` bigint(20) NOT NULL,
  `paciente_id` bigint(20) NOT NULL,
  `vacunacion` varchar(20) DEFAULT NULL,
  `higiene` varchar(20) DEFAULT NULL,
  `alimentacion` varchar(20) DEFAULT NULL,
  `familiares` varchar(50) DEFAULT NULL,
  `alcolismo` varchar(100) DEFAULT NULL,
  `tabaquismo` varchar(100) DEFAULT NULL,
  `toxicaminas` varchar(100) DEFAULT NULL,
  `quirurgicos` varchar(100) DEFAULT NULL,
  `transfucionales` varchar(100) DEFAULT NULL,
  `alergicos` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_antecedente`),
  KEY `FK_ant_no_pato_pacientes` (`paciente_id`),
  CONSTRAINT `FK_ant_no_pato_pacientes` FOREIGN KEY (`paciente_id`) REFERENCES `pacientes` (`folio`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla consultorio.ant_no_pato: ~13 rows (aproximadamente)
/*!40000 ALTER TABLE `ant_no_pato` DISABLE KEYS */;
INSERT INTO `ant_no_pato` (`id_antecedente`, `paciente_id`, `vacunacion`, `higiene`, `alimentacion`, `familiares`, `alcolismo`, `tabaquismo`, `toxicaminas`, `quirurgicos`, `transfucionales`, `alergicos`) VALUES
	(1, 23, 'incompleto', 'Buena', 'Mala', NULL, NULL, NULL, '', '', '', ''),
	(2, 24, 'Completo', 'Buena', 'Regular', NULL, NULL, NULL, '', '', '', ''),
	(3, 25, 'Completo', 'Buena', 'Mala', NULL, NULL, NULL, '', '', '', ''),
	(4, 32, 'Incompleto', 'Buena', 'Regular', 'Alcoholismo y tabaquismo', '1', '2', '3', '5', '5', '4'),
	(5, 33, 'Completo', 'Buena', 'Buena', '', '1', '2', '3', '4', '5', '6'),
	(6, 34, 'Completo', 'Buena', 'Buena', '', '1', '2', '3', '4', '5', '6'),
	(7, 35, 'Completo', 'Buena', 'Buena', '', '', '', '', '', '', ''),
	(8, 36, 'Completo', 'Buena', 'Buena', '', '', '', '', '', '', ''),
	(9, 37, 'Completo', 'Buena', 'Buena', '', '', '', '', '', '', ''),
	(10, 38, 'Completo', 'Buena', 'Buena', '', '', '', '', '', '', ''),
	(11, 39, 'Completo', 'Buena', 'Buena', '', '', '', '', '', '', ''),
	(12, 40, 'Completo', 'Buena', 'Buena', '', '', '', '', '', '', ''),
	(13, 41, 'Completo', 'Buena', 'Buena', '', '', '', '', '', '', '');
/*!40000 ALTER TABLE `ant_no_pato` ENABLE KEYS */;


-- Volcando estructura para tabla consultorio.ant_pato
CREATE TABLE IF NOT EXISTS `ant_pato` (
  `id_antecedente` bigint(20) NOT NULL,
  `paciente_id` bigint(20) NOT NULL,
  `cardiobasculares` varchar(100) DEFAULT NULL,
  `endocrinos` varchar(100) DEFAULT NULL,
  `familiares` varchar(100) DEFAULT NULL,
  `insu_intra` varchar(2) DEFAULT NULL,
  `musculo_esc` varchar(100) DEFAULT NULL,
  `neumologicos` varchar(100) DEFAULT NULL,
  `neoplasticos` varchar(100) DEFAULT NULL,
  `musculo_obe` varchar(100) DEFAULT NULL,
  `pisicritaticos` varchar(100) DEFAULT NULL,
  `gastroinstestinal` varchar(100) DEFAULT NULL,
  `hemorragicos` varchar(100) DEFAULT NULL,
  `veneros` varchar(100) DEFAULT NULL,
  `hepatabiliares` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_antecedente`),
  KEY `FK_ant_pato_pacientes` (`paciente_id`),
  CONSTRAINT `FK_ant_pato_pacientes` FOREIGN KEY (`paciente_id`) REFERENCES `pacientes` (`folio`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla consultorio.ant_pato: ~12 rows (aproximadamente)
/*!40000 ALTER TABLE `ant_pato` DISABLE KEYS */;
INSERT INTO `ant_pato` (`id_antecedente`, `paciente_id`, `cardiobasculares`, `endocrinos`, `familiares`, `insu_intra`, `musculo_esc`, `neumologicos`, `neoplasticos`, `musculo_obe`, `pisicritaticos`, `gastroinstestinal`, `hemorragicos`, `veneros`, `hepatabiliares`) VALUES
	(1, 24, '', '', 'Hipertencion', 'Si', '', '', '', '', '', '', '', '', ''),
	(2, 25, '', '', 'Hipertencion, insuficiencia intravenosa y Diabetes mellitus', 'Si', '', '', '', '', '', '', '', '', ''),
	(3, 32, '', '', '', 'No', '', '', '', '', '', '', '', '', ''),
	(4, 33, '', '', '', 'No', '', '', '', '', '', '', '', '', ''),
	(5, 34, '', '', '', 'No', '', '', '', '', '', '', '', '', ''),
	(6, 35, '', '', '', 'No', '', '', '', '', '', '', '', '', ''),
	(7, 36, '', '', '', 'No', '', '', '', '', '', '', '', '', ''),
	(8, 37, '', '', '', 'No', '', '', '', '', '', '', '', '', ''),
	(9, 38, '', '', '', 'No', '', '', '', '', '', '', '', '', ''),
	(10, 39, '', '', '', 'No', '', '', '', '', '', '', '', '', ''),
	(11, 40, '', '', '', 'No', '', '', '', '', '', '', '', '', ''),
	(12, 41, '', '', '', 'No', '', '', '', '', '', '', '', '', '');
/*!40000 ALTER TABLE `ant_pato` ENABLE KEYS */;


-- Volcando estructura para tabla consultorio.consultas
CREATE TABLE IF NOT EXISTS `consultas` (
  `id_consulta` bigint(20) NOT NULL,
  `usuario_id` bigint(20) DEFAULT NULL,
  `s` longtext,
  `o` longtext,
  `a` longtext,
  `p` longtext,
  `plan_manejo` longtext,
  `subsecuente` longtext,
  `fecha` date NOT NULL,
  PRIMARY KEY (`id_consulta`),
  KEY `FK_consulta_usuarios` (`usuario_id`),
  CONSTRAINT `FK_consulta_usuarios` FOREIGN KEY (`usuario_id`) REFERENCES `pacientes` (`folio`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='tabla consulta';

-- Volcando datos para la tabla consultorio.consultas: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `consultas` DISABLE KEYS */;
/*!40000 ALTER TABLE `consultas` ENABLE KEYS */;


-- Volcando estructura para tabla consultorio.pacientes
CREATE TABLE IF NOT EXISTS `pacientes` (
  `folio` bigint(20) NOT NULL,
  `nombre` varchar(200) NOT NULL,
  `sexo` varchar(50) DEFAULT NULL,
  `tipo_sangre` varchar(50) DEFAULT NULL,
  `fecha_naci` date DEFAULT NULL,
  `domicilio` varchar(200) DEFAULT NULL,
  `ocupacion` varchar(100) DEFAULT NULL,
  `escolaridad` varchar(100) DEFAULT NULL,
  `estado_civil` varchar(50) DEFAULT NULL,
  `religion` varchar(50) DEFAULT NULL,
  `edad` int(11) NOT NULL,
  `lugar_naci` varchar(100) DEFAULT NULL,
  `telefono` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`folio`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla consultorio.pacientes: ~36 rows (aproximadamente)
/*!40000 ALTER TABLE `pacientes` DISABLE KEYS */;
INSERT INTO `pacientes` (`folio`, `nombre`, `sexo`, `tipo_sangre`, `fecha_naci`, `domicilio`, `ocupacion`, `escolaridad`, `estado_civil`, `religion`, `edad`, `lugar_naci`, `telefono`) VALUES
	(1, 'fede enfermito', 'Masculino', 'o+', '2019-07-23', NULL, NULL, 'ingeniebrio', 'solterin', NULL, 23, 'hermosillo', NULL),
	(2, 'test', 'Femenino', 'a-', '2019-07-23', NULL, NULL, '', NULL, NULL, 29, NULL, NULL),
	(3, 'test 2', 'Femenino', 'o-', '2019-07-21', NULL, NULL, NULL, NULL, NULL, 22, 'hermosillo', NULL),
	(8, 'test 3', 'Masculino', 'A+', '2019-07-22', 'olivos', 'operador', 'secundaria', 'Soltero(a)', 'Catolico', 29, 'obregon', '123553'),
	(10, 'test 3', 'Masculino', 'A+', '2019-07-22', 'olivos', 'operador', 'secundaria', 'Soltero(a)', 'Catolico', 29, 'obregon', '123553'),
	(11, 'test 4', 'Masculino', 'o-', '2019-07-21', '', '', '', '', '', 22, 'hermosillo', ''),
	(12, 'test cinco', 'Masculino', 'o-', '2019-07-24', 'centro', '', 'Primaria', 'Viudo(a)', 'Cristiano', 15, 'guaymas', '5493589'),
	(13, 'test cinco', 'Masculino', 'o-', '2019-07-24', 'centro', '', 'Primaria', 'Viudo(a)', 'Cristiano', 15, 'guaymas', '5493589'),
	(14, 'fex', 'Femenino', '', '2019-07-23', '', '', '', '', '', 1, '', ''),
	(15, 'fex', 'Femenino', '', '2019-07-23', '', '', '', '', '', 18, '', ''),
	(16, 'hola', 'Femenino', '', '2019-07-24', '', '', '', '', '', 19, '', ''),
	(17, 'test para ante', 'Femenino', '', '2019-07-24', '', '', '', '', '', 16, '', ''),
	(18, 'test para ante dos', 'Femenino', '', '2019-07-24', '', '', '', '', '', 16, '', ''),
	(19, 'test', 'Femenino', 'o-', '2019-07-21', '', '', '', '', '', 22, 'hermosillo', ''),
	(20, 'test para ante tres', 'Femenino', '', '2019-07-24', '', '', '', '', '', 16, '', ''),
	(21, 'test nuevo', 'Masculino', 'A+', '2019-07-22', 'olivos', 'operador', 'secundaria', 'Soltero(a)', 'Catolico', 29, 'obregon', '123553'),
	(22, 'test', 'Femenino', 'a-', '2019-07-23', '', '', '', '', '', 29, '', ''),
	(23, 'test', 'Femenino', 'a-', '2019-07-23', '', '', '', '', '', 29, '', ''),
	(24, 'test chilo', 'Femenino', '', '2019-07-24', '', '', '', '', '', 1, '', ''),
	(25, 'test chilo', 'Femenino', '', '2019-07-24', '', '', '', '', '', 1, '', ''),
	(26, 'fede enfermito', 'Masculino', 'o+', '2019-07-23', '', '', 'ingeniebrio', 'solterin', '', 23, 'hermosillo', ''),
	(27, 'test', 'Femenino', 'a-', '2019-07-23', '', '', '', '', '', 29, '', ''),
	(28, 'te', 'Femenino', '', '2019-07-24', '', '', '', '', '', 1, '', ''),
	(29, 'n', 'Femenino', '', '2019-07-24', '', '', '', '', '', 1, '', ''),
	(30, 'test', 'Femenino', 'a-', '2019-07-23', '', '', '', '', '', 29, '', ''),
	(31, 'ge', 'Femenino', '', '2019-07-24', '', '', '', '', '', 3, '', ''),
	(32, 'g', 'Femenino', '', '2019-07-24', '', '', '', '', '', 1, '', ''),
	(33, 'test', 'Femenino', 'a-', '2019-07-23', '', '', '', '', '', 29, '', ''),
	(34, 'test', 'Masculino', 'A+', '2019-07-22', 'olivos', 'operador', 'secundaria', 'Soltero(a)', 'Catolico', 29, 'obregon', '123553'),
	(35, 'fex', 'Femenino', '', '2019-07-24', '', '', '', '', '', 1, '', ''),
	(36, 'ahora si', 'Femenino', '', '2019-07-24', '', '', '', '', '', 1, '', ''),
	(37, 'fex', 'Femenino', '', '2019-07-24', '', '', '', '', '', 1, '', ''),
	(38, 'fede enfermito', 'Masculino', 'o+', '2019-07-23', '', '', 'ingeniebrio', 'solterin', '', 23, 'hermosillo', ''),
	(39, 'fede enfermito', 'Masculino', 'o+', '2019-07-23', '', '', 'ingeniebrio', 'solterin', '', 23, 'hermosillo', ''),
	(40, 'test niuel', 'Femenino', '', '2019-07-25', '', '', '', '', '', 1, '', ''),
	(41, 'test', 'Femenino', 'a-', '2019-07-23', '', '', '', '', '', 29, '', '');
/*!40000 ALTER TABLE `pacientes` ENABLE KEYS */;


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
	('fede4', 'federicoco', 'castillo Valenzuelaco', '202cb962ac59075b964b07152d234b70', 'Administrador'),
	('test', 'test', 'test', '202cb962ac59075b964b07152d234b70', 'Usuario');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
