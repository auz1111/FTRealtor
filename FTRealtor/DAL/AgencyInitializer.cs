﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FTRealtor.Models;

namespace FTRealtor.DAL
{
    public class AgencyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AgencyContext>
    {
        protected override void Seed(AgencyContext context)
        {
            var realtors = new List<Realtor>
            {
            new Realtor{FirstMidName="Auz",LastName="Clement",Username="auz1111",Password="password",ListingDate=DateTime.Parse("2005-09-01")},
            new Realtor{FirstMidName="Robert",LastName="Drake",Username="iceman",Password="password",ListingDate=DateTime.Parse("2002-09-01")},
            new Realtor{FirstMidName="Jean",LastName="Grey",Username="jean",Password="password",ListingDate=DateTime.Parse("2003-09-01")},
            new Realtor{FirstMidName="Ororo",LastName="Munroe",Username="storm",Password="password",ListingDate=DateTime.Parse("2002-09-01")},
            new Realtor{FirstMidName="Charles",LastName="Xavier",Username="professor",Password="password",ListingDate=DateTime.Parse("2002-09-01")},
            new Realtor{FirstMidName="James",LastName="Logan",Username="wolverine",Password="password",ListingDate=DateTime.Parse("2001-09-01")},
            new Realtor{FirstMidName="Elizabeth",LastName="Braddock",Username="psylocke",Password="password",ListingDate=DateTime.Parse("2003-09-01")},
            new Realtor{FirstMidName="Scott",LastName="Summers",Username="cyclops",Password="password",ListingDate=DateTime.Parse("2005-09-01")}
            };

            realtors.ForEach(s => context.Realtors.Add(s));
            context.SaveChanges();
            var houses = new List<House>
            {
            new House{HouseID=1050,Title="Clement's Ranch",MLSNum=1111,Street1="101 Hardwood Drive",Street2="Suite 11",City="Columbia",State="SC",Zip="29223",Neighborhood="Killian Greene",SalesPrice=124000,DateListed=DateTime.Parse("2003-09-01"),Bedrooms=4,Bathrooms=3,Photos="image.jpg",GarageSize=800,SquareFeet=2200,LotSize=3200,Description="Starter home"},
            new House{HouseID=4022,Title="The Cave",MLSNum=2222,Street1="13 Elm Street",Street2="Suite 22",City="Bend",State="OR",Zip="97702",Neighborhood="Wild Wood",SalesPrice=224000,DateListed=DateTime.Parse("2005-01-05"),Bedrooms=4,Bathrooms=3,Photos="image.jpg",GarageSize=600,SquareFeet=2600,LotSize=4200,Description="Starter home"},
            new House{HouseID=4041,Title="The Outworld",MLSNum=3333,Street1="1234 ABC Lane",Street2="Apartment 123",City="Chicago",State="IL",Zip="34221",Neighborhood="Spring Valley",SalesPrice=307000,DateListed=DateTime.Parse("2008-04-01"),Bedrooms=4,Bathrooms=3,Photos="image.jpg",GarageSize=700,SquareFeet=2800,LotSize=3290,Description="Starter home"},
            new House{HouseID=1045,Title="The Plains",MLSNum=4444,Street1="222 Twin Two Drive",Street2="Suite 44",City="Charlotte",State="NC",Zip="29087",Neighborhood="Tillicum Village",SalesPrice=240000,DateListed=DateTime.Parse("2009-08-12"),Bedrooms=4,Bathrooms=3,Photos="image.jpg",GarageSize=500,SquareFeet=1900,LotSize=2260,Description="Starter home"},
            new House{HouseID=3141,Title="The Mansion",MLSNum=5555,Street1="5245 Long Beard Ave",Street2="Suite 55",City="Sacramento",State="CA",Zip="10980",Neighborhood="Aubrey Butte",SalesPrice=900000,DateListed=DateTime.Parse("2003-08-09"),Bedrooms=4,Bathrooms=3,Photos="image.jpg",GarageSize=834,SquareFeet=5200,LotSize=9200,Description="Mansion"},
            new House{HouseID=2021,Title="Underground Lair",MLSNum=6666,Street1="911 Emergency Circle",Street2="Suite 66",City="Bend",State="OR",Zip="97702",Neighborhood="The Bridges",SalesPrice=100000,DateListed=DateTime.Parse("2002-11-11"),Bedrooms=4,Bathrooms=3,Photos="image.jpg",GarageSize=634,SquareFeet=3200,LotSize=4200,Description="Starter home"}
            };
            houses.ForEach(s => context.Houses.Add(s));
            context.SaveChanges();
            var listings = new List<Listing>
            {
            new Listing{RealtorID=1,HouseID=1050,Grade=Grade.A},
            new Listing{RealtorID=1,HouseID=4022,Grade=Grade.B},
            new Listing{RealtorID=2,HouseID=4041,Grade=Grade.C},
            new Listing{RealtorID=3,HouseID=2021,Grade=Grade.D},
            new Listing{RealtorID=1,HouseID=1045,Grade=Grade.B},
            };
            listings.ForEach(s => context.Listings.Add(s));
            context.SaveChanges();
        }
    }
}