using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.API.DataContract.Note
{
    public class NoteImageRequest
    {
        public IFormFile Image { get; set; }
        public int NoteEntityId { get; set; }
    }
}
