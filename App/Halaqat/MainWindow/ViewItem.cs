using System;

namespace Halaqat.MainWindow
{
    public record ViewItem(string Title, Action Action = null, bool IsEnabled = true);
}
