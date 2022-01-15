using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IDE
{
    internal class Settings
    {

        public void resetToDefault()
        {
            StringWriter sw = new StringWriter(new StringBuilder());
            JsonTextWriter writer = new JsonTextWriter(sw); 
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("projectdir");
            writer.WriteValue(Path.GetFullPath("Projects"));
            writer.WritePropertyName("projects");
            writer.WriteStartArray();
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
            File.WriteAllText("settings.json",sw.ToString());
        }

        public dynamic getsettings()
        {
            dynamic settings = new ExpandoObject();
            JsonTextReader reader = new JsonTextReader(new StringReader(File.ReadAllText("settings.json")));
            while (reader.Read())
            {
                if (reader.Value == null) continue;
                switch (reader.Value.ToString())
                {
                    case "projectdir":
                        reader.Read();
                        settings.projectdir=reader.Value.ToString();
                        break;
                    case "projects":
                        reader.Read();
                        reader.Read();
                        List<string> projects = new List<string>();
                        while(reader.TokenType.ToString()!= "EndArray")
                        {
                            projects.Add(reader.Value.ToString());
                            reader.Read();
                        }
                        settings.projects = projects;
                        break;
                    default:
                        break;
                }
            }
            return settings;
        }

        public void setsettings(dynamic settings)
        {
            StringWriter sw = new StringWriter(new StringBuilder());
            JsonTextWriter writer = new JsonTextWriter(sw);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("projectdir");
            writer.WriteValue(settings.projectdir);
            writer.WritePropertyName("projects");
            writer.WriteStartArray();
            foreach(var item in settings.projects)writer.WriteValue(item);
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
            File.WriteAllText("settings.json", sw.ToString());
        }
    }
}
