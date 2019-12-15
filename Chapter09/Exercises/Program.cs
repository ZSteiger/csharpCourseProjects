using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a list of shapes to serialize
            List<Rectangle> listOfShapes = new List<Rectangle>()
            {
                new Circle { Color = "Red", Radius = 2.5 },
                new Rectangle { Color = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Color = "Green", Radius = 8.0 },
                new Circle { Color = "Purple", Radius = 12.3 },
                new Rectangle { Color = "Blue", Height = 45.0, Width = 18.0 }
            };
            XmlSerializer xs = new XmlSerializer(typeof(List<Rectangle>));

            string path = Combine(CurrentDirectory, "shapes.xml");

            using (FileStream stream = File.Create(path))
            {
                xs.Serialize(stream, listOfShapes);
            }
            WriteLine($"Written {new FileInfo(path).Length:N0} bytes of XML to {path}");
            WriteLine();

            WriteLine(File.ReadAllText(path));

            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {
                var loadedShapes = xs.Deserialize(xmlLoad) as List<Rectangle>;
                foreach (Rectangle item in loadedShapes)
                {
                    WriteLine($"{item.GetType().Name} is {item.Color} and has an area of {item.Area:N2}");
                }
            }

        }
    }
}

/* ------- Exercise 9.1 -------
1. What is the difference between using the File class and the FileInfo class? A: The File class is generally for single operations performed on the file, while FileInfo is for multiple operations. The File class is static and needs additional parameters for each of its methods to work, however FileInfo creates an instance of the File

2. What is the difference between the ReadByte method and the Read method of a stream? A: ReadByte will be a lot slower if you're using large files due to the amount of function calls to check each byte, whereas Read copies that data into a buffer if it's large enough allowing faster iterations in reading the file.

3. When would you use the StringReader, TextReader, and StreamReader
classes? A: StringReader implements a TextReader to provide a series of methods that read anything from single characters to whole strings at a time. StreamReader is designed for character input in a particular encoding. The TextReader is an abstract base class for StringReader & StreamReader. Remember you can dispose indirectly with a 'using' block.

4. What does the DeflateStream type do? A: This class represents the deflate algorithm, which is an industry-standard algorithm for lossless file compression and decompression.

5. How many bytes per character does the UTF-8 encoding use? A: 1-4 bytes depending on the complexity of the character.

6. What is an object graph? A: The view of an object system at a particular point in time.

7. What is the best serialization format to choose for minimizing space requirements? A: Protocol Buffers, Google's data interchange format, has an official .NET implementation called ProtoBuf.net. It ships binaries for both Mono 2.0 and Silverlight 2.0, and maintains speed and efficiency

8. What is the best serialization format to choose for cross-platform compatibility? A: JavaScript Object Notation, or JSON works well being strongly supported by most web browsers. Protocol buffers are also language/platform-neutral.

9. Why is it bad to use a string value like \Code\Chapter01 to represent a path and what should you do instead? A: It adds additional steps to identifying the path in the machine as it has to interpret what each character is, then format it into a readable path string, then find where the string was pointing. If stored in System.IO.Path, the reference could be made directly to memory. Plain strings can't validate a proper path.

10. Where can you find information about NuGet packages and their
dependencies? A: The NuGet package manager UI in Visual Studio will provide info on whichever NuGet package you select. Each NuGet will also have a .nuspec file that should list dependencies or other various information
 */
