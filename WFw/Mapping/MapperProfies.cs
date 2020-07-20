//using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WFw.Mapping
{
    //TODO:待完善，先直接用automapper
    public class MapperProfies //: Profile
    {
        public MapperProfies()
        {



        }
        public void CreateMap(Type sourceType)
        {
            //List<(Type Source, Type Target)> tuples = new List<(Type Source, Type Target)>();

            //System.Reflection.Assembly asm = System.Reflection.Assembly.GetAssembly(sourceType);
            ////Type[] allTypes = asm.GetTypes();    //这个得到的类型有点儿多
            //var types = asm.GetExportedTypes();//还是用这个比较好，得到的都是自定义的类型

            //foreach (var type in types)
            //{
            //    var mf = type.GetCustomAttribute<MapFromAttribute>();

            //    if (mf == null)
            //    {
            //        continue;
            //    }

            //    foreach (Type targetType in mf.TargetTypes)
            //    {
            //        var tuple = ValueTuple.Create(sourceType, targetType);
            //        if (!tuples.Contains(tuple))
            //        {
            //            tuples.Add(tuple);
            //        }
            //        // tuples.AddIfNotExist(tuple);
            //    }

            //}

            //foreach ((Type Source, Type Target) item in tuples)
            //{
            //    CreateMap(item.Source, item.Target);
            //}


        }
    }
}
