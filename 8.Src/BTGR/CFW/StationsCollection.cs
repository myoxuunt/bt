using System;
using Infragistics.Shared;
using System.Runtime.Serialization;
namespace CFW
{
    #region StationsCollection
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class StationsCollection: Infragistics.Shared.KeyedSubObjectsCollectionBase 
        ,ISerializable 
    {

        protected StationsCollection()
        {
        }


        protected StationsCollection(SerializationInfo info, StreamingContext context)
        {
            foreach (SerializationEntry entry in info)
            {
                if (entry.ObjectType == typeof (Station) ||
                    entry.ObjectType.IsSubclassOf( typeof(Station) ) )
                {
                    Station st = (Station)entry.Value;

                    if (st != null)
                        this.List.Add ( entry.Value );
                }
            }

        }

        #region ISerializable ��Ա

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // TODO:  ��� StationsCollection.GetObjectData ʵ��
            //foreach (object o in this)
            //{
            //    info.AddValue(o.ToString(), o);
            //}

            for (int i=0; i<List.Count; i++)
            {
                info.AddValue(i.ToString(), List[i]);
            }
        }

        #endregion


        public override bool AllowDuplicateKeys
        {
            get
            {
                return false;
            }
        }

        public override bool AllowEmptyKeys
        {
            get
            {
                return false;
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        protected override int InitialCapacity
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// ���һ��վ��������
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        protected int InternalAdd( Station station )
        {
            if ( this.Contains( (IKeyedSubObject) station ) )
                throw new System.ArgumentException ("station already in collection");

            ValidateStationName( station.StationName);

            // ����ת��Ϊ IKeyedSubObject �Ե��� InternalAdd (IKeyedSubObject),
            // ��������InternalAdd ( Station );
            return this.InternalAdd( (IKeyedSubObject) station );
        }

        // 2006.10.09 added
        protected void InternalRemove( Station station )
        {
            base.InternalRemove( /*(SubObjectBase)*/ station);
        }

        //protected new void InternalClear()
        //{
        //    base.InternalClear();
        //}

        protected internal void ValidateStationName( string stationName )
        {
            ValidateStationName( stationName, null );
        }


        protected internal void ValidateStationName( string stationName , Station ignoreObject)
        {
            stationName = stationName.Trim();
            foreach ( Station st in List )
            {
                if (( st != ignoreObject ) &&
                    Utility.Equals (stationName, st.StationName,true, true))
                {
                    throw new System.ArgumentException( 
                        string.Format("stationName '{0}' exist.",stationName)); 
                }
            }
        }
    }
    #endregion //StationsCollection
}
