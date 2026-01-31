Nota para la terna que evaluara.

Este proyecto fue desarrollado utilizando un enfoque moderno de vibe coding, apoyándome en herramientas de Inteligencia Artificial para acelerar tareas mecánicas y repetitivas (generación inicial de código, borradores, refactorizaciones puntuales y documentación). 
No obstante, el rol de la IA fue el de asistente, no de autor principal del sistema.
Mi aporte directo incluyó:
Análisis del problema y definición del alcance funcional.
Diseño de la arquitectura del proyecto y organización por capas.
Modelado y validación de la base de datos (relaciones, restricciones y consistencia).
Definición de flujos críticos como autenticación, control de roles y permisos.
Resolución de errores reales de compilación y ejecución en WinForms.
Decisiones técnicas orientadas a mantenibilidad, claridad y escalabilidad.
Validación del comportamiento del sistema en escenarios reales de uso.

El objetivo fue construir una solución funcional y comprensible, demostrando criterio técnico, capacidad de análisis y toma de decisiones, utilizando la IA como una herramienta de productividad y no como sustituto del razonamiento ingenieril.

Este enfoque refleja mi forma de trabajar: pensar, diseñar, validar y luego automatizar.

------------------------------------------------------------------------------------------------




SistemaViajesApp es una aplicación de escritorio desarrollada en C# con Windows Forms (.NET 9.0), orientada a la gestión de viajes de empleados, permitiendo registrar, consultar y controlar la información relacionada con:

Empleados
Sucursales
Transportistas
Viajes realizados
Usuarios del sistema y roles
Registros de actividad (logs)
El sistema cuenta con control de acceso por roles, conexión a SQL Server, formularios modulares y validacones básicas para asegurar la integridad de la información.


Objetivo del sistema

Automatizar y centralizar el registro de viajes, asignación de empleados y control operativo, permitiendo:
Reducir errores manuales
Tener trazabilidad de quién registra la información
Facilitar reportes y consultas por filtros
Controlar accesos según el rol del usuario

El sistema maneja roles de usuario, los cuales determinan el acceso a los módulos:

Rol	Descripción
Admin	Acceso total a todos los módulos
Gerente	Acceso a viajes, listados y reportes
Transportista	Acceso limitado (según implementación futura)

El control de permisos se realiza a nivel de interfaz, habilitando o deshabilitando opciones del menú.

Arquitectura general

El proyecto sigue una estructura modular, separando responsabilidades:
Interfaz (Forms) → interacción con el usuario
Servicios → lógica de negocio
Acceso a datos → conexión y consultas SQL
Seguridad → sesión y control de permisos
No se utiliza un framework externo (como MVC); el enfoque es WinForms clásico, bien estructurado.

Tecnologías utilizadas

Lenguaje: C#

Framework: .NET 9.0 (Windows Forms)
Base de datos: Microsoft SQL Server
Proveedor SQL: Microsoft.Data.SqlClient
IDE recomendado: Visual Studio 2022 o superior

Módulos implementados

Login de usuarios
Menú principal (MDI)
Gestión de empleados
Gestión de transportistas
Registro de viajes
Listado y detalle de viajes
Reportes con filtros
Logs (implementado parcialmente)


Estructura general del proyecto

El proyecto SistemaViajesApp está organizado de forma modular para facilitar el mantenimiento, la lectura del código y la escalabilidad futura.
SistemaViajesApp
│
├── Interfaz
│   ├── LoginForm.cs
│   ├── FrmMenuPrincipal.cs
│   ├── FrmEmpleados.cs
│   ├── FrmTransportistas.cs
│   ├── FrmViajesIngreso.cs
│   ├── FrmViajesListado.cs
│   ├── FrmReportes.cs
│   └── FrmLogs.cs
│
├── Services
│   ├── AuthService.cs
│   ├── EmpleadosService.cs
│   ├── TransportistasService.cs
│   ├── ViajesService.cs
│   └── LogService.cs
│
├── Data
│   └── ConexionDB.cs
│
├── Security
│   ├── Sesion.cs
│   └── PermisosUI.cs
│
├── Program.cs
└── SistemaViajesApp.csproj





Interfaz

Contiene todos los formularios WinForms del sistema.
Cada formulario es responsable únicamente de la interacción con el usuario.

Principales características:

Uso de DataGridView de solo lectura para listados
ComboBox cargados desde base de datos
Validaciones básicas de campos
Eventos generados por el Designer respetados (_Click_1, _Load_1)
Formularios principales:

