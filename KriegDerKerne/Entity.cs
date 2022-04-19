using System;
using System.Threading;
using System.Threading.Tasks;

namespace KriegDerKerne
{
	public abstract class Entity
	{
		//leerer Konstruktor
		public Entity() { }
		//Konstruktor für Name
		public Entity(string name)
		{
			Name = name;
		}
		//Felder
		private string _Name;
		private int _PosX;
		private int _PosY;
		internal int _maxX = Console.WindowWidth-1, _maxY = Console.WindowHeight-1;
		//properties
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		public int PosX
		{
			get { return _PosX; }
			set
			{
				_PosX = value;

				if (_PosX == 0)
				{
					_PosX += 1;
				}
				if (_PosX == _maxX)
				{
					_PosX -= 1;
				}
			}
		}
		public int PosY
		{
			get { return _PosY; }

			set
			{
				_PosY = value;

				if (_PosY == 0)
				{
					_PosY += 1;
				}
				if (_PosY == _maxY)
				{
					_PosY -= 1;
				}
			}
		}
		//methods
		void DrawEntity(int PosX, int PosY)
		{
			Console.SetCursorPosition(PosX, PosY);
			Console.Write(Name);
		}
		void DeleteEntity(int PosX, int PosY)
		{
			string temp = Name;
			Name = Name.Replace(Name, new String(' ', Name.Length));
			Console.SetCursorPosition(PosX, PosY);
			Console.Write(Name);
			Name = temp;
		}
	}
}
