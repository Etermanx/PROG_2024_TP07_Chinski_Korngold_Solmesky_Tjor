USE PreguntadOrt;

INSERT INTO Respuestas (IdPregunta, Opcion, Contenido, Correcta, Foto)
VALUES
    (1, 1, 'Estados Unidos', 0, 'https://annamapa.com/estados-unidos/mapa-estados-unidos.jpg'),
    (1, 2, 'Canada', 0, 'https://thumbor.bigedition.com/true-size-of-canada-compared-to-europe/QSsI_9XKujdJUEZ71NZNDp8psZM=/800x0/filters:quality(80)/granite-web-prod/d1/ab/d1ab5306ef6d4ce887c1aa35a902c7a2.jpeg'),
    (1, 3, 'Rusia', 1, 'https://i.redd.it/u2h87mi6gji91.jpg'),
    (1, 4, 'China', 0, 'https://i.pinimg.com/originals/30/4e/af/304eafc690391c6ca98b175d7d5a8b0c.png'),
    (2, 1, 'Madrid', 0, 'https://3.bp.blogspot.com/-mu4SLO1yIuk/VV0ibaZx3QI/AAAAAAAAAAU/8CTy-paUPNw/s1600/Mapa-Madrid.png'),
    (2, 2, 'Lisboa', 1, 'https://travelboulevard.be/wp-content/uploads/2015/06/maplissabon.jpg'),
    (2, 3, 'Oporto', 0, 'https://es.maps-portugal.com/download.php?id=27&name=mapa-de-porto-portugal.jpg'),
    (2, 4, 'Barcelona', 0, 'https://dondeesta.net/wp-content/uploads/2021/08/%C2%BFDonde-esta-Barcelona.png'),
    (3, 1, 'Asia', 0, NULL),
    (3, 2, 'Africa', 0, NULL),
    (3, 3, 'America', 0, NULL),
    (3, 4, 'Africa', 1, NULL),
    (4, 1, 'Egipto', 0, NULL),
    (4, 2, 'Nigeria', 0, NULL),
    (4, 3, 'Sudafrica', 0, NULL),
    (4, 4, 'Argelia', 1, NULL),
    (5, 1, '1900', 0, NULL),
    (5, 2, '2000', 0, NULL),
    (5, 3, '1800', 0, NULL),
    (5, 4, 'Hace mas de 230 millones de años', 1, NULL),
    (6, 1, 'India', 0, NULL),
    (6, 2, 'China', 0, NULL),
    (6, 3, 'Sudafrica', 0, NULL),
    (6, 4, 'Papua Nueva Guinea', 1, NULL),
    (7, 1, 'Oxigeno', 1, NULL),
    (7, 2, 'Dioxido de carbono', 0, NULL),
    (7, 3, 'Nitrogeno', 0, NULL),
    (7, 4, 'Hidrogeno', 0, NULL),
    (8, 1, 'Fotosintesis', 1, NULL),
    (8, 2, 'Respiracion', 0, NULL),
    (8, 3, 'Fermentacion', 0, NULL),
    (8, 4, 'Digestion', 0, NULL),
    (9, 1, 'Einstein', 1, NULL),
    (9, 2, 'Newton', 0, NULL),
    (9, 3, 'Galileo', 0, NULL),
    (9, 4, 'Curie', 0, NULL),
    (10, 1, 'Quimica', 1, NULL),
    (10, 2, 'Mecanica', 0, NULL),
    (10, 3, 'Electromagnetica', 0, NULL),
    (10, 4, 'Potencial', 0, NULL),
    (11, 1, 'Combatir infecciones y enfermedades', 0, NULL),
    (11, 2, 'Transportar oxígeno desde los pulmones al cuerpo', 1, NULL),
    (11, 3, 'Coagular la sangre para prevenir hemorragias.', 0, NULL),
    (11, 4, 'Producir hormonas para regular el metabolismo.', 0, NULL),
    (12, 1, 'Oro', 1, NULL),
    (12, 2, 'Plata', 0, NULL),
    (12, 3, 'Plomo', 0, NULL),
    (12, 4, 'Mercurio', 0, NULL),
    (13, 1, 'Materia que no emite luz', 1, NULL),
    (13, 2, 'Materia que emite luz', 0, NULL),
    (13, 3, 'Materia que absorbe luz', 0, NULL),
    (13, 4, 'Materia que refleja luz', 0, NULL),
    (14, 1, '1914', 0, NULL),
    (14, 2, '1939', 1, NULL),
    (14, 3, '1920', 0, NULL),
    (14, 4, '1941', 0, NULL),
    (15, 1, 'Imperio Romano', 1, NULL),
    (15, 2, 'Imperio Otomano', 0, NULL),
    (15, 3, 'Imperio Bizantino', 0, NULL),
    (15, 4, 'Imperio Britanico', 0, NULL),
    (16, 1, 'Nicolas II', 1, NULL),
    (16, 2, 'Alejandro III', 0, NULL),
    (16, 3, 'Pedro el Grande', 0, NULL),
    (16, 4, 'Ivan el Terrible', 0, NULL),
    (17, 1, 'Dinastia Ming', 0, NULL),
    (17, 2, 'Dinastia Qing', 1, NULL),
    (17, 3, 'Dinastia Han', 0, NULL),
    (17, 4, 'Dinastia Tang', 0, NULL),
    (18, 1, 'Desintegracion del Imperio Romano', 0, NULL),
    (18, 2, 'Invasiones Barbaras', 0, NULL),
    (18, 3, 'Caida de Constantinopla', 1, NULL),
    (18, 4, 'Guerra de los Cien Anos', 0, NULL),
    (19, 1, 'Desarrollo de la bomba atomica', 1, NULL),
    (19, 2, 'Desarrollo de armas quimicas', 0, NULL),
    (19, 3, 'Desarrollo de armas biologicas', 0, NULL),
    (19, 4, 'Desarrollo de armas convencionales', 0, NULL),
    (20, 1, 'Jai Hind', 0, NULL),
    (20, 2, 'Tadeo', 0, NULL),
    (20, 3, 'Jorge', 0, NULL),
    (20, 4, 'Vive le Tour', 1, NULL),
    (21, 1, 'Beisbol', 0, NULL),
    (21, 2, 'Futbol', 0, NULL),
    (21, 3, 'Baloncesto', 1, NULL),
    (21, 4, 'Hockey', 0, NULL),
    (22, 1, 'Serie A', 0, NULL),
    (22, 2, 'Premier League', 0, NULL),
    (22, 3, 'Ligue 1', 0, NULL),
    (22, 4, 'Formula 1', 1, NULL),
    (23, 1, 'Natacion', 0, NULL),
    (23, 2, 'Atletismo', 1, NULL),
    (23, 3, 'Ciclismo', 0, NULL),
    (23, 4, 'Esqui', 0, NULL),
    (24, 1, '10 km', 0, NULL),
    (24, 2, '21 km', 0, NULL),
    (24, 3, '42.195 km', 1, NULL),
    (24, 4, '50 km', 0, NULL),
    (25, 1, '2015', 0, NULL),
    (25, 2, '2018', 0, NULL),
    (25, 3, '2020', 0, NULL),
    (25, 4, '2016', 1, NULL),
    (26, 1, 'Miguel de Cervantes', 1, NULL),
    (26, 2, 'William Shakespeare', 0, NULL),
    (26, 3, 'Gabriel Garcia Marquez', 0, NULL),
    (26, 4, 'Jorge Luis Borges', 0, NULL),
    (27, 1, 'El Cascanueces', 1, NULL),
    (27, 2, 'El Lago de los Cisnes', 0, NULL),
    (27, 3, 'Don Quijote', 0, NULL),
    (27, 4, 'Romeo y Julieta', 0, NULL),
    (28, 1, 'J.K. Rowling', 1, NULL),
    (28, 2, 'J.R.R. Tolkien', 0, NULL),
    (28, 3, 'C.S. Lewis', 0, NULL),
    (28, 4, 'George R.R. Martin', 0, NULL),
    (29, 1, 'Miguel Angel', 1, NULL),
    (29, 2, 'Leonardo da Vinci', 0, NULL),
    (29, 3, 'Donatello', 0, NULL),
    (29, 4, 'Rafael', 0, NULL),
    (30, 1, 'Surrealismo', 1, NULL),
    (30, 2, 'Barroco', 0, NULL),
    (30, 3, 'Renacimiento', 0, NULL),
    (30, 4, 'Impresionismo', 0, NULL),
    (31, 1, 'Realismo', 1, NULL),
    (31, 2, 'Naturalismo', 0, NULL),
    (31, 3, 'Romanticismo', 0, NULL),
    (31, 4, 'Simbolismo', 0, NULL),
    (32, 1, 'Friends', 1, NULL),
    (32, 2, 'The Office', 0, NULL),
    (32, 3, 'Seinfeld', 0, NULL),
    (32, 4, 'How I Met Your Mother', 0, NULL),
    (33, 1, 'Elsa', 1, NULL),
    (33, 2, 'Anna', 0, NULL),
    (33, 3, 'Ariel', 0, NULL),
    (33, 4, 'Cenicienta', 0, NULL),
    (34, 1, 'Supervivientes', 0, NULL),
    (34, 2, 'Gran Hermano', 0, NULL),
    (34, 3, 'The Amazing Race', 1, NULL),
    (34, 4, 'MasterChef', 0, NULL),
    (35, 1, 'Stanley Kubrick', 1, NULL),
    (35, 2, 'Steven Spielberg', 0, NULL),
    (35, 3, 'Alfred Hitchcock', 0, NULL),
    (35, 4, 'Martin Scorsese', 0, NULL),
    (36, 1, 'Orson Scott Card', 1, NULL),
    (36, 2, 'Isaac Asimov', 0, NULL),
    (36, 3, 'Arthur C. Clarke', 0, NULL),
    (36, 4, 'Philip K. Dick', 0, NULL),
    (37, 1, 'Christopher Nolan', 1, NULL),
    (37, 2, 'Ridley Scott', 0, NULL),
    (37, 3, 'Quentin Tarantino', 0, NULL),
    (37, 4, 'David Fincher', 0, NULL),
    (38, 1, 'David Copperfield', 1, NULL),
    (38, 2, 'Houdini', 0, NULL),
    (38, 3, 'Criss Angel', 0, NULL),
    (38, 4, 'Derren Brown', 0, NULL),
    (39, 1, 'Mercado de pulgas', 1, NULL),
    (39, 2, 'Mercado de agricultores', 0, NULL),
    (39, 3, 'Mercado de productos frescos', 0, NULL),
    (39, 4, 'Mercado de artesanias', 0, NULL),
    (40, 1, 'Los 7 hábitos de la gente altamente efectiva', 0, NULL),
    (40, 2, 'El obstáculo es el camino', 1, NULL),
    (40, 3, 'Piense y hágase rico', 0, NULL),
    (40, 4, 'Cómo ganar amigos e influir sobre las personas', 0, NULL),
    (41, 1, 'MasterChef Junior', 0, NULL),
    (41, 2, 'Top Chef', 1, NULL),
    (41, 3, 'El gran pastelero', 0, NULL),
    (41, 4, 'Iron Chef', 0, NULL),
    (42, 1, 'The Voice', 0, NULL),
    (42, 2, 'Americas Got Talent', 1, NULL),
    (42, 3, 'Dancing with the Stars', 0, NULL),
    (42, 4, 'La Voz', 0, NULL),
    (43, 4, 'American Ninja Warrior', 1, NULL),
    (43, 4, 'Survivor', 0, NULL),
    (43, 4, 'The Amazing Race', 0, NULL),
    (43, 4, 'Fear Factor', 0, NULL);