Formulario	Función
LoginForm	Autenticación de usuarios
FrmMenuPrincipal	Menú principal MDI del sistema
FrmEmpleados	Gestión de empleados
FrmTransportistas	Gestión de transportistas
FrmViajesIngreso	Registro de viajes y asignación de empleados
FrmViajesListado	Consulta de viajes y detalle
FrmReportes	Reportes con filtros
FrmLogs	Visualización de registros del sistema



Services

Contiene la lógica de negocio.
Los formularios no ejecutan SQL directamente, sino que llaman a estos servicios.

Ventajas:

Código más limpio en los Forms
Reutilización de lógica
Facilita pruebas y cambios futuros



Servicios principales:

Servicio	Responsabilidad
AuthService	Validación de usuario y rol
EmpleadosService	Operaciones CRUD de empleados
TransportistasService	Operaciones CRUD de transportistas
ViajesService	Registro y consulta de viajes
LogService	Registro de eventos del sistema




Data

Contiene la capa de acceso a datos.

ConexionDB.cs
Centraliza la cadena de conexión
Retorna un SqlConnection listo para usar
Evita duplicar código de conexión en todo el sistema

Regla clave:
Ningún formulario crea conexiones directas; todo pasa por esta clase.




Security

Módulo encargado de seguridad y control de acceso.

Archivos principales:
Archivo	Función
Sesion.cs	Almacena el usuario y rol activos
PermisosUI.cs	Habilita/deshabilita opciones del menú

Este enfoque permite:

Controlar permisos desde un solo punto
Evitar lógica de roles dispersa en los formularios


Program.cs

Punto de entrada de la aplicación.

Flujo:

Inicia la aplicación
Muestra LoginForm
Si el login es exitoso:
Se inicializa la sesión
Se abre FrmMenuPrincipal



Principios de diseño aplicados

Separación de responsabilidades
Formularios ligeros
Servicios reutilizables
Control de errores con try-catch
Código alineado al WinForms Designer (sin romper eventos)





Motor y nombre de base de datos

Motor: Microsoft SQL Server
Base de datos: SistemaViajes
Propósito: almacenar usuarios, empleados, sucursales, transportistas y viajes, incluyendo el detalle de empleados asignados por viaje.



Scripts SQL incluidos en el proyecto

Dentro del proyecto se incluye una carpeta llamada:

QuerySQL


En esta carpeta se dejaron scripts SQL listos para ejecutar, con el objetivo de facilitar la instalación y pruebas del sistema sin necesidad de escribir consultas manualmente.

Contenido de la carpeta QuerySQL
Archivo SQL	Descripción
SQLQuery2_Crear _BDD.sql	y SQLQuery1_Crear_Tablas crea la base de datos SistemaViajes, incluyendo tablas, claves primarias, foráneas y restricciones
SQLQuery1_Crear_Datos_de_Prueba.sql	Inserta datos de ejemplo para pruebas iniciales del sistema
🛠️ Uso recomendado de los scripts

Abrir SQL Server Management Studio (SSMS)

Ejecutar el archivo:

SQLQuery2_Crear _BDD
SQLQuery1_Crear_Tablas

Esto crea la estructura completa de la base de datos.

Ejecutar el archivo:

SQLQuery1_Crear_Datos_de_Prueba

Esto inserta:

Usuarios de prueba
Empleados
Sucursales
Transportistas
Relaciones básicas para pruebas

Datos de prueba

Los datos insertados permiten:
Iniciar sesión sin configuraciones adicionales
Probar los módulos de empleados, viajes y reportes
Validar el control de roles desde el primer arranque

Las credenciales de prueba pueden modificarse directamente en la base de datos según sea necesario.

Ventajas de este enfoque
Instalación rápida del sistema
Reproducibilidad del entorno
Facilita pruebas y evaluación del proyecto
Ideal para revisión técnica o entrevistas




Instalación, Configuración y Ejecución

Esta sección explica cómo levantar el proyecto SistemaViajesApp desde cero: crear la base de datos, configurar la conexión y ejecutar la aplicación.

Requisitos

Windows 10/11
Visual Studio 2022 (o superior) con workload de .NET desktop development
.NET 9.0 (Windows)
Microsoft SQL Server (Developer/Express/Standard)
SQL Server Management Studio (SSMS) (recomendado para ejecutar scripts)





Configurar cadena de conexión

El proyecto centraliza la conexión en:

Data/ConexionDB.cs

Ahí se define el método GetConnection() que retorna un SqlConnection listo para usar.

Ejemplo típico de configuración (ajusta a tu ambiente):

Servidor local por nombre: localhost
Instancia: .\SQLEXPRESS


