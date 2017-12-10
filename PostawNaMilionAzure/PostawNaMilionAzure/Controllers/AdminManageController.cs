using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.Repository;
using PostawNaMilionAzure.Utilties;
using PostawNaMilionAzure.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace PostawNaMilionAzure.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminManageController : Controller
    {
        private IRepository<CategoryDict> _categoryDictRepository;
        private IRepository<KnowledgeArea> _knowledgeAreaRepository;

        private AzureContext _db = new AzureContext(); // do poprawy

        public AdminManageController(IRepository<CategoryDict> categoryDictRepository
            , IRepository<KnowledgeArea> knowledgeAreaRepository)
        {
            _categoryDictRepository = categoryDictRepository;
            _knowledgeAreaRepository = knowledgeAreaRepository;
        }
        //Get: Main page 
        public ActionResult Index()
        {
            var lastRegisterUser = _db.Users.Where(x => x.Id != "2f94a417-4a2d-4161-aa5a-fa20557490ff").
                                                    Take(5).ToList();
            ViewBag.IsRegisterUser = lastRegisterUser.Count > 0 ? true : false;
            return View(lastRegisterUser);

        }

        //Get Add Category
        [HttpGet]
        public ActionResult AddCategory()
        {

            ViewBag.DoneAddCategory = TempData["doneAddCategory"] != null
                    ? "Dodano Kategorie: " + TempData["doneAddCategory"] : "";

            AddCategoryViewModel vM = new AddCategoryViewModel();
            vM.KnowledgeAreaList = _knowledgeAreaRepository.GetOverview().ToList();
            return View(vM);
        }

        [HttpPost]
        public ActionResult AddCategory(AddCategoryViewModel vM)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCategory", vM);
            }

            MapperAdapter<AddCategoryViewModel, CategoryDict> mapper = new MapperAdapter<AddCategoryViewModel, CategoryDict>(vM);
            var categoryDict = mapper.GetItem();
            _categoryDictRepository.Add(categoryDict);

            TempData["doneAddCategory"] = vM.CategoryDict.Name;
            return RedirectToAction("AddCategory");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var vM = new AddCategoryViewModel();
            vM.CategoryDict= _categoryDictRepository.GetID(id);
            vM.KnowledgeAreaList = _knowledgeAreaRepository.GetOverview().ToList();
            return View(vM);
        }

        [HttpPost]
        public ActionResult EditCategory(AddCategoryViewModel vM)
        {


            return View("Category", "AdminManage");
        }

        //Get Add question
        public ActionResult AddQuestion()
        {
            return View();
        }

        public ActionResult Category()
        {
            var vM = _categoryDictRepository.GetOverview().ToList();
            ViewBag.CategoryDictCount = vM.Count();
            return View(vM);
        }

    }


    #region  helpers

    #endregion
}