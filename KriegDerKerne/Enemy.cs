namespace KriegDerKerne
{
	class Enemy : Entity
	{
		//init fields
		private readonly string _name = "\\_I_/";

		//Konstruktor
		public Enemy(int posX, int posY)
		{
			PosX = posX;
			PosY = posY;
			Name = _name;
		}
		//Methoden
	}
}
