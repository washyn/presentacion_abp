# Template de Arquitectura Empresarial - API

Este proyecto es una **Plantilla de Arquitectura de Referencia** diseñada para demostrar los beneficios de utilizar [ABP Framework](https://abp.io/) junto con **Clean Architecture** en entornos empresariales.

***

## Propuesta de Valor

Este template no es solo una API de productos; es una demostración de cómo estandarizar el desarrollo:

- **Productividad Extrema:** Implementación de CRUDs en minutos usando `CrudAppService`.
- **Arquitectura Limpia:** Separación estricta de responsabilidades (Dominio, Aplicación, Infraestructura, API).
- **Calidad Embebida:** Validaciones con FluentValidation, Mapeos con AutoMapper y Unit of Work automático.
- **Ecosistema de Pruebas:** Suite completa de tests (Unitarios, Integración, Dominio) lista para usar.

## Stack Tecnológico

- **Framework Core:** ASP.NET Core 8
- **Framework de Aplicación:** ABP Framework (Volo.Abp)
- **ORM:** Entity Framework Core con SQLite (fácilmente intercambiable a oracle, sqlserver o mongo )
- **Validación:** FluentValidation
- **Logging:** Serilog
- **Documentación:** Swagger / OpenAPI
- **Testing:** xUnit, Shouldly, NSubstitute

## Estructura del Proyecto

El proyecto sigue una estructura modular y de capas (DDD):

1. **[Domain](src/Domain):** Entidades de negocio, constantes e interfaces de repositorio. El "corazón" del sistema.
2. **[Infrastructure](src/Infrastructure):** Implementación de repositorios, DbContext y migraciones.
3. **[Application](src/Application):** Servicios de aplicación, DTOs y validadores. Aquí reside la lógica de casos de uso.
4. **[Api](src/Api):** Controladores REST, configuración de módulos y middlewares.
5. **[Tests](tests):** Organización paralela de pruebas para cada capa del sistema.

## 🏁 Cómo Empezar

### Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Ejecución Rápida

1. Clonar el repositorio.
2. Restaurar dependencias:
   ```bash
   dotnet restore
   ```
3. Ejecutar la API:
   ```bash
   dotnet run --project src/Api
   ```
4. Abrir Swagger: `http://localhost:5004/swagger`

## 🧪 Ejecución de Pruebas

El proyecto incluye una suite de pruebas automatizadas que validan cada capa:

```bash
dotnet test
```

***

Diseñado con ❤️ para la excelencia técnica.
