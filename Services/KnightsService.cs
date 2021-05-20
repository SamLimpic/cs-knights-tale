using System;
using System.Collections.Generic;
using cs_knights_tale.Models;
using cs_knights_tale.Repositories;

namespace cs_knights_tale.Services
{
    public class KnightsService
    {

        private readonly KnightsRepository _repo;

        public KnightsService(KnightsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Knight> GetAll()
        // IEnumerable takes the place of any collection type (List, Array, etc...)

        {
            return _repo.GetAll();
        }

        internal Knight GetById(int id)
        {
            Knight knight = _repo.GetById(id);
            if (knight == null)
            {
                throw new System.Exception("Invalid Id");
            }
            return knight;
        }

        internal Knight Create(Knight newKnight)
        {
            Knight knight = _repo.Create(newKnight);
            return newKnight;
        }

        internal Knight Update(Knight update)
        {
            Knight original = GetById(update.Id);
            original.Name = update.Name.Length > 0 ? update.Name : original.Name;
            if (_repo.Update(original))
            {
                return original;
            }
            throw new Exception("Something went wrong...");

            // Knight oldKnight = GetById(editKnight.Id);
            // // This longform method is temporary, since we only have a FakeDB
            // oldKnight.BirthYear = editKnight.BirthYear;
            // oldKnight.Name = editKnight.Name;
            // oldKnight.Medium = editKnight.Medium;
            // oldKnight.ImgUrl = editKnight.ImgUrl;

            // return oldKnight;
        }

        internal void DeleteKnight(int id)
        {
            GetById(id);
            _repo.Delete(id);
        }
    }
}