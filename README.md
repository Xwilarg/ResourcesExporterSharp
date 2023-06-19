# ResourcesExporterSharp
Easily export resx files into one file, and import them back

## Explanations

Sometimes you have a project with many .resx file, and modifying all of them is a pain, especially for someone from the outside \
Thanks to this program, easily export all your resources in one file, modify them elsewhere and reimport them

## How to use

 - Download the latest version from the Release page
 - Launch the program, it'll then ask you if you want to import or export
 - Enter 'import' and enter the path to the folder you want to extract the resx from, the program will then create you a file called Output.resx
 - Once you are done with your modifications, start the program again and enter 'export', then enter the path to the modified Output.resx file (or however you wrote it)

## TODO

 - Handle resources other than strings
 - Handle languages others than C# (for now the program launch ResGen with it)
 - Proper exception and error handling