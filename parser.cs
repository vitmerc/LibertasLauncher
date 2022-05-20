using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Libertas
{
    public class LibertasParser
    {
        public LibertasForm mainForm;
        public string curNewsURL;
        public string[] parseLBMod(string filename)
        {
            string pathname;
            if (!File.Exists(filename))
            {
                pathname = Path.Combine(Directory.GetCurrentDirectory(), "Mods", filename + ".lbmod");
            }
            else
            {
                pathname = filename;
            }
            string[] currentModLines = File.ReadAllLines(pathname);
            return currentModLines;
        }

        public string ImageToBase64(Image image,
  System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }



        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = null;
            // Convert Base64 String to byte[]
                while (imageBytes == null)
                {
                    Thread.Sleep(3000);
                    imageBytes = Convert.FromBase64String(base64String);

                }
            
            Console.Write("ha-ha");
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public void loadMods()
        {
            string[] allPathnames = new string[0];
            string path = Directory.GetCurrentDirectory();
            string modfolder = Path.Combine(path, "Mods");
            if (!Directory.Exists(modfolder))
            {
                Directory.CreateDirectory(modfolder);
            }
            string[] modsPathnames = Directory.GetFiles(modfolder, "*.lbmod", SearchOption.TopDirectoryOnly).Where(c => c != null && File.ReadAllLines(c)[0] == "[LBMOD]").ToArray();
            int fCount = modsPathnames.Length;
            string[] result = new string[fCount];
            allPathnames = new string[modsPathnames.Length];
            int i= 0;
            foreach (string pathname in modsPathnames)
            {
              allPathnames[i] = Path.GetFileNameWithoutExtension(pathname);
                i++;
            }
            mainForm.setUI("modsList", allPathnames);

        }

        public string getModParam(string filename, string param)
        {
            string result = null;

            if (mainForm.validParams.Contains<string>(param))
            {
                foreach (string line in mainForm.currentModLines)
                {
                    string[] split = line.Split('=');
                    if (split.Length < 2)
                    {
                        Array.Resize(ref split, 2);
                        split[1] = null;
                    }
                    string name = split[0];
                    string value = split[1];
                    if (name == param)
                    {
                        result = value;
                            return result;
                    }
                }
            }
            else
            {
                return "InvalidParameterName";
            }
            if (result == null)
            {
                return "param not found";
            }
            else
            {
                return result;
            }

        }
    }
}
