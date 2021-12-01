CREATE PROCEDURE [dbo].[eventos_sp]
	@id_usuarios int = null,
	@login varchar(50) = null,
	@data_evento datetime = null
AS
SELECT u.Nome, evento = e.Nome, e.DataHora, tipo = CASE e.Tipo WHEN 'E' THEN 'Exclusivo' ELSE 'Compartilhado' END
FROM Usuarios AS u
LEFT JOIN EventosUsuarios AS eu ON eu.UsuarioId = u.Id
LEFT JOIN Eventos AS e on e.Id = eu.EventoId
WHERE 
u.Id = COALESCE(@id_usuarios, u.Id)
AND u.Login = COALESCE(@login, u.Login)
AND e.DataHora = COALESCE(@data_evento, e.DataHora)