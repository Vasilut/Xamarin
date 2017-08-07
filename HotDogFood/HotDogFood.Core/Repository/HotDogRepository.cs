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
                    new HotDog { HotDogId = 1, Name = "L1", Available = true, PrepTime = 10, Price = 5 },

                    new HotDog { HotDogId = 2, Name = "L2", Available = true, PrepTime = 12, Price = 7 },

                    new HotDog { HotDogId = 3, Name = "L3", Available = true, PrepTime = 13, Price = 9 },
                }

            });

            _hotDogGroups.Add(new HotDogGroup
            {
                HotDogGroupId = 2,
                Title = "Brun lovers",
                ImagePath = "",
                HotDogs = new List<HotDog>()
                {
                    new HotDog { HotDogId = 4, Name = "L4", Available = true, PrepTime = 10, Price = 5 },

                    new HotDog { HotDogId = 4, Name = "L5", Available = true, PrepTime = 12, Price = 7 },

                    new HotDog { HotDogId = 5, Name = "L6", Available = true, PrepTime = 13, Price = 9 },
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
