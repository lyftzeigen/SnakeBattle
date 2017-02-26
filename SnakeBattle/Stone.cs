using System.Drawing;

namespace SnakeBattle
{
	public class Stone : WorldObject
	{
		public Stone(Point position)
		{
			Color = Color.DimGray;
			Position = position;
		}
	}
}
