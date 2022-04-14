using System;

namespace KriegDerKerne
{
	class Entity
	{
		private string _Name;
		private protected int maxX = Console.WindowWidth, maxY = Console.WindowHeight;
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private int _PosX; // my var

		public int PosX // my property
		{
			get { return _PosX; }
			set
			{
				_PosX = value;

				if (_PosX == 0)
				{
					_PosX += 1;
				}
				if (_PosX == maxY)
				{
					_PosX -= 1;
				}
			}
		}

		private int _PosY; // my var

		public int PosY // my property
		{
			get { return _PosY; }

			set
			{
				_PosY = value;

				if (_PosY == 0)
				{
					_PosY += 1;
				}
				if (_PosY == maxY)
				{
					_PosY -= 1;
				}
			}
		}

		public void DrawEntity(int posX, int posY)
		{
			Console.SetCursorPosition(posX, posY); //BUG OVERFLOW
			Console.Write(Name /*+ " x= " + posX + " y= " + posY*/);
		}
		public void DeleteEntitiy(int posX, int posY)
		{
			string temp = Name;
			Name = Name.Replace(Name, new String(' ', Name.Length));
			Console.SetCursorPosition(posX, posY); //BUG OVERFLOW
			Console.Write(Name);
			Name = temp;
		}
	}
}
