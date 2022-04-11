using Aspose.Zip;
using Aspose.Zip.UnRAR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    //https://blog.aspose.com/2021/04/15/unrar-extract-rar-extractor-opener-in-csharp-asp.net/
    class RarController
    {
        public RarController()
        {

        }

        public void UnrarCompleteFiles(String rarFileName,String cfgDir)
        {
            // Load input RAR file.
            RarArchive archive = new RarArchive(rarFileName);

            // Unrar or extract all files from the archive
            archive.ExtractToDirectory(cfgDir);
        }

        public void UnrarspezificFile()
        {
            // Load input RAR file.
            using (RarArchive archive = new RarArchive("Sample.rar"))
            {
                // Create a file with Create() method.
                using (var destination = File.Create("Extracted_File1.txt"))
                {
                    // Open an entry from the RAR archive.
                    using (var source = archive.Entries[0].Open())
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead;
                        // Write extracted data to the file.
                        while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                            destination.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        public void AddFoldersToZIP(String zipName, String backupDestinationDir)
        {
            // Create FileStream for output ZIP archive
            using (FileStream zipFile = File.Open(zipName, FileMode.Create))
            {
                using (Archive archive = new Archive())
                {
                    // Folder to be Zipped
                    DirectoryInfo corpus = new DirectoryInfo(backupDestinationDir);
                    archive.CreateEntries(corpus);
                    // Create ZIP archive
                    archive.Save(zipFile);
                }
            }
       
        }
    }
}
