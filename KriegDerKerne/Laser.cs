namespace KriegDerKerne
{
	class Laser : Player
	{
		//init fields
		private readonly string _name = "|";

		//Konstruktor
		public Laser(int posX, int posY)
		{
			PosX = posX;
			PosY = posY;
			Name = _name;
		}
		// Methoden
	}
}
