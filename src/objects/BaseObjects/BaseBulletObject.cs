using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{

	enum BulletType
	{
		PlayerBulletCard,
		EnemyBlueMidBall,
		StaticDebugBullet
	}

	class Bullet : BaseObject
	{

		private BulletType bulletType;

		private Texture2D texture;
		private Rectangle textureRect;
		private float textureRotation;

		private int speed;
		private float angle;
		private Vector2 velocity;
		public bool isPlayerBullet;
		public Rectangle collision;

		public bool isDeleted;

		public Bullet(Vector2 pos, int speed, float angle, BulletType type)
		{
			bulletType = type;
			isDeleted = false;
			switch(bulletType)
			{
				case BulletType.PlayerBulletCard:
					texture = GlobalResources.PlayerBulletCardTexture;
					textureRect = new Rectangle(4, 179, 61, 13);
					textureRotation = -90;
					collision = new Rectangle(Position, 10, 50);
					isPlayerBullet = true;
				break;

				case BulletType.EnemyBlueMidBall:
					texture = GlobalResources.EnemyBlueMidBallTexture;
					textureRect = new Rectangle(97, 49, 16, 16);
					textureRotation = 0;
					collision = new Rectangle(Position, 16, 16);
					isPlayerBullet = false;
				break;

				case BulletType.StaticDebugBullet:
					texture = GlobalResources.EnemyBlueMidBallTexture;
					textureRect = new Rectangle(97, 49, 16, 16);
					textureRotation = 0;
					collision = new Rectangle(Position, 16, 16);
					isPlayerBullet = false;
				break;
			}

			Position = pos;
			this.speed = speed;
			this.angle = angle;
		}

		public override void Draw()
		{
			base.Draw();
			//BeginBlendMode(BlendMode.Additive);
			DrawTexturePro(texture, textureRect, new Rectangle(Position.X, Position.Y, textureRect.Width, textureRect.Height), new Vector2(textureRect.Width/2, textureRect.Height/2), textureRotation, Color.White);
			//EndBlendMode();
			// if(Debug.Debugging)
			// {
			// 	DrawRectangleRec(collision, new Color(45, 127, 222, 200));
			// }
		}

		public override void Update()
		{
			base.Update();
			UpdateCollision();

			velocity = new Vector2(MathF.Cos(angle) * speed, MathF.Sin(angle) * speed);

			if(Position.Y < 0 - 500 || Position.X < 0 - 500 || Position.X >= 450 + 500 || Position.Y >= 540 + 500)
			{
				isDeleted = true;
			}
			if(bulletType != BulletType.StaticDebugBullet)
			{
				Position += velocity;
			}
		}

		public override void Unload()
		{
			base.Unload();
			//UnloadTexture(texture);
		}

		private void UpdateCollision()
		{
			switch(bulletType)
			{
				case BulletType.PlayerBulletCard:
					collision = new Rectangle(Position.X - 5, Position.Y - 35, collision.Width, collision.Height);
				break;

				case BulletType.EnemyBlueMidBall:
					collision = new Rectangle(Position.X - 7, Position.Y - 7, collision.Width, collision.Height);
				break;
			}
		}
	}
}