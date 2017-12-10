using PostawNaMilionAzure.Utilties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostawNaMilionAzure.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ITarget _mapper;
        
        public BaseController(ITarget mapper)
        {
            _mapper = mapper;
        }
    }
}