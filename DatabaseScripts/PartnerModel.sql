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
-- Table `ptpmultiservice`.`document_master`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ptpmultiservice`.`document_master` (
  `document_id` INT NOT NULL AUTO_INCREMENT,
  `type` SMALLINT NULL,
  `name` VARCHAR(250) NULL,
  `number` VARCHAR(45) NULL,
  `birthdate` DATE NULL,
  `address` VARCHAR(500) NULL,
  PRIMARY KEY (`document_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ptpmultiservice`.`bank_master`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ptpmultiservice`.`bank_master` (
  `bank_id` INT NOT NULL AUTO_INCREMENT,
  `account_no` VARCHAR(45) NULL,
  `bank_holder_name` VARCHAR(250) NULL,
  `bank_name` VARCHAR(250) NULL,
  `ifsc_code` VARCHAR(45) NULL,
  `branch_name` VARCHAR(250) NULL,
  PRIMARY KEY (`bank_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ptpmultiservice`.`terms_condition_master`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ptpmultiservice`.`terms_condition_master` (
  `terms_condition_id` INT NOT NULL AUTO_INCREMENT,
  `pl_sharing_percent` FLOAT NULL,
  `monthly_incentives` FLOAT NULL,
  `yearly_incentives` FLOAT NULL,
  `other_perks` FLOAT NULL,
  `notice_period_in_days` SMALLINT NULL,
  `other_terms` VARCHAR(500) NULL,
  PRIMARY KEY (`terms_condition_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ptpmultiservice`.`partners`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ptpmultiservice`.`partners` (
  `partner_id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(100) NULL,
  `middle_name` VARCHAR(100) NULL,
  `last_name` VARCHAR(100) NULL,
  `mother_name` VARCHAR(100) NULL,
  `email` VARCHAR(100) NULL,
  `mobile` VARCHAR(45) NULL,
  `tel` VARCHAR(45) NULL,
  `birth_date` DATE NULL,
  `education_id` SMALLINT NULL,
  `designation_id` SMALLINT NULL,
  `marital_status_id` SMALLINT NULL,
  `gender_id` SMALLINT NULL,
  `joining_date` DATE NULL,
  `present_address` VARCHAR(500) NULL,
  `permanent_address` VARCHAR(500) NULL,
  `identity_body_mark` VARCHAR(250) NULL,
  `remarks` VARCHAR(500) NULL,
  `document_id` INT NULL,
  `bank_id` INT NULL,
  `terms_condition_id` INT NULL,
  `is_active` BIT NULL,
  `created_on` DATETIME NULL,
  PRIMARY KEY (`partner_id`),
  INDEX `partner_document_id_FK_idx` (`document_id` ASC) VISIBLE,
  INDEX `partner_bank_id_FK_idx` (`bank_id` ASC) VISIBLE,
  INDEX `terms_condition_id_FK_idx` (`terms_condition_id` ASC) VISIBLE,
  CONSTRAINT `partner_document_id_FK`
    FOREIGN KEY (`document_id`)
    REFERENCES `ptpmultiservice`.`document_master` (`document_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `partner_bank_id_FK`
    FOREIGN KEY (`bank_id`)
    REFERENCES `ptpmultiservice`.`bank_master` (`bank_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `terms_condition_id_FK`
    FOREIGN KEY (`terms_condition_id`)
    REFERENCES `ptpmultiservice`.`terms_condition_master` (`terms_condition_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
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
