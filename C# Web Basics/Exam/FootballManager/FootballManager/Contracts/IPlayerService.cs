using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(PlayerViewModel model);
        void AddPlayer(PlayerViewModel model);
        IEnumerable<PlayerListViewModel> GetAllPlayers();
        PlayersCollectionViewModel GetPlayerCollection(string playerId);
        void AddUserToPlayer(string playerId, string id);
    }
}
