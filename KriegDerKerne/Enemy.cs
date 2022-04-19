using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KriegDerKerne
{
	class Enemy : Entity
	{
		//inti vars
		public new int PosX;
		public new int PosY;
		private new string Name = "\\_I_/";

		//Konstruktor
		public Enemy(int x, int y)
		{
			PosX = x;
			PosY = y;
		}
		//Methoden
		public void DrawEnemy()
		{
			Console.SetCursorPosition(PosX, PosY);
			Console.Write(Name);
		}
		public void DeleteEnemy()
		{
			string temp = Name;
			Name = Name.Replace(Name, new String(' ', Name.Length));
			Console.SetCursorPosition(PosX, PosY);
			Console.Write(Name);
			Name = temp;
		}
	}
}
