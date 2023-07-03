using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Divisor.DAL;
using Divisor.Models;
namespace Divisor.BLL
{
    public class StudentsBLL
    {
        private Contexto _contexto;
        public StudentsBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Save(Student student)
        {
            if (!Exist(student.StudentId))
                return Insert(student);
            else
                return Modify(student);
        }

        public bool Exist(int studentId)
        {
            return _contexto.Students.Any(o => o.StudentId == studentId);
        }

        private bool Insert(Student student)
        {
            _contexto.Students.Add(student);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(student).State = EntityState.Detached;
            return cantidad > 0;
        }

        public bool Modify(Student student)
        {
            _contexto.Update(student);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(student).State = EntityState.Detached;
            return cantidad > 0;
        }

        public bool Delete(Student student)
        {
            _contexto.Students.Remove(student);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(student).State = EntityState.Detached;
            return cantidad > 0;
        }

        public Student? Search(int studentId)
        {
            return _contexto.Students.AsNoTracking().SingleOrDefault(o => o.StudentId == studentId);
        }

        public List<Student> GetList()
        {
            return _contexto.Students.AsNoTracking().ToList();
        }
    }
}