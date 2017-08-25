# How to use Tesseract OCR 4.0 with C#

Sure you can compile it, but here is a quick and easy way to get the job done.

## Installation

- Consult the CI website (https://ci.appveyor.com/project/zdenop/tesseract)
- Go to the latest working build
- Go to the Artifacts section
- Download the build
- Download the data files for the languages you want to support (https://github.com/tesseract-ocr/tesseract/wiki/Data-Files)

## Demo 
- Open the solution on Visual Studio 2017 (Demo.sln)
- Run it

The ParseText function is thread-safe.
So, to maximize the overall speed, use multi-threading.

## Folder structure

- Demo (C# solution)
- Samples (Images you want to extract text)
- tesseract-master.1153 (The build version I am ganna use for the demo)
  - tessdata (data files for the languages)
    - eng.traineddata
    - fra.traineddata

# Copyright and license
Code released under the MIT license.
