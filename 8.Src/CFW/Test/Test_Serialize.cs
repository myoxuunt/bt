using System;
using NUnit.Framework;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
namespace CFW.Test
{
    public class c_serializer
    {
        bool            _isDeserial = false;
        string          _filename   = null;
        SoapFormatter   _formatter  = null;
        FileStream      _fs         = null;


        public c_serializer(string xmlfile, bool isDeserialize)
        {
            _filename = xmlfile;
            _isDeserial = isDeserialize;
        }

        public void Open()
        {
            if (_isDeserial)
                _fs = new FileStream(_filename, FileMode.Open);
            else
                _fs = new FileStream( _filename, FileMode.Create );

            _formatter = new SoapFormatter();
        }

        public void Close()
        {
            _fs.Close();
        }

        public void Serialize( object obj)
        {
            _formatter.Serialize ( _fs, obj );
        }

        public object Deserialize()
        {
            return _formatter.Deserialize(_fs);
        }
    }
    /// <summary>
    /// Test_Serialize 的摘要说明。
    /// </summary>
    public class Test_Serialize
    {
        public Test_Serialize()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
    }


    [TestFixture]
    public class Test_CommPortProxySerialize
    {
        const string _filename = "c:\\commportproxy.xml";
        
        [Test]
        public void serialize()
        {
            c_serializer c = new c_serializer(_filename, false);
            c.Open();
            c.Serialize(new CommPortProxy());
            c.Close();

            c = new c_serializer(_filename, true);
            c.Open();
            CommPortProxy p = c.Deserialize() as CommPortProxy;
            c.Close();
            Assert.IsNotNull( p );
            Assert.AreEqual (1, p.ComPort );
            Assert.AreEqual ("9600,n,8,1", p.Settings );
            Assert.IsFalse(p.IsOpen);
            p.Open();
            Assert.IsTrue(p.IsOpen);
        }
    }

    [TestFixture ]
    public class Test_TaskSchedulerSerialize
    {
        const string _fn = "c:\\taskscheduler.xml";

        [Test]
        public void serial()
        {
            c_serializer c = new c_serializer(_fn, false);
            c.Open();
            TaskScheduler nt = new TaskScheduler(new CommPortProxy());
            // 2006.12.13
            //
            //nt.Tasks.Add(new Task("n1", T.station,T.cmd_coll_realdata,new ImmediateTaskStrategy())); 
            nt.Tasks.Add(new Task("n1", T.cmd_coll_realdata,new ImmediateTaskStrategy())); 

            c.Serialize(nt);
            c.Close();

            c = new c_serializer(_fn, true);
            c.Open();
            TaskScheduler t = c.Deserialize() as TaskScheduler;
            c.Close();
            Assert.IsNotNull( t );
            Assert.IsNotNull ( t.CommPortProxy );
            //Assert.IsNull( t.Tasks );
            Assert.IsTrue (t.Tasks.Count == 1);
            Assert.IsTrue( t.Tasks[0].CommCmd.GetType().Name  == typeof(A_Cmd_Coll_Rd).Name );
            Assert.IsNull( t.ActiveTask );
        }
    }
}
