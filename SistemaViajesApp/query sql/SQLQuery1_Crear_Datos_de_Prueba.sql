USE SistemaViajes;
GO

-- 1. Usuarios (Admin y Gerente)
INSERT INTO dbo.Usuarios (Usuario, Contrasena, Rol, Activo)
VALUES 
('admin', 'admin123', 'Admin', 1),
('gerente1', 'gerente123', 'Gerente', 1);

-- 2. Empleados
INSERT INTO dbo.Empleados (Nombre, Activo)
VALUES 
('Juan Perez', 1),
('Ana Gomez', 1),
('Luis Martinez', 1);

-- 3. Sucursales
INSERT INTO dbo.Sucursales (CodigoSucursal, Nombre, Activo)
VALUES
('S001', 'Sucursal Centro', 1),
('S002', 'Sucursal Norte', 1);

-- 4. EmpleadoSucursal (asignaciones de empleados a sucursales)
-- UsuarioRegistro = 1 (Admin)
INSERT INTO dbo.EmpleadoSucursal (IdEmpleado, IdSucursal, DistanciaKm, UsuarioRegistro)
VALUES
(1, 1, 10.5, 1),
(2, 1, 8.0, 1),
(3, 2, 12.0, 1);

-- 5. Transportistas
INSERT INTO dbo.Transportistas (Nombre, TarifaPorKm, Activo)
VALUES
('Transporte Rapido', 5.00, 1),
('Transporte Seguro', 4.50, 1);

-- 6. Viajes
-- FechaViaje = hoy, UsuarioRegistro = 2 (Gerente)
INSERT INTO dbo.Viajes (FechaViaje, IdSucursal, IdTransportista, UsuarioRegistro)
VALUES
(GETDATE(), 1, 1, 2),
(GETDATE(), 2, 2, 2);

-- 7. ViajeEmpleado (detalle de empleados en cada viaje)
-- Distancia y tarifa calculada = Distancia * TarifaPorKm
INSERT INTO dbo.ViajeEmpleado (IdViaje, IdEmpleado, DistanciaKm, TarifaCalculada)
VALUES
(1, 1, 10.5, 10.5*5.00),
(1, 2, 8.0, 8.0*5.00),
(2, 3, 12.0, 12.0*4.50);