﻿
class Rat : Entity
{
    public Rat(int xCord, int yCord)
    {
        CharacterChar = 'r';
        CharacterColor = ConsoleColor.Red;

        CoordX = xCord;
        CoordY = yCord;

        HealthPoints = 10;
    }

    public override void Move()
    {
        throw new NotImplementedException();
    }
}