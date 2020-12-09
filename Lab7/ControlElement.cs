using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    enum UIElements : byte
    {
        button = 1,
        checkbox,
        radiobutton = 2
    }
    struct TextField
    {
        public string text;
        public int width;
        public TextField(string text, int width)
        {
            this.text = text;
            this.width = width;
        }
        public void TextInput(string text)
        {
            this.text = text;
        }
        public void TextOutput(string text)
        {
            Console.WriteLine(text);
        }
    }
    partial class ControlElement
    {
        public bool isActive { get; set; }
        public ControlElement Next { get; set; }
        public ControlElement(bool isAct, int id, int size)
        {
            this.isActive = isAct;
            this.id = id;
            this.size = size;
        }
        public ControlElement NextElement()
        {
            return this.Next;
        }
        public void Switch()
        {
            if (isActive)
            {
                isActive = false;
            }
            else
            {
                isActive = true;
            }
        }
        public void Status()
        {
            Console.WriteLine($"Element is {this.GetType()}. Is active = {isActive}. Id = {id}. Size = {size}");
        }
        public override string ToString()
        {
            return $"Объект типа {this.GetType()}";
        }
    }
}
