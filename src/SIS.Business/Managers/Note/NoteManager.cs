using AutoMapper;
using RedStarter.Business.DataContract.Note;
using RedStarter.Database.DataContract.Note;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.Managers.Note
{
    public class NoteManager : INoteManager
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _repository;
        private readonly IImageEngine _engine;

        public NoteManager(IMapper mapper, INoteRepository repository, IImageEngine engine)
        {
            _mapper = mapper;
            _repository = repository;
            _engine = engine;
        }

        public async Task<bool> CreateNote(NoteCreateDTO dto)
        {
            var rao = _mapper.Map<NoteCreateRAO>(dto);

            if(await _repository.CreateNote(rao))
                return true;

            throw new NotImplementedException();
        }

        public Task<bool> UploadeNoteImage(NoteImageDTO image)
        {

            //TODO 6: Call the ImageEngine that uploads to Cloudinary. Return a string to store. 
            //You will only store this string.
            var returnedURL = _engine.UploadImageAndGetURL(image);
            

            //TODO 9: Call the repository. Fix the NoteEntity so that it can store the URL property.
            throw new NotImplementedException();
        }
    }
}
