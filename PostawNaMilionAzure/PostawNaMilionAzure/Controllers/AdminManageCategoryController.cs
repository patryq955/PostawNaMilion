using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.Repository;
using PostawNaMilionAzure.Utilties;
using PostawNaMilionAzure.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace PostawNaMilionAzure.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminManageCategoryController : BaseController
    {
        private IRepository<CategoryDict> _categoryDictRepository;
        private IRepository<KnowledgeArea> _knowledgeAreaRepository;

        private AzureContext _db = new AzureContext(); // do poprawy

        public AdminManageCategoryController(IRepository<CategoryDict> categoryDictRepository
            , IRepository<KnowledgeArea> knowledgeAreaRepository, ITarget mapper) : base(mapper)
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
            vM.NameAction = "AddCategory";
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
            _categoryDictRepository.Add(_mapper.GetItem<AddCategoryViewModel, CategoryDict>(vM));

            TempData["doneAddCategory"] = vM.CategoryDict.Name;
            return RedirectToAction("AddCategory");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var vM = new AddCategoryViewModel();
            vM.NameAction = "EditCategory";
            vM.CategoryDict = _categoryDictRepository.GetID(id);
            vM.KnowledgeAreaList = _knowledgeAreaRepository.GetOverview().ToList();
            return View(vM);
        }

        [HttpPost]
        public ActionResult EditCategory(AddCategoryViewModel vM)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCategory", vM);
            }
            //var category = _categoryDictRepository.GetID(vM.CategoryDict.Id);
            var category =   _mapper.GetItem<AddCategoryViewModel, CategoryDict>(vM);
            _categoryDictRepository.Update(category);
            return RedirectToAction("Category", "AdminManageCategory");
        }

        [HttpPost]
        public ActionResult HiddenCategory(int id)
        {
            var category = _categoryDictRepository.GetID(id);
            category.IsHidden = !category.IsHidden;
            _categoryDictRepository.Update(category);

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);

        }

        public ActionResult Category()
        {
            var vM = _categoryDictRepository.GetOverview().ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListCategory", vM);
            }
            return View(vM);
        }

    }


    #region  helpers

    #endregion
}