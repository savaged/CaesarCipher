namespace Rot13.CLI;

internal static class KeyPressPresenter
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
        var origPos = cursorPosition.GetPosition();
        cursorPosition.SetPosition(origPos.Left - 1, origPos.Top + 1);
        writer(output.ToString());
        cursorPosition.SetPosition(origPos.Left, origPos.Top);
    }

    private static void SetPosition(
        CursorPosition cursorPosition,
        (int Left, int Top) origPos)
    {
        try
        {
            cursorPosition.SetPosition(origPos.Left - 1, origPos.Top + 1);
        }
        catch (ArgumentOutOfRangeException)
        {
            cursorPosition.SetPosition(1, 1);
        }
    }
}