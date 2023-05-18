using NAudio.Wave;
using OpenAI.Audio;
using System.Windows.Forms;

// you know adding comments is one of my favorite things to do
// because i know no one will read them
namespace Bluebird_TTS;

public partial class MainWindow : Form
{
    public bool StopRecord = false;
    private Button _record = new Button();
    private Button _stop = new Button();
    private Button _transcribe = new Button(); 
    private Button _savelocation = new Button();
    private Button _copy = new Button();
    //adding a output text block place for easy viewing
    private TextBox _textblock = new TextBox();

    public string SavePath;
    public string TranscribedText;

    public MainWindow() //Regretting doing this in WinForms...
    {
        InitializeComponent();
        this.Text = "Blackbird TTS";
        this.TopMost = true;
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
        //_textblock.Size = new Size(300, 100);
        _savelocation.Size = new Size(124, 50);
        _copy.Size = new Size(124, 50);
        

        _textblock.ReadOnly = true;
        
        _stop.Location = new System.Drawing.Point(0, 62);
        _transcribe.Location = new Point(0, 124);
        _savelocation.Location = new Point(0, 204);
        _copy.Location = new Point(0, 266);

        _textblock.Location = new Point (200, 1);
        _record.Click += new EventHandler(Record_method);
        _stop.Click += new EventHandler(Stop_method);
        _transcribe.Click += new EventHandler(Transcribe_method);
        _savelocation.Click += new EventHandler(Save_method);
        _copy.Click += new EventHandler(Copy_method);

        _stop.Enabled = false;
        _transcribe.Enabled = false;
        //_savelocation.Enabled = false;
        
        _textblock.BorderStyle = BorderStyle.FixedSingle;
        _textblock.Dock = DockStyle.Fill;
        _textblock.BackColor = Color.WhiteSmoke;
        _textblock.Font = new Font("Arial", 12);
        
        // Create and configure the layout panel


        
        Controls.Add(_record);
        Controls.Add(_stop);
        Controls.Add(_transcribe);// naww look at how neat and boiler plate it is
        // Controls.Add(_textblock);
        Controls.Add(_savelocation);
        Controls.Add(_copy);
    }

    private void Copy_method(object? sender, EventArgs e)
    {
        Clipboard.SetText(TranscribedText);
    }

    private void Save_method(object? sender, EventArgs e)
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

    private void Stop_method(object? sender, EventArgs e)
    {
        StopRecord = true;
        _record.Enabled = true;
        _stop.Enabled = false;
        _transcribe.Enabled = true;
        // there has got to be a better way to do this
    }

    private async void Transcribe_method(object? sender, EventArgs e)
    {
        string Transcription_request = await Variable.AiClient.AudioEndpoint.CreateTranscriptionAsync(new AudioTranscriptionRequest(Path.GetFullPath(Variable.OutputFilePath), language: "en"));
        MessageBox.Show(Transcription_request);
        TranscribedText = Transcription_request;
    }

    private void Record_method(object? sender, EventArgs e)
    {
        try
        {
            _record.Enabled = false;
            _stop.Enabled = true;
            StopRecord = false;
            WaveInEvent Wave_in = new WaveInEvent();
            WaveFileWriter Writer = new WaveFileWriter(Variable.OutputFilePath, Wave_in.WaveFormat);
            Wave_in.StartRecording();
            Wave_in.DataAvailable += (s, a) =>
            {
                //Boolean plsStop = ;
                Writer.Write(a.Buffer, 0, a.BytesRecorded);
                if (StopRecord)
                {
                    Wave_in.StopRecording();
                    Wave_in.Dispose();
                    Writer.Dispose();
                }
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    protected override void OnFormClosing(FormClosingEventArgs e) {
        e.Cancel = false;
        base.OnFormClosing(e);
        // stackoverflow told me to do this and if stackoverflow told me to do it... i would have killed myself but thats not the point
    }
}


