Console.WriteLine("Please enter 'export' or 'import'");
var cmd = Console.ReadLine()?.ToUpperInvariant().Trim();

if (cmd == "EXPORT")
{
    RessourcesExporterSharp.Export();
}
else if (cmd == "IMPORT")
{
    RessourcesExporterSharp.Import();
}
else
{
    Console.WriteLine("Invalid command");
}

Console.WriteLine("Press any key to close the program");
Console.ReadKey();