Autenticación Windows o SQL Login

Ejemplos comunes de ConnectionString:

1) Windows Authentication (Trusted Connection):
Server=localhost;Database=SistemaViajes;Trusted_Connection=True;TrustServerCertificate=True;

2) SQL Authentication (usuario/clave):
Server=localhost;Database=SistemaViajes;User Id=sa;Password=TU_PASSWORD;TrustServerCertificate=True;

3) SQL Express (instancia típica):
Server=.\SQLEXPRESS;Database=SistemaViajes;Trusted_Connection=True;TrustServerCertificate=True;


Importante: TrustServerCertificate=True ayuda a evitar errores de certificado en entornos locales.

Ejecutar la aplicación

Abre el proyecto en Visual Studio
Selecciona configuración Debug
Presiona F5 o Start
El flujo de arranque es:
Program.cs inicia la app
Se muestra LoginForm
Al validar usuario/rol se abre FrmMenuPrincipal (MDI)




Credenciales de prueba

Los usuarios de prueba se insertan desde:
QuerySQL/02_InsertarDatosEjemplo.sql


Notas:

Los roles determinan el acceso a menús y formularios.
Si cambias contraseñas o roles, hazlo directamente desde SQL o edita el script de inserción.

Verificación rápida (Checklist)

 Ejecute los query adjuntos.
 Ajusté ConexionDB.cs con mi servidor/instancia
 Compila sin errores en Visual Studio
 Login abre FrmMenuPrincipal correctamente



Errores comunes y solución rápida

Error: “cannot open database” / no existe la BD
Solución: confirma que ejecutaste 01_CrearBaseDeDatos.sql y que la DB se llama SistemaViajes.

Error de conexión / instancia
Solución: revisa el Server= en tu connection string:
localhost
.\SQLEXPRESS
NOMBREPC\INSTANCIA

Certificado / SSL error
Solución: agrega TrustServerCertificate=True.





Uso del Sistema (Guía Funcional por Módulos)

Esta sección describe cómo se usa el sistema, qué hace cada pantalla y qué puede esperar el usuario final o el desarrollador que lo ejecute por primera vez.

Login del sistema
LoginForm

Función:
Autenticar al usuario contra la base de datos y obtener su rol.

Flujo:

El usuario ingresa:
Usuario
Contraseña
Presiona Ingresar

El sistema:
Valida campos vacíos
Consulta la tabla Usuarios
Verifica que el usuario esté activo

Si es válido:
Se inicializa la sesión
Se abre FrmMenuPrincipal

Si falla:
Se muestra mensaje de error

Resultado:
Usuario autenticado con rol activo en la sesión.


Menú Principal
FrmMenuPrincipal (MDI)

Función:
Centralizar el acceso a todos los módulos del sistema.

Características:
Interfaz MDI (formularios hijos)
Menú dinámico según rol

StatusStrip con:
Usuario
Rol
Fecha
Hora

Control de acceso:
Admin: acceso total
Gerente: acceso a viajes, listados y reportes
Otros roles: acceso limitado

Módulo de Empleados
FrmEmpleados

Función:
Administrar el catálogo de empleados.
Acciones disponibles:
Listar empleados
Agregar nuevo empleado
Editar empleado existente
Desactivar empleado (campo Activo)

Controles comunes:
DataGridView (solo lectura)
TextBox para nombre
Botones:
Nuevo
Guardar
Editar
Eliminar / Desactivar
Cerrar

Notas:

No se eliminan registros físicamente
Se trabaja con estado activo/inactivo

Módulo de Transportistas
FrmTransportistas

Función:
Gestionar los transportistas y su tarifa por kilómetro.

Acciones disponibles:

Crear transportista
Editar tarifa
Activar / desactivar
Campos principales:
Nombre
Tarifa por KM

Registro de Viajes
FrmViajesIngreso

Función:
Registrar un viaje y asignar empleados.

Flujo de uso:
Seleccionar:
Fecha del viaje
Sucursal
Transportista
Cargar empleados disponibles
Agregar empleados al detalle del viaje
Guardar el viaje

Características clave:

Uso de dos DataGridView:

Empleados disponibles
Empleados asignados

Validaciones:
No se permite guardar sin empleados
No se permite duplicar empleados

Inserción en:
Viajes (encabezado)
ViajeEmpleado (detalle)

Listado de Viajes
FrmViajesListado

Función:
Consultar viajes registrados y ver su detalle.

Funcionamiento:
DataGridView principal con viajes
Al seleccionar un viaje:
Se carga el detalle de empleados
Permite análisis rápido por registro

