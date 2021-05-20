using System;
using System.Collections.Generic;
using cs_knights_tale.Models;
using cs_knights_tale.Repositories;

namespace cs_knights_tale.Services
{
    public class KingdomsService
    {

        private readonly KingdomsRepository _repo;

        public KingdomsService(KingdomsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Kingdom> GetAll()
        // IEnumerable takes the place of any collection type (List, Array, etc...)

        {
            return _repo.GetAll();
        }

        internal Kingdom GetById(int id)
        {
            Kingdom kingdom = _repo.GetById(id);
            if (kingdom == null)
            {
                throw new System.Exception("Invalid Id");
            }
            return kingdom;
        }

        internal Kingdom Create(Kingdom newKingdom)
        {
            Kingdom kingdom = _repo.Create(newKingdom);
            return newKingdom;
        }

        internal Kingdom Update(Kingdom update)
        {
            Kingdom original = GetById(update.Id);
            original.Name = update.Name.Length > 0 ? update.Name : original.Name;
            if (_repo.Update(original))
            {
                return original;
            }
            throw new Exception("Something went wrong...");

            // Kingdom oldKingdom = GetById(editKingdom.Id);
            // // This longform method is temporary, since we only have a FakeDB
            // oldKingdom.BirthYear = editKingdom.BirthYear;
            // oldKingdom.Name = editKingdom.Name;
            // oldKingdom.Medium = editKingdom.Medium;
            // oldKingdom.ImgUrl = editKingdom.ImgUrl;

            // return oldKingdom;
        }

        internal void DeleteKingdom(int id)
        {
            GetById(id);
            _repo.Delete(id);
        }
    }
}