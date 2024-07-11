# EmpleoCom - Portal de Empleo

## Descripción

EmpleoCom es una aplicación web desarrollada con .NET Core 7 que permite a los usuarios buscar y aplicar a ofertas de empleo, así como a los empleadores publicar ofertas de trabajo. La aplicación incluye tanto el backend como el frontend, ambos desarrollados en .NET Core 7 y utilizando Razor Pages. La base de datos se gestiona con SQL Server.

## Características

- **Registro y Autenticación de Usuarios:** Los usuarios pueden registrarse como demandantes de empleo o empleadores y autenticarse para acceder a sus respectivas funcionalidades.
- **Perfil de Demandante de Empleo:** Los demandantes de empleo pueden crear y actualizar su perfil, incluyendo la selección de habilidades.
- **Publicación de Ofertas de Trabajo:** Los empleadores pueden publicar y gestionar ofertas de trabajo.
- **Búsqueda de Empleo:** Los demandantes de empleo pueden buscar ofertas de trabajo basadas en habilidades específicas.
- **Gestión de Habilidades:** Los demandantes pueden seleccionar habilidades relacionadas con los trabajos que buscan, y estas se muestran en las ofertas de trabajo.

## Tecnologías Utilizadas

- **Backend:** .NET Core 7
- **Frontend:** Razor Pages
- **Base de Datos:** SQL Server
- **Servicios Web:** RESTful APIs

## Requisitos Previos

- [.NET Core 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Instalación

1. **Clonar el repositorio:**

    ```bash
    git clone https://github.com/GRIIMLY/empleo-com-PT.git
    cd EmpleoCom
    ```

2. **Configurar la Base de Datos:**

    Crear la base de datos y las tablas necesarias en SQL Server utilizando los scripts SQL proporcionados en la carpeta `DatabaseScripts`.

3. **Actualizar las cadenas de conexión:**

    Modificar el archivo `appsettings.json` en el proyecto para incluir la cadena de conexión a tu base de datos SQL Server.

    ```json
{

  "ConnectionStrings": {
    "Connectionkey": "Server=Servidor;Database=EmpleadoCom;User Id=AdminUsuario;password=Empl34doCom!$%;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True;"
  }
}

    ```

4. **Restaurar paquetes NuGet:**

    ```bash
    dotnet restore
    ```

5. **Ejecutar migraciones de Entity Framework (si se utilizan):**

    ```bash
    dotnet ef database update
    ```

6. **Compilar y ejecutar la aplicación:**

    ```bash
    dotnet build
    dotnet run
    ```

## Uso

1. **Registro de Usuarios:** Los usuarios pueden registrarse como demandantes de empleo o empleadores.
2. **Inicio de Sesión:** Los usuarios registrados pueden iniciar sesión para acceder a sus respectivas funcionalidades.
3. **Creación y Actualización de Perfiles:** Los demandantes de empleo pueden crear y actualizar su perfil, incluyendo la selección de habilidades.
4. **Publicación de Ofertas de Trabajo:** Los empleadores pueden publicar nuevas ofertas de trabajo y gestionarlas.
5. **Búsqueda de Empleo:** Los demandantes de empleo pueden buscar ofertas de trabajo basadas en habilidades específicas.

## Estructura del Proyecto

- **EmpleadoComBackend:** Contiene el código backend del proyecto.
- **EmpleadoComFrontend:** Contiene el código frontend del proyecto, incluyendo las páginas Razor y los servicios web.



## Licencia

Este proyecto está licenciado bajo la [MIT License](LICENSE).
