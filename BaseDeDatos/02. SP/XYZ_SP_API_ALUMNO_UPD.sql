USE EscuelaXYZ;
GO
DROP PROCEDURE IF EXISTS XYZ_SP_API_ALUMNO_UPD;
GO
CREATE PROCEDURE XYZ_SP_API_ALUMNO_UPD
	@PARAM_IN_ID_ALUMNO INT,
	@PARAM_VC_NOMBRES VARCHAR(50),
	@PARAM_VC_APELLIDOS VARCHAR(50)
AS
BEGIN
	UPDATE XYZ_TA_ALUMNO SET 
	VC_NOMBRES = @PARAM_VC_NOMBRES,
	VC_APELLIDOS = @PARAM_VC_APELLIDOS
	WHERE IN_ID_ALUMNO = @PARAM_IN_ID_ALUMNO

	SELECT 'Se actualiz� el alumno correctamente' AS VC_MENSAJE
END;