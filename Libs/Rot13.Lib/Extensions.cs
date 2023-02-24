namespace CaesarCipher;

public static class Extensions
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
