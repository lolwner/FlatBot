using FlatBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBot.Persistance
{
    internal class FlatBotContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<CitySource> CitySources { get; set; }
        public DbSet<OlxOfferEntity> OlxOfferEntities { get; set; }
        public DbSet<OlxSearchParameters> OlxSearchParameters { get; set; }
        public DbSet<RawOlxOffer> RawOlxOffers { get; set; }
    }
}
