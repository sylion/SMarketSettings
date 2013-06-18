using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ini;
using System.IO;

namespace SMarketSettings
{
    public class Operator
    {
        public Operator()
        {
            Mask = 0;
            Updated = false;
            New = false;
            ForDelete = false;
            Password = "";
            NotActive = false;
            CashPwd = "";
            ID = 0;
            Code = 0;
            Name = "";

        }
        public int Mask { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int ID { get; set; }
        public string CashPwd { get; set; }
        public bool NotActive { get; set; }
        public string Password { get; set; }
        public bool Updated { get; set; }
        public bool ForDelete { get; set; }
        public bool New { get; set; }
    }

    public static class OperatorsControl
    {
        public static Operator[] LoadOperators(string address)
        {
            IniFile settings = new IniFile(Directory.GetCurrentDirectory() + "\\settings\\" + address + ".ini");
            int count;
            count = int.Parse(settings.IniReadValue("operators", "count"));

            Operator[] op = new Operator[count];
            for (int i = 0; i < count; i++)
            {
                op[i] = new Operator();
                op[i].Name = settings.IniReadValue("op" + i, "name");
                op[i].Code = int.Parse(settings.IniReadValue("op" + i, "code"));
                op[i].ID = int.Parse(settings.IniReadValue("op" + i, "id"));
                op[i].CashPwd = settings.IniReadValue("op" + i, "edCashPsw");
                op[i].NotActive = bool.Parse(settings.IniReadValue("op" + i, "chNotActive"));
                op[i].Mask = int.Parse(settings.IniReadValue("op" + i, "mask"));
                op[i].Password = settings.IniReadValue("op" + i, "password");
                try
                {
                    op[i].ForDelete = bool.Parse(settings.IniReadValue("op" + i, "ForDelete"));
                }
                catch
                {
                    op[i].ForDelete = false;
                }
                try
                {
                    op[i].Updated = bool.Parse(settings.IniReadValue("op" + i, "Updated"));
                }
                catch
                {
                    op[i].Updated = false;
                }
                try
                {
                    op[i].New = bool.Parse(settings.IniReadValue("op" + i, "New"));
                }
                catch
                {
                    op[i].New = false;
                }
            }
            return op;
        }
        //Добавление нового оператора
        public static Operator[] addOperator(Operator[] op, string Name, string Password)
        {
            Operator[] temp;
            try
            {
                temp = op;
                Array.Resize(ref temp, temp.Length + 1);
                temp[op.Length] = new Operator();
                temp[op.Length].Name = Name;
                temp[op.Length].Password = Password;
                op = temp;
                return op;
            }
            catch
            {
                temp = new Operator[1];
                temp[temp.Length - 1] = new Operator();
                temp[temp.Length - 1].Name = Name;
                temp[temp.Length - 1].Password = Password;
                op = temp;
                return op;
            }
        }
        //Сохранение операторов в файл
        public static void SaveOperators(string address, Operator[] Op)
        {
            IniFile settings = new IniFile(Directory.GetCurrentDirectory() + "\\settings\\" + address + ".ini");
            int count = Op.Length;
            for (int i = 0; i < count; i++)
            {
                settings.IniWriteValue("op" + i, "name", Op[i].Name);
                settings.IniWriteValue("op" + i, "id", Op[i].ID.ToString());
                if (Op[i].CashPwd == "")
                {
                    Op[i].CashPwd = "1";
                }
                settings.IniWriteValue("op" + i, "edCashPsw", Op[i].CashPwd);
                settings.IniWriteValue("op" + i, "chNotActive", Op[i].NotActive.ToString());
                settings.IniWriteValue("op" + i, "mask", Op[i].Mask.ToString());
                settings.IniWriteValue("op" + i, "password", Op[i].Password);
                if (!Op[i].New)
                {
                    settings.IniWriteValue("op" + i, "code", Op[i].Code.ToString());
                    if (Op[i].ForDelete)
                    {
                        settings.IniWriteValue("op" + i, "New", "False");
                        settings.IniWriteValue("op" + i, "ForDelete", "True");
                        settings.IniWriteValue("op" + i, "Updated", "False");
                    }
                    else
                    {
                        settings.IniWriteValue("op" + i, "New", "False");
                        settings.IniWriteValue("op" + i, "ForDelete", "False");
                        settings.IniWriteValue("op" + i, "Updated", "True");
                    }
                }
                if (Op[i].New)
                {
                    settings.IniWriteValue("op" + i, "New", "True");
                    settings.IniWriteValue("op" + i, "ForDelete", "False");
                    settings.IniWriteValue("op" + i, "Updated", "False");
                }
            }
            settings.IniWriteValue("operators", "count", count.ToString());
        }
    }
}
