using Ninject.Modules;
using NLayerApp.BLL.Services;
using NLayerApp.BLL.Interfaces;

namespace NLayerApp.WEB.Util
{
    public class Parcel_InfoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IParcel_InfoService>().To<Parcel_InfoService>();
        }
    }
}