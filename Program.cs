if (args?.Length > 0)
    Console.WriteLine(args[0].Rot13());
else
{
    Console.WriteLine("Ctl-c to exit. Start typing...");
    while (true)
        Presenter(
            Console.ReadKey().Rot13(),
            Console.Write,
            new CursorPosition(Console.GetCursorPosition, Console.SetCursorPosition));
}

static void Presenter(
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

internal class CursorPosition
{
    private readonly Func<(int Left, int Top)> _getter;
    private readonly Action<int, int> _setter;
    
    public CursorPosition(Func<(int Left, int Top)> getter, Action<int, int> setter)
    {
        _getter = getter ?? throw new ArgumentNullException(nameof(getter));
        _setter = setter ?? throw new ArgumentNullException(nameof(setter));
    }

    public (int Left, int Top) GetPosition() => _getter();

    public void SetPosition(int left, int top) => _setter(left, top);
}

internal static class CaesarCipher
{
    public static char[] Rot13(this string self) =>
        self.ToCharArray().Rot13();
    
    public static char Rot13(this ConsoleKeyInfo self) =>
        self.KeyChar.Rot13();

    private static char[] Rot13(this IEnumerable<char> self) =>
        self.Select(c => c.Rot13()).ToArray();
    
    private static char Rot13(this char self) =>
        self switch
        {
            >= 'a' and <= 'm' or >= 'A' and <= 'M' => (char)(self + 13),
            >= 'n' and <= 'z' or >= 'N' and <= 'Z' => (char)(self - 13),
            _ => self
        };
}