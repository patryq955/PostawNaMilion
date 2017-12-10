using AutoMapper;
using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Utilties
{
    public class MapperAdapter : ITarget
    {
       

        public TDo GetItem<T, TDo>(T _vM)
                    where TDo : class, new()
                     where T : class
        {
            MapperAdaptee<T, TDo> adaptee = new MapperAdaptee<T, TDo>(_vM);
            return adaptee.GetItem();
        }



    }
}
