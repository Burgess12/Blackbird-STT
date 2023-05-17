using NAudio.Wave;
using OpenAI;
// you know adding comments is one of my favorite things to do
// because i know no one will read them
namespace Bluebird_TTS;

public partial class MainWindow : Form
{
    public bool StopRecord = false;
    private Button _record = new Button();
    private Button _stop = new Button();
    private Button _transcribe = new Button();
    public MainWindow() //Regretting doing this in WinForms...
    {
        InitializeComponent();
        this.Text = "Blackbird TTS";
        InitializeAllThingys();
    }

    private void InitializeAllThingys() //So what if i can't name things for shit? its not like people read this
    {

        
        _record.DialogResult = DialogResult.OK;
        _stop.DialogResult = DialogResult.OK;
        _transcribe.DialogResult = DialogResult.OK;
        
        
        _record.Text = "Record";
        _stop.Text = "Stop"; 
        _transcribe.Text = "Transcribe";
        
        _record.Size = new System.Drawing.Size(124, 50);
        _stop.Size = new Size(124, 50);
        _transcribe.Size = new Size(124, 50);
        
        _stop.Location = new System.Drawing.Point(0, 62);
        _transcribe.Location = new Point(0, 124);
        
        _record.Click += new EventHandler(Record_method);
        _stop.Click += new EventHandler(Stop_method);
        _transcribe.Click += new EventHandler(Transcribe_method);

        _stop.Enabled = false;
        
        Controls.Add(_record);
        Controls.Add(_stop);
        Controls.Add(_transcribe);// naww look at how neat and boiler plate it is
    }

    private void Stop_method(object? sender, EventArgs e)
    {
        StopRecord = true;
        _record.Enabled = true;
        _stop.Enabled = false;
        // there has got to be a better way to do this
    }

    private void Transcribe_method(object? sender, EventArgs e)
    {
        Console.Write("Apparently throwing an exception means git wont commit so i have to write this");
        // wait, why did i use console.write instead of a comment
    }

    private void Record_method(object? sender, EventArgs e)
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
            int Threshold = 1;
            if (StopRecord)
            {
                Wave_in.StopRecording();
                Wave_in.Dispose();
                Writer.Dispose();
            }
        };
    }
    protected override void OnFormClosing(FormClosingEventArgs e) {
        e.Cancel = false;
        base.OnFormClosing(e);
        // stackoverflow told me to do this and if stackoverflow told me to do it... i would have killed myself but thats not the point
    }
}


