using MenuBuilder.Menu.Models;

namespace MenuBuilder.Menu.Renderer;
internal static class ConsoleDraw
{
    public static void WriteAtPosition(Vector2 position, string text, ConsoleColor fgColor, ConsoleColor bgColor)
    {
        var tempBackgroundColor = Console.BackgroundColor;
        var tempFontColor = Console.ForegroundColor;
        Console.BackgroundColor = bgColor;
        Console.ForegroundColor = fgColor;

        Console.SetCursorPosition(position.X, position.Y);
        Console.Write(text);

        Console.BackgroundColor = tempBackgroundColor;
        Console.ForegroundColor = tempFontColor;
    }

    public static void WriteAtPosition(Vector2 position, string text, ConsoleColor fgColor, ConsoleColor bgColor, ConsoleColor markedColor, bool isMarked)
    {
        var tempBackgroundColor = Console.BackgroundColor;
        var tempFontColor = Console.ForegroundColor;

        if (isMarked)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = markedColor;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write("[");
            Console.ForegroundColor = fgColor;
            Console.Write(text);
            Console.ForegroundColor = markedColor;
            Console.Write("]");
        }
        else
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write($" {text} ");
        }

        Console.BackgroundColor = tempBackgroundColor;
        Console.ForegroundColor = tempFontColor;
    }

    public static void BorderCorner(Vector2 startPosition, Vector2 gridSize, ConsoleColor borderColor, int cornerSize)
    {
        if (gridSize.X < 2 || gridSize.Y < 2)
            throw new ArgumentOutOfRangeException(nameof(gridSize));

        var leftTop = "╔";
        var rightTop = "╗";
        var horizontalBlankSize = gridSize.X - 2 - 2 * cornerSize;
        string rowMiddle = horizontalBlankSize > 0
            ? new string('═', cornerSize) + new string(' ', gridSize.X - 2 - 2 * cornerSize) + new string('═', cornerSize)
            : new string('═', gridSize.X - 2);
        var leftBottom = "╚";
        var rightBottom = "╝";
        var leftRightEdge = "║";

        var topRow = leftTop + rowMiddle + rightTop;
        var bottomRow = leftBottom + rowMiddle + rightBottom;

        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = borderColor;

        for (var y = startPosition.Y; y < startPosition.Y + gridSize.Y; y++)
        {
            if (y == startPosition.Y)
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.WriteLine(topRow);
            }
            else if (y == startPosition.Y + gridSize.Y - 1)
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.Write(bottomRow);
            }
            else if (y < startPosition.Y + cornerSize || y > startPosition.Y + gridSize.Y - 1 - cornerSize)
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.Write(leftRightEdge);
                Console.SetCursorPosition(startPosition.X + gridSize.X - 1, y);
                Console.Write(leftRightEdge);
            }
        }
        Console.ForegroundColor = previousColor;
    }

    public static void Border(Vector2 startPosition, Vector2 gridSize)
        => Border(startPosition, gridSize, ConsoleColor.Black);
    public static void Border(Vector2 startPosition, Vector2 gridSize, ConsoleColor borderColor)
    {
        // ╔ ═ ╗ ╚ ╝ ║ 
        // |

        if (gridSize.X < 3 || gridSize.Y < 3)
            throw new ArgumentOutOfRangeException(nameof(gridSize));

        var leftTop = "╔";
        var rightTop = "╗";
        var rowMiddle = new string('═', gridSize.X - 2);
        var leftBottom = "╚";
        var rightBottom = "╝";
        var leftRightEdge = "║";

        var topRow = leftTop + rowMiddle + rightTop;
        var bottomRow = leftBottom + rowMiddle + rightBottom;

        var previousColor = Console.ForegroundColor;
        Console.ForegroundColor = borderColor;

        for (var y = startPosition.Y; y < startPosition.Y + gridSize.Y; y++)
        {
            if (y == startPosition.Y)
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.Write(topRow);
            }
            else if (y == startPosition.Y + gridSize.Y - 1)
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.Write(bottomRow);
            }
            else
            {
                Console.SetCursorPosition(startPosition.X, y);
                Console.Write(leftRightEdge);
                Console.SetCursorPosition(startPosition.X + gridSize.X - 1, y);
                Console.Write(leftRightEdge);
            }
        }
        Console.ForegroundColor = previousColor;
    }
}

