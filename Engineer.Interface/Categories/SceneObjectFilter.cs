using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engineer.Engine;

namespace Engineer.Interface.Categories
{
    public class SceneObjectFilter
    {
        private string _Title;
        private List<SceneObject> _Objects;
        public string Title { get => _Title; set => _Title = value; }
        public List<SceneObject> Objects { get => _Objects; set => _Objects = value; }
        public SceneObjectFilter(string Title)
        {
            this._Title = Title;
        }
    }
}
