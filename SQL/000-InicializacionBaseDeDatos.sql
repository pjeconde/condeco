SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.Usuario(
	IdUsuario varchar(50) NOT NULL,
	Nombre varchar(50) NOT NULL,
	Telefono varchar(50) NOT NULL,
	Email varchar(128) NOT NULL,
	Password varchar(50) NOT NULL,
	Pregunta varchar(256) NOT NULL,
	Respuesta varchar(256) NOT NULL,
	CantidadEnviosMail int NOT NULL,
	FechaUltimoReenvioMail datetime NOT NULL,
	EmailSMS varchar(50) NOT NULL,
	IdMedio varchar(15) NOT NULL,
	IdWF int NOT NULL,
	Estado varchar(15) NOT NULL,
	UltActualiz timestamp NOT NULL,
	Pais varchar(50) not null default '',
	Provincia varchar(50) not null default '',
	Localidad varchar(50) not null default '',
	Direccion varchar(60) not null default '',
	CodPost varchar(10) not null default '',
	Facebook varchar(100) not null default '',
	DatoAdicional1 varchar(250) not null default '',
	DatoAdicional2 varchar(250) not null default '',
 CONSTRAINT PK_Usuario PRIMARY KEY CLUSTERED 
(
	IdUsuario ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.Medio(
	IdMedio varchar(15) NOT NULL,
	DescrMedio varchar(50) NOT NULL,
 CONSTRAINT PK_Medio PRIMARY KEY CLUSTERED 
(
	IdMedio ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert Medio values ('', '')
insert Medio values ('Internet', 'Internet')
insert Medio values ('Recomendacion', 'Recomendacion')
insert Medio values ('CompraLC', 'Compra en Local comercial')
insert Medio values ('CompraFE', 'Compra en Feria')
insert Medio values ('Mail', 'Mail')
insert Medio values ('Mercado Libre', 'Mercado Libre')
insert Medio values ('Otro medio', 'Otro medio')



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.Producto(
	IdProducto int NOT NULL,
	Nombre varchar(50) NOT NULL,
	Descripcion varchar(500) NOT NULL,
	IdMoneda varchar(10) NOT NULL,   
	PrecioBase numeric(18, 2) NOT NULL,
	ComentarioPrecioBase varchar(250) NOT NULL,
	IdWF int NOT NULL,
	Estado varchar(15) NOT NULL,
	IdTipoProducto int NOT NULL,
	Ranking int NOT NULL,
	UltActualiz timestamp NOT NULL,
	YouTube varchar(100) NOT NULL,
 CONSTRAINT PK_Producto PRIMARY KEY CLUSTERED 
(
	IdProducto ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

alter table Producto add TipoDestacado varchar(2) not null default('')


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.TipoProducto(
	IdTipoProducto int NOT NULL,
	DescrTipoProducto varchar(50) NOT NULL,
	IdPariente int NOT NULL,
	Estado varchar(15) NOT NULL,
 CONSTRAINT PK_TipoProducto PRIMARY KEY CLUSTERED 
(
	IdTipoProducto ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert TipoProducto values (100, 'Marcos', 0, 'Vigente')
insert TipoProducto values (101, 'Marcos de Pinotea', 100, 'Vigente')
insert TipoProducto values (102, 'Marcos de Cedro', 100, 'Vigente')
insert TipoProducto values (103, 'Marcos Vintage', 100, 'Vigente')
insert TipoProducto values (200, 'Espejos', 0, 'Vigente')
insert TipoProducto values (300, 'Carteles', 0, 'Vigente')
insert TipoProducto values (400, 'Mesas', 0, 'Vigente')
insert TipoProducto values (401, 'Mesas Ratonas', 4, 'Vigente')
insert TipoProducto values (500, 'Bancos', 0, 'Vigente')
insert TipoProducto values (501, 'Bancos rusticos', 6, 'Vigente')



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.TipoPermiso(
	IdTipoPermiso varchar(30) NOT NULL,
	DescrTipoPermiso varchar(50) NOT NULL,
 CONSTRAINT PK_TipoPermiso PRIMARY KEY CLUSTERED 
(
	IdTipoPermiso ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert TipoPermiso values ('AdminSITE', 'Administrator Site')
insert TipoPermiso values ('OperProductos', 'Operator de Productos')



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.Permiso(
	IdUsuario varchar(50) NOT NULL,
	IdTipoPermiso varchar(30) NOT NULL,
	FechaFinVigencia datetime NOT NULL,
	IdWF int NOT NULL,
	Estado varchar(15) NOT NULL,
 CONSTRAINT PK_Permiso PRIMARY KEY CLUSTERED 
(
	IdUsuario ASC,
	IdTipoPermiso ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE dbo.Permiso  WITH CHECK ADD  CONSTRAINT FK_Permiso_TipoPermiso FOREIGN KEY(IdTipoPermiso)
REFERENCES dbo.TipoPermiso (IdTipoPermiso)
GO
ALTER TABLE dbo.Permiso CHECK CONSTRAINT FK_Permiso_TipoPermiso
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.Configuracion(
	IdUsuario varchar(50) NOT NULL,
	IdTipoPermiso varchar(30) NOT NULL,
	IdItemConfig varchar(50) NOT NULL,
	Valor varchar(256) NOT NULL,
 CONSTRAINT PK_Configuracion PRIMARY KEY CLUSTERED 
(
	IdUsuario ASC,
	IdTipoPermiso ASC,
	IdItemConfig ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert Configuracion values ('', '', 'UltimoIdWF', '0')
insert Configuracion values ('', 'OperProducto', 'UltimoIdProducto', '0')



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.Log(
	IdLog int IDENTITY(1,1) NOT NULL,
	IdWF int NOT NULL,
	Fecha datetime NOT NULL,
	IdUsuario varchar(50) NOT NULL,
	Entidad varchar(30) NOT NULL,
	Evento varchar(30) NOT NULL,
	Estado varchar(15) NOT NULL,
	Comentario varchar(256) NOT NULL,
 CONSTRAINT PK_Log PRIMARY KEY CLUSTERED 
(
	IdLog ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.LogDetalle(
	IdLogDetalle int IDENTITY(1,1) NOT NULL,
	IdLog int NOT NULL,
	TipoDetalle varchar(50) NOT NULL,
	Detalle text NOT NULL,
 CONSTRAINT PK_LogDetalle PRIMARY KEY CLUSTERED 
(
	IdLogDetalle ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE dbo.LogDetalle  WITH CHECK ADD  CONSTRAINT FK_LogDetalle_Log FOREIGN KEY(IdLog)
REFERENCES dbo.Log (IdLog)
GO
ALTER TABLE dbo.LogDetalle CHECK CONSTRAINT FK_LogDetalle_Log
GO



declare @idWF varchar(256)
update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
insert Usuario (IdUsuario, Nombre, Telefono, Email, Password, Pregunta, Respuesta, CantidadEnviosMail, FechaUltimoReenvioMail, EmailSMS, IdMedio, IdWF, Estado) values ('administrador', 'Usuario administardor del sitio', '', 'pjeconde@yahoo.com.ar', '123456', 'Cual es mi equipo de futbol', 'boca', 0, getdate(), 'pjeconde@yahoo.com.ar', '', @IdWF, 'Vigente')
insert Log values (@IdWF, getdate(), 'administrador', 'Usuario', 'Nuevo', 'Vigente', 'Nuevo Script')
update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
insert Permiso values ('administrador', 'AdminSITE', '20621231', @idWF, 'Vigente')
insert Log values (@IdWF, getdate(), 'administrador', 'Permiso', 'Nuevo', 'Vigente', 'Nuevo Script')


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.Comentario (
	IdComentario int NOT NULL,
	IdReplica int NOT NULL, 
	NombreEntidad varchar(50) NOT NULL,
	IdEntidad int NOT NULL,
	NombreUsuario varchar(50) NOT NULL,
	IdUsuario varchar(50) NOT NULL,
	Contenido ntext NOT NULL,
	Fecha datetime NOT NULL,
	Url nvarchar(200) NOT NULL,
	Estado varchar(15) NOT NULL, 
	ManoOk int NOT NULL, 
	ManoNoOk int NOT NULL, 
	AbusoContenido int NOT NULL, 
CONSTRAINT PK_Comentario PRIMARY KEY CLUSTERED 
(
	NombreEntidad ASC, 
	IdEntidad ASC,
	IdComentario ASC, 
	IdReplica ASC 
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.ComentarioEstadistica (
	NombreEntidad varchar(50) NOT NULL,
	IdEntidad int NOT NULL,
	IdComentario int NOT NULL,
	IdReplica int NOT NULL, 
	IdUsuario varchar(50) NOT NULL,
	Objeto varchar(30) NOT NULL,
CONSTRAINT PK_ComentarioEstadistica PRIMARY KEY CLUSTERED 
(
	NombreEntidad ASC,
	IdEntidad ASC,
	IdComentario ASC, 
	IdReplica ASC,
	IdUsuario ASC, 
	Objeto ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE dbo.Publicidad(
	IdCatalogo varchar(50) NOT NULL,
	IdPublicidad int NOT NULL,
	IdUsuario varchar(50) NOT NULL,
	ImageUrl varchar(250) NOT NULL,
	NavigateUrl varchar(250) NOT NULL,
	AlternateText varchar(250) NOT NULL,
	Impression varchar(250) NOT NULL,
	Keyword varchar(250) NOT NULL,
	Estado varchar(15) NOT NULL,
CONSTRAINT PK_Publicidad PRIMARY KEY CLUSTERED 
(
	IdCatalogo ASC,
	IdPublicidad
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

insert Configuracion values ('', '', 'UltimoIdPublicidad', '0')
GO




declare @idWF varchar(256)
update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
insert Permiso values ('administrador', 'OperProductos', '20621231', @idWF, 'Vigente')
insert Log values (@IdWF, getdate(), 'administrador', 'Permiso', 'Nuevo', 'Vigente', 'Nuevo Script')

/*----- Modif. 25/9/2015 -----*/
alter table Producto alter column Descripcion varchar(2000) not null
go

