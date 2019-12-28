CREATE TABLE IF NOT EXISTS cars (
    brand varchar(20) NOT NULL,
    model varchar(16) NOT NULL, 
    "year" integer NOT NULL,
    id_carpower integer NOT NULL,
    price integer NOT NULL,
    id_colour integer NOT NULL,
    "type" varchar(16) NOT NULL,
    plateNr varchar(10) NOT NULL,
    PRIMARY KEY (plateNr)
);

CREATE TABLE IF NOT EXISTS carpower (
    carpower_id serial NOT NULL,
    carpower varchar(10) NOT NULL,
    PRIMARY KEY (carpower_id)
);

CREATE TABLE IF NOT EXISTS colour (
    colour_id serial NOT NULL,
    colour varchar(10) NOT NULL,
    PRIMARY KEY (colour_id)
);

INSERT INTO cars (brand, model, "year", id_carpower, price, id_colour, "type", plateNr) VALUES
('BMW', '330D', 2007, '2', 5000, '1', 'Wagon', 'OYU-809'),
('Volvo', 'V90', 2010, '1', 10000, '2', 'Wagon', 'ASD-123'),
('Audi', 'A6', 2000, '2', 3000, '3', 'Sedan', 'IOO-345'),
('Opel', 'Corsa', 2008, '1', 2000, '5', 'Hatchback', 'CZZ-987'),
('BMW', '335i', 2005, '2', 5000, '4', 'Wagon', 'VBC-908'),
('Volvo', 'XC70', 2019, '1', 25000, '6', 'Wagon', 'WER-432');

INSERT INTO carpower (carpower_id, carpower) VALUES
(default, 'Gasoline'),
(default, 'Diesel');

INSERT INTO colour (colour_id, colour) VALUES
(default, 'Black'),
(default, 'Red'),
(default, 'Blue'),
(default, 'Yellow'),
(default, 'Grey'),
(default, 'White');






