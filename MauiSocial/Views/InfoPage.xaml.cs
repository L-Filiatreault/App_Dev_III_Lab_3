using System.Reflection;
namespace MauiSocial.Views;

public partial class InfoPage : ContentPage
{

    public InfoPage()
	{
		InitializeComponent();
        LoadFile();

    }

    private void LoadFile()
    {
        ///\ TODO:
        ///AddPost the Files/InfoText.txt to your MSBuild embedded ressources 
        ///Load its content and display it in the Editor of this page.
        ///

        Stream stream;
        string fileContents = "";

        var fileToRead = "";

        var info = Assembly.GetExecutingAssembly().GetManifestResourceNames();

        foreach (var item in info)
        {
            if (item.EndsWith("InfoText.txt"))
            {
                fileToRead = item;
            }
        }

        using (stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileToRead))
        {
            if (stream != null)
            {

                using (StreamReader reader = new StreamReader(stream))
                {
                    fileContents = reader.ReadToEnd();
                    FileEditor.Text = fileContents;
                }

            }
            else
            {
                Console.WriteLine("Failed to open resource.");
            }

        }
    }

}