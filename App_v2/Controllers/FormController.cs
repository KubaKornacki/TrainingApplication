using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;
using App_v2.Repositories;
using App_v2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App_v2.Controllers
{
    public class FormController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IFormRepository _formRepository;

        private readonly IDictRepository _dictRepository;

        private readonly ITrainingRepository _trainingRepository;

        public FormController(UserManager<AppUser> userManager, IFormRepository form, IDictRepository dict,ITrainingRepository training)
        {
            _userManager = userManager;
            _formRepository = form;
            _dictRepository = dict;
            _trainingRepository = training;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Form()
        {
            AppUser appUser = await _userManager.GetUserAsync(User);

            Form form = _formRepository.GetUserForm(appUser.Id);

            FormViewModel formVM = new FormViewModel();

            formVM.Form = form;

            formVM.FreeTime = Tools.GlobalFunctions.GenerateDropdownListForDict(form?.FreeTimeID, _dictRepository.GetDictsByName("free_time"));

            formVM.Goal = Tools.GlobalFunctions.GenerateDropdownListForDict(form?.GoalID, _dictRepository.GetDictsByName("goal"));
            formVM.TrainingCategory = Tools.GlobalFunctions.GenerateDropdownListForDict(form?.TrainingCategoryID, _dictRepository.GetDictsByName("training_category"));


            return View(formVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Form([Bind("ID,GoalID,FreeTimeID,TrainingCategoryID")]Form form)
        {
            AppUser appUser = await _userManager.GetUserAsync(User);

            form.User = appUser;

            if (form.ID == 0)
            {
                _formRepository.CreateForm(form);
            }
            else
            {
                _formRepository.UpdateForm(form);
            }

            return RedirectToAction("TrainingType"); /*RedirectToAction("Index");*/
        }

        public async Task<IActionResult> TrainingType()
        {
            AppUser appUser = await _userManager.GetUserAsync(User);

            Form form = _formRepository.GetUserForm(appUser.Id);
            TrainingTypeViewModel vm = new TrainingTypeViewModel();
            Dict freeTime = _dictRepository.GetDict("free_time", form.FreeTimeID);

            IEnumerable<Dict> trainingTypes = _dictRepository.GetDictsByName("training_type");

            if (freeTime.intValue==1)
            {
             vm.TrainingTypes = Tools.GlobalFunctions.GenerateDropdownListForDict(1, trainingTypes.Where(x=>x.intValue==1));
            }
            else if(freeTime.intValue == 2)
            {
                vm.TrainingTypes = Tools.GlobalFunctions.GenerateDropdownListForDict(1, trainingTypes.Where(x => x.intValue == 1|| x.intValue == 2));
            }
            else
            {
                vm.TrainingTypes= Tools.GlobalFunctions.GenerateDropdownListForDict(2, trainingTypes.Where(x => x.intValue == 2 || x.intValue == 3));
            }
            vm.TrainingKinds= Tools.GlobalFunctions.GenerateDropdownListForDict(1, _dictRepository.GetDictsByName("training_kind"));

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TrainingType([Bind("TrainingKindId,TrainingTypeId")]TrainingTypeViewModel vm)
        {
            AppUser appUser = await _userManager.GetUserAsync(User);

            string trainingType=_dictRepository.GetDict("training_type", vm.TrainingTypeId).textValue;

            Training training = new Training();
            training.Active = true;
            training.AppUser = appUser;
            training.TrainingName = trainingType + " " + DateTime.Now.ToShortDateString();

            Training trainingDb= _trainingRepository.CreateTraining(training,vm.TrainingTypeId,vm.TrainingKindId);



            return RedirectToAction("Records", "Exercise");
            //return RedirectToAction("Success", new {id= trainingDb.ID }); /*RedirectToAction("Index");*/
        }

        public IActionResult Success(int id)
        {

            return View(id);
        }
    }
}