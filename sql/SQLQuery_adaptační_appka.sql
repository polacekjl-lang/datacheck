INSERT INTO Subjekty (Typ, Nazev, Ico, Mesto, Psc, Email, CisloUctu, JePlatceDph, KodPojistovny)
VALUES
('Dodavatel', 'Dentimed s.r.o.',        '00023001', 'Litomyšl',     '57001',  'info@dentimed.cz',   '123456789/0800', 1, NULL),
('Dodavatel', 'Dental Trade a.s.',      '25478931', 'Praha',        '11000',  'obchod@dental.cz',   '987654321/0300', 1, NULL),
('Dodavatel', 'Stomatex s.r.o.',        '1234',     'Brno',         '60200',  NULL,                 '111222333/2010', 0, NULL),
('Dodavatel', 'MediPlus s.r.o.',        'ABCD1234', 'Ostrava',      '70200',  'info@mediplus.cz',   NULL,             1, NULL),
('Dodavatel', 'Zubní technika s.r.o.',  '45632178', 'Plzeò',        '301 00', 'zt@zubni.cz',        '555666777/0600', 1, NULL),
('Dodavatel', 'Implantáty CZ s.r.o.',   '78945612', 'Olomouc',      '7790',   NULL,                 '444555666/0100', 0, NULL),
('Dodavatel', 'Ortodoncie Plus s.r.o.', '32165498', NULL,           NULL,     'info@ortoplus',      '222333444/5500', 1, NULL),
('Dodavatel', '   ',                    '65498732', 'Hradec Králové','50002', NULL,                 '777888999/0800', 1, NULL),
('Zakaznik',  'Ordinace MUDr. Novák',   NULL,       'Tábor',        '39001',  'novak@ordinace.cz',  NULL,             0, '111'),
('Zakaznik',  'Zubní centrum Náchod',   '11223344', 'Náchod',       '54701',  'info@zcnachod.cz',   NULL,             0, '201'),
('Zakaznik',  'MUDr. Svobodová',        NULL,       'Litomyšl',     '570 01', NULL,                 NULL,             0, '111'),
('Zakaznik',  'Dentální studio Praha',  '99887766', 'Praha',        '1100',   'studio@dental.cz',   NULL,             0, '207'),
('Zakaznik',  'Ordinace Pardubice',     NULL,       'Pardubice',    '53002',  'ordinace.pardubice', NULL,             0, '111'),
('Zakaznik',  'MUDr. Èerný',            '55667788', 'Chrudim',      '53701',  NULL,                 NULL,             0, '213'),
('Zakaznik',  '',                       NULL,       'Svitavy',      '56802',  NULL,                 NULL,             0, '111'),
('Zakaznik',  'Zubní pohotovost s.r.o.','12',       'Vysoké Mýto',  '56601',  'pohotovost@zubni.cz',NULL,             0, '205'),
('Zakaznik',  'MUDr. Dvoøák',           NULL,       'Polièka',      '57201',  'dvorak@email.cz',    NULL,             0, '111'),
('Zakaznik',  'Dentimed Tábor',         '00023001', 'Tábor',        '39002',  NULL,                 NULL,             0, '201'),
('Zakaznik',  'Ordinace Moravská',      '44556677', 'Zlín',         'ABCDE',  NULL,                 NULL,             0, '111'),
('Zakaznik',  'MUDr. Horák',            NULL,       'Jihlava',      '58601',  'horak@ordinace.cz',  NULL,             0, '207');


SELECT * FROM Subjekty;

SELECT Typ, COUNT(*) AS Pocet
FROM Subjekty
GROUP BY Typ;

SELECT Id, Nazev, Ico
FROM Subjekty
WHERE Ico IS NOT NULL
  AND LEN(Ico) <> 8;

  SELECT Id, Nazev, Ico
FROM Subjekty
WHERE Ico IS NOT NULL
  AND (LEN(Ico) <> 8 OR Ico LIKE '%[^0-9]%');


  INSERT INTO Nalezy (SubjektId, KodPravidla, Zavaznost, Popis)
VALUES
(3,  'ICO_DELKA',     'Chyba',    'IÈO má 4 znaky, oèekáváno 8'),
(4,  'ICO_DELKA',     'Chyba',    'IÈO obsahuje neèíselný znak'),
(16, 'ICO_DELKA',     'Chyba',    'IÈO má 2 znaky, oèekáváno 8'),
(6,  'PSC_FORMAT',    'Varovani', 'PSÈ má 4 èíslice, oèekáváno 5'),
(8,  'NAZEV_PRAZDNY', 'Chyba',    'Název subjektu je prázdný');


SELECT n.Id, s.Nazev, s.Typ, n.KodPravidla, n.Zavaznost, n.Popis
FROM Nalezy n
INNER JOIN Subjekty s ON n.SubjektId = s.Id
ORDER BY n.Zavaznost, s.Nazev;