-- Vytvoření databáze
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DataCheck')
BEGIN
    CREATE DATABASE DataCheck;
END
GO

USE DataCheck;
GO

-- Tabulka subjektů
IF OBJECT_ID('dbo.Subjekty', 'U') IS NOT NULL
    DROP TABLE dbo.Nalezy;
GO

IF OBJECT_ID('dbo.Subjekty', 'U') IS NOT NULL
    DROP TABLE dbo.Subjekty;
GO

CREATE TABLE dbo.Subjekty
(
    Id              INT             NOT NULL IDENTITY(1,1),
    Typ             NVARCHAR(20)    NOT NULL,
    Nazev           NVARCHAR(200)   NOT NULL,
    Ico             NVARCHAR(20)    NULL,
    Mesto           NVARCHAR(100)   NULL,
    Psc             NVARCHAR(10)    NULL,
    Email           NVARCHAR(200)   NULL,
    CisloUctu       NVARCHAR(50)    NULL,
    JePlatceDph     BIT             NOT NULL DEFAULT 0,
    KodPojistovny   NVARCHAR(10)    NULL,

    CONSTRAINT PK_Subjekty PRIMARY KEY (Id),
    CONSTRAINT CK_Subjekty_Typ CHECK (Typ IN ('Dodavatel', 'Zakaznik'))
);
GO

-- Tabulka nálezů
CREATE TABLE dbo.Nalezy
(
    Id              INT             NOT NULL IDENTITY(1,1),
    SubjektId       INT             NOT NULL,
    KodPravidla     NVARCHAR(50)    NOT NULL,
    Zavaznost       NVARCHAR(20)    NOT NULL,
    Popis           NVARCHAR(500)   NOT NULL,
    Zjisteno        DATETIME2       NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Nalezy PRIMARY KEY (Id),
    CONSTRAINT FK_Nalezy_Subjekty FOREIGN KEY (SubjektId)
        REFERENCES dbo.Subjekty (Id) ON DELETE CASCADE,
    CONSTRAINT CK_Nalezy_Zavaznost CHECK (Zavaznost IN ('Informace', 'Varovani', 'Chyba'))
);
GO

-- Indexy
CREATE INDEX IX_Subjekty_Ico ON dbo.Subjekty (Ico);
CREATE INDEX IX_Nalezy_SubjektId ON dbo.Nalezy (SubjektId);
GO