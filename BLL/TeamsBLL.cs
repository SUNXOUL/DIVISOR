using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Divisor.DAL;
using Divisor.Models;

namespace Divisor.BLL
{
    public class TeamsBLL
    {
        private Contexto _contexto;
        public TeamsBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Save(Team team)
        {
            if (!Exist(team.TeamId))
                return Insert(team);
            else
                return Modify(team);
        }

        public bool Exist(int TeamId)
        {
            return _contexto.Teams.Any(o => o.TeamId == TeamId);
        }

        private bool Insert(Team team)
        {
            _contexto.Teams.Add(team);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(team).State = EntityState.Detached;
            return cantidad > 0;
        }

        public bool Modify(Team team)
        {
            var LastTeam = _contexto.Teams.Include(t => t.StudentList).AsNoTracking().SingleOrDefault(t => t.TeamId == team.TeamId);
            _contexto.RemoveRange(LastTeam.StudentList);
            _contexto.AddRange(team.StudentList);
            _contexto.Update(team);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(team).State = EntityState.Detached;
            return cantidad > 0;
        }

        public bool Delete(Team team)
        {
            _contexto.RemoveRange(team.StudentList);
            _contexto.Teams.Remove(team);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(team).State = EntityState.Detached;
            return cantidad > 0;
        }

        public Team? Search(int TeamId)
        {
            return _contexto.Teams.Include(t => t.StudentList).AsNoTracking().SingleOrDefault(o => o.TeamId == TeamId);
        }

        public List<Team> GetList()
        {
            return _contexto.Teams.AsNoTracking().ToList();
        }
    }
}