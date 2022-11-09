using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        public PlayerService(IRepository _repo)
        {
            repo = _repo;
        }
        public void AddPlayer(PlayerViewModel model)
        {
            Player player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description
            };

            repo.Add(player);
            repo.SaveChanges();
        }

        public void AddUserToPlayer(string playerId, string id)
        {
            var user = repo.All<User>()
                .FirstOrDefault(u => u.Id == id);
            var player = repo.All<Player>()
                .FirstOrDefault(p => p.Id == playerId);

            if (user == null || player == null)
            {
                throw new ArgumentException("User or player not found");
            }

            user.UserPlayers.Add(new UserPlayer()
            {
                PlayerId = playerId,
                Player = player,
                User = user,
                UserId = id
            });

            repo.SaveChanges();

        }

        public IEnumerable<PlayerListViewModel> GetAllPlayers()
        {
            return repo.All<Player>()
                .Select(p => new PlayerListViewModel()
                {
                    Description = p.Description,
                    Endurance = p.Endurance,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed
                });
        }

        public PlayersCollectionViewModel GetPlayerCollection(string playerId)
        {
            return repo.All<Player>()
                .Where(p => p.Id == playerId)
                .Select(p => new PlayersCollectionViewModel()
                {
                    Description = p.Description,
                    Endurance = p.Endurance,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed,
                    Id = p.Id
                }).FirstOrDefault();

        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(PlayerViewModel model)
        {
           bool isValid = false;
           List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (string.IsNullOrWhiteSpace(model.FullName)
                || model.FullName.Length < 5 || model.FullName.Length > 80)
            {
                isValid = true;
                errors.Add(new ErrorViewModel("FullName is required and must be between 5 and 80"));
            }
            if (string.IsNullOrWhiteSpace(model.ImageUrl))
            {
                isValid = true;
                errors.Add(new ErrorViewModel("ImageUrl is required"));
            }
            if (string.IsNullOrWhiteSpace(model.Position)
                || model.Position.Length < 5 || model.Position.Length > 20)
            {
                isValid = true;
                errors.Add(new ErrorViewModel("Position is required and must be between 5 and 80"));
            }
            if (model.Speed < 0 || model.Speed > 10)
            {
                isValid = true;
                errors.Add(new ErrorViewModel("Speed is required and cannot be negative or bigger than 10"));
            }
            if (model.Endurance < 0 || model.Endurance > 10)
            {
                isValid = true;
                errors.Add(new ErrorViewModel("Endurance is required and cannot be negative or bigger than 10"));
            }
            if (string.IsNullOrWhiteSpace(model.Description)
               ||  model.Description.Length > 200)
            {
                isValid = true;
                errors.Add(new ErrorViewModel("Description is required and must not be more than 80 long"));
            }

            return (isValid, errors);
        }
    }
}

