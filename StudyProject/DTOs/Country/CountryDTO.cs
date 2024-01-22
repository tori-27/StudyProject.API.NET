using StudyProject.DTOs.Hotel;

namespace StudyProject.DTOs.Country
{
    public class CountryDTO : BaseCountryDTO
    {
        public int Id { get; set; }

        public List<HotelDTO> Hotels { get; set; }
    }
}
