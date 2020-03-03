using System.Windows.Forms;

namespace Asteroids
{

/*
 * Класс Program
 * Создание шаблона приложения, где подключаем модули
 * 
 */
    class Program
    {  
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