Uso típico:
Auditoría, verificación o consulta operativa.
Reportes
FrmReportes

Función:
Generar reportes filtrados.
Filtros disponibles:
Sucursal
Transportista
Rango de fechas
Salida:
DataGridView de solo lectura
Información lista para exportar o analizar
Logs del Sistema
FrmLogs

Función:
Visualizar eventos del sistema.
Estado actual: Parcial

Problemas conocidos:
Algunos registros tienen:

Usuario vacío
Modulo NULL
Los filtros no funcionan correctamente

Pendiente técnico:
Completar llamadas a LogService.Registrar() para asegurar trazabilidad completa.

Comportamientos importantes del sistema

Cada formulario tiene su propio DataGridView
No se reutilizan grids entre forms
Los servicios controlan la lógica
Los forms solo orquestan la UI
Manejo de errores con try-catch

Buenas prácticas de uso

Cerrar formularios hijos antes de abrir nuevos (MDI)
No modificar eventos del Designer manualmente
Probar siempre con datos de ejemplo antes de cambios
Usar SQL scripts para entornos nuevos







Convenciones de Código y Consideraciones Técnicas

Esta sección describe las reglas, criterios y decisiones técnicas utilizadas en el desarrollo de SistemaViajesApp, con el fin de facilitar su mantenimiento, comprensión y futura ampliación.

1. Convenciones de nombres
Formularios (WinForms)
Prefijo: Frm
PascalCase

Un formulario por archivo
Ejemplos:
FrmEmpleados
FrmTransportistas
FrmViajesIngreso
FrmViajesListado

Clases de servicio
Sufijo: Service
PascalCase
Responsabilidad única por clase
Ejemplos:
AuthService
ViajesService
EmpleadosService
LogService

Controles de interfaz
Convención aplicada para claridad y consistencia:
Tipo	Prefijo	Ejemplo
TextBox	txt	txtNombre
ComboBox	cmb	cmbSucursal
Button	btn / Btn	BtnGuardar
DataGridView	dgv / nombre explícito	dgvViajes
DateTimePicker	dtp	dtpDesde




2. Organización del código
Separación de responsabilidades

Forms:
Manejan interacción con el usuario y eventos UI.

Services:
Contienen la lógica de negocio y acceso a datos.

Data:
Centraliza la conexión a la base de datos.

Security:
Maneja sesión activa y control de permisos.

No se ejecutan consultas SQL directamente desde los formularios.



3. Manejo de base de datos

Uso exclusivo de Microsoft.Data.SqlClient

Todas las conexiones se crean mediante ConexionDB.GetConnection()

Uso de using para asegurar cierre de conexiones

Uso de parámetros SQL para evitar inyección SQL



Ejemplo conceptual:

@Usuario
@IdViaje
@FechaDesde




4. Manejo de errores

Uso consistente de try-catch
Mensajes claros para el usuario final
Errores técnicos no se muestran en detalle en producción

Ejemplos de control:
Errores de conexión
Errores de consulta SQL
Validaciones de datos incompletos



5. Control de roles y permisos
El rol se obtiene en el login
Se almacena en la clase Sesion
La habilitación de opciones se controla desde PermisosUI
El sistema no bloquea acciones a nivel de base de datos, sino a nivel de interfaz.




6. Uso del WinForms Designer
No se modifican archivos .Designer.cs manualmente
Los eventos generados por el Designer se respetan
Métodos con sufijo _1 se mantienen para evitar errores de compilación

Esta práctica evita:
Errores CS0103
Conflictos al recompilar el proyecto



7. DataGridView
Cada formulario que muestra datos tiene su propio DataGridView
No existen DataGridView compartidos entre formularios

Configuración típica:
Solo lectura
Selección de fila completa
Sin edición directa



8. Logs del sistema

El sistema cuenta con una estructura de logs

La tabla Logs existe y recibe registros

Implementación actual incompleta:
Algunos eventos no envían Usuario o Modulo
Filtros del formulario de logs no funcionan correctamente
Pendiente técnico identificado y documentado.

9. Buenas prácticas aplicadas

Evitar borrados físicos (uso de campo Activo)
Validar entradas del usuario antes de guardar
Evitar duplicados mediante restricciones UNIQUE
Código legible y comentado cuando es necesario
Estructura preparada para escalar



10. Consideraciones para mantenimiento futuro
Migrar a una arquitectura por capas más estricta si el sistema crece
Centralizar aún más el manejo de logs
Agregar exportación de reportes
Implementar pruebas unitarias en la capa de servicios
Mejorar control de permisos a nivel de acciones.
