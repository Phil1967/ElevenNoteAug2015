using ElevenNote.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.Web.Controllers
{
    public class GameController : Controller
    {
        #region GET
        // GET: Game
        [HttpGet]
        [ActionName("Index")]
        public ActionResult IndexGet()
        {
            var correctAnswer = new Random().Next(1, 10);
            Session["Answer"] = correctAnswer;
            return View();
        }
        #endregion
        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(GuessingGameViewModel model)
        { 
            if (!ModelState.IsValid)
            {
                //if there was an error.
            }
            else
            {
                var numberToCompareTo = (int)Session["Answer"];
                var isCorrect = model.Guess == numberToCompareTo;
                //guessing logic
                ViewBag.GuessWasCorrect = isCorrect;

            }
            return View(model);
        }
    }

}