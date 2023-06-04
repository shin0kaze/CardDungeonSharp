using static CardDungeon.Utils.Iterator;
using static System.Linq.Enumerable;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using System.Collections;

namespace CardDungeon.Render
{
	internal class GameRender
	{
		public Card[,] cards;
		public GameRender(Point fieldSize)
		{
			cards = new Card[fieldSize.X, fieldSize.Y];
			Fill(cards, () => new Card());
        }
		
		public void Update(Point index, string title, Dictionary<string, string> content)
		{
            cards[index.X, index.Y].Replace(title, content);
		}

		public IRenderable Render()
		{
			Grid field = new Grid();
			int fieldWidth = cards.GetLength(0);
			int fieldHeight = cards.GetLength(1);
			Do(fieldWidth, () => field.AddColumn());
            for (int i=0; i < fieldHeight; i++)
			{
				Card[] cardRow = GetRow(cards, i);
                IRenderable[] row = Array.ConvertAll(cardRow, x => x.Render());
                field.AddRow(row);
			}
			return field;
		}

	}
}
