using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

            var solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            var tesseractPath = solutionDirectory + @"\tesseract-master.1153";
            var testFiles = Directory.EnumerateFiles(solutionDirectory + @"\samples");

            var maxDegreeOfParallelism = Environment.ProcessorCount;
            Parallel.ForEach(testFiles, new ParallelOptions { MaxDegreeOfParallelism = maxDegreeOfParallelism }, (fileName) =>
            {
                var imageFile = File.ReadAllBytes(fileName);
                var text = ParseText(tesseractPath, imageFile, "eng", "fra");
                Console.WriteLine("File:" + fileName + "\n" + text + "\n");
            });

			stopwatch.Stop();
			Console.WriteLine("Duration: " + stopwatch.Elapsed);
			Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        private static string ParseText(string tesseractPath, byte[] imageFile, params string[] lang)
        {
            string output = string.Empty;
            var tempOutputFile = Path.GetTempPath() + Guid.NewGuid();
            var tempImageFile = Path.GetTempFileName();

            try
            {
                File.WriteAllBytes(tempImageFile, imageFile);

                ProcessStartInfo info = new ProcessStartInfo();
                info.WorkingDirectory = tesseractPath;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.UseShellExecute = false;
                info.FileName = "cmd.exe";
                info.Arguments =
                    "/c tesseract.exe " +
                    // Image file.
                    tempImageFile + " " +
                    // Output file (tesseract add '.txt' at the end)
                    tempOutputFile +
                    // Languages.
                    " -l " + string.Join("+", lang);

                // Start tesseract.
                Process process = Process.Start(info);
                process.WaitForExit();
                if (process.ExitCode == 0)
                {
                    // Exit code: success.
                    output = File.ReadAllText(tempOutputFile + ".txt");
                }
                else
                {
                    throw new Exception("Error. Tesseract stopped with an error code = " + process.ExitCode);
                }
            }
            finally
            {
                File.Delete(tempImageFile);
                File.Delete(tempOutputFile + ".txt");
            }
            return output;
        }
    }
}
