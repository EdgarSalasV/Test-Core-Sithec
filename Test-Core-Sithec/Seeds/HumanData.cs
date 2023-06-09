using Test_Core_Sithec.Models;

namespace Test_Core_Sithec.Services
{
    public interface IHumanData
    {
        List<Human> GetHumanList();
    }

    public class HumanData : IHumanData
    {
        private readonly List<Human> humanList = new List<Human> {
            new Human
            {
                Id = 11,
                Name= "Human 11",
                Gender = false,
                Age = 23,
                Height = 1.12m,
                Weight = 55m,
            },
            new Human
            {
                Id = 12,
                Name= "Human 12",
                Gender = true,
                Age = 18,
                Height = 12,
                Weight = 60m,
            },
        };

        public List<Human> GetHumanList()
        {
            List<Human> list = humanList;

            return humanList;
        }
    }
}
