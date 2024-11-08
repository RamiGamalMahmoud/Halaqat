using System;

namespace Halaqat.MainWindow
{
    public record ViewItem(string Title, bool IsEnabled = true, Action Action = null);
}
