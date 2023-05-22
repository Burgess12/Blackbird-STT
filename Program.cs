namespace Bluebird_TTS;
using OpenAI;
// DID I REALLY CALL MY SOLUTION BlueBird TTS INSTEAD OF BlackBird STT ASJNUEFMKNIUEOK
// ok im good now

//right Im going to give my teacher a link to this repo and see what she says

static class Program
{
    [STAThread]
    static void Main()
    {
        Directory.CreateDirectory(Variable.OutputFolder); 
        Directory.CreateDirectory(Variable.ConfigFilePath);
        //Checks if openai file is present in config folder
        if (!File.Exists(Variable.ConfigFilePath + "/.openai"))
        {
            File.Create(Variable.ConfigFilePath + "/.openai").Close();
            // Now we need to write the api key placeholder to the file using a streamwriter

            using (StreamWriter Add_place_holder = new StreamWriter(Variable.ConfigFilePath + "/.openai"))
            {
                Add_place_holder.WriteLine("{\n" + "\t\"apiKey\": \"sk-<your api key here>\"" + "\n}");
            } 
            
        }
        // very important this makes a folder in %appdata% for the program to store temp files
        try
        {
            Variable.AiClient = new OpenAIClient(OpenAIAuthentication.LoadFromDirectory(Variable.ConfigFilePath));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
        
        
    } 
    //god what a mess
    //why did i do this in winforms. i could have have a lovely wpf app or even a ASP.NET app I love asp
    // but NOOOO i had to do it in winforms
    // i hate myself
    
}
