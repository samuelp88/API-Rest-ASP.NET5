CREATE TABLE IF NOT EXISTS `person` (
	`id` BIGINT(20) NOT NULL AUTO_INCREMENT,
	`adress` VARCHAR(100) NOT NULL,
	`first_name` VARCHAR(80) NOT NULL,
	`gender` varchar(6) NOT NULL,
	`last_name` VARCHAR(80) NOT NULL,
	
	PRIMARY KEY (`id`)
)