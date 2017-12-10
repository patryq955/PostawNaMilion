using AutoMapper;
using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Utilties
{
    public class MapperAdaptee<T, TDo>
        where TDo : class, new()
        where T : class
    {
        private T _source;
        MapperConfiguration _config;

        public MapperAdaptee(T source)
        {
            _source = source;
            _config = new MapperConfiguration(cfg => cfg.CreateMap<T, TDo>());
        }

        public TDo GetItem()
        {
            if (typeof(T) == typeof(AddCategoryViewModel) && typeof(TDo) == typeof(CategoryDict))
            {
                return GetCategoryDict();
            }
            return default(TDo);
        }

        private TDo GetCategoryDict()
        {
            var mapper = _config.CreateMapper();

            var vM = _source as AddCategoryViewModel;
            var tDo = mapper.Map<TDo>(vM.CategoryDict);

            return (TDo)tDo;
        }




  



    }
}