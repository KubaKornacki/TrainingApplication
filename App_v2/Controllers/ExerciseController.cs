using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;
using App_v2.Repositories;
using App_v2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace App_v2.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IPersonExerciseRepository _personExerciseRepository;
        private readonly ITrainingRepository _trainingRepository;

        public ExerciseController(UserManager<AppUser> userManager, IPersonExerciseRepository personExerciseRepository, ITrainingRepository trainingRepository)
        {
            _userManager = userManager;
            _personExerciseRepository = personExerciseRepository;
            _trainingRepository = trainingRepository;
        }

        public async Task<IActionResult> Index()
        {
            AppUser appUser = await _userManager.GetUserAsync(User);

            List<Training> trainings = _trainingRepository.ListAllTraining(appUser).ToList();

            return View(trainings);
        }

        public  IActionResult ViewTraining(int id)
        {
            List<Subtraining> subtrainings = _trainingRepository.ListSubtrainings(id).ToList();

            return View(subtrainings);
        }

        public IActionResult HistoryTrainings(int id)
        {
            //List<HistoryTraining> historyTrainings = _trainingRepository.ListHistoryTrainings(id).ToList();

            ViewHistoryViewModel vm = new ViewHistoryViewModel(_trainingRepository.ListHistoryTrainingsDates(id).ToList(), id);
            return View(vm);
        }

        public IActionResult ViewHistory(int id,DateTime date)
        {
            List<HistoryTraining> ht = _trainingRepository.ListHistoryTrainings(id, date).ToList();
            return View(ht);
        }

        public async Task<IActionResult> Records()
        {
            AppUser appUser = await _userManager.GetUserAsync(User);
            List <PersonExcercise> maxes= _personExerciseRepository.ListPersonExercises(appUser);


            return View(maxes);
        }

        public IActionResult EditRecord(int id)
        {
            PersonExcercise exercise =_personExerciseRepository.GetPersonExcercise(id);


            return View(exercise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRecord([Bind("ID,Max,Progress")]PersonExcercise personExcercise)
        {
            _personExerciseRepository.UpdatePersonExercise(personExcercise);


            return RedirectToAction("Records");
        }

        public IActionResult TrainingDetails(int id)
        {
            List<TrainingExercise> trainingExercises = _trainingRepository.GetSubtraingsExercises(id).ToList();


            return View(trainingExercises);
        }

        public  IActionResult AddHistoryTraining(int id)
        {
            var userId = _userManager.GetUserId(this.User);
            List<HistoryTraining> historyTrainings = _trainingRepository.ListHistoryTrainings(id, DateTime.Now.Date).ToList();
            List<TrainingExercise> trainingExercises = _trainingRepository.GetSubtraingsExercises(id).ToList();
            List<PersonExcercise> personExcercises = _personExerciseRepository.ListPersonExercises(userId);
            List<AddHistoryTrainingViewModel> model = Tools.GlobalFunctions.GenerateHistoryTrainings(trainingExercises,personExcercises,historyTrainings);
            return View(model);
        }

        [HttpPost]
        public bool SaveHistoryExercise([FromBody]List<SaveHistoryTrainingViewModel> historyTraining)
        {
            var userId = _userManager.GetUserId(this.User);
            bool ret=_trainingRepository.AddHistoryTrainings(historyTraining);
            SaveHistoryTrainingViewModel vm = historyTraining.OrderByDescending(x => x.Weight).ThenByDescending(x=>x.Repeats).FirstOrDefault();
            TrainingExercise trainingExercise = _trainingRepository.GetTrainingExercise(vm.ExerciseId);
            _personExerciseRepository.UpdatePersonExercise(trainingExercise.Excercise.ID, vm.Weight,vm.Repeats, userId);
            return ret;
        }

    }
}