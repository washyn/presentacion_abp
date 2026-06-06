# Template de Arquitectura Empresarial - KFC API

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512bd4.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![ABP Framework](https://img.shields.io/badge/ABP-Framework-blue.svg)](https://abp.io/)

Este proyecto es una **Plantilla de Arquitectura de Referencia** diseñada para demostrar los beneficios de utilizar [ABP Framework](https://abp.io/) junto con **Clean Architecture** en entornos empresariales. 

> [!IMPORTANT]
> **Para Líderes Técnicos:** Hemos preparado una [Propuesta Técnica Detallada](PROPUESTA_TECNICA.md) que explica por qué esta arquitectura es la mejor opción para acelerar el desarrollo y garantizar la calidad en la compañía.

---

## 🚀 Propuesta de Valor

Este template no es solo una API de productos; es una demostración de cómo estandarizar el desarrollo:

- **Productividad Extrema:** Implementación de CRUDs en minutos usando `CrudAppService`.
- **Arquitectura Limpia:** Separación estricta de responsabilidades (Dominio, Aplicación, Infraestructura, API).
- **Calidad Embebida:** Validaciones con FluentValidation, Mapeos con AutoMapper y Unit of Work automático.
- **Ecosistema de Pruebas:** Suite completa de tests (Unitarios, Integración, Dominio) lista para usar.

## 🛠️ Stack Tecnológico

- **Framework Core:** ASP.NET Core 8
- **Framework de Aplicación:** ABP Framework (Volo.Abp)
- **ORM:** Entity Framework Core con SQLite (fácilmente intercambiable)
- **Validación:** FluentValidation
- **Logging:** Serilog
- **Documentación:** Swagger / OpenAPI
- **Testing:** xUnit, Shouldly, NSubstitute

## 🏗️ Estructura del Proyecto

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

---
Diseñado con ❤️ para la excelencia técnica.