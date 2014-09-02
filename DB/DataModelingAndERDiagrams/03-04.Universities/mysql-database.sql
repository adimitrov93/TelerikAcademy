SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema UniversitiesNoDuplicateChance
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `UniversitiesNoDuplicateChance` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `UniversitiesNoDuplicateChance` ;

-- -----------------------------------------------------
-- Table `UniversitiesNoDuplicateChance`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitiesNoDuplicateChance`.`Titles` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitiesNoDuplicateChance`.`People`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitiesNoDuplicateChance`.`People` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitiesNoDuplicateChance`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitiesNoDuplicateChance`.`Faculties` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitiesNoDuplicateChance`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitiesNoDuplicateChance`.`Departments` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `FacultyID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `FK_Departments_Faculties_idx` (`FacultyID` ASC),
  CONSTRAINT `FK_Departments_Faculties`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `UniversitiesNoDuplicateChance`.`Faculties` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitiesNoDuplicateChance`.`Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitiesNoDuplicateChance`.`Professors` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `PersonID` INT NOT NULL,
  `DepartmentID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `FK_Professors_Departments_idx` (`DepartmentID` ASC),
  CONSTRAINT `FK_Professors_People`
    FOREIGN KEY (`PersonID`)
    REFERENCES `UniversitiesNoDuplicateChance`.`People` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Professors_Departments`
    FOREIGN KEY (`DepartmentID`)
    REFERENCES `UniversitiesNoDuplicateChance`.`Departments` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitiesNoDuplicateChance`.`Professors_Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitiesNoDuplicateChance`.`Professors_Titles` (
  `ProfessorID` INT NOT NULL,
  `TitleID` INT NOT NULL,
  INDEX `TitleID_idx` (`TitleID` ASC),
  INDEX `FK_Professors_Titles_Titles_idx` (`ProfessorID` ASC),
  CONSTRAINT `FK_Professors_Titles_Titles`
    FOREIGN KEY (`TitleID`)
    REFERENCES `UniversitiesNoDuplicateChance`.`Titles` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Professors_Titles_Professors`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `UniversitiesNoDuplicateChance`.`Professors` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitiesNoDuplicateChance`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitiesNoDuplicateChance`.`Students` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `PersonID` INT NOT NULL,
  `FacultyID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `FK_Students_Faculties_idx` (`FacultyID` ASC),
  CONSTRAINT `FK_Students_Faculties`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `UniversitiesNoDuplicateChance`.`Faculties` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Students_People`
    FOREIGN KEY (`PersonID`)
    REFERENCES `UniversitiesNoDuplicateChance`.`People` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitiesNoDuplicateChance`.`Cources`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitiesNoDuplicateChance`.`Cources` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `DepartmentID` INT NOT NULL,
  `ProfessorID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `FK_Cources_Departments_idx` (`DepartmentID` ASC),
  INDEX `FK_Cources_Professors_idx` (`ProfessorID` ASC),
  CONSTRAINT `FK_Cources_Departments`
    FOREIGN KEY (`DepartmentID`)
    REFERENCES `UniversitiesNoDuplicateChance`.`Departments` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Cources_Professors`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `UniversitiesNoDuplicateChance`.`Professors` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitiesNoDuplicateChance`.`Cources_Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitiesNoDuplicateChance`.`Cources_Students` (
  `CourseID` INT NOT NULL,
  `StudentID` INT NOT NULL,
  INDEX `FK_Cources_Students_Students_idx` (`StudentID` ASC),
  INDEX `FK_Cources_Students_Cources_idx` (`CourseID` ASC),
  CONSTRAINT `FK_Cources_Students_Students`
    FOREIGN KEY (`StudentID`)
    REFERENCES `UniversitiesNoDuplicateChance`.`Students` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Cources_Students_Cources`
    FOREIGN KEY (`CourseID`)
    REFERENCES `UniversitiesNoDuplicateChance`.`Cources` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
