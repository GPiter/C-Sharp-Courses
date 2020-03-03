using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    static class Game
    {
        static BaseObject[] objects;
        static Planet earth;
        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;

        static public int Width { get; set; }
        static public int Height { get; set; }

        static Game()
        {

        }

        static public void Init(Form form)
        {
            Graphics gr;
            context = BufferedGraphicsManager.Current;
            gr = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            buffer = context.Allocate(gr, new Rectangle(0, 0, Width, Height));

            Load(); // Загружаем все объекты в игре
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

        static public void Draw()
        {
            buffer.Graphics.Clear(Color.Black);

            foreach(BaseObject obj in objects)
            {
                obj.Draw();
            }

            earth.Draw();

            buffer.Render();
        }

        static public void Load()
        {
            earth = new Planet(new Point(700, 200), new Point(-2, 0), new Size(50, 50));

            objects = new BaseObject[30];
            for (int i = 0; i < objects.Length/2; i++)
                objects[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
            for (int i = objects.Length / 2; i < objects.Length; i++)
                objects[i] = new Star(new Point(600, i * 20), new Point(-i, 100), new Size(5, 5));
            
        }

        static public void Update()
        {
            foreach(BaseObject obj in objects)
            {
                obj.Update();
            }
           
            earth.Update();

        }
    }
}
