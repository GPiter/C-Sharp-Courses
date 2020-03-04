using System.Windows.Forms;

namespace Asteroids
{

/* ----- КЛАСС Program -----
  * 
  *   Отвечает за:
  * - создание формы;
  * - инициализацию и отрисовку игрового поля.
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
