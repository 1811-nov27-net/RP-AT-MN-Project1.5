﻿using Project1_5_Library;
using Project1_5_Library.RepoInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project1_5_DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly Project15Context _db;

        public RoomRepository(Project15Context db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // code-first style, make sure the database exists by now.
            db.Database.EnsureCreated();
        }

        public Room Create(Room model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetAll()
        {
            throw new NotImplementedException();
        }

        public Room GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Room Update(Room model, int? id = null)
        {
            throw new NotImplementedException();
        }
    }
}
