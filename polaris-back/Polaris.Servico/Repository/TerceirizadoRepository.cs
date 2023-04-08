﻿using Microsoft.EntityFrameworkCore;
using Polaris.Servico.Context;
using Polaris.Servico.Models;
using Polaris.Servico.Pagination;
using System;
using System.Linq.Expressions;

namespace Polaris.Servico.Repository
{
    public class TerceirizadoRepository : Repository<Models.Terceirizado>, ITerceirizadoRepository
    {
        private readonly AppDbContext _context;
        public TerceirizadoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Models.Terceirizado> GetTerceirizadosCompleto()
        {
            return Get().Include(x => x.Servicos);
        }

        public IEnumerable<Models.Terceirizado> GetTerceirizados(TerceirizadosParameters terceirizadosParameters)
        {
            return Get()
                .OrderBy(on => on.Empresa)
                .Skip((terceirizadosParameters.PageNumber - 1) * terceirizadosParameters.PageSize)
                .Take(terceirizadosParameters.PageSize)
                .ToList();
        }

        public IEnumerable<Models.Terceirizado> GetTerceirizadosPorServico(string servico)
        {
            return GetAllByParameter(t => t.Servicos.Any(s => s.Nome == servico)).Include(x => x.Servicos);
        }

        public async Task<Models.Terceirizado> GetTerceirizado(Guid uuid)
        {
            return await _context.Set<Terceirizado>().AsNoTracking().Where(x => x.TerceirizadoUuid == uuid).Include(x => x.Servicos).FirstOrDefaultAsync();
        }
    }
}
