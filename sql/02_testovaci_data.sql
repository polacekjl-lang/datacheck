-- Testovací data pro DataCheck
-- Spouštět po 01_vytvoreni_tabulek.sql. Lze spustit opakovaně: vždy začne od čistých tabulek.
-- Data obsahují záměrně vadné záznamy (krátké IČO, písmena v IČO, prázdný název, špatné PSČ),
-- aby měla kontrola co najít. Nálezy se sem nevkládají, vytvoří je aplikace (DataCheck.Cli).

USE DataCheck;
GO

DELETE FROM Nalezy;
DELETE FROM Subjekty;
DBCC CHECKIDENT ('Nalezy', RESEED, 0);
DBCC CHECKIDENT ('Subjekty', RESEED, 0);
GO

-- Prefix N před textem = Unicode literál. Bez něj se česká diakritika (š, č, ř) změní na ? nebo se ztratí.
INSERT INTO Subjekty (Typ, Nazev, Ico, Mesto, Psc, Email, CisloUctu, JePlatceDph, KodPojistovny)
VALUES
(N'Dodavatel', N'Dentimed s.r.o.',        N'00023001', N'Litomyšl',     N'57001',  N'info@dentimed.cz',   N'123456789/0800', 1, NULL),
(N'Dodavatel', N'Dental Trade a.s.',      N'25478931', N'Praha',        N'11000',  N'obchod@dental.cz',   N'987654321/0300', 1, NULL),
(N'Dodavatel', N'Stomatex s.r.o.',        N'1234',     N'Brno',         N'60200',  NULL,                 N'111222333/2010', 0, NULL),
(N'Dodavatel', N'MediPlus s.r.o.',        N'ABCD1234', N'Ostrava',      N'70200',  N'info@mediplus.cz',   NULL,             1, NULL),
(N'Dodavatel', N'Zubní technika s.r.o.',  N'45632178', N'Plzeň',        N'301 00', N'zt@zubni.cz',        N'555666777/0600', 1, NULL),
(N'Dodavatel', N'Implantáty CZ s.r.o.',   N'78945612', N'Olomouc',      N'7790',   NULL,                 N'444555666/0100', 0, NULL),
(N'Dodavatel', N'Ortodoncie Plus s.r.o.', N'32165498', NULL,           NULL,     N'info@ortoplus',      N'222333444/5500', 1, NULL),
(N'Dodavatel', N'   ',                    N'65498732', N'Hradec Králové',N'50002', NULL,                 N'777888999/0800', 1, NULL),
(N'Zakaznik',  N'Ordinace MUDr. Novák',   NULL,       N'Tábor',        N'39001',  N'novak@ordinace.cz',  NULL,             0, N'111'),
(N'Zakaznik',  N'Zubní centrum Náchod',   N'11223344', N'Náchod',       N'54701',  N'info@zcnachod.cz',   NULL,             0, N'201'),
(N'Zakaznik',  N'MUDr. Svobodová',        NULL,       N'Litomyšl',     N'570 01', NULL,                 NULL,             0, N'111'),
(N'Zakaznik',  N'Dentální studio Praha',  N'99887766', N'Praha',        N'1100',   N'studio@dental.cz',   NULL,             0, N'207'),
(N'Zakaznik',  N'Ordinace Pardubice',     NULL,       N'Pardubice',    N'53002',  N'ordinace.pardubice', NULL,             0, N'111'),
(N'Zakaznik',  N'MUDr. Černý',            N'55667788', N'Chrudim',      N'53701',  NULL,                 NULL,             0, N'213'),
(N'Zakaznik',  N'',                       NULL,       N'Svitavy',      N'56802',  NULL,                 NULL,             0, N'111'),
(N'Zakaznik',  N'Zubní pohotovost s.r.o.',N'12',       N'Vysoké Mýto',  N'56601',  N'pohotovost@zubni.cz',NULL,             0, N'205'),
(N'Zakaznik',  N'MUDr. Dvořák',           NULL,       N'Polička',      N'57201',  N'dvorak@email.cz',    NULL,             0, N'111'),
(N'Zakaznik',  N'Dentimed Tábor',         N'00023001', N'Tábor',        N'39002',  NULL,                 NULL,             0, N'201'),
(N'Zakaznik',  N'Ordinace Moravská',      N'44556677', N'Zlín',         N'ABCDE',  NULL,                 NULL,             0, N'111'),
(N'Zakaznik',  N'MUDr. Horák',            NULL,       N'Jihlava',      N'58601',  N'horak@ordinace.cz',  NULL,             0, N'207');
GO

SELECT * FROM Subjekty;
