// See https://aka.ms/new-console-template for more information
using CardDungeon.Render;
using CardDungeon.Utils;
using System.Drawing;
using Spectre.Console;
class Program
{
    static void Main(string[] args)
    {

        int[] arr = { 2, 4, 8 };

        GameRender gr = new GameRender(new Point(3, 3));
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("abc", "bcabca");
        gr.Update(new Point(1, 1), "abc", dic);
        AnsiConsole.Write(gr.Render());
        Iterator.Iterate(arr, (e, i) => { Console.WriteLine($"{e}:{i}"); });


        //Console.WriteLine(Enumerable.Range(0, 3).Count());
        //AnsiConsole.Markup("[underline red]Hello[/] World!");
        //AnsiConsole.Markup("[green]This is all green[/]");
        //Panel panel = new Panel("Hello World");
        //panel.Header = new PanelHeader("test");
        //var table = new Table();
        //table.AddColumn("").Centered();
        //table.AddColumn(new TableColumn(panel).Centered());
        //table.Border(TableBorder.None);
        //table.AddRow(panel, panel);
        //table.AddRow(panel, panel);
        //AnsiConsole.Write(table);
    }
}
