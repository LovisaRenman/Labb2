﻿
abstract class Enemy : Creature
{
    public void AttackPlayer(bool hasMoved, Directions direction, LevelData levelData, List<LevelElement> list)
    {
        if (!hasMoved)
        {            
            if (levelData.Player is Player && CoordX - 1 == levelData.Player.CoordX && CoordY == levelData.Player.CoordY && direction == Directions.left)
            {
                AttackAnimation(-1);
                DamagePlayer(levelData.Player, levelData.enemiesToRemove);
            }
            else if (levelData.Player is Player && CoordX + 1 == levelData.Player.CoordX && CoordY == levelData.Player.CoordY && direction == Directions.right)
            {
                AttackAnimation(1);
                DamagePlayer(levelData.Player, levelData.enemiesToRemove);
            }
            else if (levelData.Player is Player && CoordX == levelData.Player.CoordX && CoordY - 1 == levelData.Player.CoordY && direction == Directions.up)
            {
                AttackAnimation(-2);
                DamagePlayer(levelData.Player, levelData.enemiesToRemove);
            }
            else if (levelData.Player is Player && CoordX == levelData.Player.CoordX && CoordY + 1 == levelData.Player.CoordY && direction == Directions.down)
            {
                AttackAnimation(2);
                DamagePlayer(levelData.Player, levelData.enemiesToRemove);
            }
        }
    }
    public void DamagePlayer(LevelElement player, List<LevelElement> enemiesToRemove)
    {
        if (player is Player p && this is Rat)
        {
            int damage = RatAttackDice.Throw() - p.PlayerDefenceDice.Throw();
            if (damage <= 0) damage = 0;
            else p.HealthPoints = p.HealthPoints - damage;
            WriteAttack(player, damage);

            if (p.HealthPoints > 0)
            {
                damage = p.PlayerAttackDice.Throw() - RatDefenceDice.Throw();
                if (damage <= 0) damage = 0;
                else HealthPoints = HealthPoints - damage;
                p.WriteAttack(this, damage);

                if (HealthPoints < 0)
                {
                    IsAlive = false;
                    enemiesToRemove.Add(this);
                }
            }
            else p.IsAlive = false;

        }
        else if (player is Player pl && this is Snake)
        {
            int damage = SnakeAttackDice.Throw() - pl.PlayerDefenceDice.Throw();
            if (damage <= 0) damage = 0;
            else pl.HealthPoints = pl.HealthPoints - damage;
            WriteAttack(player, damage);

            if (pl.HealthPoints > 0)
            {
                damage = pl.PlayerAttackDice.Throw() - SnakeDefenceDice.Throw();
                if (damage <= 0) damage = 0;
                else HealthPoints = HealthPoints - damage;
                pl.WriteAttack(this, damage);

                if (HealthPoints < 0) 
                {
                    IsAlive = false;
                    enemiesToRemove.Add(this);
                }
            }
            else pl.IsAlive = false;
        }
    }
}