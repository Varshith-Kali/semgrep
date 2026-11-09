// C# 12 collection expressions with a trailing comma (gh-12033).
// `[Color.Red, Color.Green,]` used to fail to parse: the scan reported
// PartialParsing and silently dropped rule matches after the expression
// in the same method. Every method below must parse, including the
// statement that follows the collection expression.

namespace Repro;

public enum Color { Red, Green }

public static class CollectionTrailingComma
{
    public static void MemberAccess(string cmd)
    {
        Color[] items = [Color.Red, Color.Green,];
        System.Diagnostics.Process.Start(cmd);
    }

    public static void Identifiers(string cmd)
    {
        int a = 1;
        int b = 2;
        int[] xs = [a, b,];
        System.Diagnostics.Process.Start(cmd);
    }

    public static void SingleElement(string cmd)
    {
        Color[] one = [Color.Red,];
        System.Diagnostics.Process.Start(cmd);
    }

    public static void Multiline(string cmd)
    {
        Color[] items =
        [
            Color.Red,
            Color.Green,
        ];
        System.Diagnostics.Process.Start(cmd);
    }
}
