
namespace Communication
{
    using System;
    using CFW;
    using Utilities;
    using GRCtrl;

    /// <summary>
    ///
    /// </summary>
    public class FreeDataProcessor
    {
        private static FreeDataProcessor s_default = new FreeDataProcessor();

        /// <summary>
        /// 
        /// </summary>
        public static FreeDataProcessor Default
        {
            get { return FreeDataProcessor.s_default; }
        }

        /// <summary>
        /// 
        /// </summary>
        public FreeDataProcessor()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromIP"></param>
        /// <param name="bs"></param>
        public void Process( string fromIP, byte[] bs )
        {
            GrDataPicker grdp = new GrDataPicker();
            byte[][] grdatas = grdp.Picker( bs );

            if ( grdatas != null )
            {
                foreach( byte[] aGrData in grdatas )
                {
                    if ( GRCommandMaker.IsRealData( aGrData ) )
                    {
                        GrRealDataParser grrdparser = new GrRealDataParser( aGrData );
                        GRRealData rd = grrdparser.ToValue() as GRRealData;
                        if ( rd != null )
                        {
                            CommTaskResultProcessor.Default.ProcessGRRealData(
                                fromIP,
                                rd.FromAddress,
                                rd
                                );
                        }
                                       
                    }
                }
            }

            XgDataPicker xgdp = new XgDataPicker();
            byte[][] xgdatas = xgdp.Picker( bs );
            if ( xgdatas != null )
            {
                foreach( byte[] aXgData in xgdatas )
                {
                    if ( XGCommandMaker.IsXgRecord ( aXgData ) )
                    {
                        XgRecordParser xgrp = new XgRecordParser( aXgData );
                        XGData xgdata =  xgrp.ToValue() as XGData;
                        if ( xgdata != null )
                        {
                            XGDB.InsertXGData( 
                                fromIP, //cmd.Station.DestinationIP, 
                                xgdata
                                );
                        }
                    }
                }
            }

        }
    }
}
