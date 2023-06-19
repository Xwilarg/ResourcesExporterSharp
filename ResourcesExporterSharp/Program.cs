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