namespace Rot13.CLI;

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
