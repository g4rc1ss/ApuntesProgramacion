Instalamos el paquete Nuget

`Install-Package ElectronNET.API`

En el `Startup.cs` agregamos:

```Csharp
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //Agregamos esta linea
                    webBuilder.UseElectron(args);
                });
```

En el `Program.cs` agregamos:

```Csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
   if (env.IsDevelopment())
   {
      app.UseDeveloperExceptionPage();
   }
   else
   {
      app.UseExceptionHandler("/Home/Error");
      // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      app.UseHsts();
   }
   app.UseHttpsRedirection();
   app.UseStaticFiles();
 
   app.UseRouting();
 
   app.UseAuthorization();
 
   app.UseEndpoints(endpoints =>
   {
      endpoints.MapControllerRoute(
         name: "default",
         pattern: "{controller=Home}/{action=Index}/{id?}");
   });
 
   // Open the Electron-Window here
   Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());
}
```
Hay que instalar la herramienta para compilar:
```Powershell
dotnet tool install ElectronNET.CLI -g
```

Después de ello tenemos que crear el archivo de configuración de ElectronNet, para ello hay que ejecutar lo siguiente:

```Powershell
#Hay que asegurarse de que estamos en el directorio del proyecto ubicado
# Una vez en la carpeta del proyecto principal que es el que va a ejecutar Electron hacemos lo siguiente:

electronize init
electronize start # Tambien se puede ejecutar directamente desde el play del VS
```

Para poder depurar el codigo hay que attachear el proyecto, simplemente es ir a `Debug > Attach to process > buscar el nombre de tu proyecto y Attach`