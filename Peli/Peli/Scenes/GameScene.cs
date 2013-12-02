using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uppercut.Components;
using Microsoft.Xna.Framework;
using Peli.Engine;
using Peli.Objects;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Peli.Scenes
{
    class GameScene:SceneParent
    {
        Timer color_change;
        Timer font_color_change;
        Color font_väri = new Color(100, 100, 100);

        Color väri = new Color(100, 100, 100);

        List<Bullet> bullets = new List<Bullet>();
        List<Enemy> enemies = new List<Enemy>();
        List<Boss> bosses = new List<Boss>();
        public static List<BossBullet> boss_bullets = new List<BossBullet>();
        Boolean cheat = false;
        Player player;
        Timer enemy_spawn_timer;
        Timer boss_spawn_timer;
        Random random = new Random();
        int killed = 0;
        ScrollingBackground background1;
        ScrollingBackground background2;
        public GameScene()
            :base()
        {
            background1 = new ScrollingBackground(Vector2.Zero, 80, new Sprite(Resources.GetTexture("sky")));
            background2 = new ScrollingBackground(new Vector2(-224, -200), 80, new Sprite(Resources.GetTexture("sky")));
            player = new Player(Resources.GetTexture("Ship"), new Vector2(100, 100), 5);

            enemy_spawn_timer = new Timer(1500);
            boss_spawn_timer = new Timer(10000);

            color_change = new Timer(1000);
            font_color_change = new Timer(100);
            Game1.camera.addZoom(0.5f);
            Vector2 offset = new Vector2(Game1.screen_size.Width, Game1.screen_size.Height) * 0.5f;
            Game1.camera.PositionOffset = offset;
            Game1.camera.setOffset(offset);
        }


        public override void Update(float dT)
        {
            Console.WriteLine("Enemy amount: " + enemies.Count + "\nBullet amount: " + bullets.Count);
            Console.WriteLine("Enemies killed: " + killed);
            if (Input.isCheat())
                cheat = !cheat;
            if (Input.IsKeyPressed(Keys.M))
            {
                SceneSys.PauseCurrentScene(true);
                SceneSys.OpenScene(new MenuScene());
            }
            if (!player.IsDead)
            {
                if (!cheat)
                {
                    if (Input.IsKeyPressed(Keys.Space))
                    {
                        //for (int i = 0; i < 10000; i++)
                        bullets.Add(new Bullet(Resources.GetTexture("Bullet"), player.Position, 750));
                    }
                }
                else
                {
                    if (Input.IsKeyDown(Keys.Space))
                    {
                        //for(int i = 0;i< 10;i++)
                        bullets.Add(new Bullet(Resources.GetTexture("Bullet"), player.Position, 750));
                    }
                }
                if (Input.IsKeyDown(Keys.Tab))
                {
                    //for(int i = 0;i< 100;i++)
                    enemies.Add(new Enemy(Resources.GetTexture("Ship"), new Vector2(Game1.screen_size.Width, random.Next(Game1.screen_size.Height)), 50));
                }

                if (enemy_spawn_timer.Update(dT))
                {
                    enemies.Add(new Enemy(Resources.GetTexture("enemy"), new Vector2(Game1.screen_size.Width, random.Next(Game1.screen_size.Height)), 500));
                    if (enemy_spawn_timer.Delay > 300)
                        enemy_spawn_timer.Delay -= 100;
                }
                if (boss_spawn_timer.Update(dT))
                {
                    bosses.Add(new Boss(Resources.GetTexture("boss"), new Vector2(Game1.screen_size.Width, random.Next(Game1.screen_size.Height)), 500));
                    if (boss_spawn_timer.Delay > 2000)
                        boss_spawn_timer.Delay -= 500;
                }

            }

            //Game object updates
            if (!player.IsDead)
                player.Update(dT);
            foreach (Enemy item in enemies)
            {
                item.Update(dT);
                if (item.Position.X < 0)
                {
                    item.IsDead = true;
                }
                if (!player.IsDead)
                {
                    if (item.CollisionRect.Intersects(player.CollisionRect))
                    {
                        if (!player.IsDead)
                        {
                            player.decHp();
                            if (player._hp == 0)
                            {
                                player.IsDead = true;
                            }
                        }

                        item.IsDead = true;
                    }
                }

            }
            foreach (Boss item in bosses)
            {
                item.Update(dT);
            }
            foreach (BossBullet item in boss_bullets)
            {
                item.Update(dT);
                if (item.CollisionRect.Intersects(player.CollisionRect))
                {
                    player.decHp();
                    if (player._hp == 0)
                    {
                        player.IsDead = true;
                    }
                    item.IsDead = true;
                }

            }
            foreach (Bullet item in bullets)
            {

                item.Update(dT);
                foreach (Enemy e in enemies)
                {
                    if (item.CollisionRect.Intersects(e.CollisionRect))
                    {
                        e.IsDead = true;
                        item.IsDead = true;
                        killed++;
                    }
                    if (item.Position.X > Game1.screen_size.Width)
                    {
                        item.IsDead = true;
                    }

                }
                foreach (BossBullet a in boss_bullets)
                {
                    if (item.CollisionRect.Intersects(a.CollisionRect))
                    {
                        item.IsDead = true;
                        a.IsDead = true;
                    }
                }

                foreach (Boss b in bosses)
                {
                    if (item.CollisionRect.Intersects(b.CollisionRect))
                    {
                        item.IsDead = true;
                        b.losehealth();
                    }
                }

            }
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e = enemies[i];
                if (e.IsDead)
                {
                    enemies.Remove(e);
                    i--;
                }
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                Bullet e = bullets[i];
                if (e.IsDead)
                {
                    bullets.Remove(e);
                    i--;
                }
            }
            for (int i = 0; i < bosses.Count; i++)
            {
                Boss e = bosses[i];
                if (e.IsDead)
                {
                    bosses.Remove(e);
                    i--;
                }
            }
            for (int i = 0; i < boss_bullets.Count; i++)
            {
                BossBullet e = boss_bullets[i];
                if (e.IsDead)
                {
                    boss_bullets.Remove(e);
                    i--;
                }
            }
            //isku_sprite.Update(dT);
            background1.Update(dT);
            background2.Update(dT);
            Game1.camera.Position = player.Position;
            Vector2 offset = Game1.camera.PositionOffset / Game1.camera.getZoom();
            if (Game1.camera.Position.X < offset.X)
                Game1.camera.Position.X = offset.X;
            if (Game1.camera.Position.X > Game1.screen_size.Width - offset.X)
                Game1.camera.Position.X = Game1.screen_size.Width - offset.X;

            if (Game1.camera.Position.Y < offset.Y)
                Game1.camera.Position.Y = offset.Y;
            if (Game1.camera.Position.Y > Game1.screen_size.Width - offset.Y)
                Game1.camera.Position.Y = Game1.screen_size.Width - offset.Y;

        }
        public override void Draw(float deltaTime)
        {
            if (color_change.Update(deltaTime))
                väri = new Color(random.Next(250), random.Next(250), random.Next(250));

            background1.Draw();
            background2.Draw();

            //here we shall draw
            foreach (Bullet item in bullets)
            {
                item.Draw();
            }
            foreach (Enemy item in enemies)
            {
                item.Draw();
            }
            foreach (Boss item in bosses)
            {
                item.Draw();
            }
            foreach (BossBullet item in boss_bullets)
            {
                item.Draw();
            }
            if (font_color_change.Update(deltaTime))
                font_väri = new Color(random.Next(250), random.Next(250), random.Next(250));
            if (bosses.Count == 1 && !player.IsDead)
                DrawSys.DrawText("Wild boss appeared", Resources.GetFont("font"), new Vector2(250, 400), font_väri);
            else if(bosses.Count > 1 && !player.IsDead)
                DrawSys.DrawText("Wild boss appeared x" + bosses.Count, Resources.GetFont("font"), new Vector2(250, 400), font_väri);
            if (!player.IsDead)
                player.Draw();
            else
                DrawSys.DrawText("Game Over", Resources.GetFont("font"), new Vector2(220, 200), Color.Red);
        }
    }
}
