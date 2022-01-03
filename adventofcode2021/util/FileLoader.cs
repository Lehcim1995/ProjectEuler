using System.Reflection;

namespace adventofcode2021.util;

public class FileLoader
{
    public static List<string> LoadAsList(string fileName)
    {
        
        List<String> lines = new List<string>();

        // Read the file and display it line by line.  
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"input\" + fileName);

        using (StreamReader file =
               new StreamReader(path))
        {
            string? line;
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }

        return lines;
    }
}