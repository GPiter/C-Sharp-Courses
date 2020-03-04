using System.Drawing;

namespace Asteroids
{

    /* -------------- КЛАСС BaseObject --------------
      * 
      *  Базовый класс, который задает общие характеристики и поведение для всех объектов.
      * 
    */
    abstract class BaseObject
    {
        // ------ ОПИСАНИЕ ПОЛЕЙ ------

        protected Point pos;    // Позиция на экране
        protected Point dir;    // Направление движения
        protected Size size;    // Размер объекта

        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        // ------ ОПИСАНИЕ МЕТОДОВ ------

        // Отрисовка объекта в буффер
        public abstract void Draw();

        // Обновление объекта на следующем кадре
        public virtual void Update()
        {
            pos.X += dir.X;
            if (pos.X < 0) pos.X = Game.Width + size.Width;
        }

        // Переопределение метода ToString() для вывода информации об объекте
        public override string ToString()
        {
            return "Pos: " + pos.ToString() + " Dir: " + dir.ToString() + " Size: " + size.ToString(); 
        }
    }

    /* -------------- КЛАСС Star --------------
      * 
      *  Описывает характеристики и поведение для объекта типа "Звезда"
      * 
    */
    class Star : BaseObject
    {
        // ------ ОПИСАНИЕ МЕТОДОВ ------
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        // Переопределение метода отрисовки объекта
        public override void Draw()
        {
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height);
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X + size.Width, pos.Y, pos.X, pos.Y + size.Height);
        }

        // Переопределение метода обновления объекта
        public override void Update()
        {
            /*
            pos.X += dir.X;
            if (pos.X < 0)
            {
                pos.X = 900;
                pos.Y = Game.rnd.Next(0, Game.Height);
                dir.X = -Game.rnd.Next(1, 10);
            }
            */
            
            pos.X += dir.X;
            if (pos.X < 0)
            {
                pos.X = Game.Width + size.Width;
                pos.Y += dir.Y;
                if (pos.Y > Game.Height) dir.Y = -dir.Y;
                if (pos.Y < 0) dir.Y = -dir.Y;
            }
            

        }
    }

    /* -------------- КЛАСС Planet --------------
      * 
      *  Описывает характеристики и поведение для объекта типа "Планета"
      * 
    */

    class Planet : BaseObject
    {
        Image img = Image.FromFile("img\\earth.bmp");

        // ------ ОПИСАНИЕ МЕТОДОВ ------

        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y);
        }

        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X < Game.Width) dir.X = -dir.X;
            if (pos.X > Game.Width/2) dir.X = -dir.X;
        }

    }

    /* -------------- КЛАСС Asteroid --------------
      * 
      *  Описывает характеристики и поведение для объекта типа "Астероид"
      * 
    */
    class Asteroid : BaseObject
    {
        public int Power { get; set; }

        Image img = Image.FromFile("img\\asteroid.bmp");    // Изображение объекта

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y);
        }
    }
}
