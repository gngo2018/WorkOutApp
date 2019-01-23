using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Business.DataContract.Note
{
    public class NoteImageDTO
    {
        public IFormFile Image { get; set; }
        public int NoteEntityId { get; set; }
    }
}
