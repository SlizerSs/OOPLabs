using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class UI : IEnumerable
    {
        private ControlElement _first;
        private ControlElement _last;
        private int _count = 0;
        ControlElement[] Elements;
        public UI(ControlElement firstElement)
        {
            Elements = new ControlElement[1];
            Elements[0] = firstElement;
            _first = firstElement;
            _last = firstElement;
            _count++;
        }
        public UI(params ControlElement[] Element)
        {
            Elements = new ControlElement[Element.Length];
            _first = Element[0];
            _last = Element[0];
            for (; _count < Element.Length; _count++)
            {
                Elements[_count] = Element[_count];
                _last.Next = Element[_count];
                _last = Element[_count];
            }
        }
        public void Add(ControlElement nextElement)
        {
            if (nextElement == null)
            {
                throw new NullReferenceException("Null-ссылка");
            }
            Array.Resize(ref Elements, Elements.Length + 1);
            Elements[_count] = nextElement;
            _last.Next = nextElement;
            _last = nextElement;
            _count++;
        }
        public void Show()
        {
            ControlElement Element = this._first;
            do
            {
                Element.Status();
                Element = Element.NextElement();
            } while (Element != this._last);
            Element.Status();
        }
        public void Show(int index)
        {
            ControlElement Element = this._first;
            while (Element != Elements[index])
            {
                Element = Element.NextElement();
            } 
            Element.Status();
        }
        public void DeleteLast()
        {
            ControlElement Element = this._first;
            while (Element.NextElement() != this._last)
            {
                Element = Element.NextElement();
            }
            Element.Next = Element;
            this._last = Element;
            _count--;
        }
        public void Delete(int index)
        {
            if (index == 0)
            {
                _first = Elements[1];
                Elements[0] = Elements[1];
                Refresh();
            }
            else if (index == _count - 1)
            {
                DeleteLast();

            }
            else
            {
                Elements[index - 1].Next = Elements[index + 1];
                Refresh();
            }
        }
        private void Refresh()
        {
            ControlElement Element = _first;
            int index = 0;
            while (Element.NextElement() != this._last)
            {
                Elements[index] = Element;
                index++;
                Element = Element.NextElement();
            }
            _count--;
        }

        public IEnumerator GetEnumerator()
        {
            return Elements.GetEnumerator();
        }
        public int this[int index]
        {
            get => index;
            set => index = value;
        }
    }
}
