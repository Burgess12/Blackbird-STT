using OpenAI;
using System;

namespace Bluebird_TTS;

public abstract class Variable
{
    public static readonly string OutputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BlackBird/Temp");
    public static string ConfigFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BlackBird/Config");
    public static readonly string OutputFilePath = Path.Combine(OutputFolder, "Temp.wav");
    public static OpenAIClient AiClient;
}