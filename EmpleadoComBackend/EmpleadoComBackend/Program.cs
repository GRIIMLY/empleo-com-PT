using AutoMapper;
using EmpleoComBI.BI;
using EmpleoComRepository.ContextDB;
using EmpleoComRepository.DTOs;
using EmpleoComRepository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Se agrega la injeccion de dependencias de las interfaces de la capa de repositories
EmpleoComRepository.Middleware.IoCRepositories.addDependency(builder.Services);
//// Se agrega la injeccion de dependencias de las interfaces de la capa de services
EmpleoComBI.Middleware.IoCBI.addDependency(builder.Services);

var conection = builder.Configuration.GetConnectionString("Connectionkey");
builder.Services.AddDbContext<EmpleadoComDB>(options =>
{
    options.UseSqlServer(conection);
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        //policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    }
    );

});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

#region DescripcionesTrabajo Endpoints
var UserEndpointBase = "empleadocom/v1/";
app.MapGet(UserEndpointBase + "DescripcionesTrabajo", async (IDescripcionesTrabajoBI descripcionesTrabajoBI) =>
await descripcionesTrabajoBI.getAll());

app.MapGet(UserEndpointBase + "DescripcionesTrabajo/GetResumenDescripcionTrabajo", async (IDescripcionesTrabajoBI descripcionesTrabajoBI) =>
descripcionesTrabajoBI.GetDescripcionTrabajoDTOs());
#endregion

#region Usuario Endpoints
app.MapPost(UserEndpointBase + "Usuario", async (UsuarioDTO usuarioDTO, IUsuariosBI usuariosBI, IMapper mapper) =>
{
    try
    {
        await usuariosBI.insert(mapper.Map<Usuario>(usuarioDTO));
    }
    catch (Exception e)
    {
        throw e;
    }
});

app.MapGet(UserEndpointBase + "Usuario/PorNombreUsuario/{nombreusuario}", async ([BindRequired] string nombreusuario, IUsuariosBI usuarioBI) =>
{
    try
    {
        return Results.Ok(usuarioBI.GetUsuarioPorNombreUsuario(nombreusuario));
    }
    catch (Exception e)
    {
        throw e;
    }
});
#endregion

#region Demandante Endpoints

app.MapPost(UserEndpointBase + "Demandante", async (DemandanteDTO demandante, IDemandantesBI demandantesBI, IMapper mapper) =>
{
    try
    {
        await demandantesBI.insert(mapper.Map<Demandante>(demandante));
    }
    catch (Exception e)
    {
        throw e;
    }
});

app.MapPut(UserEndpointBase + "Demandante", async (DemandanteDTO demandante, IDemandantesBI demandantesBI, IMapper mapper) =>
{
    try
    {
        await demandantesBI.update(mapper.Map<Demandante>(demandante));
    }
    catch (Exception e)
    {
        throw e;
    }
});

app.MapGet(UserEndpointBase + "Demandante/{id}", async ([BindRequired] int id, IDemandantesBI demandantesBI, IMapper mapper) =>
{
    try
    {
        var demandante = mapper.Map<DemandanteDTO>(await demandantesBI.getById(id));
        if (demandante == null)
        {
            demandante = new DemandanteDTO();
        }
        return Results.Ok(demandante);

    }
    catch (Exception e)
    {
        throw e;
    }
});
#endregion

#region Habilidad Endpoints

app.MapGet(UserEndpointBase + "Habilidad", async (IHabilidadBI habilidadBI) =>
{
    try
    {
        return Results.Ok(await habilidadBI.getAll());
    }
    catch (Exception e)
    {
        throw e;
    }
});


app.MapGet(UserEndpointBase + "Habilidad/PorIdUsuario/{IdUsuario}", async ([BindRequired] int IdUsuario, IHabilidadBI habilidadBI) =>
{
    try
    {
        return Results.Ok(habilidadBI.GetHabilidadPorIdUsuario(IdUsuario));
    }
    catch (Exception e)
    {
        throw e;
    }
});


app.MapGet(UserEndpointBase + "Habilidad/PorIdTabajo/{IdTabajo}", async ([BindRequired] int IdTabajo, IHabilidadBI habilidadBI) =>
{
    try
    {
        return Results.Ok(habilidadBI.GetHabilidadPorIdTrabajo(IdTabajo));
    }
    catch (Exception e)
    {
        throw e;
    }
});
#endregion

#region HabilidadUsuarioTrabajo Endpoints

app.MapPost(UserEndpointBase + "HabilidadUsuarioTrabajo/all", async ([FromBody] List<HabilidadUsuarioTrabajoDTO> habilidadUsuario, IHabilidadUsuarioBI habilidadUsuarioBI, IMapper mapper) =>
{
    try
    {

        return Results.Ok(await habilidadUsuarioBI.insertAll(mapper.Map<List<HabilidadUsuarioTrabajo>>(habilidadUsuario)));
    }
    catch (Exception e)
    {
        throw e;
    }
});

app.MapDelete(UserEndpointBase + "HabilidadUsuarioTrabajo/DeleteHabilidadPorIdUsuario/{IdUsuario}", async ([BindRequired] int IdUsuario, IHabilidadUsuarioBI habilidadUsuarioBI) =>
{
    try
    {
        habilidadUsuarioBI.DeleteHabilidadPorIdUsuario(IdUsuario);
        return Results.Ok();
    }
    catch (Exception e)
    {
        throw e;
    }
});


app.MapDelete(UserEndpointBase + "HabilidadUsuarioTrabajo/DeleteHabilidadPorIdTrabajo/{IdTrabajo}", async ([BindRequired] int IdTrabajo, IHabilidadUsuarioBI habilidadUsuarioBI) =>
{
    try
    {
        habilidadUsuarioBI.DeleteHabilidadPorTrabajoId(IdTrabajo);
        return Results.Ok();
    }
    catch (Exception e)
    {
        throw e;
    }
});
#endregion

app.Run();
