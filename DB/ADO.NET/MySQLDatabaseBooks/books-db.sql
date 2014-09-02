SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema BooksDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `BooksDB` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `BooksDB` ;

-- -----------------------------------------------------
-- Table `BooksDB`.`Books`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BooksDB`.`Books` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(45) NOT NULL,
  `Author` VARCHAR(45) NOT NULL,
  `PublishDate` DATETIME NULL,
  `ISBN` CHAR(13) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
