namespace RealEstates.Services
{
    using Contracts;
    using Data.Repositories;
    using Model;
    using System;
    using System.Linq;
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

        public IQueryable<RealEstate> GetAll()
        {
            return this.realEstates
                 .All()
                 .OrderByDescending(c => c.CreatedOn);
        }

        public IQueryable<RealEstate> GetById(int? id)
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

        public IQueryable<RealEstate> GetByCity(string name)
        {
            return this.realEstates
                .All()
                .Where(c => c.City.Name == name);
        }

        public int SaveChanges()
        {
            return this.realEstates.SaveChanges();
        }

        public void UpdateRealEstate(RealEstate realEstate)
        {
            this.realEstates.Update(realEstate);
        }

        public void Delete(int id)
        {
            this.realEstates.Delete(id);
        }

        public IQueryable<RealEstate> GetMostRecent()
        {
            return this.realEstates.All()
                .OrderBy(r => r.CreatedOn)
                .Take(5);
        }

        public IQueryable<RealEstate> GetForSale()
        {
            return this.realEstates.All()
                .Where(r => r.SellingPrice > 0)
                .OrderBy(r => r.CreatedOn);
        }

        public IQueryable<RealEstate> GetForRent()
        {
            return this.realEstates.All()
                .Where(r => r.RentingPrice > 0)
                .OrderBy(r => r.CreatedOn);
        }
    }
}