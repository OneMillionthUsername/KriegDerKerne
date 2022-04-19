using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KriegDerKerne
{
	class Laser : Player
	{
		private new int PosX;
		private new int PosY;
		private new string Name = "|";

		//leerer Konstruktor
		public Laser() { }
		public Laser(int posX, int posY)
		{
			PosX = posX;
			PosY = posY;
		}
		// methoden
		public void DrawEntity(int PosX, int PosY)
		{
			Console.SetCursorPosition(PosX, PosY); //BUG OVERFLOW
			Console.Write(Name /*+ " x= " + posX + " y= " + posY*/);
		}
		public void DeleteEntity(int PosX, int PosY)
		{
			string temp = Name;
			Name = Name.Replace(Name, new String(' ', Name.Length));
			Console.SetCursorPosition(PosX, PosY); //BUG OVERFLOW
			Console.Write(Name);
			Name = temp;
		}
		public void Shoot(int PosX, int PosY)
		{
			// bringe Cursor in richtiger Position
			PosX += 2;
			PosY -= 1;
			// shoot
			for (int i = 0; i < _maxY; i++)
			{
				Console.SetCursorPosition(PosX, PosY);
				DeleteEntity(PosX, PosY);
				PosY -= 1;
				DrawEntity(PosX, PosY);
				if (PosY == 0)
				{
					DeleteEntity(PosX, PosY);
					break;
				}
				if (PosY == _maxY)
				{
					DeleteEntity(PosX, PosY);
					break;
				}
				Thread.Sleep(100);
			}
		}
	}
}
