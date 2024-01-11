USE EscuelaXYZ;
GO
DROP PROCEDURE IF EXISTS XYZ_SP_API_ALUMNO_DELETE;
GO
CREATE PROCEDURE XYZ_SP_API_ALUMNO_DELETE
	@PARAM_IN_ID_ALUMNO INT
AS
BEGIN
	UPDATE XYZ_TA_ALUMNO SET 
	IN_ID_AULA = 0
	WHERE IN_ID_ALUMNO = @PARAM_IN_ID_ALUMNO

	SELECT 'Se elimin� el alumno del aula correctamente' AS VC_MENSAJE
END;