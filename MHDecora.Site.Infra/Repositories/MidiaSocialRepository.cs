using MHDecora.Site.Domain.Entities;
using MHDecora.Site.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MHDecora.Site.Infra.Repository
{
    public class MidiaSocialRepository : IMidiaSocialRepository
    {
        private readonly SiteContext _context;
        private readonly IConfiguration _configuration;

        public MidiaSocialRepository(SiteContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
              
        public async Task<MidiaSocial> GetMidiaSocial()
        {
            return await _context.MH_MIDIASOCIAL.SingleOrDefaultAsync();
        }
    }
}
