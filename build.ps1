$publishPath = [System.IO.Path]::Combine($env:TEMP, "GeoQuality_Publish")
dotnet publish TextEncryptionGUI.Desktop -c Release -o $publishPath  /p:PublishSingleFile=true
explorer $publishPath