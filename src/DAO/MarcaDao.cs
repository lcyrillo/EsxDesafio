using ESX.DesafioSimplificado.Infra;
using ESX.DesafioSimplificado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ESX.DesafioSimplificado.DAO
{
    public class MarcaDao
    {
        private readonly ApiContext _context;

        public MarcaDao(ApiContext _context)
        {
            this._context = _context;
        }

        public IList<Marca> GetAll()
        {
            return _context.Marca.ToList();
        }

        public Marca GetById(int id)
        {
            return _context.Marca.Where(m => m.MarcaId == id).First();
        }

        public bool GetByName(string nome)
        {
            return _context.Marca.Where(m => m.Nome.Contains(nome)).Any();
        }

        public IList<Patrimonio> GetPatrimoniosMarca(int id)
        {
            return _context.Patrimonio.Where(p => p.MarcaId == id).ToList();
        }

        public void AddMarca(Marca marca)
        {
            try
            {
                _context.Add(marca);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateMarca(Marca marca)
        {
            try
            {
                _context.Entry(marca).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteMarca(Marca marca)
        {
            try
            {
                _context.Remove(marca);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
