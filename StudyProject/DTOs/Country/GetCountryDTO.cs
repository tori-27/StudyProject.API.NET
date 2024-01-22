using StudyProject.DTOs.Hotel;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyProject.DTOs.Country
{
    public class GetCountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }

}
