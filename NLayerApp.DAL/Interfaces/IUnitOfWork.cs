﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Parcel_Search> Parcel_Searchs { get; }
        IRepository<Parcel_Info> Parcel_Infos { get; }
    void Save();
    }
}
