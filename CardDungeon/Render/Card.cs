using static CardDungeon.Utils.Iterator;
using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Spectre.Console.Color;
using CardDungeon.Utils;

namespace CardDungeon.Render;

internal class Card
{
    public static Point Size = new Point(16, 6);
    public string Title = "Stub";
    public Content InnerContent = new Content();

    public void Replace(string title, Dictionary<string, string> content)
    {
        Title = title;
        InnerContent.Props = content.ToArray();
    }

    public IRenderable Render()
    {
        if (InnerContent.Length < Size.Y)
        {
            int sideY = Size.Y / 2;
            KeyValuePair<string, string> stubProp = new KeyValuePair<string, string>("stub:", "0");
            KeyValuePair<string, string>[] newContent = Enumerable.Repeat(stubProp, Size.Y).ToArray();
            Array.Copy(InnerContent.Props.ToArray(), 0, newContent, sideY, InnerContent.Length);
            InnerContent.Props = newContent;
        }

        Panel container = new Panel(InnerContent.Render());
        container.Padding = new Padding(1, 0);
        container.Border = BoxBorder.Heavy;
        container.Header = new PanelHeader(Title);
        container.BorderColor(new Color(255, 100, 255));
        return container;
    }


    public class Content
    {
        private bool ContentChanged = true;
        private Grid? Grid;
        private ChangeFlag<KeyValuePair<string, string>[]> props;
        public KeyValuePair<string, string>[] Props
        {
            get { return props.Value; } set { props.Value = value; } 
        }

        public int Length { get { return Props.Length; } }
        public Content()
        {
            KeyValuePair<string, string>[] prop = new KeyValuePair<string, string>[0];
            props = new ChangeFlag<KeyValuePair<string, string>[]>(prop);
        }
        public IRenderable Render()
        {
            if (!props.Changed) return Grid!;
            Grid grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();
            grid.Width = Size.X;
            Do(Length, Props, p => grid.AddRow(new string[] { p.Key, p.Value }));
            Grid = grid;
            props.Changed = false;
            return grid;
        }
    }
}

