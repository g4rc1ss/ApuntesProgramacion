namespace TextFiles.ClaseBinary;

public class EscribirBinario
{
    public EscribirBinario(string nombreArchivo)
    {
        // Crea objeto `FileStream` para referenciar un archivo binario -ArchivoBinario.bin-:
        // Escritura sobre el archivo binario `ArchivoBinario.bin` usando un 
        // objeto de la clase `BinaryWriter`:
        using (var fs = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write))
        {
            using var bw = new BinaryWriter(fs);
            // Escritura de datos de naturaleza primitiva:
            bw.Write(1.0M);
            bw.Write("Este es el texto que se esta");
            bw.Write('\n');
            bw.Write("escribiendo con la Clase Binary de .NET");
        }
        Console.WriteLine($"Los datos han sido escritos en el archivo `{nombreArchivo}`.");
    }
}
