# BlackBird Whisperer

## Description
A personal project for my own whisper client so I dont have to run to my browser to use by far the best speech to text service out there.
(Please add whisper to word Microsoft, dictation is terrible and you know it [Also Rider has a better spell checker than word, which is sad])

## Features
- [x] Speech to text
- [x] Saving the text to a file
<br> That's it

## Requirements
- Windows
- An education that taught you how to read
- An API key from [OpenAI](https://beta.openai.com/)

## How to use
1. Download the latest release
2. Run the exe (it will error that's ok its meant to)
3. Close the exe
4. Press windows key + R and type `appdata`
5. Navigate to `Local\BlackBird\Config`
6. Open `.openai` and paste your API key in the file
7. Save the file
8. Run the exe again
9. Profit

### How to use
1. Click the big record button
2. Talk
3. Click the stop button
4. Click the transcript button
5. Copy the text or save it to a file

## How to build
1. Clone the repo
2. Open the solution folder in a console of your choice
3. Run `dotnet build`
<br>
If that doesn't work you probably need to install the .NET 7.0 SDK

## Q & A

### Q: HELP IT NO WORK

Just open an issue and I'll try to help you out.

### Q: Why is it called BlackBird?

A: Because Black Cockatoo's are an endangered species that are native to Australia that lack funding for conservation efforts

### Q: Why do i need to go into the appdata folder to add my API key?

A: <br> 1. easier to hide the API key from the public
<br> 2. Compered to other way I have seem this is easier for you. That's right I did this for you

### Q: Why Does it not come with an API key?

A: Because I don't want to pay for your API usage. There are free alternatives out there if you look hard enough.

### Q: Why is it called BlueBird in several places?

A: I may have made a slight blunder when naming the project, and rider keeps throwing errors when I try to rename it.

### Q: Is this a school project?

A: Yes and no, I made it for myself but I am also submitting it for a school project (Hi Miss, B I commented my work this time)

### Q: What about Linux and/or Mac?

A: Its a WinForms app, so try [Wine](https://www.winehq.org/)? If that doesn't work then no.


## Credits
- [OpenAI](https://beta.openai.com/) for the API
- [OpenAI-DotNet](https://github.com/RageAgainstThePixel/OpenAI-DotNet) for the API wrapper
- [NAudio](https://github.com/naudio/NAudio) for the audio recording
- All the other libraries I used that I forgot to mention



