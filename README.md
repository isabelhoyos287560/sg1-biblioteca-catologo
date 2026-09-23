# API de Catálogo de Biblioteca

API de solo lectura para consultar el catálogo de una biblioteca (libros, autores, categorías).


## Configuración

### 1. Cadena de conexión

En `Library.Api/appsettings.json`:

```json
"ConnectionStrings": {
  "MyConnection": "Server=.\\SQLEXPRESS;Database=library-sg1;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 2. Aplicar migraciones

```bash
dotnet ef database update --project Library.Persistence --startup-project Library.Api
```

### 3. Ejecutar

```bash
dotnet run --project Library.Api
```

## Endpoints

| Método | Ruta                                | Descripción                              |
|--------|--------------------------------------|-------------------------------------------|
| GET    | `/api/books`                         | Lista todos los libros                    |
| GET    | `/api/books/{id}`                    | Consulta el detalle de un libro por Id    |
| GET    | `/api/books/category/{categoryId}`   | Lista los libros filtrados por categoría  |