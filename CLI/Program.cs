using CaesarCipher;
using Rot13.CLI;

if (args?.Length > 0)
    Console.WriteLine(args[0].Rot13());
else
{
    Console.WriteLine("Ctl-c to exit. Start typing...");
    while (true)
        KeyPressPresenter.Present(
            Console.ReadKey().Rot13(),
            Console.Write,
            new CursorPosition(Console.GetCursorPosition, Console.SetCursorPosition));
}
