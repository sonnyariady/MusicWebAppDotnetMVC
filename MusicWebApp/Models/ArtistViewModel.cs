using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWebApp.Models
{
    public class ArtistViewModel : Artist
    {
        public string ReleaseDateStr  { get; set; }
    }
}