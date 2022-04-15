using System;
using System.Threading;
using System.Threading.Tasks;

namespace KriegDerKerne
{
	public class Entity
	{
		//leerer Konstruktor
		public Entity() { }
		//Konstruktor für Name
		public Entity(string name)
		{
			Name = name;
		}
		//Felder
		protected string _Name;
		protected int _PosX;
		protected int _PosY;
		protected int _maxX = Console.WindowWidth, _maxY = Console.WindowHeight;
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
				if (_PosX == _maxY)
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
		public async Task DrawEntityAsync(int PosX, int PosY)
		{
			Console.SetCursorPosition(PosX, PosY); //BUG OVERFLOW
			Console.Write(Name /*+ " x= " + posX + " y= " + posY*/);
		}
		public async Task DeleteEntityAsync(int PosX, int PosY)
		{
			string temp = Name;
			Name = Name.Replace(Name, new String(' ', Name.Length));
			Console.SetCursorPosition(PosX, PosY); //BUG OVERFLOW
			Console.Write(Name);
			Name = temp;
		}
	}
}
