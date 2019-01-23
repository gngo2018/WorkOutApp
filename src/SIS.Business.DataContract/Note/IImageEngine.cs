using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.DataContract.Note
{
    public interface IImageEngine
    {
        string UploadImageAndGetURL(NoteImageDTO image);
    }
}
