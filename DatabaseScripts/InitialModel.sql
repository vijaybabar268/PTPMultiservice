-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema ptpmultiservice
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema ptpmultiservice
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ptpmultiservice` DEFAULT CHARACTER SET utf8 ;
USE `ptpmultiservice` ;

-- -----------------------------------------------------
-- Table `ptpmultiservice`.`admins`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ptpmultiservice`.`admins` (
  `admin_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `password` NVARCHAR(10) NOT NULL,
  `created_on` DATETIME NOT NULL,
  `is_active` BIT NULL,
  PRIMARY KEY (`admin_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ptpmultiservice`.`partners`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ptpmultiservice`.`partners` (
  `partner_id` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`partner_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ptpmultiservice`.`clients`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ptpmultiservice`.`clients` (
  `client_id` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`client_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ptpmultiservice`.`employees`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ptpmultiservice`.`employees` (
  `employee_id` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`employee_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ptpmultiservice`.`vendors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ptpmultiservice`.`vendors` (
  `vendor_id` INT NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`vendor_id`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
