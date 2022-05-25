USE [prueba]
GO

INSERT INTO [dbo].[usuarios]
           ([Rut]
           ,[Nombre]
           ,[Apellido]
           ,[AnoNacimiento]
           ,[Email]
           ,[Password])
     VALUES
           ('12345678-9',
           'admin',
           'administrador',
			1900,
		   'admin@admin.com',
		   '12345')

INSERT INTO [dbo].[vehiculos]
           ([Patente]
           ,[Ano]
           ,[Modelo]
           ,[Marca]
           ,[Color])
     VALUES
           ('mnl231',
            2020,
           'Baleno',
           'suzuki',
           'rojo')
GO


