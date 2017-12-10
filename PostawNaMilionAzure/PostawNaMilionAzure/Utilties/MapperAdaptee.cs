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
        IMapper _mapper;

        public MapperAdaptee(T source)
        {
            _source = source;
            _config = new MapperConfiguration(cfg => cfg.CreateMap<T, TDo>());
            _mapper = _config.CreateMapper();
        }

        public TDo GetItem()
        {
            if (typeof(T) == typeof(AddCategoryViewModel) && typeof(TDo) == typeof(CategoryDict))
            {
                return GetCategoryDict();
            }
            if (typeof(T) == typeof(QuestionViewModel) && typeof(TDo) == typeof(Question))
            {
                return GetQuestion();
            }
            return default(TDo);
        }

        private TDo GetCategoryDict()
        {
            var vM = _source as AddCategoryViewModel;
            var tDo = _mapper.Map<TDo>(vM.CategoryDict);

            return (TDo)tDo;
        }

        private TDo GetQuestion()
        {
            var vM = _source as QuestionViewModel;
            var tDo = _mapper.Map<TDo>(vM.Question);

            return (TDo)tDo;
        }








    }
}