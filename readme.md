# KFC API - Gestión de Productos y Precios por Canal

Este proyecto de beneficios de uso de ABP(librerias) en una API REST hecha con ASP.NET Core 8 que nos permite gestionar los productos de KFC, sus canales de venta y los precios en cada canal como ejemplo de uso.

## ¿Cómo está construido?

Se ha usado una arquitectura limpia (Clean Architecture) que separa todo en capas bien organizadas:

1. **Capa de Dominio** (`Domain`) - El core del sistema:

   - Aquí estan nuestras entidades (Product, Channel)
   - Las interfaces de repositorios (IProductRepository)

2. **Capa de Aplicación** (`Application`):

   - Los servicios que hacen el trabajo duro (ProductsAppService)
   - DTOs para mover datos de un lado a otro
   - Validaciones con **FluentValidation** para que nadie meta datos raros
   - Mapeos automáticos con **AutoMapper**

3. **Capa de Infraestructura** (`Infrastructure`) - Infraestructura:

   - Repositorios que interactuan con la base de datos usando Entity Framework Core
   - Configuración de SQLite para guardar todo
   - Migraciones para evolucionar la base de datos

4. **Capa de API** (`Api`) - La presentacion:
   - Controladores REST que exponen todo
   - Swagger para que probar la API
   - Middleware para capturar errores y que nada se rompa
   - Toda la configuración necesaria


## Patrones y principios, buenas practicas

1. **Repositorio** - El almacén de datos :

   - Usamos IProductRepository como una puerta de acceso a los datos sin preocuparnos por los detalles
   - La implementación real está en ProductRepository con EF Core haciendo el trabajo sucio que se puede cambiar por otro orm de acceso a datos o SPs segun sea necesario.

3. **DTO (Data Transfer Object)**:

   - Objetos como ProductDto y PriceDto que llevan datos entre capas
   - Evitan exponer las entidades del dominio al exterior

4. **Unidad de Trabajo (Unit of Work)** - Para asegurar las transacciones con ef core:

   - Implementado con app.UseUnitOfWork()
   - Garantiza que todas las operaciones de base de datos se completen o fallen juntas

5. **Módulo** - Los bloques de construcción:

   - Organizamos todo en módulos cohesivos (ApiModule, ApplicationModule...)
   - Cada módulo tiene su propia responsabilidad y configuración

6. **Fábrica** - Para crear objetos:

   - EntityFrameworkCoreDbContextFactory crea contextos de base de datos cuando los necesitamos en la migracion y creacion de base de datos
   - Centraliza la lógica de creación de objetos complejos

7. **Validador** - Para asegurar que los datos sean correctos:
   - Validadores con **FluentValidation** que aseguran que los datos sean correctos
   - Código de validación limpio, legible y separado de la lógica de negocio

## Para ejecutar el proyecto:

### Lo que se necesita tener instalado

- .NET 8 SDK
- Un editor de código (Visual Studio, VS Code, Rider...)

### Pasos para ejecutar

1. Restaurar paquetes NuGet:

   ```
   dotnet restore
   ```

2. Ejecutar la aplicación:

   ```
   cd src/Api
   dotnet run
   ```

3. Acceder a Swagger para probar la API:
   ```
   http://localhost:5004/swagger
   ```

### Sobre la base de datos

Usamos SQLite porque es ligero y no requiere instalacion como se solicito en la descripcion de la prueba. La configuración está en `src/Api/appsettings.json`, se puede cambiar por sqlite en memoria para los tests integrales(en infraestructura):

```json
{
  "ConnectionStrings": {
    "Default": "Data Source=.KFC.db;"
  }
}
```

## Para ejecutar tests

1. En la carpeta de pruebas:

   ```
   cd tests
   ```

2. Ejecutar las pruebas:

   ```
   dotnet test
   ```

## Si tuviéra mas tiempo

10. **Test de integración** :

- Pruebas de integración para ver cómo funciona todo en conjunto
- Llamadas a los endpoints de la API
