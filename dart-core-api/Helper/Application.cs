﻿using System.Reflection;
using TypeGen.Core.Generator;

namespace dart_core_api.Helper
{
    public class Application
    {
        public static void SyncModels()
        {
            var directory = @$"{Directory.GetParent(Environment.CurrentDirectory)}/dart-electron/src/models";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            System.IO.DirectoryInfo di = new DirectoryInfo(directory);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            var options = new GeneratorOptions()
            {
                BaseOutputDirectory = directory,
                CreateIndexFile = true,
            }; // create the options object
            var generator = new Generator(options); // create the generator instance
            var assembly = Assembly.GetCallingAssembly(); // get the assembly to generate files for
            generator.Generate(assembly); // generates the files
        }
    }
}
