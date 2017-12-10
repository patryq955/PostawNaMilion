using AutoMapper;
using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Utilties
{
    public class MapperAdapter<T, TDo> : ITarget<TDo>
        where TDo : class, new()
        where T : class
    {
        T _vM;
        public MapperAdapter(T vM)
        {
            _vM = vM;
        }

        public TDo GetItem()
        {
            MapperAdaptee<T, TDo> adaptee = new MapperAdaptee<T, TDo>(_vM);
            return adaptee.GetItem();
        }



    }
}
