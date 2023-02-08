create database TravelDB
GO
USE TravelDB
go
Create table Authors
(
id int identity(1,1) primary key,
name varchar(45),
surnames varchar(45)
)
go
create table Editorials
(
id int identity(1,1) primary key,
name varchar(45),
campus varchar(45)
)
go
create table Books
(
ISBN bigint primary key,
editorials_id int,
title varchar(45),
synopsis nvarchar(max),
n_pages varchar(45)
)
GO
ALTER TABLE Books add foreign key (editorials_id)
references editorials(id)
GO
create table Authors_has_Books
(
authors_id int,
books_ISBN bigint,
primary key (authors_id, books_ISBN)
)
GO
ALTER TABLE Authors_has_Books add foreign key (authors_id)
references Authors(id)
GO
ALTER TABLE Authors_has_Books add foreign key (books_ISBN)
references Books(ISBN)
GO
insert into Authors values ('Gabriel', 'García Márquez')
insert into Authors values ('Edgar', 'Allan Poe')
GO
insert into Editorials values ('Debolsillo', 'Barcelona (España)')
insert into Editorials values ('Austral', 'Barcelona (España)')
GO
insert into Books values (9789588886145,1, 'Del Amor y Otros Demonios', 'En el esplendor y decadencia de la América esclavista del siglo XVIII se escribió la historia de Sierva María de Todos los Ángeles, la marquesita recluida en un convento donde enfrentará el prejuicio y la ignorancia de su tiempo, los horrores de la Inquisición y de la enfermedad incurable, y el dolor inagotable del amor sin esperanza. Su leyenda desbordante de magia trascenderá los siglos para cuestionar la naturaleza de la fe, de la pasión y aun la opresión definitiva de la muerte. «La lápida saltó en pedazos al primer golpe de la piocha, y una cabellera viva de un color de cobre intenso se derramó fuera de la cripta. El maestro de obra quiso sacarla completa con la ayuda de sus obreros, y cuanto más tiraban de ella más larga y abundante parecía, hasta que salieron las últimas hebras todavía prendidas a un cráneo de niña.»', '‎208')
insert into Books values (9789588886213,1, 'Cien Años de Soledad', '«Muchos años después, frente al pelotón de fusilamiento, el coronel Aureliano Buendía había de recordar aquella tarde remota en que su padre lo llevó a conocer el hielo. Macondo era entonces una aldea de veinte casas de barro y cañabrava construidas a la orilla de un río de aguas diáfanas que se precipitaban por un lecho de piedras pulidas, blancas y enormes como huevos prehistóricos. El mundo era tan reciente, que muchas cosas carecían de nombre, y para mencionarlas había que señalarlas con el dedo.» Mito por derecho propio, saludada por sus lectores como la obra en español más importante después de la Biblia, Cien años de soledad cuenta la saga de la familia Buendía y su maldición, que castiga el matrimonio entre parientes dándoles hijos con cola de cerdo. Como un río desbordante, a lo largo de un siglo se entretejerán sus destinos por medio de sucesos maravillosos en el fantástico pueblo de Macondo, en una narración que es la cumbre indiscutible del realismo mágico y la literatura del boom. Alegoría universal, es también una visión de Latinoamérica y una parábola sobre la historia humana.', '‎494')
insert into Books values (9788497945134,2, 'Cuentos TD', 'Se reúnen en esta edición especial de Austral catorce de los mejores relatos de Edgar Allan Poe (1809-1849), uno de los escritores norteamericanos más destacados. La modernidad de Poe y su sintonía con las preocupaciones de nuestra época hacen de él un autor tan cercano como indispensable, y en estos relatos se aprecian tanto su asombrosa pericia narrativa como su genuino talento para la construcción de tramas de misterio y terror.', '‎384')
GO
insert into Authors_has_Books values (1, 9789588886145)
insert into Authors_has_Books values (1, 9789588886213)
insert into Authors_has_Books values (2, 9788497945134)