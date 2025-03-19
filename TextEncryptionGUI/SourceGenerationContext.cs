using System.Text.Json.Serialization;
using TextEncryptionGUI.ViewModels;

namespace TextEncryptionGUI;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(MainViewModel))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
