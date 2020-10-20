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
            List<HistoryTraining> historyTrainings = _trainingRepository.ListHistoryTrainings(id).ToList();

            return View(historyTrainings);
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

        public IActionResult AddHistoryTraining(int id)
        {
            List<TrainingExercise> trainingExercises = _trainingRepository.GetSubtraingsExercises(id).ToList();
            List<AddHistoryTrainingViewModel> model = Tools.GlobalFunctions.GenerateHistoryTrainings(trainingExercises);

            return View(model);
        }

        [HttpPost]
        public IActionResult Test([FromBody] List<SaveHistoryTrainingViewModel> historyTraining)
        {
            
            return RedirectToAction("AddHistoryTraining", 1);
        }

    }
}