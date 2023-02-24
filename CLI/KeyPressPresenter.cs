namespace Rot13.CLI;

internal static class KeyPressPresenter
{
    public static void Present(
        char output,
        Action<string> writer,
        Func<(int Left, int Top)>? cursorPositionGetter = null,
        Action<int, int>? cursorPositionSetter = null)
    {
        if (output == 127)
        {
            writer($"\b\b");
            return;
        }
        if (cursorPositionGetter == null
            || cursorPositionSetter == null)
        {
            writer($"\b{output}");
            return;
        }
        Write(output,
            cursorPositionGetter(),
            writer,
            cursorPositionSetter);
    }

    private static void Write(
        char output,
        (int Left, int Top) origPos,
        Action<string> writer,
        Action<int, int> cursorPositionSetter)
    {
        SetPosition(cursorPositionSetter, origPos);
        writer($"{output}");
        ResetPosition(cursorPositionSetter, origPos);
    }

    private static void SetPosition(
        Action<int, int> cursorPositionSetter,
        (int Left, int Top) origPos)
    {
        try
        {
            cursorPositionSetter(origPos.Left - 1, origPos.Top + 1);
        }
        catch (ArgumentOutOfRangeException)
        {
            cursorPositionSetter(1, 1);
        }
    }

    private static void ResetPosition(
        Action<int, int> cursorPositionSetter,
        (int Left, int Top) origPos)
    {
        cursorPositionSetter(origPos.Left, origPos.Top);
    }
}