using System.Collections.Generic;
using System.Linq;

namespace SimulatorDataModel
{
    public interface ISimulatorContext
    {
        void Add<TSimData>(TSimData ent)
                       where TSimData : class, ISimData;

        void Adda<TSimData>(IEnumerable<TSimData>  ents)
                       where TSimData : class, ISimData;

        void Delete<TSimData>(TSimData ent)
               where TSimData : class, ISimData;

        void Delete<TSimData>(IEnumerable<TSimData> ents)
                       where TSimData : class, ISimData;

        void Save();


        IQueryable<TSimData> SimulatorData<TSimData>()
           where TSimData : class, ISimData;

        bool IsOpen { get; }

        TSimData Find<TSimData>(int id)
            where TSimData : class, ISimData;
    }
}
