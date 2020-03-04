using System.Windows.Forms;
using System.Drawing;
using System;

namespace Asteroids
{
    static class Game
    {
        // ------ ОПИСАНИЕ ПОЛЕЙ ------

        // Массив базовых объектов (астероиды, звезды)
        static BaseObject[] objects;
        static Asteroid[] asteroids;

        // Объект планеты
        static Planet earth;

        // Поля для создания графического буффера
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;

        // Свойства для задания ширины и высоты игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }

        static public Random rnd = new Random();

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
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
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
            asteroids = new Asteroid[3];

            for (int i = 0; i < objects.Length; i++)
            {
                int r = rnd.Next(5, 50);
                objects[i] = new Star(new Point( 600, Game.rnd.Next(0, Game.Height) ), new Point(-r, r), new Size(5, 5));
            }

            for (int i = 0; i < asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                asteroids[i] = new Asteroid(new Point( 600, Game.rnd.Next(0, Game.Height) ), new Point(-r/5, r), new Size(r, r));
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

            foreach(BaseObject obj in asteroids)
            {
                obj.Draw();
            }

            earth.Draw();

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

            foreach (BaseObject obj in asteroids)
            {
                obj.Update();
            }

        }
    }
}
