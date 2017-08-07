using HotDogFood.Core.Model;
using HotDogFood.Core.Repository;
using System.Collections.Generic;

namespace HotDogFood.Core.Service
{
    public class HotDogDataService
    {
        private static HotDogRepository _repository = new HotDogRepository();

        public List<HotDog> GetAllHotDogs()
        {
            return _repository.GetAllHotDogs();
        }

        public List<HotDogGroup> GetHotDogsGrouped()
        {
            return _repository.GetHotDogsGrouped();
        }

        public List<HotDog> GetHotDogForGroup(int groupId)
        {
            return _repository.GetHotDogsForGroup(groupId);
        }

        public HotDog GetHotDogById(int hotDogId)
        {
            return _repository.GetHotDogById(hotDogId);
        }

        public List<HotDog> GetFavouriteHotDog()
        {
            return _repository.GetFavouriteHotDogs();
        }


    }
}
