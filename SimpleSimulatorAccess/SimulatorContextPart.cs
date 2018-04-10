using System.Linq;
using SimulatorDataModel;
using System.Data;
using System.Collections.Generic;

namespace SimpleSimulatorAccess
{
    public partial class SimulatorContext: ISimulatorContext
    {
        public bool IsOpen
        {
            get
            {
                return this.Database.Connection.State==ConnectionState.Open;
            }
        }

        public TSimData Find<TSimData>(int id)
             where TSimData : class, ISimData
        {
            return this.Set<TSimData>().Find(id);
        }

        public void Save()
        {
           
                this.SaveChanges();
        }

        /// <summary>
        /// access of entity sets through interface
        /// </summary>
        /// <typeparam name="TSimData"></typeparam>
        /// <returns></returns>
        public IQueryable<TSimData> SimulatorData<TSimData>()
            where TSimData : class, ISimData
        {
                return this.Set<TSimData>();
        }

        void ISimulatorContext.Add<TSimData>(TSimData ent)
        {
            this.Set<TSimData>().Add(ent);
        }

        void ISimulatorContext.Adda<TSimData>(IEnumerable<TSimData> ents)
        {
            this.Set<TSimData>().AddRange(ents);
        }

        void ISimulatorContext.Delete<TSimData>(IEnumerable<TSimData> ents)
        {
            this.Set<TSimData>().RemoveRange(ents);
        }

        void ISimulatorContext.Delete<TSimData>(TSimData ent)
        {
            this.Set<TSimData>().Remove(ent);
        }

    }
}
