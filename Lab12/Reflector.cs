using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Type;
using System.IO;

namespace Lab12
{
    static class Reflector
    {
        public static void AssemblyName(object obj)
        {
            Type type = obj.GetType();
            FileSave(type.Assembly);
        }
        public static void PublicConstructors(object obj)
        {
            Type type = obj.GetType();
            ConstructorInfo[] Ci = type.GetConstructors();
            foreach(ConstructorInfo ci in Ci)
            {
                FileSave(ci);
            }
        }
        public static void Methods(object obj)
        {
            Type type = obj.GetType();
            MethodInfo[] Mi = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MethodInfo mi in Mi)
            {
                FileSave(mi);
            }
        }
        public static void Properties(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] Pi = type.GetProperties();
            foreach (PropertyInfo pi in Pi)
            {
                FileSave(pi);
            }
        }
        public static void Fields(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] Fi = type.GetFields();
            foreach (FieldInfo fi in Fi)
            {
                FileSave(fi);
            }
        }
        public static void Interfaces(object obj)
        {
            Type type = obj.GetType();
            Type[] Fi = type.GetInterfaces();
            foreach (Type fi in Fi)
            {
                FileSave(fi);
            }
        }
        public static void MethodsByParametr(object obj, string parametr)
        {
            Type type = obj.GetType();
            MethodInfo[] Fi = type.GetMethods();
            foreach (MethodInfo fi in Fi)
            {
                string str = fi.ToString();
                if (str.Contains(parametr))
                    FileSave(fi);
            }
        }
        public static object Invoke(object obj, string methodName, params object[] parametrs)
        {

            MethodInfo obMethod = obj.GetType().GetMethod(methodName);
            return obMethod.Invoke(obj, parametrs);
        }
        public static object[] ParamsGenerater(string ClassName, string MethodName)
        {
            Type type = Type.GetType(ClassName);
            Console.WriteLine(type.Name);

            MethodInfo[] Met = type.GetMethods();

            int index = 0;
            string[] nameT = new string[16];

            foreach (var m in Met)
            {
                ParameterInfo[] pars = m.GetParameters();
                if (m.Name == MethodName)
                {

                    foreach (var p in pars)
                    {
                        nameT[index] = Convert.ToString(p.ParameterType);
                        index++;
                    }
                }
            }

            object[] param = new object[index];
            Random rnd = new Random();
            for (int i = 0; nameT[i] != null; i++)
            {
                switch (nameT[i])
                {
                    case "System.Int32":
                        param[i] = rnd.Next(50); 
                        break;
                    case "System.String":
                        int size = rnd.Next(3, 12);
                        string str = "";
                        for (int ind = 1; ind < size; ind++)
                        {
                            str += Convert.ToChar(rnd.Next(65, 90));
                        }
                        param[i] = Convert.ToString(str); break;
                    case "System.Char":
                        param[i] = Convert.ToChar(rnd.Next(65, 90));
                        break;
                    case "System.Boolean":
                        param[i] = Convert.ToBoolean(rnd.Next(0, 1));
                        break;

                    default: break;
                }
            }
            return param;
        }

        public static object[] FileRead(string ClassName, string MethodName)
        {
            Type type = Type.GetType(ClassName);
            Console.WriteLine(type.Name);

            MethodInfo[] Met = type.GetMethods();

            int index = 0;
            string[] nameT = new string[16];

            foreach (var m in Met)
            {
                ParameterInfo[] pars = m.GetParameters();
                if (m.Name == MethodName)
                {

                    foreach (var p in pars)
                    {
                        nameT[index] = Convert.ToString(p.ParameterType);
                        index++;
                    }
                }
            }
            string readPath = @"D:\12labReadFile2.txt";

            StreamReader sr = new StreamReader(readPath);
            object[] param = new object[index];
            for (int i = 0; nameT[i] != null; i++)
            {
                
                while (!sr.EndOfStream)
                {
                    object line = sr.ReadLine();
                    if (line.GetType().ToString() == nameT[i])
                    {
                        param[i] = line;
                        break;
                    }
                }
                
            }
            sr.Close();
            return param;
        }
        public static Object Create(Type cl)
        {
            Console.WriteLine("объект создан");
            return Activator.CreateInstance(cl);
        }


        public static void FileSave(object obj)
        {

            string writePath = @"D:\12lab.txt";
            StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default);
            sw.WriteLine(obj);
            sw.Close();
            StreamReader sr = new StreamReader(writePath);
            Console.WriteLine(sr.ReadLine());
            sr.Close();
        }

    }
}
