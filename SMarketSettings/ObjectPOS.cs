using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS
{
    //Класс обьекта(магазина)
    public class ObjectPOS
    {
        public string name { get; set; }
        public string[] pos { get; set; }
        public int pos_number { get; set; }
        //Конструктор свойств
        public ObjectPOS(string obj_name, string[] addresses)
        {
            name = obj_name;
            pos_number = addresses.Length;
            pos = addresses;
        }
        public ObjectPOS()
        {
        }
        //Удаление поса
        public void delete_addr(int index)
        {
            try
            {
                string[] temp = new string[pos.Length - 1];
                for (int i = 0, z = 0; i < pos.Length - 1; i++, z++)
                {
                    if (i == index)
                    {
                        z++;
                        temp[i] = pos[z];

                    }
                    temp[i] = pos[z];
                }
                pos = temp;
                pos_number--;
            }
            catch
            {
            }
        }
        //Добавление поса
        public void add_addr(string address)
        {
            string[] temp;
            try
            {
                temp = pos;
                Array.Resize(ref temp, temp.Length + 1);
            }
            catch
            {
                temp = new string[1];
            }
            temp[pos_number] = address;
            pos = temp;
            pos_number++;
        }
    }
}
