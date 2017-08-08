using HotDogFood.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace HotDogFood.Core.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> _hotDogGroups = new List<HotDogGroup>();
        public HotDogRepository()
        {
            _hotDogGroups.Add(new HotDogGroup
            {
                HotDogGroupId = 1,
                Title = "Meat lovers",
                ImagePath = "",
                HotDogs = new List<HotDog>()
                {
                    new HotDog { HotDogId = 1, Name = "HotDog1", Available = true, PrepTime = 10, Price = 5, ShortDescription = "Short D1", Description = "Nebunie1" },

                    new HotDog { HotDogId = 2, Name = "HotDog2", Available = true, PrepTime = 12, Price = 7, ShortDescription = "Short D2", Description = "Nebunie2" },

                    new HotDog { HotDogId = 3, Name = "HotDog3", Available = true, PrepTime = 13, Price = 9, ShortDescription = "Short D3", Description = "Nebunie3" },
                }

            });

            _hotDogGroups.Add(new HotDogGroup
            {
                HotDogGroupId = 2,
                Title = "Brun lovers",
                ImagePath = "",
                HotDogs = new List<HotDog>()
                {
                    new HotDog { HotDogId = 4, Name = "HotDog4", Available = true, PrepTime = 10, Price = 5, ShortDescription = "Short D4", Description = "Nebunie4" },

                    new HotDog { HotDogId = 4, Name = "HotDog5", Available = true, PrepTime = 12, Price = 7, ShortDescription = "Short D5", Description = "Nebunie5" },

                    new HotDog { HotDogId = 5, Name = "HotDog6", Available = true, PrepTime = 13, Price = 9, ShortDescription = "Short D6", Description = "Nebunie6" },
                }

            });
        }

        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in _hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          select hotDog;
            return hotDogs.ToList();
        }

        public HotDog GetHotDogById(int id)
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in _hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          where hotDog.HotDogId == id
                                          select hotDog;
            return hotDogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetHotDogsGrouped()
        {
            return _hotDogGroups;
        }

        public List<HotDog> GetHotDogsForGroup(int groupId)
        {
            var group = _hotDogGroups.Where(ht => ht.HotDogGroupId == groupId).FirstOrDefault();
            return group?.HotDogs;
        }

        public List<HotDog> GetFavouriteHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from hotDogGroup in _hotDogGroups
                                          from hotDog in hotDogGroup.HotDogs
                                          where hotDog.IsFavorite
                                          select hotDog;
            return hotDogs.ToList();
        }

    }
}
