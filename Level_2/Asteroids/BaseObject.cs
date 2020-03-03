using System.Drawing;

namespace Asteroids
{
    /*----- КЛАСС BaseObject -----*/
    // Базовый класс, который задает общие характеристики и поведение для всех объектов
    class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;

        //Image img = Image.FromFile("asteroid.bmp");

        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }

        public virtual void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
            //Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y);
        }

        public virtual void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if (pos.X > Game.Width) dir.X = -dir.X;
            if (pos.Y < 0) dir.Y = -dir.Y;
            if (pos.Y > Game.Height) dir.Y = -dir.Y;
        }

        public override string ToString()
        {
            return "Pos: " + pos.ToString() + " Dir: " + dir.ToString() + " Size: " + size.ToString(); 
        }
    }

    /*----- КЛАСС Star -----*/
    // Описывает характеристики и поведение для объекта типа "Звезда"
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height);
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X + size.Width, pos.Y, pos.X, pos.Y + size.Height);
        }

        public override void Update()
        {
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

    class Planet : BaseObject
    {
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.buffer.Graphics.FillEllipse(Brushes.Green, pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X < Game.Width) dir.X = -dir.X;
            if (pos.X > Game.Width/2) dir.X = -dir.X;
            /*
            if (pos.X < Game.Width / 2) dir.X = -dir.X;
            if (pos.X > 0) dir.X = -dir.X;
            */
        }

    }
}
