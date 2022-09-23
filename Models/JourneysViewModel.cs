using System;
namespace Trouble_shootingApp.Models
{
	public class JourneysViewModel
	{

		public int JourneyId  { get; set; }
        public string? Vehicle { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; }
        public int Rating { get; set; }
        public string? City { get; set; }
        public int Miles { get; set; }
        public int TimeTaken { get; set; }

        
    }

    public class JourneyListViewModel
    {
        public List<JourneysViewModel>? JourneysList { get; set; }
    }


}

