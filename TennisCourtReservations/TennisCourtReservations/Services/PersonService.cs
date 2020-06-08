using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisCourtReservations.Replies;
using TennisCourtReservationsDb;

namespace TennisCourtReservations.Services
{
    public class PersonService
    {
        private readonly TennisContext db;

        public PersonService(TennisContext db)
        {
            this.db = db;
        }

        public IEnumerable<Person> GetAll()
        {
            return db.Persons.AsEnumerable();
        }

        public Person GetPerson(int id)
        {
            Person person = (db.Persons.Where(x => x.Id == id).FirstOrDefault());
            return person;
        }

        public PersonReply PostPerson(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
            return new PersonReply(person);
        }

        public PersonReply PutPerson(int id, Person person)
        {
            db.Persons.Remove(db.Persons.Where(x => x.Id == id).FirstOrDefault());
            if(db.Persons.Where(x => x.Id == id).FirstOrDefault() != null)
            {
                db.Persons.Add(person);
            }
            db.SaveChanges();
            return new PersonReply(person);
        }

        public PersonReply DeletePerson(int id)
        {
            Person person = db.Persons.Where(x => x.Id == id).FirstOrDefault();
            db.Persons.Remove(db.Persons.Where(x => x.Id == id).FirstOrDefault());
            db.SaveChanges();
            return new PersonReply(person);
        }
    }
}
