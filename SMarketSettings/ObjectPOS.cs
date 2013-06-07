using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ini;
using System.IO;

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
                temp[pos_number] = address;
                pos = temp;
                pos_number++;
            }
            catch
            {
                temp = new string[1];
                temp[pos_number] = address;
                pos = temp;
                pos_number++;
            }
        }
        //Получение всех объектов из файла
        
    }
    public static class POScnt
    {
        public static ObjectPOS[] get_obj()
        {
            IniFile cfg = new IniFile(Directory.GetCurrentDirectory() + "\\cfg.ini");
            int number_of_objects = 0;
            ObjectPOS[] objectp;
            string[] tmp;
            try
            {
                number_of_objects = int.Parse(cfg.IniReadValue("objects", "numberofobjects"));
            }
            catch
            {
                return null;
            }
            try
            {
                if (number_of_objects != 0)
                {
                    objectp = new ObjectPOS[number_of_objects];
                    for (int i = 0; i < number_of_objects; i++)
                    {
                        objectp[i] = new ObjectPOS();
                        objectp[i].name = cfg.IniReadValue("objects", "obj" + (i + 1));
                        objectp[i].pos_number = int.Parse(cfg.IniReadValue(objectp[i].name, "numofpos"));
                        tmp = new string[objectp[i].pos_number];
                        for (int z = 0; z < objectp[i].pos_number; z++)
                        {
                            tmp[z] = cfg.IniReadValue(objectp[i].name, "pos" + (z + 1));
                        }
                        objectp[i].pos = tmp;
                    }
                    return objectp;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public static int get_num_of_pos()
        {
            IniFile cfg = new IniFile(Directory.GetCurrentDirectory() + "\\cfg.ini");
            int number_of_objects = 0;
            try
            {
                number_of_objects = int.Parse(cfg.IniReadValue("objects", "numberofobjects"));
                return number_of_objects;
            }
            catch
            {
                return -1;
            }
        }
    }
}
