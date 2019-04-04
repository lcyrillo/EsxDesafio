using ESX.DesafioSimplificado.Infra;
using ESX.DesafioSimplificado.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESX.DesafioSimplificado.DAO
{
    public class PatrimonioDao
    {
        private readonly ApiContext _context;

        public PatrimonioDao(ApiContext _context)
        {
            this._context = _context;
        }

        public IList<Patrimonio> GetAll()
        {
            return _context.Patrimonio.ToList();           
        }

        public Patrimonio GetById(int id)
        {
            return _context.Patrimonio.Where(p => p.PatrimonioId == id).First();
        }

        public void AddPatrimonio(Patrimonio patrimonio)
        {
            try
            {
                _context.Add(patrimonio);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdatePatrimonio(Patrimonio patrimonio)
        {
            try
            {
                _context.Entry(patrimonio).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeletePatrimonio(Patrimonio patrimonio)
        {
            try
            {
                _context.Remove(patrimonio);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
