namespace Rot13.CLI;

internal static class KeyPressPresenter
{
    public static void Present(
        char output,
        Action<string> writer,
        CursorPosition? cursorPosition = null)
    {
        if (output == '\b')
        {
            writer($"{output}");
        }
        if (cursorPosition == null)
        {
            writer($"\b{output}");
            return;
        }
        var origPos = cursorPosition.GetPosition();
        SetPosition(cursorPosition, origPos);
        writer($"{output}");
        ResetPosition(cursorPosition, origPos);
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

    private static void ResetPosition(
        CursorPosition cursorPosition,
        (int Left, int Top) origPos)
    {
        cursorPosition.SetPosition(origPos.Left, origPos.Top);
    }
}