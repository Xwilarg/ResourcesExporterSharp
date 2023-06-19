﻿using System.Xml;
using System.Xml.Serialization;

partial class RessourcesExporterSharp
{
    public static void Import()
    {
        Console.WriteLine("Please enter path to the resx");
        string? path = Console.ReadLine();


        if (string.IsNullOrEmpty(path) || !File.Exists(path))
        {
            Console.WriteLine("Invalid argument, exiting...");
            return;
        }

        XmlSerializer xml = new(typeof(Resource));
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        var tmp = xml.Deserialize(stream);
        Resource res = (Resource)tmp!;

        var binary = res.Data.FirstOrDefault(x => x.Name == "METADATA" && x.Mimetype == Constants.MetadataMimeType);

        if (binary == null)
        {
            Console.WriteLine("Metadata not found, make sure this file was imported with this program first");
            return;
        }

        using var ms = new MemoryStream(Convert.FromBase64String(binary.Value));
        using var binReader = new BinaryReader(ms);

        var size = binReader.ReadInt32();

        List<string> paths = new(); // This is ugly but that will do for now

        for (int i = 0; i < size; i++)
        {
            var count = binReader.ReadInt32();
            var p = binReader.ReadString();
            paths.AddRange(Enumerable.Repeat(p, count));
        }

        // Metadata is treated, we remove it to make things easier
        var data = res.Data.ToList();
        data.Remove(binary);
        if (paths.Count != data.Count)
        {
            Console.WriteLine("Metadata are inconsistent, this may mean new keys were added/deleted after the file was exporter");
            return;
        }

        List<(string path, Data data)> tmpData = new(); // TODO: Linq
        for (int i = 0; i < data.Count; i++)
        {
            tmpData.Add((paths[i], data[i]));
        }

        var finalData = tmpData.GroupBy(x => x.path);
        XmlSerializer outputXml = new(typeof(Resource));

        foreach (var fd in finalData)
        {
            var writer = XmlWriter.Create(fd.Key);
            var outData = fd.Select(x => x.data).ToArray();
            outputXml.Serialize(writer, new Resource()
            {
                Data = outData,
                Resheaders = res.Resheaders
            });
            Console.WriteLine($"Wrote {outData.Length} into {fd.Key}");
        }

        Console.WriteLine("OK");
    }
}