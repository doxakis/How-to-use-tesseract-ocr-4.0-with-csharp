# How to use Tesseract OCR 4.0 with C#

Sure you can compile it, but here is a quick and easy way to get the job done.

## Installation

**NOTE: All the required files to run the demo are in this repo. You can skip the installation section for now.**

You may find this section helpful when you are ready to integrate Tesseract in your app in c#.

- Consult the CI website (https://ci.appveyor.com/project/zdenop/tesseract)
- Go to the latest working build
- Choose 32 bit or 64 bit build
- Go to the Artifacts section
- Download the build and extract it somewhere
- Download the data files for the languages you want to support (https://github.com/tesseract-ocr/tesseract/wiki/Data-Files)
- Add the data files in the tessdata folder
- Implements something similar to the ParseText function (Program.cs)

## Demo

- Open the solution on Visual Studio 2017 (Demo.sln)
- Run it

The ParseText function is thread-safe.

## Folder structure

- Demo (C# solution)
- Samples (Images you want to extract text)
- tesseract-master.1153 (The build version I am gonna use for the demo)
  - tessdata (data files for the languages)
    - eng.traineddata
    - fra.traineddata

# Copyright and license
Code released under the MIT license.
