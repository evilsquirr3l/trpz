namespace BLL
{
    public class TimeService : ITimeService
    {
        private readonly IAnimalService _animalService;

        public TimeService(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public void ShiftTime(int hours)
        {
            _animalService.CurrentTime.AddHours(hours);
        }
    }
}