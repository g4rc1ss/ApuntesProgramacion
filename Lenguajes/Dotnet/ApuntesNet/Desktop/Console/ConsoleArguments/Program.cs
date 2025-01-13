using System.CommandLine;

var rootCommand = new RootCommand("Ejemplo de la nueva api de Microsoft para Argumentos de comandos para CLI");

var fileOpt = new Option<FileInfo?>(name: "--file", description: "The file to read");
rootCommand.AddOption(fileOpt);
rootCommand.SetHandler(async (file) =>
{
    ArgumentNullException.ThrowIfNull(file);
    await foreach (var line in File.ReadLinesAsync(file.FullName))
    {
        Console.WriteLine(line);
    }
}, fileOpt);

await rootCommand.InvokeAsync(args);