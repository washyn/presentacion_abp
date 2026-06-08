using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Repositories;

namespace Washyn.Kfc;

public class ExampleAppService : ApplicationService
{
    public ExampleAppService()
    {
    }

    public async Task<string> GetHelloAsync()
    {
        return "Hello";
    }
}

// TODO: add automatic enable remote service gen...
// TODO: add todo list basic crud.
// https://abp.io/docs/latest/framework/api-development/auto-controllers

public class TodoTask : FullAuditedEntity<Guid>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
}

public class TodoTaskDto : EntityDto<Guid>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
}

public class TodoTaskAppService : CrudAppService<TodoTask, TodoTaskDto, Guid, PagedAndSortedResultRequestDto>
{
    public TodoTaskAppService(IRepository<TodoTask, Guid> repository) : base(repository)
    {
    }

    public override Task<PagedResultDto<TodoTaskDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return base.GetListAsync(input);
    }
}

// falto
// sonar qube
// app service automatico
// health check

// ----

// - 4 capas  
// - preparado pra microservicios
// - Multitenant
// - Caché
// - Healthchecks
// - Unit test
// - Integration test
// - Modularidad
// - Servicios comuines, crud, generic repos, email sending, storage
// - Unot of work
// - HEalthchecks
// - Authorization
// - validation, fluentvalidation automatic
// - Exception handling
// - Auditing
// - Ai module
// - Automapper u otro
// - Background jobs, workers, storage, event bus, localization json
// - Croos cutting concerns
// - DDD infraestructure
// - Auto rest apis
// - Blob storage
// - Audit logging
// - object mapping
// - Email an sms abstraction
// - Localization
// - Settings management
// - Dependency injection
// - Servicios de encriptación