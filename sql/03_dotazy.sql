-- Ukázkové dotazy nad databází DataCheck (vznikly při učení SQL)

USE DataCheck;
GO

-- Počet subjektů podle typu
SELECT Typ, COUNT(*) AS Pocet
FROM Subjekty
GROUP BY Typ;

-- IČO se špatnou délkou
SELECT Id, Nazev, Ico
FROM Subjekty
WHERE Ico IS NOT NULL
  AND LEN(Ico) <> 8;

-- IČO se špatnou délkou nebo s nečíselným znakem (totéž, co kontroluje pravidlo ICO_DELKA)
SELECT Id, Nazev, Ico
FROM Subjekty
WHERE Ico IS NOT NULL
  AND (LEN(Ico) <> 8 OR Ico LIKE '%[^0-9]%');

-- Duplicitní IČO (zatím aplikace nekontroluje)
SELECT Ico, COUNT(*) AS Pocet, STRING_AGG(Nazev, ', ') AS Subjekty
FROM Subjekty
WHERE Ico IS NOT NULL
GROUP BY Ico
HAVING COUNT(*) > 1;

-- Nálezy z poslední kontroly i s názvem subjektu
SELECT n.Id, s.Nazev, s.Typ, n.KodPravidla, n.Zavaznost, n.Popis, n.Zjisteno
FROM Nalezy n
INNER JOIN Subjekty s ON n.SubjektId = s.Id
ORDER BY n.Zavaznost, s.Nazev;
