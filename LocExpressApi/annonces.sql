-- CREATE DATABASE annonces
--  WITH ENCODING = 'UTF8'
--     LC_COLLATE = 'fr_FR.UTF-8'
--     LC_CTYPE = 'fr_FR.UTF-8'
--     TEMPLATE = template0;

-- CREATE TABLE users (
--     id SERIAL PRIMARY KEY,
--     name VARCHAR(30) NOT NULL,
--     FirstName VARCHAR(30) NOT NULL,
--     email VARCHAR(30) UNIQUE NOT NULL,
--     password VARCHAR(255) NOT NULL
-- );

-- CREATE TABLE listings (
--     id SERIAL PRIMARY KEY,
--     price INTEGER NOT NULL,
--     title VARCHAR(100) NOT NULL,
--     description VARCHAR(1000),
--     adress VARCHAR(50),
--     owner INTEGER,
--     FOREIGN KEY (owner) REFERENCES users (id)
-- );

-- CREATE TABLE pictures (
--     id SERIAL PRIMARY KEY,
--     path VARCHAR(100),
--     listing INTEGER,
--     FOREIGN KEY (listing) REFERENCES listings (id)
-- );

INSERT INTO users (name, FirstName, email, password) VALUES
    ('Muller', 'Youri', 'youri@mail.com', '12345'),
    ('Bekkaev', 'Magomed', 'magomed@mail.com', 1234),
    ('Doe', 'John', 'johndoe@mail.com', 'azerty'),
    ('Dupont', 'Marc', 'marc.dupont@mail.com', 'password');

INSERT INTO property_types(name) VALUES 
    ('Appartement'),
    ('Maison'),
    ('Chambre en colocation'),
    ('Chambre chez l''habitant');

INSERT INTO energy_categories (value) VALUES 
    ('A'),
    ('B'),
    ('C'),
    ('D'),
    ('E'),
    ('F'),
    ('G');

INSERT INTO "rentalAds"(title, rent, rental_charges, city, post_code, 
    surface, rooms_number, bedrooms_number,description, 
    energy_category_id, owner_id, type_id, longitude, latitude) VALUES 
    ('Appartement 2 pièces 54m²', '590', '60', 'Montpellier',  '34000', '54', '2', '1', 
    'Beau deux pièces lumineux avec cuisine équipée, balcon et cave', '4', '1', '1', '7.749655','48.55744' ),
    ('3 pièces 65m² neuf', '770', '110', 'Schiltigheim', '67300', '65', '3', '2', 
    'Appartement 3 pièces comprenant 1 salon/cuisine, 2 chambres, salle de bains et wc séparés. 
    Logement neuf, vous serez les premiers locataires !', '2', '2', '1', '7.742214', '48.601625'),
    ('Bel appartement quartier gare', '680', '80', 'Marseille', '13000', '65', '3', '2', 
    'Surface: 65 m², proche toutes commodités. Cuisine équipée, 2 chambres avec balcons, 
    poutres apparentes.', '6', '2', '1','7.734365', '48.581652'),
    ('Chambre dans colocation Krutenau', '410', '40', 'Strasbourg', '67000', '12', '1', '1', 
    'Une chambre se libère dans notre colocation proche place de Zurich ! Appartement de 85 m² 
    avec 3 chambres, une grande cuisine et un salon avec terrasse.', '4', '3', '3', '7.756423', '48.580313'),
    ('Grand duplex quartier Orangerie', '1200', '180', 'Strasbourg', '67000', '102', '6', '3', 
    'Superbe appartement en duplex, comprenant une cuisine / salle à manger, un grand salon et 1 chambre au premier niveau 
    et 2 chambres et un bureau au deuxième niveau, le tout au dernier étage dun petit immeuble 
    idéalement situé à deux pas du parc de l"Orangerie', '3', '3', '1', '7.783096', '48.588804'),
    ('Studio idéal étudiant', '430', '35', 'Lyon', '69000', '19', '1', '1', 
    'Studio proche universités, idéal pour étudiant. Cuisine équipée, fibre', '4', '2', '1', '7.771981', '48.584477'),
    ('Appartement petite France', '880', '90', 'Strasbourg', '67000', '75', '4', '2', 
    'Lorem Elsass Ipsum mitt picon bière munster du ftomi! Ponchour bisame. Bibbeleskaas jetz rossbolla sech choucroute un schwanz geburtstàg, 
    Chinette dû, ìch bier deppfele schiesser. Flammekueche de knèkes Seppele gal! a hopla geburtstàg, alles fraü Chulia Roberts oder knäckes dûû blottkopf. 
    Noch bredele schissabibala, yeuh e schmutz. E gewurtztraminer doch Carola schneck, 
    schmutz a riesling de chambon eme rucksack Roger dû hopla geiss, 
    jetz Chorchette de Scharrarbergheim.', '5', '1', '2', '7.742261', '48.579594');

INSERT INTO pictures (path, "rentalAd_id") VALUES 
    ('images/chambre.jpg', '1'),
    ('images/cuisine.jpg', '1'),
    ('images/sdb.jpg', '1'),
    ('images/vide.jpg', '2'),
    ('images/sdb.jpg', '2'),
    ('images/cuisine.jpg', '2'),
    ('images/chambre.jpg', '3'),
    ('images/cuisine.jpg', '3'),
    ('images/sdb.jpg', '3'),
    ('images/vide.jpg', '4'),
    ('images/vide.jpg', '4'),
    ('images/vide.jpg', '4'),
    ('images/cuisine.jpg', '5'),
    ('images/sdb.jpg', '5'),
    ('images/vide.jpg', '5'),
    ('images/cuisine.jpg', '6'),
    ('images/sdb.jpg', '6'),
    ('images/cuisine.jpg', '7'),
    ('images/sdb.jpg', '7'),
    ('images/vide.jpg', '7');