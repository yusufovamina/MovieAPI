CREATE DATABASE movieDB;
go
USE movieDB;
go
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);
go
CREATE TABLE Movies (
    MovieId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    ReleaseYear INT NULL,
    Director NVARCHAR(100) NULL,
    Description NVARCHAR(MAX) NULL,
    Rating DECIMAL(3,2) NULL,
    CategoryId INT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

INSERT INTO Categories (CategoryName) VALUES ('Action');
INSERT INTO Categories (CategoryName) VALUES ('Comedy');
INSERT INTO Categories (CategoryName) VALUES ('Drama');
INSERT INTO Categories (CategoryName) VALUES ('Horror');
INSERT INTO Categories (CategoryName) VALUES ('Sci-Fi');


INSERT INTO Movies (Title, ReleaseYear, Director, Description, Rating, CategoryId) 
VALUES 
('Die Hard', 1988, 'John McTiernan', 'NYPD officer tries to save his wife and others taken hostage by German terrorists.', 8.2, 1),
('The Mask', 1994, 'Chuck Russell', 'A bank clerk discovers a magical mask that transforms him into a mischievous superhero.', 6.9, 2),
('Forrest Gump', 1994, 'Robert Zemeckis', 'The story of a man with a low IQ who achieves great things in his life.', 8.8, 3),
('The Shining', 1980, 'Stanley Kubrick', 'A family heads to an isolated hotel where an evil presence drives the father into violence.', 8.4, 4),
('Blade Runner', 1982, 'Ridley Scott', 'A blade runner must pursue and terminate four replicants who stole a ship in space.', 8.1, 5);

