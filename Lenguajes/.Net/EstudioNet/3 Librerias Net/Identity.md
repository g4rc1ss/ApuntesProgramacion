`Identity` es un framework que nos permite abstraernos de toda la configuracion que requiere hacer un proceso de login, crear usuarios, modificar y cerrar sesion.

Permite entre otros, el uso de un doble factor de autenticacion, inicio de sesion con otros proveedores como, Google, Facebook, etc.

Identity tiene sus propias entidades ya creadas, las cuales podemos utilizar sin ningun problema, si por algun casual necesitamos crear o señalizar nuestras propias entidades no pasaria nada

Identity por debajo hace uso de `Entity Framework core` para la ejecucion de las queries.

# Configurar Identity
Si queremos personalizar alguna tabla, como agregar campos extras a la tabla usuario o la de Roles, podemos crear clases que hereden directamente de su clase Identity.

- Creamos la clase `User` y la clase `Role` y heredamos de `IdentityUser` e `IdentityRole` respectivamente indicando un tipo `int`, ese tipo puede ser cualquier dato y corresponde a la key principal de las columnas, esos significa, que si le indicamos `Guid`, la key cuando se autogenere al, por ejemplo, crear un usuario, sera de tipo `Guid`
```Csharp
public class User : IdentityUser<int> 
{
}
public class Role : IdentityRole<int> 
{
}
``` 

- Creamos la configuracion con las clases personalizadas de Identity
- Creamos las opciones de requisitos minimos en la contraseña a utilizar para el registros de sesion
- Agregamos el proveedor de tokens por defecto para restablecer contraseñas
- Agregamos la clase `SignInManager` indicando la clase que debemos usar para la gestion de sesion.
- Agregamos la clase que va a llevar los Roles del usuario, por ejemplo, comprobar si es un usuario Administrador
- Agregamos el Contexto de EF Core para que las consultas se ejecuten con el framework.
```Csharp
services.AddIdentity<User, Role>(options => {
    // Password settings.
    options.Password.RequireDigit = true;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
}).AddDefaultTokenProviders()
    .AddSignInManager<SignInManager<User>>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<EguzkimendiContext>();
```

## Cambiar nombres a las Tablas
Agregamos en el metodo `OnModelCreating` de la clase de `DbContext` que contiene estas entidades, podemos cambiar el nombre por defecto a las tablas de Identity
```Csharp
 // Cambio de nombre de las tablas de identity
builder.Entity<User<int>>().ToTable("Users");
```

# Configurar Identity
```Csharp
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.Cookie.Name = "Nombre de la cookie";
    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});
```

```Csharp
app.UseAuthentication();
app.UseAuthorization();
```

# Authentication
El proceso de autenticacion consiste en validar la existencia de un usuario, por ejemplo, mediante la comprobacion de un usuario y contraseña, comprobacion mediante un sistema biometrico, etc.

## SignInManager
Clase de Identity que tenemos que inyectar como dependencia y esta enfocada en el proceso de sesion, por ejemplo, realizar login, logout, obtener el 2FA, etc.

```Csharp
private readonly SignInManager<IdentityUser> _signInManager;

internal Constructor(SignInManager<IdentityUser> signInManager)
{
    _signInManager = signInManager;
}
```

### PasswordSignInAsync
```Csharp
_signInManager.PasswordSignInAsync(user, password, rememberMe, lockOnFailure);
```

### TwoFactorAuthenticatorSignInAsync
```Csharp
_signInManager.TwoFactorAuthenticatorSignInAsync(code, isPersistent, rememberClient);
```

# Authorization
El proceso de autorizacion se encarga de validar si el usuario tiene los permisos necesarios para acceder a ciertas partes de la aplicacion, por ejemplo, validar si el usuario conectado tiene el rol de administrador para acceder a poder crear usuarios nuevos.

La validacion de autenticacion se realiza mediante el Middleware que agregamos al inicio del programa.

## AuthorizationAttribute
Podemos usar el atributo de autorizacion para comprobar si el usuario esta autenticado en el sistema, si pertenece a un rol, etc.

Este atributo se puede poner encima de metodos y de la propia clase de Controller.
```Csharp
[Authorize]
[Authorize(Roles = "Administrador, Usuario")]
```

## Con HttpContext
```Csharp
if (HttpContext.User.IsInRole(roleAdmin)) 
{
}

if (HttpContext.User.Identity.IsAuthenticated) 
{
}
```

# Manager de tablas de Identity
Clases que gestionan las tablas de usuario de Identity, como la tabla User, la tabla Role, etc.

## UserManager
Clase de Identity que tenemos que inyectar como dependencia y se utiliza para la gestion de la tabla de usuario, por ejemplo, crear un usuario, asignar roles a usuarios, etc.

```Csharp
private readonly UserManager<IdentityUser> _userManager;

internal Constructor(UserManager<IdentityUser> userManager)
{
    _userManager = userManager;
}
```

### CreateAsync
```Csharp
var usuario = new IdentityUser() 
{
    UserName = "usuario",
    SecurityStamp = new Guid().ToString()
};
await _userManager.CreateAsync(usuario, "Contraseña");
```

### UpdateAsync
```Csharp
var usuario = await _userManager.GetUserAsync(HttpContext.User);
usuario.Email = "modificamos email";
await _userManager.UpdateAsync(usuario);
```

### AddToRoleAsync
```Csharp
await _userManager.AddToRoleAsync(usuario, "role");
```

### GetUserId
En aspnetcore podemos obtener el user desde el HttpContext.User

```Csharp
ClaimsPrincipal user;
userManager.GetUserId(user);
```

## RoleManager
```Csharp
private readonly RoleManager<IdentityRole> _roleManager;

public Constructor(RoleManager<IdentityRole> roleManager) 
{ 
    _roleManager = roleManager;
}
```
    
### CreateAsync
```Csharp
var roleUsuario = new IdentityRole()
{
    Name = "Usuario",
    NormalizedName = "Usuario"
};
await _roleManager.CreateAsync(roleUsuario);
```

### UpdateAsync
```Csharp
var role = await _roleManager.FindByNameAsync("Usuario");
role.Name = "UsuarioModificado";
await _roleManager.UpdateAsync(role);
```
