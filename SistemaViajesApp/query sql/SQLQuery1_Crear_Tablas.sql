-- Tabla Usuarios
CREATE TABLE dbo.Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Usuario VARCHAR(50) NOT NULL,
    Contrasena VARCHAR(50) NOT NULL,
    Rol VARCHAR(50) NOT NULL,
    Activo BIT NOT NULL
);

-- Tabla Empleados
CREATE TABLE dbo.Empleados (
    IdEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Activo BIT NOT NULL
);

-- Tabla Sucursales
CREATE TABLE dbo.Sucursales (
    IdSucursal INT IDENTITY(1,1) PRIMARY KEY,
    CodigoSucursal VARCHAR(20) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Activo BIT NOT NULL
);

-- Tabla EmpleadoSucursal
CREATE TABLE dbo.EmpleadoSucursal (
    IdEmpleadoSucursal INT IDENTITY(1,1) PRIMARY KEY,
    IdEmpleado INT NOT NULL,
    IdSucursal INT NOT NULL,
    DistanciaKm DECIMAL(5,2) NOT NULL,
    FechaAsignacion DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioRegistro INT NOT NULL,
    CONSTRAINT FK_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleados(IdEmpleado),
    CONSTRAINT FK_Sucursal FOREIGN KEY (IdSucursal) REFERENCES dbo.Sucursales(IdSucursal),
    CONSTRAINT UQ_EmpleadoSucursal UNIQUE (IdEmpleado, IdSucursal)
);

-- Tabla Transportistas
CREATE TABLE dbo.Transportistas (
    IdTransportista INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    TarifaPorKm DECIMAL(10,2) NOT NULL,
    Activo BIT NOT NULL
);

-- Tabla Viajes
CREATE TABLE dbo.Viajes (
    IdViaje INT IDENTITY(1,1) PRIMARY KEY,
    FechaViaje DATE NOT NULL,
    IdSucursal INT NOT NULL,
    IdTransportista INT NOT NULL,
    UsuarioRegistro INT NOT NULL,
    FechaHoraRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Viaje_Sucursal FOREIGN KEY (IdSucursal) REFERENCES dbo.Sucursales(IdSucursal),
    CONSTRAINT FK_Viaje_Transportista FOREIGN KEY (IdTransportista) REFERENCES dbo.Transportistas(IdTransportista),
    CONSTRAINT FK_Viaje_Usuario FOREIGN KEY (UsuarioRegistro) REFERENCES dbo.Usuarios(IdUsuario)
);

-- Tabla ViajeEmpleado
CREATE TABLE dbo.ViajeEmpleado (
    IdViajeEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    IdViaje INT NOT NULL,
    IdEmpleado INT NOT NULL,
    DistanciaKm DECIMAL(5,2) NOT NULL,
    TarifaCalculada DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_VE_Viaje FOREIGN KEY (IdViaje) REFERENCES dbo.Viajes(IdViaje),
    CONSTRAINT FK_VE_Empleado FOREIGN KEY (IdEmpleado) REFERENCES dbo.Empleados(IdEmpleado),
    CONSTRAINT UQ_ViajeEmpleado UNIQUE (IdViaje, IdEmpleado)
);
GO
