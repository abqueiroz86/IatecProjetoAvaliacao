CREATE VIEW [dbo].[eventos_vw]
	AS 
SELECT u.Nome, evento = e.Nome, e.DataHora, tipo = CASE e.Tipo WHEN 'E' THEN 'Exclusivo' ELSE 'Compartilhado' END
FROM Usuarios AS u
LEFT JOIN EventosUsuarios AS eu ON eu.UsuarioId = u.Id
LEFT JOIN Eventos AS e on e.Id = eu.EventoId