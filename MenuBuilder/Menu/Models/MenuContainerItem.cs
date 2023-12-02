using ConsoleExtensions.Menu.Abstract;
using ConsoleExtensions.Models;
using ConsoleExtensions.Renderer;

namespace ConsoleExtensions.Menu.Models;
internal class MenuContainerItem<T> : IMenuContainerItem<T>
{
    public bool IsMarked { get; set; }
    public T Value { get; set; }
    public string Title { get; set; }
    public Vector2 Position { get; set; }
    public bool IsSelected { get; set; }

    public MenuContainerItem(T value)
    {
        Value = value;
        Title = value.ToString();
    }

    public Vector2 AreaNeeded() => new(Title.Length + 2, 1);
    public void Render()
    {
        ConsoleDraw.WriteAtPosition(Position, Title, ConsoleColor.Black, ConsoleColor.Gray, ConsoleColor.Blue, IsSelected);
    }

    public void RenderSelection() => ConsoleDraw.WriteAtPosition(Position, Title, ConsoleColor.Black, ConsoleColor.Gray, ConsoleColor.Blue, IsMarked);
}
