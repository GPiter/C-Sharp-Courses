using System.Drawing;

namespace Asteroids
{
    delegate void Message();
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }

    /* -------------- КЛАСС BaseObject --------------
      * 
      *  Базовый класс, который задает общие характеристики и поведение для всех объектов.
      * 
    */
    abstract class BaseObject : ICollision
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
        public abstract void Update();

        // Переопределение метода ToString() для вывода информации об объекте
        public override string ToString()
        {
            return "Pos: " + pos.ToString() + " Dir: " + dir.ToString() + " Size: " + size.ToString(); 
        }

        public bool Collision(ICollision obj)
        {
            if (obj.Rect.IntersectsWith(this.Rect)) return true; else return false;
        }

        public Rectangle Rect
        {
            get { return new Rectangle(pos, size); }
        }

    }

    /* -------------- КЛАСС Star --------------
      * 
      *  Описывает характеристики и поведение для объекта типа "Звезда"
      * 
    */
    class Star : BaseObject
    {
        Image img = Image.FromFile("img\\star.bmp");    // Изображение объекта

        // ------ ОПИСАНИЕ МЕТОДОВ ------
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        // Переопределение метода отрисовки объекта
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y);
        }

        // Переопределение метода обновления объекта
        public override void Update()
        {
            
            pos.X += dir.X;
            if (pos.X < 0)
            {
                pos.X = 900;
                pos.Y = Game.rnd.Next(0, Game.Height);
                dir.X = -Game.rnd.Next(1, 10);
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
        public int Power { get; set; } = 3;

        Image img = Image.FromFile("img\\asteroid.bmp");    // Изображение объекта

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = Game.rnd.Next(1, 4);    // От 1 до 3 выстрелов для разрушения
        }

        public override void Draw()
        {
            //Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y);
            Game.buffer.Graphics.FillEllipse(Brushes.White, pos.X, pos.Y, size.Width, size.Height);
        }

        // Переопределение метода обновления объекта
        public override void Update()
        {

            pos.X += dir.X;
            if (pos.X < 0)
            {
                pos.X = 830;
                pos.Y = Game.rnd.Next(0, Game.Height);
                dir.X = -Game.rnd.Next(1, 10);
            }
        }

        // Обновление объекта в начальное положение
        public void Reset()
        {
            pos.X = 830;
            pos.Y = Game.rnd.Next(0, Game.Height);
            dir.X = -Game.rnd.Next(1, 10);
        }
    }

    /* -------------- КЛАСС Bullet --------------
      * 
      *  Описывает характеристики и поведение для объекта типа "Bullet"
      * 
    */

    class Bullet : BaseObject
    {
        // ------ ОПИСАНИЕ МЕТОДОВ ------

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawRectangle(Pens.OrangeRed, pos.X, pos.Y, size.Width, size.Height);

        }

        public override void Update()
        {
            pos.X += 10;
        }

        // Обновление объекта в начальное положение
        public void Reset()
        {
            pos.X = 10;
            pos.Y = Game.rnd.Next(0, Game.Height);
            dir.X = -Game.rnd.Next(1, 10);
        }
    }

    /* -------------- КЛАСС Ship --------------
      * 
      *  Описывает характеристики и поведение для объекта типа "Корабль"
      * 
    */

    class Ship : BaseObject
    {
        int energy = 100;
        Image img = Image.FromFile("img\\ship.png");    // Изображение объекта
        public static event Message MessageDie;

        public int Energy
        {
            get { return energy; }
        }

        public void EnergyLow(int n)
        {
            energy -= n;
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y);
        }

        public override void Update()
        {
            
        }

        public void Up()
        {
            if (pos.Y > 0) pos.Y = pos.Y - dir.Y;
        }

        public void Down()
        {
            if (pos.Y < Game.Height) pos.Y = pos.Y + dir.Y;
        }

        public void Die()
        {
            if (MessageDie != null) MessageDie();
        }
    }



}
