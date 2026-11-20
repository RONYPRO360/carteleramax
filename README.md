# carteleramax
# Cartelera de Cine (`carteleramax`)

Aplicación de consola desarrollada en **C# (.NET 10)** para la gestión de funciones de cine conectada a **SQL Server LocalDB** mediante `Microsoft.Data.SqlClient` (ADO.NET), aplicando consultas parametrizadas, patrón repositorio y manejo de excepciones con `try/catch`.

## Requisitos previos

- **Visual Studio Community 2026** (con la carga de trabajo de desarrollo de escritorio .NET / .NET 8 SDK).
- **SQL Server LocalDB** (`(localdb)\MSSQLLocalDB`).
- Paquete NuGet **`Microsoft.Data.SqlClient`** instalado en el proyecto.

## Estructura del proyecto

- `01_crear_CarteleraDB.sql`: Script SQL para crear la base de datos `CarteleraDB`, la tabla `Funciones` e insertar los registros iniciales (`Coco` y `Moana`).
- `Funcion.cs`: Clase modelo que representa una función de cine (`Id`, `Pelicula`, `Sala`, `Precio`) con su formato de salida `ToString()`.
- `FuncionRepositorio.cs`: Clase de acceso a datos con la cadena de conexión y los métodos CRUD parametrizados (`Insertar`, `ListarTodos`, `BuscarPorId`, `Actualizar`, `Eliminar`).
- `Program.cs`: Menú interactivo en consola con validaciones de entrada y control de errores de base de datos (`SqlException`).
- `capturas/`: Carpeta con las evidencias de ejecución del sistema.

## Instrucciones de ejecución

### 1. Crear la base de datos
1. Abre **Visual Studio 2026** y dirígete a **Ver > Explorador de objetos de SQL Server**.
2. Conéctate a la instancia `(localdb)\MSSQLLocalDB`.
3. Abre el archivo `01_crear_CarteleraDB.sql` en una nueva consulta sobre `(localdb)\MSSQLLocalDB` y ejecútalo completo (`Ctrl + Shift + E`).
4. Verifica que se haya creado la base de datos `CarteleraDB` con la tabla `Funciones` y los 2 registros iniciales (`Coco` y `Moana`).

### 2. Ejecutar la aplicación
1. Abre la solución `carteleramax.slnx` en **Visual Studio 2026**.
2. Compila la solución (`Ctrl + Shift + B`) para verificar que no existan errores.
3. Ejecuta el proyecto presionando **`F5`** o **`Ctrl + F5`**.
4. Utiliza las opciones del menú:
   - `1`: Registrar función
   - `2`: Listar funciones (muestra cada función y el total acumulado de precios)
   - `3`: Buscar función por Id
   - `4`: Actualizar precio
   - `5`: Eliminar función
   - `6`: Salir


### 4. Control de error de base de datos (`SqlException`)
![Error de base de datos controlado](capturas/04_error_bd.png)
