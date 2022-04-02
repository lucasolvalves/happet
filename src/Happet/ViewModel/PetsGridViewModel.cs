using System;

namespace Happet.ViewModel
{
    public record PetsGridViewModel
    {
        public Guid IdPet { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
        public bool Viewer { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
    }
}
