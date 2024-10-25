INSERT INTO Store (stor_id, stor_name) VALUES (1, 'Nova Loja');

UPDATE Titles SET type = 'culinária' WHERE title_id = 'MC3021';

DELETE FROM Sales WHERE stor_id = '7066';

SELECT * FROM Store WHERE stor_id NOT IN (SELECT DISTINCT stor_id FROM Sales);

SELECT * FROM Titles WHERE title_id NOT IN (SELECT DISTINCT title_id FROM Sales);

SELECT t.title_id, t.title, SUM(s.qty) AS total_vendidos 
FROM Titles t
LEFT JOIN Sales s ON t.title_id = s.title_id
GROUP BY t.title_id, t.title;

SELECT title, COUNT(*) AS ocorrencias
FROM Titles
GROUP BY title
HAVING COUNT(*) > 2;