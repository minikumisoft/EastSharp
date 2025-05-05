using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class BaseEnemy : BaseObject
	{
		public enum EnemyMoveType
		{
			Static,
			LinearMove
		}

		public Texture2D texture{get; set;}
		public Rectangle textureRect{get; set;}

		public EnemyMoveType enemyMoveType;
		public List<Bullet> globalBullets;
		public List<Bullet> bullets;
		public Vector2 velocity;
		public float speed{get; set;}
		public float angle{get; set;}
		public float HP{get; set;}
		public bool isDeleted{get; set;}

		public override void Draw()
		{
			base.Draw();
		}

		public override void Update()
		{
			base.Update();

			if(HP < 0)
			{
				isDeleted = true;
			}

			switch(enemyMoveType)
			{
				case EnemyMoveType.LinearMove:
					velocity = new Vector2(MathF.Cos(angle) * speed, MathF.Sin(angle) * speed);
					Position += velocity;
				break;
			}
		}

		public override void Unload()
		{
			base.Unload();
			UnloadTexture(texture);
		}

		public void sukaAddThisShitToGlobalBulletsMotherfucker()
		{
			for(int i = 0; i < bullets.Count(); i++)
			{
				globalBullets.Add(bullets[i]);
			}
		}
	}
}