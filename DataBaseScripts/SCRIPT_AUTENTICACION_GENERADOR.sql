/*
Proyecto: Todos los proyectos (Generador de CÛdigo)
Autor/Desarrollador: Jorge Medina	
Fecha: 09/12/2020
Descripcion: Crea la Tabla AutenticaciÛn y los SP Login y Logout.
Prerequisitos: Crear la BD del Sistema y apuntar a ella al ejecutar el presente script.
Postrequisitos: Ninguno.
*/

CREATE TABLE [dbo].[Autenticacion](
	[IDAutenticacion] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NULL,
	[Password] [varchar](max) NULL,
	[SesionIniciada] [bit] NULL,
	[FechaUltimaSesionIniciada] [datetime] NULL,
	[FechaUltimaSesionCerrada] [datetime] NULL,
	[Estado] [bit] NOT NULL
)

GO

Create procedure [dbo].[Proc_Autenticacion_Login]
	@Usuario varchar(50),
	@Password varchar(MAX)	
as

IF NOT EXISTS(SELECT * FROM AUTENTICACION Where AUTENTICACION.Usuario = @Usuario And AUTENTICACION.Estado = 1)
BEGIN
	RAISERROR ('Usuario no registrado!',16,1)
	Return 0
END
	DECLARE @HASHED_PASSWORD varchar(MAX)
	SET @HASHED_PASSWORD = (SELECT HASHBYTES('SHA2_256',@Password))
	select @HASHED_PASSWORD 
	
	IF NOT EXISTS(SELECT * FROM AUTENTICACION Where AUTENTICACION.Usuario = @Usuario And AUTENTICACION.Password = @HASHED_PASSWORD And AUTENTICACION.Estado = 1)
	BEGIN
		RAISERROR ('Usuario no registrado!',16,1)
		Return 0
	END

	Select *
	from dbo.AUTENTICACION
	where
		AUTENTICACION.Usuario = @Usuario
		AND
		AUTENTICACION.Password = @HASHED_PASSWORD

	Update AUTENTICACION 
	set AUTENTICACION.SesionIniciada = 1,
		AUTENTICACION.FechaUltimaSesionIniciada = SYSDATETIME() 

GO 

Create procedure [dbo].[Proc_Autenticacion_Logout]
	@Usuario varchar(50)
as

IF NOT EXISTS(SELECT * FROM AUTENTICACION Where AUTENTICACION.Usuario = @Usuario And AUTENTICACION.Estado = 1)
BEGIN
	RAISERROR ('Usuario no registrado!',16,1)
	Return 0
END

IF NOT EXISTS(SELECT * FROM AUTENTICACION Where AUTENTICACION.Usuario = @Usuario And AUTENTICACION.Estado = 1 And AUTENTICACION.SesionIniciada = 0)
BEGIN
	RAISERROR ('La sesiÛn se encuentra cerrada!',16,1)
	Return 0
END

BEGIN
	Update AUTENTICACION 
	set AUTENTICACION.SesionIniciada = 0,
		AUTENTICACION.FechaUltimaSesionCerrada = SYSDATETIME()
END


-- INSERTS

Insert into Autenticacion 
Values ('admin',
		'&æ]®Æ˙UÍX4’ˆ˙¥	#o˙¶yèäÉZú',
		0,
		SYSDATETIME(),
		SYSDATETIME(),
		1)