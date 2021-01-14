using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using System.Collections.Specialized;

namespace BigBoxLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Open("BigBoxLauncher.log");

            // Load the configuration settings.  (These should be in BigBoxLauncher.exe.config)
            string platform_value = ConfigurationManager.AppSettings.Get("LastPlatform");
            string bigBoxSettingsFile = ConfigurationManager.AppSettings.Get("BigBoxSettingsLocation");


            bool saveFlag = false; // Used to indicate whether we made changes to the BigBoxSettings file.  If so, we'll write out the updates.
            string elementToSearch = "LastPlatform";

            Logger.WriteLine("BigBoxLauncher started.");

            try
            {
                Logger.WriteLine("Loading [" + bigBoxSettingsFile + "]...");
                XmlDocument doc = new XmlDocument();
                doc.Load(bigBoxSettingsFile);   // Load the XML file into an XML document object.
                Logger.WriteLine("File successfully loaded.");

                XmlNode bigbox = doc.SelectSingleNode("/LaunchBox/BigBoxSettings"); // Get the parent node where BigBox stores all the settings.

                if (bigbox != null)
                {
                    Logger.WriteLine("Looking for LastPlatform element...");
                    XmlNode node = bigbox.SelectSingleNode(elementToSearch);
                    if (node != null)
                    {
                        Logger.WriteLine("Found!  Value is [" + node.InnerText + "]");
                        if (node.InnerText.Equals(platform_value))
                        {
                            Logger.WriteLine("This value matches expected value of [" + platform_value + "].  No update necessary.");
                        }
                        else
                        {
                            Logger.WriteLine("Overriding value to [" + platform_value + "]");
                            node.InnerText = platform_value;
                            saveFlag = true;
                        }
                    }
                    else
                    {
                        Logger.WriteLine("<" + elementToSearch + "> element is missing!  We'll insert it.");
                        XmlElement lastplatform = doc.CreateElement(elementToSearch);
                        XmlNode lastnode = doc.CreateNode(XmlNodeType.Element, elementToSearch, "");
                        lastnode.InnerText = "PANTS!";
                        bigbox.AppendChild(lastnode);
                        saveFlag = true;
                    }
                }
                else
                {
                    Logger.WriteLine("ERROR!  XPATH of [/LaunchBox/BigBoxSettings] was missing from the file!");
                    Logger.WriteLine("Since this is totally unexpected, there's nothing we can do.  Please check your file and location.");
                }

 

                if (saveFlag)
                {
                    Logger.WriteLine("Saving file...");
                    doc.Save(bigBoxSettingsFile);
                }

            }
            catch(System.IO.FileNotFoundException ex)
            {
                Logger.WriteLine("ERROR!  We couldn't find [" + bigBoxSettingsFile + "].  Unable to continue.");
            }
            catch(Exception ex)
            {
                Logger.WriteLine("UNEXPECTED ERROR!  " + ex.ToString());
            }

            Logger.WriteLine("Program finished.");
            Logger.Close();

            ///// Uncomment the below lines if you would like the program to pause on exit waiting for a key stroke.
            //Console.WriteLine("Finished.  Press any key to exit.");
            //Console.ReadKey();
        }
    }
}
