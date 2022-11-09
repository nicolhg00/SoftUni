using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        public PlayersController(Request request,
            IPlayerService _playerService) 
            : base(request)
        {
            playerService = _playerService;
        }

        [Authorize]
        public Response Add() => View();

        [HttpPost]
        [Authorize]
        public Response Add(PlayerViewModel model)
        {
            var(isValid,error) = playerService.ValidateModel(model);
            if(!isValid)
            {
                return View(error, "/Error");
            }
            try
            {
                playerService.AddPlayer(model);
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>()
                { new ErrorViewModel("Error")}, "/Error");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<PlayerListViewModel> players = playerService.GetAllPlayers();

            return View(players);
        }

        [Authorize]
        public Response Collection(string playerId)
        {
            PlayersCollectionViewModel playersCollectionViewModel =
                playerService.GetPlayerCollection(playerId);

            return View(playersCollectionViewModel);
        }

        public Response AddUserToPlayer(string playerId)
        {
            try
            {
                playerService.AddUserToPlayer(playerId, User.Id);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel>()
                { new ErrorViewModel(aex.Message)}, "/Error");
            }
            catch (Exception ex)
            {
                return View(new List<ErrorViewModel>()
                { new ErrorViewModel("Unexpected Error")}, "/Error");
            }

            return Redirect("/");
        }
    }
}
