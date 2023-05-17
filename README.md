# BlackBird Whisperer

## Description
A personal project for my own whisper client so I dont have to run to my browser to use by far the best speech to text service out there.
(Please add whisper to word Microsoft, dictation is terrible and you know it [Also Rider has a better spell checker than word, which is sad])

## Features
- [x] Speech to text
<br> That's it

## Requirements
- Windows
- Some common sense
- An API key from [OpenAI](https://beta.openai.com/)

## How to use
1. Download the latest release
2. Run the exe (it will error thats ok)
3. Close the exe
4. Press windows key + R and type `appdata`
5. Navigate to `Local\BlackBird\Config`
6. Open `.openai` and paste your API key in the file
7. Save the file
8. Run the exe again
9. Profit

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

### Q: This sucks

A: yes its a personal project that I made for myself, if you want to make it better feel free to open a PR

### Q: Why is it so ugly?

A: See above

### Q: Why Does it not come with an API key?

A: Because I don't want to pay for your API usage. There are free alternatives out there if you look hard enough.

### Q: Why is it called BlueBird and not BlackBird?

A: I may have made a slight blunder when naming the project

### Q: Is this a school project?

A: Yes and no, I made it for myself but I am also submitting it for a school project (Hi Miss, B I commented my work this time)


## Credits
- [OpenAI](https://beta.openai.com/) for the API
- [OpenAI-DotNet](https://github.com/RageAgainstThePixel/OpenAI-DotNet) for the API wrapper
- [NAudio](https://github.com/naudio/NAudio) for the audio recording
- All the other libraries I used that I forgot to mention
- Myself: with out you this would not be possible
