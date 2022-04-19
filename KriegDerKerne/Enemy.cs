namespace KriegDerKerne
{
	class Enemy : Entity
	{
		//init fields
		private readonly string _name = "\\_I_/";

		//Konstruktor
		public Enemy(int x, int y)
		{
			PosX = x;
			PosY = y;
			Name = _name;
		}
		//Methoden

	}
}
