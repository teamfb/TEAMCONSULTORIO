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

-- Volcando datos para la tabla consultorio.ant_familiares: ~35 rows (aproximadamente)
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
	(35, 24, 'Tios', '', '', '', '', '', '', '', '');
/*!40000 ALTER TABLE `ant_familiares` ENABLE KEYS */;


-- Volcando estructura para tabla consultorio.ant_no_pato
CREATE TABLE IF NOT EXISTS `ant_no_pato` (
  `id_antecedente` bigint(20) NOT NULL,
  `paciente_id` bigint(20) NOT NULL,
  `vacunacion` varchar(20) DEFAULT NULL,
  `higiene` varchar(20) DEFAULT NULL,
  `alimentacion` varchar(20) DEFAULT NULL,
  `alcoholismo` varchar(100) DEFAULT NULL,
  `tabaquismo` varchar(100) DEFAULT NULL,
  `toxicaminas` varchar(100) DEFAULT NULL,
  `quirurgicos` varchar(100) DEFAULT NULL,
  `transfucionales` varchar(100) DEFAULT NULL,
  `alergicos` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_antecedente`),
  KEY `FK_ant_no_pato_pacientes` (`paciente_id`),
  CONSTRAINT `FK_ant_no_pato_pacientes` FOREIGN KEY (`paciente_id`) REFERENCES `pacientes` (`folio`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla consultorio.ant_no_pato: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `ant_no_pato` DISABLE KEYS */;
INSERT INTO `ant_no_pato` (`id_antecedente`, `paciente_id`, `vacunacion`, `higiene`, `alimentacion`, `alcoholismo`, `tabaquismo`, `toxicaminas`, `quirurgicos`, `transfucionales`, `alergicos`) VALUES
	(1, 23, 'incompleto', 'Buena', 'Mala', '', '', '', '', '', ''),
	(2, 24, 'Completo', 'Buena', 'Regular', '', '', '', '', '', '');
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

-- Volcando datos para la tabla consultorio.ant_pato: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `ant_pato` DISABLE KEYS */;
INSERT INTO `ant_pato` (`id_antecedente`, `paciente_id`, `cardiobasculares`, `endocrinos`, `familiares`, `insu_intra`, `musculo_esc`, `neumologicos`, `neoplasticos`, `musculo_obe`, `pisicritaticos`, `gastroinstestinal`, `hemorragicos`, `veneros`, `hepatabiliares`) VALUES
	(1, 24, '', '', 'Hipertencion', 'Si', '', '', '', '', '', '', '', '', '');
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

-- Volcando datos para la tabla consultorio.pacientes: ~19 rows (aproximadamente)
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
	(24, 'test chilo', 'Femenino', '', '2019-07-24', '', '', '', '', '', 1, '', '');
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
