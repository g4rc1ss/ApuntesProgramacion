namespace TextFiles.ClaseFile;

internal class DeleteFile
{
    public DeleteFile(params string[] archivosToDelete)
    {
        foreach (var archivo in archivosToDelete)
        {
            File.Delete(archivo);
            Console.WriteLine($"Archivo {archivo} borrado");
        }
    }
}
