using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class UserUp
    {

    }
    class User : UserUp
    {
        public delegate void UserHandler(string message);
        public event UserHandler MoveEvent;
        public event UserHandler CompressEvent;
        public User(int x, int y, int cr)
        {
            X = x;
            Y = y;
            CompressionRatio = cr;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int CompressionRatio { get; set; }
        public void Move(int x, int y)
        {
            X += x;
            Y += y;
            MoveEvent?.Invoke($"Смещение на x = {x}, y = {y}");
        }
        public void Compress(int cr)
        {
            if (CompressionRatio + cr >= 0 && CompressionRatio + cr <= 100)
            {
                CompressionRatio += cr;
                CompressEvent?.Invoke($"Сжато на {cr}%");
            }
            else
            {
                CompressEvent?.Invoke($"Коэффициент сжатия не может быть меньше 0 и больше 100. Текущий коэффициент: {CompressionRatio}"); ;
            }
        }
    }

    class UserLow : User
    {
        public UserLow(int x, int y, int cr) : base(x,y,cr)
        {
            X = x;
            Y = y;
            CompressionRatio = cr;
        }

    }
}
