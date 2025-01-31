
---

# Prueba Técnica CODIFICO SAS - Sales Date Prediction

## Requisitos Previos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (2016 o superior)
- [dotnet-ef CLI](https://docs.microsoft.com/es-es/ef/core/cli/dotnet) (opcional para migraciones)

---

## Configuración Inicial

### 1. Configuración de Base de Datos

#### 🔧 Opción A: Usar Base de Datos Existente
1. Ubicar el script de base de datos en:
   ```
   PruebaTecnicaCodifico/SalesDatePrediction/Persistence/DbObjects/DbSetup.txt
   ```
2. Ejecutar el script en tu instancia de SQL Server

#### 🛠 Opción B: Crear Nueva Base de Datos
1. Crear base de datos vacía en SQL Server
2. Configurar cadena de conexión en:
   ```json
   // API/appsettings.json
   "ConexSqlServer": "Server=TU_SERVIDOR;Database=TU_BASE_DATOS;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
   ```

---

## Ejecución del Proyecto

### 1. Configuración de Conexiones
Actualizar cadenas de conexión en:
```
API/appsettings.json
API/appsettings.Development.json
```

### 2. Restauración de Paquetes
```bash
dotnet restore
```

### 3. Migraciones (Solo para Opción B)
```bash
# Instalar herramientas EF (si no lo has hecho)
dotnet tool install --global dotnet-ef

# Generar migración
dotnet ef migrations add InitialCreate --project Persistence/ --startup-project API/ --output-dir ./Data/Migrations

# Aplicar migración
dotnet ef database update --project Persistence/ --startup-project API/
```

### 4. Ejecución del Backend
```bash
dotnet build
dotnet run --project API/
```

El servicio estará disponible en: `https://localhost:5001` o `http://localhost:5000`

---

## Estructura del Proyecto
```
📦 PruebaTecnicaCodifico
┣ 📂 API            # Capa de presentación
┣ 📂 Aplication     # Lógica de negocio
┣ 📂 Persistence    # Configuración de base de datos
┗ 📂 Domain         # Dominio del proyecto
```

---

## Consideraciones Importantes
1. **Permisos de SQL Server**: Asegurar que el usuario tenga permisos de creación de objetos si usas migraciones
2. **Puertos**: Verificar que los puertos 5000 y 5001 o los puertos asignados a la ejecucion del proyecto estén disponibles
3. **Variables de Entorno**: Para entorno de desarrollo, priorizar configuraciones en `appsettings.Development.json`



## 2 Ejecucion FrontEnd

- Entrar al archivo index, encontrado en: FrontEnd/index.html, luego desplegar usando la extension LiveServer o cualquier otro servidor local.


## (opcional)
- En caso de querer probar cada funcionalidad del backend, mas a detalle, se puede acceder a la siguiente ruta /swagger/index.html


# NOTAS

El proyecto ha sido desarrollado utilizando una arquitectura de cuatro capas basada en los principios de **Clean Architecture** y **SOLID**, lo que garantiza un código modular, mantenible y escalable. Para optimizar la gestión de los repositorios en consultas sencillas, se ha implementado el patrón **Unit of Work**, facilitando la administración y ejecución de operaciones en la base de datos.  

### **Capa de Persistencia (Persistence)**  
Dentro de esta capa, se encuentra una carpeta denominada **dbObjects**, la cual contiene dos archivos clave:  
1. **Setup de la base de datos**: Permite la configuración inicial del esquema y estructura de la base de datos.  
2. **Creación de objetos DML**: Implementa el requerimiento de generar objetos de manipulación de datos (DML) para ser consumidos en la **Web API**.  

El uso de estos DML se ha implementado a través de **Stored Procedures**, lo que facilita su ejecución y reutilización. Para estas operaciones, sería más eficiente el uso de **Dapper**, aunque también se ha dejado un ejemplo de ejecución directa de un procedimiento almacenado utilizando **Entity Framework Core** en el archivo `Application/Repository/CustomerRepository.cs`. Un fragmento de código que ilustra esta implementación es el siguiente:  

```csharp
public async Task<List<CustomerOrderPrediction>> GetNextOrderPredictionsAsync()
{
    return await _context.Set<CustomerOrderPrediction>()
        .FromSqlRaw("EXEC GetCustomerOrderPredictions")
        .ToListAsync();
}
```

### **Capa de Presentación**  
Para mejorar la estructura y el manejo de datos, se ha configurado un sistema de **Profiles/Mapping Profiles** que permite transformar entidades en **DTOs (Data Transfer Objects)**, tanto para recibir peticiones como para enviar respuestas a los consumidores de la API.  

Además, se ha incluido una configuración dentro de la carpeta **Helpers** para gestionar un **middleware de excepciones**, asegurando un mejor manejo de errores en las solicitudes hacia la API. También se ha agregado un sistema de **paginación por defecto**, pensado para optimizar la consulta de grandes volúmenes de datos desde el servidor.  

### **Configuraciones en la Carpeta Extensions**  
Dentro de la carpeta **Extensions**, se han definido diversas configuraciones esenciales para el proyecto, tales como:  
- **CORS**: Para permitir solicitudes desde diferentes orígenes y garantizar la comunicación con el frontend u otros servicios.  
- **ApplicationServices**: Configuración de inyección de dependencias para diferentes servicios del proyecto.  
- **Versionamiento de API**: Permite manejar múltiples versiones de los endpoints y garantizar compatibilidad con futuras actualizaciones.  
- **Rate Limiting**: Implementa un control de peticiones para limitar y administrar el acceso a la API, mejorando la seguridad y el rendimiento.  