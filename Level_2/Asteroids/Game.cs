using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System;

namespace Asteroids
{
    static class Game
    {
        // ------ ОПИСАНИЕ ПОЛЕЙ ------

        // Массив базовых объектов (астероиды, звезды)
        static BaseObject[] objects;
        static List<Asteroid> asteroids = new List<Asteroid>();
        static List<Bullet> bullets = new List<Bullet>();

        // Объект планеты
        static Planet earth;

        // Объект корабля
        static Ship ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));

        // Поля для создания графического буффера
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;

        // Свойства для задания ширины и высоты игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }

        static Timer timer = new Timer();
        static public Random rnd = new Random();

        static int bulletCounter = 0;
        static int asteroidCounter = 3;

        static Game()
        {

        }

        // ------ ОПИСАНИЕ МЕТОДОВ ------

        /* --- Инициализация формы ---
         * Для вывода графики на форму используется класс Graphic.
         * Для того, чтобы убрать мерцание в игре будем выводить графику в промежуточный буфер <buffer>.
         * Для получения графического буфера используется класс BufferedGraphicsManager и его свойство Current.
         * Для связи буфера и графики используется метод Allocate.
         * 
         */
        static public void Init(Form form)
        {
            Graphics gr;
            context = BufferedGraphicsManager.Current;
            gr = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            buffer = context.Allocate(gr, new Rectangle(0, 0, Width, Height));

            // Загрузка всех игровых объектов
            Load(); 

            // Установка таймера для связывания события отрисовки и обновления экрана
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();

            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }

        // Обработка события нажатия на клавиши
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                bullets.Add( new Bullet(new Point(ship.Rect.X + 25, ship.Rect.Y + 26), new Point(4, 0), new Size(4, 1)) );
                bulletCounter++;
            }
            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
        }

        // Каждый тик таймера отрисовываем и обновляем экран
        private static void Timer_Tick(object sender, System.EventArgs e)
        {
            Draw();
            Update();
        }

        // Загрузка всех игровых объектов
        static public void Load()
        {
            earth = new Planet(new Point(700, 200), new Point(-2, 0), new Size(50, 50));
            objects = new BaseObject[30];

            for (int i = 0; i < objects.Length; i++)
            {
                int r = rnd.Next(5, 50);
                objects[i] = new Star(new Point( 600, Game.rnd.Next(0, Game.Height) ), new Point(-r, r), new Size(5, 5));
            }

            for (int i = 0; i < asteroidCounter; i++)
            {
                int r = rnd.Next(5, 50);
                asteroids.Add(new Asteroid(new Point( 600, Game.rnd.Next(0, Game.Height) ), new Point(-r/5, r), new Size(r, r)));
            }

        }

        /* --- Отрисовка формы и игровых объектов ---
         * В начале очищаем экран, закрашивая его черным цветом.
         * Для отрисовки объектов в буффер, вызываем соответствующий метод.
         * После того, как графический кадр сформирован, нужно вывести его на экран методом Render.
         */
        static public void Draw()
        {
            buffer.Graphics.Clear(Color.Black);

            foreach(BaseObject obj in objects)
            {
                obj.Draw();
            }

            foreach(Asteroid asteroid in asteroids)
            {
                if( asteroid != null) asteroid.Draw();
            }

            foreach (Bullet bullet in bullets)
            {
                bullet.Draw();
            }

            earth.Draw();
            ship.Draw();

            buffer.Graphics.DrawString("Energy: " + ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            buffer.Graphics.DrawString("Bullets count: " + bulletCounter, SystemFonts.DefaultFont, Brushes.White, 100, 0);

            buffer.Render();
        }

        // Обновление данных игровых объектов
        static public void Update()
        {
            earth.Update();

            foreach (BaseObject obj in objects)
            {
                obj.Update();
            }

            foreach (Bullet bullet in bullets)
            {
                bullet.Update();
            }

            for (int i = 0; i < asteroids.Count; i++)
            {
                if (asteroids[i] != null)
                {
                    asteroids[i].Update();

                    for (int j = 0; j < bullets.Count; j++)
                        if (asteroids[i] != null && bullets[j].Collision(asteroids[i]))
                        {
                            System.Media.SystemSounds.Hand.Play();
                            asteroids[i] = null;
                            bullets.RemoveAt(j);
                            j--;
                            continue;
                        }

                    if (asteroids[i] != null && ship.Collision(asteroids[i]))
                    {
                        ship.EnergyLow(rnd.Next(1, 10));
                        System.Media.SystemSounds.Asterisk.Play();
                        if (ship.Energy <= 0) ship.Die();
                    }
                }

                if (asteroids[i] == null)
                {
                    asteroids.RemoveAt(i);
                    i--;
                }
            }

            if (asteroids.Count == 0)
            {
                asteroidCounter++;

                for (int i = 0; i < asteroidCounter; i++)
                {
                    int r = rnd.Next(5, 50);
                    asteroids.Add(new Asteroid(new Point(600, Game.rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r)));
                }
            }
        }

        static public void Finish()
        {
            timer.Stop();
            buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            buffer.Render();
        }
    }
}
