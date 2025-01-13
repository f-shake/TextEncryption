$publishPath = [System.IO.Path]::Combine($env:TEMP, "TextEncryptionGUI_Publish")
dotnet publish TextEncryptionGUI.Desktop -r win-x64 -c Release -o $publishPath
explorer $publishPath