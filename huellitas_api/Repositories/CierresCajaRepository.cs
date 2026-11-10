using AutoMapper;
using huellitas_api.Dtos;
using huellitas_api.Models;
using huellitas_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace huellitas_api.Repositories
{
    public class CierresCajaRepository : ICierresCajaRepository
    {
        private readonly HuellitasDigitalesContext _context;
        private readonly IMapper _mapper;

        public CierresCajaRepository(HuellitasDigitalesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CierresCajaDto>> GetAll()
        {
            var entities = await _context.CierresCajas
                .Include(x => x.Cajero)
                .Include(x => x.Cajero).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<CierresCajaDto>>(entities);
        }

        public async Task<CierresCajaDto?> GetById(Guid id)
        {
            var entity = await _context.CierresCajas
                .Include(x => x.Cajero)
                .Include(x => x.Cajero).ThenInclude(x => x.Rol)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity is null ? null : _mapper.Map<CierresCajaDto>(entity);
        }

        public async Task<bool> Create(CierresCajaDto dto)
        {
            var entity = new CierresCaja
            {
                Id = dto.Id,
                CajeroId = dto.CajeroId,
                Fecha = dto.Fecha,
                Turno = dto.Turno,
                TotalEfectivo = dto.TotalEfectivo,
                TotalQrTransferencia = dto.TotalQrTransferencia,
                TotalTarjeta = dto.TotalTarjeta,
                MontoTotalRecaudado = dto.MontoTotalRecaudado,
                CreatedAt = dto.CreatedAt
            };
            _context.CierresCajas.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Guid id, CierresCajaDto dto)
        {
            var entity = await _context.CierresCajas.FindAsync(id);
            if (entity == null) return false;

            entity.CajeroId = dto.CajeroId;
            entity.Fecha = dto.Fecha;
            entity.Turno = dto.Turno;
            entity.TotalEfectivo = dto.TotalEfectivo;
            entity.TotalQrTransferencia = dto.TotalQrTransferencia;
            entity.TotalTarjeta = dto.TotalTarjeta;
            entity.MontoTotalRecaudado = dto.MontoTotalRecaudado;
            entity.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.CierresCajas.FindAsync(id);
            if (entity == null) return false;

            _context.CierresCajas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}