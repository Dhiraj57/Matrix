﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;

namespace MatrixEditor.Utilities
{
    public static class Serializer
    {
        public static void ToFile<T>(T instance, string path)
        {
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    serializer.WriteObject(fileStream, instance);
                }    
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static T FromFile<T>(string path)
        {
            try
            {
                using(var fileStream = new FileStream(path,FileMode.Open))
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    T instance = (T)serializer.ReadObject(fileStream);
                    return instance;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default(T);
            }
        }
    }
}
