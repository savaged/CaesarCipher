namespace Rot13.CLI;

internal static class Presenter
{
    public static void Present(
        char output,
        Action<string> writer,
        CursorPosition? cursorPosition = null)
    {
        if (cursorPosition == null)
        {
            writer($"\b{output}");
            return;
        }
    //    var origPos = cursorPosition.G
    }
}