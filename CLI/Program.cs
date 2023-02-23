﻿using CaesarCipher;
using Rot13.CLI;

if (args?.Length > 0)
    Console.WriteLine(args[0].Rot13());
else
{
    Console.WriteLine("Start typing (Return key to exit)");
    PresentUntilReturnKey();
}

static void PresentUntilReturnKey(char output = '\0')
{
    if (output != 0)
    {
        if (output == '\r') return;
        Present(
            output,
            Console.Write,
            new CursorPosition(Console.GetCursorPosition, Console.SetCursorPosition));
    }
    PresentUntilReturnKey(Console.ReadKey().Rot13());
}

static void Present(char output, Action<string> writer, CursorPosition cursorPosition) =>
    KeyPressPresenter.Present(output, writer, cursorPosition);
