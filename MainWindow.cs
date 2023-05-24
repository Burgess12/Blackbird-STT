using NAudio.Wave;
using OpenAI.Audio;
using System.Windows.Forms;

// you know adding comments is one of my favorite things to do
// because i know no one will read them
namespace Bluebird_TTS;

public partial class MainWindow : Form
{
    public bool StopRecord = false;

    //adding a output text block place for easy viewing
    private TextBox _textblock = new TextBox();
    public string SavePath;
    public string TranscribedText;


    public MainWindow() //Regretting doing this in WinForms...
    {
        InitializeComponent();
        this.Text = "Blackbird TTS";
        this.TopMost = true;
        // Locking the form size
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        
        //Changing the forms icon
        this.Icon = new Icon("icon.ico");
        BackColor = Color.White;
        Font = new Font("Arial", 12);

        InitializeAllThingys();
    }
     private void InitializeAllThingys() //So what if i can't name things for shit? its not like people read this
    {
        _record.DialogResult = DialogResult.OK;
        _stop.DialogResult = DialogResult.OK;
        _transcribe.DialogResult = DialogResult.OK;
        _savelocation.DialogResult = DialogResult.OK;
        _copy.DialogResult = DialogResult.OK;


        _record.Text = "Record";
        _stop.Text = "Stop";
        _transcribe.Text = "Transcribe";
        _textblock.Text = "Placeholder";
        _savelocation.Text = "Save";
        _copy.Text = "Copy";

        _record.Size = new System.Drawing.Size(124, 50);
        _stop.Size = new Size(124, 50);
        _transcribe.Size = new Size(124, 50);
        _output.Size = new Size(600, 900);
        _savelocation.Size = new Size(124, 50);
        _copy.Size = new Size(124, 50);


        _stop.Location = new System.Drawing.Point(0, 62);
        _transcribe.Location = new Point(0, 124);
        _savelocation.Location = new Point(0, 204);
        _copy.Location = new Point(0, 266);
        _output.Location = new Point(200, 1);
        _record.Click += new EventHandler(Record_method);
        _stop.Click += new EventHandler(Stop_method);
        _transcribe.Click += new EventHandler(Transcribe_method);
        _savelocation.Click += new EventHandler(Save_method);
        _copy.Click += new EventHandler(Copy_method);

        _stop.Enabled = false;
        //_transcribe.Enabled = false;
        //_savelocation.Enabled = false;


        Controls.Add(_record);
        Controls.Add(_stop);
        Controls.Add(_transcribe); // naww look at how neat and boiler plate it is
        // Controls.Add(_textblock);
        Controls.Add(_savelocation);
        Controls.Add(_copy);
        Controls.Add(_output);
    }

    private void Copy_method(object? sender, EventArgs e) => Clipboard.SetText(TranscribedText); // what a great one liner... get it?
    
    private void Save_method(object? sender, EventArgs e) // I should move this to a different file, should, but i won't
    {
        SaveFileDialog Save_location = new SaveFileDialog();
        Save_location.Title = "Where to Save Transcription";
        Save_location.InitialDirectory = @Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        Save_location.DefaultExt = "txt";
        Save_location.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        //Saving the path to a variable
        SavePath = Save_location.FileName;

        Save_location.ShowDialog();

        // Writing the transcription to the file
        File.WriteAllText(SavePath, TranscribedText);
    }

    private void Stop_method(object? sender, EventArgs e) => StopRecordVoid();


    private async void Transcribe_method(object? sender, EventArgs e)
    {
        if (!StopRecord)
        {
            StopRecordVoid();
        }

        await Task.Delay(1000);
        string Transcription_request = await Variable.AiClient.AudioEndpoint.CreateTranscriptionAsync(new AudioTranscriptionRequest(Path.GetFullPath(Variable.OutputFilePath), language: "en"));
        //MessageBox.Show(Transcription_request);
        TranscribedText = Transcription_request;
        _output.Text = TranscribedText;

        Clipboard.SetText(TranscribedText);
        await Task.Delay(1000);
        //sending control V to paste the text
        SendKeys.Send("^v");
    }

    private WaveInEvent Wave_in;
    private WaveFileWriter Writer;

    private void Record_method(object? sender, EventArgs e)
    {
        try
        {
            _record.Enabled = false;
            _stop.Enabled = true;
            StopRecord = false;
            _transcribe.Enabled = false;
            Wave_in = new WaveInEvent();
            Writer = new WaveFileWriter(Variable.OutputFilePath, Wave_in.WaveFormat);
            Wave_in.StartRecording();
            Wave_in.DataAvailable += (s, a) =>
            {
                //Boolean plsStop = ;
                Writer.Write(a.Buffer, 0, a.BytesRecorded);
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    void StopRecordVoid()
    {
        StopRecord = true;
        Wave_in.StopRecording();
        Wave_in.Dispose();
        Writer.Dispose();
        _record.Enabled = true;
        _stop.Enabled = false;
        _transcribe.Enabled = true;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        e.Cancel = false;
        base.OnFormClosing(e);
        // stackoverflow told me to do this and if stackoverflow told me to do it... i would have killed myself but thats not the point
    }
}

public partial class MainWindow //I did this so i didn't have to look at them
{
    private Button _record = new Button();
    private Button _stop = new Button();
    private Button _transcribe = new Button();
    public Button _savelocation = new Button();
    public Button _copy = new Button();
    private TextBox _output = new TextBox();
} //I could have done this in the designer but thats incompatible with Net core i guess. thanks JetBrains great product,
  //how much does it cost non students? Let me check.... $149 a year! wow, ok did not expect that, how much is VS Community? $0?
  //good thing i have a student email.