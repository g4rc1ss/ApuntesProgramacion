namespace PrimerEjercicio.Windows;

public partial class WindowWrap : ContentPage
{
    public WindowWrap()
    {
        InitializeComponent();
    }

    async void BtnSave_Click(System.Object sender, System.EventArgs e)
    {
        var saveFileDialog1 = await FilePicker.PickAsync();

        if (saveFileDialog1 != null)
        {
            var nombreFichero = saveFileDialog1.FileName;
            await DisplayAlert("titulo", "Has intentado guardar el fichero " + nombreFichero, "Cancel");
        }
    }

    async void BtnOpen_Click(System.Object sender, System.EventArgs e)
    {
        var openFileDialog1 = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images
        });

        var nombreFichero = openFileDialog1.FileName;
        await DisplayAlert("titulo", "Has intentado abrir el fichero " + nombreFichero, "Cancel");
    }
}

