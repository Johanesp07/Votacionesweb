CREATE DATABASE [Votaciones2];
GO

USE [Votaciones2];
GO

CREATE TABLE [dbo].[Partidos] (
    [IDPartido] INT PRIMARY KEY IDENTITY(1,1),
    [NombrePartido] VARCHAR(50) NOT NULL
);

CREATE TABLE [dbo].[Votantes] (
    [IDVotante] INT PRIMARY KEY IDENTITY(1,1),
    [NombreVotante] VARCHAR(50) NOT NULL,
    [ApellidoVotante] VARCHAR(50) NOT NULL,
    [Correo] VARCHAR(100) UNIQUE NOT NULL,
    [Contrasena] VARCHAR(100) NOT NULL,
    CONSTRAINT UQ_Nombre_Apellido UNIQUE (NombreVotante, ApellidoVotante)
);

CREATE TABLE [dbo].[Candidatos] (
    [IDCandidato] INT PRIMARY KEY IDENTITY(1,1),
    [NombreCandidato] VARCHAR(50) NOT NULL,
    [ApellidoCandidato] VARCHAR(50) NOT NULL,
    [NumeroTelefono] VARCHAR(8) NOT NULL,
    [Plataforma] VARCHAR(100),
    [IDPartido] INT NOT NULL,
    CONSTRAINT FK_Candidatos_Partidos FOREIGN KEY ([IDPartido]) REFERENCES [dbo].[Partidos]([IDPartido])
);

CREATE TABLE [dbo].[Votos] (
    [IDVoto] INT PRIMARY KEY IDENTITY(1,1),
    [IDCandidato] INT NOT NULL,
    [IDVotante] INT NOT NULL,
    [FechaVoto] DATETIME NOT NULL,
    CONSTRAINT FK_Votos_Candidatos FOREIGN KEY ([IDCandidato]) REFERENCES [dbo].[Candidatos]([IDCandidato]),
    CONSTRAINT FK_Votos_Votantes FOREIGN KEY ([IDVotante]) REFERENCES [dbo].[Votantes]([IDVotante])
);

CREATE TABLE [dbo].[Resultados] (
    [IDResultado] INT PRIMARY KEY IDENTITY(1,1),
    [IDCandidato] INT NOT NULL,
    [TotalVotos] INT NOT NULL,
    CONSTRAINT FK_Resultados_Candidatos FOREIGN KEY ([IDCandidato]) REFERENCES [dbo].[Candidatos]([IDCandidato])
);

  INSERT INTO [dbo].[Partidos] (NombrePartido) VALUES ('Frente Amplio');
  INSERT INTO [dbo].[Partidos] (NombrePartido) VALUES ('Partido Liberacion Nacional');

CREATE PROCEDURE sp_Login
    @Correo VARCHAR(100),
    @Contrasena VARCHAR(100)
AS
BEGIN
    SELECT 
        IDVotante,
        NombreVotante,
        ApellidoVotante,
        Correo
    FROM 
        Votantes
    WHERE 
        Correo = @Correo 
        AND Contrasena = @Contrasena;
END;

CREATE PROCEDURE GestionarVotantes
    @IDVotante INT = NULL,
    @NombreVotante VARCHAR(50) = NULL,
    @ApellidoVotante VARCHAR(50) = NULL,
    @Correo VARCHAR(100) = NULL,
    @Contrasena VARCHAR(100) = NULL
AS
BEGIN
    INSERT INTO Votantes (NombreVotante, ApellidoVotante, Correo, Contrasena) 
    VALUES (@NombreVotante, @ApellidoVotante, @Correo, @Contrasena);
END;

select * from Votantes
select * from Candidatos