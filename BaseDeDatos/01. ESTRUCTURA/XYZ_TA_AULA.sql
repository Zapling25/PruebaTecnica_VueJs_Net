USE EscuelaXYZ;
GO
DROP TABLE IF EXISTS XYZ_TA_AULA;
CREATE TABLE XYZ_TA_AULA
(
    IN_ID_AULA INT IDENTITY(1,1) PRIMARY KEY,
    VC_ETAPA VARCHAR(50),
	CH_GRADO CHAR(1),
	CH_SECCION CHAR(1),
	CH_ESTADO CHAR(1)
);