namespace RealEstates.Services
{
    using Contracts;
    using System;
    using System.Linq;
    using Model;
    using Data.Repositories;
    using Web;

    public class RealEstatesService : IRealEstatesService
    {
        private readonly IRepository<RealEstate> realEstates;
        private readonly IIdentifierProvider identifierProvider;

        public RealEstatesService(IRepository<RealEstate> realEstates, IIdentifierProvider identifierProvider)
        {
            this.realEstates = realEstates;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<RealEstate> GetAll(int skip, int take)
        {
            return this.realEstates
                 .All()
                 .OrderByDescending(c => c.CreatedOn)
                 .Skip(skip)
                 .Take(take);
        }

        public IQueryable<RealEstate> GetById(int id)
        {
            return this.realEstates
                .All()
                .Where(c => c.Id == id);
        }

        public int AddNew(RealEstate newRealEstate, string userId)
        {
            newRealEstate.CreatedOn = DateTime.Now;
            newRealEstate.UserId = userId;

            this.realEstates.Add(newRealEstate);
            this.realEstates.SaveChanges();

            return newRealEstate.Id;
        }

        public RealEstate GetByEncodedId(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var realEstate = this.realEstates.GetById(intId);
            return realEstate;
        }
    }
}
