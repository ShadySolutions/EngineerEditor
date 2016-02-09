using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime;
using Engineer.Mathematics;

namespace Engineer.Data
{
    public class FileContainer
    {
        public FileContainer()
        {
        }
        public virtual void Load(string FilePath, BackgroundWorker Worker)
        {
            GCSettings.LargeObjectHeapCompactionMode
                = GCLargeObjectHeapCompactionMode.CompactOnce;
            System.GC.Collect();
        }
        public virtual void Save(string FilePath, BackgroundWorker Worker)
        {
        }
    }
    public class AnimationContainer : FileContainer
    {
        private Axis _AxisUp;
        private int _StartFrame;
        private int _EndFrame;
        private float _DataRate;
        private TimeCode _StartTime;
        public Axis AxisUp
        {
            get { return this._AxisUp; }
            set { this._AxisUp = value; }
        }
        public int StartFrame
        {
            get { return this._StartFrame; }
            set { this._StartFrame = value; }
        }
        public int EndFrame
        {
            get { return this._EndFrame; }
            set { this._EndFrame = value; }
        }
        public int NumFrames
        {
            get { return this._EndFrame - this._StartFrame + 1; }
        }
        public float DataRate
        {
            get { return _DataRate; }
            set { _DataRate = value; }
        }
        public TimeCode StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        public AnimationContainer()
        {
            this._AxisUp = Axis.Y;
            this._StartFrame = 0;
            this._EndFrame = 0;
            this._DataRate = 0;
            this._StartTime = new TimeCode();
        }
        public AnimationContainer(AnimationContainer AC)
        {
            this._AxisUp = AC._AxisUp;
            this._StartFrame = AC._StartFrame;
            this._EndFrame = AC._EndFrame;
            this._DataRate = AC._DataRate;
            this._StartTime = new TimeCode(AC._StartTime);
        }
    }
    public class SkeletonContainer : AnimationContainer
    {
        private string _EulerRotationOrder;
        public string EulerRotationOrder
        {
            get { return _EulerRotationOrder; }
            set { _EulerRotationOrder = value; }
        }
        private List<Segment> _Segments;
        public int NumSegments
        {
            get
            {
                return this._Segments.Count;
            }
        }
        public List<Segment> Segments
        {
            get { return _Segments; }
            set { _Segments = value; }
        }
        public SkeletonContainer()
            : base()
        {
            this._Segments = new List<Segment>();
        }
        public SkeletonContainer(SkeletonContainer SC) : base(SC)
        {
            this._EulerRotationOrder = SC._EulerRotationOrder;
            this._Segments = new List<Segment>();
            for (int i = 0; i < SC.Segments.Count; i++) this._Segments.Add(new Segment(SC.Segments[i]));
        }
        public void AddSkeleton(SkeletonContainer SC)
        {
            int NStartFrame = StartFrame;
            if (SC.StartFrame < NStartFrame) NStartFrame = SC.StartFrame;
            int NEndFrame = EndFrame;
            if (SC.EndFrame > NEndFrame) NEndFrame = SC.EndFrame;
            if (StartTime.IsValid()) StartTime += (NStartFrame - StartFrame);
        }
    }
    public class MeshContainer : FileContainer
    {
        private List<Geometry> _Geometries;
        public List<Geometry> Geometries
        {
            get
            {
                return _Geometries;
            }

            set
            {
                _Geometries = value;
            }
        }
        public MeshContainer()
        {
            this._Geometries = new List<Geometry>();
        }
        public void RecalculateNormals()
        {
            for (int i = 0; i < this._Geometries.Count; i++) this._Geometries[i].RecalculateNormals();
        }
        public void CreaseVerts()
        {
            for (int i = 0; i < this._Geometries.Count; i++) this._Geometries[i].CreaseVerts();
        }
    }
}
