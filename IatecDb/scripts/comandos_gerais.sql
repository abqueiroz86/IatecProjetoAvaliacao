-- Usuarios
/*
INSERT INTO Usuarios (Nome, Login, Senha) VALUES ('Antonio', 'abqueiroz86', CONVERT(VARCHAR(200), HashBytes('MD5', '123456'), 2))

UPDATE Usuarios SET Nome = 'Antonio Bianco' WHERE Id = 1

DELETE FROM Usuarios WHERE Id = 4

SELECT * FROM Usuarios
*/

-- Eventos
/*
INSERT INTO Eventos	(Nome, Descricao, DataHora, Local, Tipo) VALUES ('Avaliação IATec', 'Avaliação entrevista de emprego', '2021-12-01 08:00:00', 'Zoom', 'C')

SELECT * FROM eventos_tbl
*/

-- EventosUsuarios
/*
INSERT INTO EventosUsuarios (UsuarioId, EventoId) VALUES (1,5)
*/

-- Procedure que retorna os eventos dos usuarios
EXEC eventos_sp 1

-- View que retorna os eventos dos usuarios
SELECT * FROM eventos_vw