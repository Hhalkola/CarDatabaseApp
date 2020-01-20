-- Fixed some formations and upper and lower case letters

CREATE TABLE IF NOT EXISTS cars (
    platenumber varchar(10) NOT NULL,
    brand varchar(20) NOT NULL,
    model varchar(16) NOT NULL, 
    "year" integer NOT NULL,
    fuelid integer NOT NULL,
    price integer NOT NULL,
    colorid integer NOT NULL,
    PRIMARY KEY (platenumber)
);

CREATE TABLE IF NOT EXISTS fuel (
    fuelid serial NOT NULL,
    carpower varchar(10) NOT NULL,
    PRIMARY KEY (fuelid)
);

INSERT INTO fuel (fuelid, carpower) VALUES
(1, 'Gasoline'),
(2, 'Diesel');

CREATE TABLE IF NOT EXISTS colour (
    colour_id serial NOT NULL,
    colour varchar(10) NOT NULL,
    PRIMARY KEY (colour_id)
);

INSERT INTO colour (colour_id, colour) VALUES
(1, 'Black'),
(2, 'Red'),
(3, 'Blue'),
(4, 'Yellow'),
(5, 'Grey'),
(6, 'White');

INSERT INTO cars (platenumber, brand, model, "year", fuelid, price, colorid) VALUES
('OYU809', 'BMW', '330D', 2007, '2', 5000, '1'),
('ASD123', 'Volvo', 'V90', 2010, '1', 10000, '2'),
('IOO345', 'Audi', 'A6', 2000, '2', 3000, '3'),
('CZZ987', 'Opel', 'Corsa', 2008, '1', 2000, '5'),
('VBC908','BMW', '335i', 2005, '2', 5000, '4'),
('WER432','Volvo', 'XC70', 2019, '1', 25000, '6');
