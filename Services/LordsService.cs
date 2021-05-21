using System;
using System.Collections.Generic;
using cs_knights_tale.Models;
using cs_knights_tale.Repositories;

namespace cs_knights_tale.Services
{
    public class LordsService
    {

        private readonly LordsRepository _repo;

        public LordsService(LordsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Lord> GetAll()
        // IEnumerable takes the place of any collection type (List, Array, etc...)

        {
            return _repo.GetAll();
        }

        internal Lord GetById(int id)
        {
            Lord lord = _repo.GetById(id);
            if (lord == null)
            {
                throw new System.Exception("Invalid Id");
            }
            return lord;
        }

        internal Lord Create(Lord newLord)
        {
            Lord lord = _repo.Create(newLord);
            return newLord;
        }

        internal Lord Update(Lord edit)
        {
            Lord original = GetById(edit.Id);
            original.Name = edit.Name.Length > 0 ? edit.Name : original.Name;
            if (_repo.Update(original))
            {
                return original;
            }
            throw new Exception("Something went wrong...");

            // Lord oldLord = GetById(editLord.Id);
            // // This longform method is temporary, since we only have a FakeDB
            // oldLord.BirthYear = editLord.BirthYear;
            // oldLord.Name = editLord.Name;
            // oldLord.Medium = editLord.Medium;
            // oldLord.ImgUrl = editLord.ImgUrl;

            // return oldLord;
        }

        internal void DeleteLord(int id)
        {
            GetById(id);
            _repo.Delete(id);
        }
    }
}