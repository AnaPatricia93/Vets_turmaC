using System;

namespace ClinicaVet.Controllers
{
    public class iFormFile
    {
        public string ContentType { get; internal set; }
        public ReadOnlySpan<char> FileName { get; internal set; }
    }
}