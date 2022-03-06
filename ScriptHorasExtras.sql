
-- Db HorasExtras

create table Departamento (
IdDepartamento int identity(1,1) primary key,
NombreDepartamento nvarchar(50) not null unique,
Enable bit not null
);

create table Empleado (
IdEmpleado int identity(1,1) primary key,
Nombre nvarchar(50) not null,
Apellido nvarchar(50) not null,
CodigoEmpleado as (RIGHT('0000000'+CAST(IdEmpleado as nvarchar(8)),8)) persisted,
Puesto nvarchar(50) not null,
IdDepartamento int not null foreign key references Departamento(IdDepartamento),
Enable bit not null
);

create table Usuario(
IdUsuario int identity,
[User] nvarchar(25) primary key,
IdEmpleado nvarchar(8) not null unique,
Nombre nvarchar(30) not null,
Apellido nvarchar(30) not null,
Correo nvarchar(50) not null,
IdOficina nvarchar(3) not null,
FechaCreacion datetime not null default(getdate()),
Enable bit not null
);

create table PerfilHorasExtras(
IdPerfil int identity primary key,
NombrePerfil nvarchar(30),
Enable bit not null
);

create table UsuarioPerfilHorasExtras(
IdUsuarioPerfil int identity primary key,
[User] nvarchar(25) not null,
IdPerfil int not null foreign key references PerfilHorasExtras(IdPerfil),
Enable bit not null
)

--create table Departamento (
--IdDepartamento int identity,
--CodigoDepartamento nvarchar(5) primary key,
--NombreDepartamento nvarchar(50) not null unique,
--Enable bit not null
--);

--create table UsuarioDepartamento(
--IdUsuarioDepartamento int identity primary key,
--[User] nvarchar(25) not null foreign key references Usuario([User]) ,
--CodigoDepartamento nvarchar(5) not null foreign key references Departamento(CodigoDepartamento),
--Enable bit not null
--);


create table Modulo(
IdModulo int identity primary key,
NombreModulo nvarchar(30) unique,
Icono nvarchar(30),
Ruta nvarchar(30),
Enable bit not null 
);

create table UsuarioModulo(
IdUsuarioModulo int identity primary key,
[User] nvarchar(25)  foreign key references Usuario([User]),
IdModulo int  foreign key references Modulo(IdModulo),
Supervisor bit not null,
Enable  bit not null
);

create table Menu
(
 IdMenu int identity primary key,
 IdModulo int not null,
 NombreMenu nvarchar(25),
 Icono nvarchar(30),
 Ruta nvarchar(30),
 Enable bit not null 
);

create table UsuarioMenu
(
 IdUsuarioMenu int identity primary key,
 [User] nvarchar(25) not null foreign key references Usuario([User]),
 IdMenu int not null foreign key references Menu(IdMenu),
 Enable bit not null 

);


--Db HorasExtras

create table TipoHorasExtras(
IdTipoHora int identity primary key,
TipoHora nvarchar(5) not null unique,
DescripcionHora nvarchar(30) not null unique,
Enable bit not null
);

create table PeriodoDeCorte(
IdPeriodo int identity primary key,
CreadoPor nvarchar(25) not null,
PeriodoDescripcion nvarchar(100) not null,
FechaCreacion datetime not null default (getdate()),
FechaInicial date not null,
FechaFinal date not null,
FechaTope date not null,
PeriodoOriginal nvarchar(30),
ModificadoPor nvarchar(25),
FechaModificacion datetime,
Cerrado bit not null,
CerradoPor nvarchar(25),
FechaCierre datetime,
Enable bit not null
);

create table RegistroHorasExtras(
IdHorasExtras int identity primary key,
CodigoHorasExtras as (RIGHT('0000000'+CAST(IdHorasExtras as nvarchar(8)),8)) persisted,
CreadoPor nvarchar(25) not null,
IdEmpleado int not null foreign key references Empleado(IdEmpleado),
CodigoEmpleado as (RIGHT('0000000'+CAST(IdEmpleado as nvarchar(8)),8)) persisted,
IdTipoHora int not null foreign key references TipoHorasExtras(IdTipoHora),
CodigoTipoHora as (RIGHT('0000000'+CAST(IdTipoHora as nvarchar(8)),8)) persisted,
CantidadHoras decimal(5,2) not null,
CantidadHorasAprobadas  decimal(5,2) not null default(0),
Justificacion nvarchar(100) not null,
IdPeriodo int not null foreign key references PeriodoDeCorte(IdPeriodo),
CodigoPeriodo as (RIGHT('0000000'+CAST(IdPeriodo as nvarchar(8)),8)) persisted,
IdPeriodoOriginar int not null,
FechaCreacion datetime not null default (getdate()),
FechaHorasExtras date not null,
FechaModificacion datetime,
Aprobado  bit not null,
ModificadoPor nvarchar(25),
AprobadoPor nvarchar(25),
FechaAprobacion datetime,
Enviada bit not null,
Enable bit not null 
);





